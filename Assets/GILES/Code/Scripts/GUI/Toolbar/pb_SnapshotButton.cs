using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;
using System.Collections;

namespace GILES
{
	public class pb_SnapshotButton : pb_ToolbarButton
	{

		public override string tooltip { get { return "Grab png snapshot"; } }

        private byte[] file = null;

		public void Snapshot()
        {
            //pb_SceneLoader.LoadScene(pb_Scene.SaveLevel(), true);
            if( WebGLFileSaver.IsSavingSupported() ){
                StartCoroutine( GrabPNG() );
            }else{
                Debug.Log("Snapshot saving is not available");
            }
        }


        IEnumerator GrabPNG() {

            // Only read the screen after all rendering is complete
            yield return new WaitForEndOfFrame();
            // Create a texture the size of the screen, RGB24 format
            int width = Screen.width;
            int height = Screen.height;
            Texture2D tex = new Texture2D(width, height, TextureFormat.RGB24, false);
            // Read screen contents into the texture
            tex.ReadPixels(new Rect(0, 0, width, height), 0, 0);
            tex.Apply();
            // Encode texture into JPG
            file = ImageConversion.EncodeToPNG(tex);
            Destroy(tex);

            WebGLFileSaver.SaveFile(file, "segmentation.png", "image/png");

        }

	}
}