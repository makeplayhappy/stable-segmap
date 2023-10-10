using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine.UI;

namespace GILES.Interface
{
	/**
	 * Field editor for Pose types. / /SimpleAnimateClipChanger
	 */
	[pb_TypeInspector(typeof(PoseChanger))]
	public class pb_PoseChangerInspector : pb_TypeInspector
	{
		//PoseChanger value;
		int value;

		//public MaterialListSO matList;
		public PoseChanger poseChanger;
		public UnityEngine.UI.Text title;
		public UnityEngine.UI.Dropdown dropdown;


		void OnGUIChanged()
		{
			//SetValue(value);
			Debug.Log("OnGUIChanged");

			dropdown.RefreshShownValue();

		}

		//add events and initialise pre variables
		public override void InitializeGUI()
		{
			Debug.Log("PoseChanger InitializeGUI");

			if(target != null){
				Debug.Log("InitializeGUI Setting target pose changer");
				poseChanger = (PoseChanger) target;
			}

/*
			if( value == null){
				Debug.Log("InitializeGUI NULL");
			}else{
				Debug.Log("InitializeGUI val:" + value.CurrentClip );
			}
*/
			//pb_GUIUtility.AddVerticalLayoutGroup(gameObject);

			title.text = "Choose Pose";//GetName().SplitCamelCase();

			//RefreshDropdown();

			dropdown.onValueChanged.AddListener( delegate {
                OnDropDownValueChanged(dropdown);
            });

		}

		protected override void OnUpdateGUI()
		{
			if( value == null){
				Debug.Log("OnUpdateGUI value is null GetValue");
				value = GetValue<int>();
			}

			if( value != null){
				Debug.Log("value" + value);
			//dropbox.text = (value == null ? "null" : value.ToString());
				RefreshDropdown();
			}

			if( target != null){
				Debug.Log("OnUpdateGUI target not null");
			}

			/*
			value = GetValue<ICollection>();

			if(value == null)
				return;

			int prev_length = array.Length;

			array = value.Cast<object>().ToArray();
			
			if(array.Length < 1 || array.Length > 32)
				return;

			if(prev_length != array.Length)	
			{
				foreach(Transform t in transform)
					pb_ObjectUtility.Destroy(t.gameObject);

				InitializeGUI();
			}*/
			
		}

		void RefreshDropdown() {
			if( poseChanger != null){
            	dropdown.ClearOptions();
            	dropdown.AddOptions( poseChanger.GetClipList() );
			}
        }

/*
		public void OnValueChange(Material val)
		{
			value = val;
			OnGUIChanged();
		}
*/

		public void OnDropDownValueChanged( Dropdown change ){

			Debug.Log("changed : " + change.value);
			value = change.value;

			poseChanger.SetClip((int) value);
			//SetValue(change.value);
        	//value = change.value;

			//string selectedName = change.options[change.value].text;

			//string matName = SegmentColors.CleanName( selectedName );

			//Material newMat = matList.GetMaterialByName(matName);

			OnGUIChanged();


		}
/*
		public void OnSearchValueChange( string val ){
			if( val.Length > 2){

				IDictionary<string, Color32> results = SegmentColors.NameSearch(val);
				if( results.Count > 0){

					dropdown.ClearOptions();

					List<Dropdown.OptionData> newDropList = new List<Dropdown.OptionData>();

					Dropdown.OptionData firstItem = new Dropdown.OptionData("Select segmentation color"); 
					newDropList.Add(firstItem);

					foreach( KeyValuePair<string, Color32> kvp in results ){


						Texture2D dtexture = new Texture2D(1,1); // creating texture with 1 pixel
 						dtexture.SetPixel(0, 0, (Color)kvp.Value); // setting to this pixel some color
 						dtexture.Apply();
						// creating dropdown item and converting texture to sprite

						string dtext = kvp.Key;
						Sprite dimage = Sprite.Create(dtexture, new Rect(0, 0, dtexture.width, dtexture.height), new Vector2(0, 0)); 
						Dropdown.OptionData item = new Dropdown.OptionData(dtext, dimage); 
						newDropList.Add(item);

					}

					dropdown.AddOptions(newDropList);
					
				}


			}
		}
*/
	}
}