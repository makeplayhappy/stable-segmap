using UnityEngine;
using UnityEngine.UI;
using System.Collections;

namespace GILES.Interface
{
	/**
	 * Resize grid element width and height to best fit the available space.
	 */
	public class pb_GridLayoutGroup : GridLayoutGroup, pb_IOnResizeHandler
	{
		public Vector2 elementSize = new Vector2(100f, 100f);

		public bool maintainAspectRatio = true;

		private Canvas canvas;
		private bool hasScaler = false;




		protected override void Start()
		{
			
			
			base.Start();

			canvas = GetScaledCanvas();//GameObject.Find ("Canvas").gameObject.GetComponent<CanvasScaler> ();

			OnResize();
		}

		public void OnResize()
		{
			if(hasScaler){
				Debug.Log("need scaling: " + canvas.scaleFactor);
			}

			float sf = canvas.scaleFactor;
			Vector2 scaledElementSize = sf * elementSize;
			Vector2 scaledSpacing = sf * spacing;

			float width = (rectTransform.rect.width - scaledSpacing.x);
			float grid = (scaledElementSize.x + scaledSpacing.x) * sf; 

			if(width <= grid)
				return;

			Vector2 cell = Vector2.zero;

			Debug.Log( "width:" + width + " grid:" + grid);

			cell.x = scaledElementSize.x + (width % grid) / (float)(((int)width) / ((int)grid));

			if(maintainAspectRatio)
				cell.y = scaledElementSize.y * (cell.x / scaledElementSize.x);

			cellSize = cell;
		}

		private Canvas GetScaledCanvas(){

			Canvas[] canvases = GetComponentsInParent<Canvas>();
			//top most is at the end so run through backwards
			for(int i = canvases.Length -1 ; i >= 0; i--){

				CanvasScaler cscaler = canvases[i].GetComponent<UnityEngine.UI.CanvasScaler>();

				if( cscaler != null){
					hasScaler = true;
					Debug.Log("Found Canvas Scaler");
					return canvases[i];
				}
			}

			return null;
		}
	}
}
