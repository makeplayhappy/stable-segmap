using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using GILES;
using System.Collections;





public class DefaultSceneItemLoader : MonoBehaviour	{
	/// A reference to the inspector GUI scroll panel.  All new UI elements will be 
	/// instantiated as children of this GameObject.
	public GameObject[] defaultItems;
    public GameObject snapshotCam; //prefab
    public RawImage snapCamImageTarget;
    public RenderTexture rt;
    public Camera snapshotCamCamera;



    void Start(){
        if( defaultItems != null && defaultItems.Length >0 ){

            for(int i = 0; i < defaultItems.Length; i++){
                GameObject go = (GameObject)pb_Scene.Instantiate(defaultItems[i], Vector3.zero, Quaternion.identity);
            }
        }

        if( snapshotCam != null){
            GameObject snapCameraGO = (GameObject)pb_Scene.Instantiate(snapshotCam, Vector3.zero, Quaternion.identity);
            if( snapCameraGO.tag != "Snapshot"){
                snapCameraGO.tag = "Snapshot";
            }

            snapshotCamCamera = snapCameraGO.GetComponent<Camera>();



            if(snapCamImageTarget != null){
                SnapshotCamera camSettings = snapCameraGO.GetComponent<SnapshotCamera>();

                rt = new RenderTexture(512, 512, 16, RenderTextureFormat.ARGB32);
                snapshotCamCamera.targetTexture = rt;
                snapCamImageTarget.texture = rt;
                camSettings.rt = rt;
            }

        }


	}
}