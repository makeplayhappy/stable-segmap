using UnityEngine;
using System.Collections;

namespace GILES
{
	/**
	 * Draw a few arrows pointing in the direction that this light is facing.
	 */
	[pb_Gizmo(typeof(Camera))]
	public class pb_Gizmo_Camera : pb_Gizmo
	{
		public Material camMaterial;
		private Mesh _camMesh;

		private readonly Color yellow = new Color(0.73f, 0.9f, 0.9f, .5f);

		Matrix4x4 gizmoMatrix = Matrix4x4.identity;

		private Mesh camMesh
		{
			get
			{
				if(_camMesh == null){
					_camMesh = ConeMesh();
					camMaterial = pb_BuiltinResource.GetMaterial(pb_BuiltinResource.mat_UnlitVertexColor);
				}
				return _camMesh;
			}
		}

		void Start()
		{
			icon = pb_BuiltinResource.GetMaterial(pb_BuiltinResource.mat_CameraGizmo);
			RebuildGizmos();
		}

		public override void Update()
		{
			base.Update();

			if(!isSelected)
				return;

			if(camMesh == null)
				return;


			gizmoMatrix.SetTRS(trs.position, trs.localRotation, Vector3.one);


			for(int i = 0; i < camMesh.subMeshCount; i++)
				Graphics.DrawMesh(camMesh, gizmoMatrix, camMaterial, 0, null, i, null, false, false);
		}

		private void RebuildGizmos()
		{
			if(_camMesh != null)
			{
				pb_ObjectUtility.Destroy(camMesh);
				_camMesh = null;
			}
		}


		public override void OnComponentModified()
		{
			RebuildGizmos();
		}


		private Mesh ConeMesh()
		{
			Mesh m = new Mesh();

			float r = 5f; //cone radius //lightComponent.range * Mathf.Tan( Mathf.Deg2Rad * (lightComponent.spotAngle / 2f) );
			float range = 20f;
			const int RADIUS_INC = 32;

			Vector3[] v = new Vector3[RADIUS_INC + 1];
			int[] tris = new int[RADIUS_INC * 2 + 8];

			int n = 0;

			for(int i = 0; i < RADIUS_INC; i++)
			{
				float p = (i/(float)RADIUS_INC) * 360f * Mathf.Deg2Rad;
				v[i] = new Vector3( Mathf.Cos(p) * r, Mathf.Sin(p) * r, range );
				tris[n++] = i;
				tris[n++] = i < (RADIUS_INC - 1) ? i + 1 : 0;
			}

			v[RADIUS_INC] = Vector3.zero;

			tris[n++] = RADIUS_INC;
			tris[n++] = 0;
			tris[n++] = RADIUS_INC;
			tris[n++] = RADIUS_INC / 4;
			tris[n++] = RADIUS_INC;
			tris[n++] = RADIUS_INC / 2;
			tris[n++] = RADIUS_INC;
			tris[n++] = (RADIUS_INC / 4) * 3;
			
			m.vertices = v;
			m.normals = pb_CollectionUtil.Fill<Vector3>(Vector3.up, v.Length);
			m.colors = pb_CollectionUtil.Fill<Color>(yellow, v.Length);

			m.subMeshCount = 1;
			m.SetIndices(tris, MeshTopology.Lines, 0);

			return m;
		}

	}
}