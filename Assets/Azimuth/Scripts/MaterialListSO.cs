using System.Collections;
using System.Collections.Generic;
using System;
using System.Linq;
using System.IO;
using System.Text;
using UnityEngine;
using UnityEditor;

[CreateAssetMenu(fileName = "new MaterialList", menuName = "Azimuth/MaterialList", order = 5)]
public class MaterialListSO : ScriptableObject{

    public Material defaultMaterial;
    public List<Material> materialList;
    

    public Material GetMaterialByName(string nameSearch){
        for(int i= 0 ; i < materialList.Count; i++){
            if( materialList[i].name == nameSearch){
                return materialList[i];
            }
        }

        return defaultMaterial;
    }


}