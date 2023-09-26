using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using System.IO;


[CustomEditor(typeof(SegmentMaterialsBuilderSO))]
public class SegmentMaterialsBuilderSOEditor : Editor{
    public override void OnInspectorGUI () {

        DrawDefaultInspector();

        SegmentMaterialsBuilderSO builder = (SegmentMaterialsBuilderSO)target;
        if(GUILayout.Button("Run Process")){          
           builder.RunProcess();
        }
	}
}