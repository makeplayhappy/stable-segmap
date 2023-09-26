using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine.UI;

namespace GILES.Interface
{
	/**
	 * Field editor for Material types.
	 */
	[pb_TypeInspector(typeof(Material))]
	public class pb_MaterialInspector : pb_TypeInspector
	{
		Material value;

		public MaterialListSO matList;

		public UnityEngine.UI.Text title;
		public UnityEngine.UI.InputField dropbox;
		public UnityEngine.UI.Image colorImage;
		public UnityEngine.UI.Dropdown dropdown;


		void OnGUIChanged()
		{
			SetValue(value);
		}

		public override void InitializeGUI()
		{
			title.text = GetName().SplitCamelCase();
			colorImage.type = Image.Type.Simple;
			colorImage.color = new Color32(128, 128, 128, 255);
			dropbox.onValueChanged.AddListener( OnSearchValueChange );

			dropdown.onValueChanged.AddListener( delegate {
                OnDropDownValueChanged(dropdown);
            });

		}

		protected override void OnUpdateGUI()
		{
			value = GetValue<Material>();
			dropbox.text = (value == null ? "null" : value.ToString());
		}

		public void OnValueChange(Material val)
		{
			value = val;
			OnGUIChanged();
		}

		public void OnDropDownValueChanged( Dropdown change ){

        	string selectedName = change.options[change.value].text;
			Debug.Log("dropdown set to " + selectedName );
			string matName = SegmentColors.CleanName( selectedName );
			Debug.Log("set matrial to " + matName);
			Material newMat = matList.GetMaterialByName(matName);
			SetValue(newMat);

		}

		public void OnSearchValueChange( string val ){
			if( val.Length > 2){

				IDictionary<string, Color32> results = SegmentColors.NameSearch(val);
				if( results.Count > 0){

					dropdown.ClearOptions();

					List<Dropdown.OptionData> newDropList = new List<Dropdown.OptionData>();

					foreach( KeyValuePair<string, Color32> kvp in results ){

						Debug.Log("Key = " + kvp.Key );
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
					
			


//					Debug.Log("Found " + results.Count + " results");
//					foreach( KeyValuePair<string, Color32> kvp in results ){
//						Debug.Log("Key = " + kvp.Key );
//					}

				//build a clickable list
				}


			}
		}
	}
}