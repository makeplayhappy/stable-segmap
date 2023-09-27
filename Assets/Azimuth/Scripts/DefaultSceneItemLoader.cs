using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using GILES;
using System.Collections;





public class DefaultSceneItemLoader : MonoBehaviour	{
	/// A reference to the inspector GUI scroll panel.  All new UI elements will be 
	/// instantiated as children of this GameObject.
	public GameObject[] defaultItems;


    void Start(){
        if( defaultItems != null && defaultItems.Length >0 ){

            for(int i = 0; i < defaultItems.Length; i++){
                GameObject go = (GameObject)pb_Scene.Instantiate(defaultItems[i], Vector3.zero, Quaternion.identity);
            }

        }

	}
}