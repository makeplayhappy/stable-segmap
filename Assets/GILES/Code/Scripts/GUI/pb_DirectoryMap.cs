#define USING_RESOURCE_DB

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Text.RegularExpressions;
using System.Linq;


namespace GILES
{
    public class pb_DirectoryMap
    {
        public string name;
        public string path;
        //public ResourceDB resourceDB;
        public List<pb_DirectoryMap> directories;
#if USING_RESOURCE_DB
        public List<ResourceItem> files;
#else
        public List<string> files;
#endif
        public pb_DirectoryMap(string name, string path)
        {
            //resourceDB = new ResourceDB();
            //resourceDB.FindInstance();
            //Debug.Log( "DirectoryMap for name:" + name + " path:" + path);

            this.name = name;
            this.path = path;
            map(path);
        }
        public List<string> getSubDirectoryNames()
        {
            List<string> names = new List<string>();
            foreach (pb_DirectoryMap dir in directories)
            {
                names.Add(dir.name);
            }
            return names;
        }

        public string getParrentDirectory()
        {
            Regex r = new Regex(".*\\/");
            Match m = r.Match(path);
            if (m.Success)
            {
                string parDirectory = m.Value;
                return parDirectory.Substring(0, parDirectory.Length - 1);
            }

            return "";
        }

        public string getRoot()
        {
            Regex r = new Regex(".*?\\/");
            Match m = r.Match(path);
            return m.Value;
        }

        public string getPathNoRoot()
        {
            string root = getRoot();
            if (root != "")
            {
                return path.Replace(root, "");
            }
            return "";
        }

        public List<string> getFileNames()
        {
#if USING_RESOURCE_DB
            //buidl filename list - !TODO - nothings using this afaik
            return new List<string>();
#else           
            return files;
#endif
        }

#if USING_RESOURCE_DB
        public List<string> getFileMatch(ResourceItem.Type resourceType) 
        {
            List<string> matches = new List<string>();

            foreach (ResourceItem file in files)
            {
                if (file.ResourcesType == resourceType )
                {
                    matches.Add(file.Name);
                }
            }
            return matches;
        }

#else

        public List<string> getFileMatch(string pattern)
        {
            Regex r = new Regex(pattern);
            List<string> matches = new List<string>();
            foreach (string file in files)
            {
                if (r.IsMatch(file))
                {
                    matches.Add(file);
                }
            }
            return matches;
        }
     
#endif

#if USING_RESOURCE_DB
        
        //build directories & files Lists
        public void map(string path)
        {
            directories = new List<pb_DirectoryMap>();
            files = new List<ResourceItem>();


            ResourceItem folderItem = ResourceDB.GetFolder(path);
            //ResourceItem imagesFolder = ResourceDB.GetFolder("images");

            if( folderItem != null){

                //directories.Add(new pb_DirectoryMap(folderItem.Name, path + "/" + folderName));

                List<ResourceItem> childItems = folderItem.GetChilds("",ResourceItem.Type.Any).ToList();

                foreach (ResourceItem childItem in childItems)
                {

                    if ( childItem.ResourcesType == ResourceItem.Type.Folder )
                    {
                        //string folderName = fInfo.Name.Replace(".meta", "");
                        directories.Add(new pb_DirectoryMap(childItem.Name, childItem.ResourcesPath));
                    }
                    else if( childItem.ResourcesType == ResourceItem.Type.Asset )
                    {

                        files.Add(childItem);

                    }
                }
#if UNITY_EDITOR                
            }else{
                Debug.Log("DirectoryMap map( " + path + " ) IS NULL");
#endif
            }

        }
#else
// this doesnt work in build / packed up environments
// I guess the original expects you to be in control of the fiole system after install 
// eg. for modding games where you load in the assets seperately

        public void map(string path)
        {
            directories = new List<pb_DirectoryMap>();
            files = new List<string>();
            DirectoryInfo info = new DirectoryInfo(Application.dataPath + "/Resources/" + path);
            FileInfo[] fileInfo = info.GetFiles();
            foreach (FileInfo fInfo in fileInfo)
            {
                if (isFolder(fInfo.Name))
                {
                    string folderName = fInfo.Name.Replace(".meta", "");
                    //Debug.Log("!! Adding to folders " + path + "/" + folderName);
                    directories.Add(new pb_DirectoryMap(folderName, path + "/" + folderName));
                }
                else
                {
                    //Debug.Log("!! Adding to files " + fInfo.Name);
                    files.Add(fInfo.Name);

                }
            }

        }
#endif
        bool isFolder(string fName)
        {
            int sIndex = fName.LastIndexOf(".meta");
            if (sIndex == -1)
                return false;
            if ((fName.Substring(0, sIndex).IndexOf(".")) != -1)
                return false;

            return true;
        }
    }
}