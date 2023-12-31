using System;
using UnityEngine;
using System.Linq;
using Newtonsoft.Json;
using GILES.Serialization;

namespace GILES
{
	/**
	 * Renders a billboard with an icon.  Inherit this class to add aditional functionality to a gizmo.
	 */
	[pb_JsonIgnore]
	[pb_EditorComponent]
	public abstract class pb_Gizmo : MonoBehaviour
	{
		/// The icon to be rendered facing the camera at the position of this object.
		public Material icon;

		/// A reference to the main camera transform.
		protected Transform cam;

		/// A reference to this object's transform.
		protected Transform trs;

		/// Matrix with a camera facing rotation, world position of parent transform, and scale of 1.
		protected Matrix4x4 cameraFacingMatrix { get { return _cameraFacingMatrix; }}
		private Matrix4x4 _cameraFacingMatrix = Matrix4x4.identity;
		
		public bool isSelected = false;

		private static Mesh _mesh;
		private static Mesh mesh
		{
			get
			{
				if(_mesh == null)
				{
					//GameObject go = GameObject.CreatePrimitive(PrimitiveType.Quad);
					//_mesh = go.GetComponent<MeshFilter>().sharedMesh;
					//pb_ObjectUtility.Destroy(go);
					_mesh = CreateQuad();
				}
				return _mesh;
			}
		}

		private void Awake()
		{
			cam = Camera.main.transform;
			trs = transform;
		}

		/**
		 * Called when something on a component has changed.  Use this to modify gizmo after instantiation if necessary.
		 */
		public virtual void OnComponentModified()
		{}

		public bool CanEditType(Type t)
		{
			pb_GizmoAttribute attrib = this.GetType().GetCustomAttributes(true).FirstOrDefault(x => x is pb_GizmoAttribute) as pb_GizmoAttribute;

			if(attrib != null)
				return attrib.CanEditType(t);

			return false;
		}

		public virtual void Update()
		{
			// To keep handle sizes consistent, uncomment this line
			//_cameraFacingMatrix.SetTRS(trs.position, Quaternion.LookRotation(cam.forward, Vector3.up), Vector3.one * pb_HandleUtility.GetHandleSize(trs.position) * 100f );
			_cameraFacingMatrix.SetTRS(trs.position, Quaternion.LookRotation(cam.forward, Vector3.up), Vector3.one );

			Graphics.DrawMesh(mesh, _cameraFacingMatrix, icon, 0);
		}


		private static Mesh CreateQuad(float width = 1.0f, float height = 1.0f){

			Mesh mesh = new Mesh();

			Vector3[] vertices = new Vector3[4]
			{
				new Vector3(0, 0, 0),
				new Vector3(width, 0, 0),
				new Vector3(0, height, 0),
				new Vector3(width, height, 0)
			};
			mesh.vertices = vertices;

			int[] tris = new int[6]
			{
				// lower left triangle
				0, 2, 1,
				// upper right triangle
				2, 3, 1
			};
			mesh.triangles = tris;

			Vector3[] normals = new Vector3[4]
			{
				-Vector3.forward,
				-Vector3.forward,
				-Vector3.forward,
				-Vector3.forward
			};
			mesh.normals = normals;

			Vector2[] uv = new Vector2[4]
			{
				new Vector2(0, 0),
				new Vector2(1, 0),
				new Vector2(0, 1),
				new Vector2(1, 1)
			};
			mesh.uv = uv;
			return mesh;
		}

	}
}