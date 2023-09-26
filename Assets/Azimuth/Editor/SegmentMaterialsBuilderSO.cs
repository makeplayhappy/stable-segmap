using System.Collections;
using System.Collections.Generic;
using System;
using System.Linq;
using System.IO;
using System.Text;
using UnityEngine;
using UnityEditor;

[CreateAssetMenu(fileName = "new SegmentMaterialBuilderEditor", menuName = "Azimuth/SegmentMaterialBuilderEditor", order = 100)]
public class SegmentMaterialsBuilderSO : ScriptableObject{

    public enum MaterialBuildProcess{
        MaterialPerColor, 
    }
    
    public Material baseMaterial;
    public string materialColorName = "_MainTex";
    public string texturesPath = "Assets/Electric/Textures/Body";
    public string materialsOutPath = "Assets/Azimuth/Materials/Segments";


#if UNITY_EDITOR

    public void RunProcess(){

        Debug.Log("Running Process");

        foreach( KeyValuePair<string, Color32> kvp in SegmentColors.segmentColorDict ){
            string safeName = SegmentColors.CleanName( kvp.Key );
            GenerateNewMaterial(safeName, (Color)kvp.Value);
        }



    }

    public void GenerateNewMaterial(string newName, Color newColor){
        //clone base mat
        Material newMaterial = new Material(baseMaterial);
        string newFileName = materialsOutPath + Path.DirectorySeparatorChar + newName + ".mat";
        
        newMaterial.SetColor(materialColorName, newColor); 
        AssetDatabase.DeleteAsset(newFileName);
        string thisPath = AssetDatabase.GenerateUniqueAssetPath(newFileName);
        Debug.Log("GenerateNewMaterial : " + thisPath);
        AssetDatabase.CreateAsset(newMaterial, thisPath);

    }

#endif

}