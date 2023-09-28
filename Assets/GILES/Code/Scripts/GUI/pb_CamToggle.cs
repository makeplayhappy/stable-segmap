using UnityEngine;
using UnityEngine.UI;
using System.Collections;

namespace GILES.Interface
{
	/**
	 * Controls the toggles in the scene that shows / hides panels.
	 */
	public class pb_CamToggle : pb_ToolbarButton
	{
		/// The panel to enable / disable with this toggle.
		public Camera mainCamera;
		public Camera snapCamera;

		private Color 	onColor = new Color(1f, .68f, 55f/255f, 1f), 
						offColor = new Color(.26f, .26f, .26f, 1f);

		protected override void Start()
		{
			base.Start();

			mainCamera = Camera.main;
			
			onColor = selectable.colors.normalColor;
			offColor = selectable.colors.disabledColor;
			
			SetTextColor();


		}

		private void SetTextColor(){
			ColorBlock block = selectable.colors;
			block.normalColor = mainCamera.enabled ? offColor : onColor ;
			selectable.colors = block;
		}

		public void DoToggle()
		{

			mainCamera.enabled = !mainCamera.enabled;

			SetTextColor();

			
		}
	}
}
