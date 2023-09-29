using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;
using System.Collections;
using System.IO;
#if UNITY_EDITOR
using UnityEditor;
#endif


namespace GILES
{
	public class pb_SnapshotButton : pb_ToolbarButton
	{

		public override string tooltip { get { return "Grab png snapshot"; } }
        private byte[] file = null;

        private Camera snapCam;
        private Camera mainCam;

        private Vector2 outputSize = new Vector2(512f,512f); 
        private RenderTexture rt;

        private static string filename = "Screenshots";
        

		public void Snapshot()
        {
            //pb_SceneLoader.LoadScene(pb_Scene.SaveLevel(), true);

            bool okayToSnapshot = false;

            switch( Application.platform ){
                case RuntimePlatform.WebGLPlayer:
                    if( WebGLFileSaver.IsSavingSupported() ){
                        okayToSnapshot = true;
                    }

                break;
                default:
                    okayToSnapshot = true;
                break;
            }



            if( okayToSnapshot ){
                if(mainCam == null){
                    mainCam = Camera.main;
                }

                //need to get snapshot camera
                if( snapCam == null ){

                    GameObject cameraGO = GameObject.FindWithTag("Snapshot");
                    if( cameraGO != null){
                        Camera cam = cameraGO.GetComponent<Camera>();
                        if( cam != null ){
                            snapCam = cam;
                            SnapshotCamera camSettings = cameraGO.GetComponent<SnapshotCamera>();
                            if(camSettings != null){
                                outputSize = camSettings.outputSize;
                                rt = camSettings.rt;
                            }
                        }
                    }
                }

                if( rt == null){
                    Debug.Log("Couldnt find a snapshot texture");
                    return;
                }
                
                if( snapCam != null ){

                    StartCoroutine( GrabPNG() );

                }else{
                    Debug.Log("Couldnt find a snapshot camera");
                }

            }else{
                Debug.Log("Snapshot saving is not available");
            }
        }


        IEnumerator GrabPNG() {

///            mainCam.enabled = false;

            // Only read the screen after all rendering is complete
            yield return new WaitForEndOfFrame();
            // Create a texture the size of the screen, RGB24 format
            int width = Mathf.RoundToInt(outputSize.x);
            int height = Mathf.RoundToInt(outputSize.y);
/*
            int width = Screen.width;
            int height = Screen.height;
*/
            Texture2D tex = new Texture2D(width, height, TextureFormat.RGB24, false);

            //Texture2D tex = new Texture2D(rt.width, rt.height, TextureFormat.RGB24, false);
            //tex.ReadPixels(new Rect(0, 0, rt.width, rt.height), 0, 0);
            RenderTexture.active = rt;
        
        

            // Read screen contents into the texture
            tex.ReadPixels(new Rect(0, 0, width, height), 0, 0);
            tex.Apply();
            // Encode texture into JPG
            file = ImageConversion.EncodeToPNG(tex);
            Destroy(tex);

            RenderTexture.active = null;

            if( Application.platform == RuntimePlatform.WebGLPlayer ){ 

                WebGLFileSaver.SaveFile(file, "segmentation.png", "image/png");

            }else{
                //string directory = Application.dataPath
                string path = Application.dataPath + "/" + filename + ".png";
                File.WriteAllBytes(path, file);
#if UNITY_EDITOR
                EditorUtility.RevealInFinder(Application.dataPath);
#endif
            }


///            mainCam.enabled = true;

        }

	}
}