using UnityEngine;
using System.Collections;
using System.Reflection;
using GILES.Serialization;

namespace GILES.Interface
{
	/**
	 * Custom component editor for UnityEngine.Transform.
	 */
	public class pb_TransformEditor : pb_ComponentEditor
	{
		private Transform _transform;
		private MeshRenderer _renderer;

		protected override void InitializeGUI()
		{
			pb_GUIUtility.AddVerticalLayoutGroup(gameObject);

			_transform = (Transform) target;
			_renderer = _transform.gameObject.GetComponent<MeshRenderer>();

		    pb_TypeInspector position_inspector = pb_InspectorResolver.GetInspector(typeof(Vector3));
			pb_TypeInspector rotation_inspector = pb_InspectorResolver.GetInspector(typeof(Vector3));
			pb_TypeInspector scale_inspector 	= pb_InspectorResolver.GetInspector(typeof(Vector3));

			

			position_inspector.Initialize("Position", UpdatePosition, OnSetPosition);
			rotation_inspector.Initialize("Rotation", UpdateRotation, OnSetRotation);
			scale_inspector.Initialize("Scale", UpdateScale, OnSetScale);

			position_inspector.onValueBeginChange = () => { Undo.RegisterState( new UndoTransform(_transform), "Set Position: " + _transform.position.ToString("G") ); };
			rotation_inspector.onValueBeginChange = () => { Undo.RegisterState( new UndoTransform(_transform), "Set Rotation: " + _transform.localRotation.eulerAngles.ToString("G")); };
			scale_inspector.onValueBeginChange = () => { Undo.RegisterState( new UndoTransform(_transform), "Set Scale: " + _transform.localScale.ToString("G") ); };

			position_inspector.transform.SetParent(transform);
			rotation_inspector.transform.SetParent(transform);
			scale_inspector.transform.SetParent(transform);


			if( _renderer != null){

				pb_TypeInspector material_inspector 	= pb_InspectorResolver.GetInspector(typeof(Material));

				material_inspector.Initialize("Material", UpdateMaterial, OnSetMaterial);
				//material_inspector.onValueBeginChange = () => { Undo.RegisterState( new UndoTransform(_transform), "Set Scale: " + _transform.localScale.ToString("G") ); };
				material_inspector.transform.SetParent(transform);


			}else{
				Debug.Log("No mesh filter on " + target.name);
			}


		}

		void Update()
		{
			if(Input.GetMouseButton(0))
			{
				if(pb_SelectionHandle.instance != null && pb_SelectionHandle.instance.InUse())
				{
					UpdateGUI();
				}
			}
		}

		object UpdatePosition(int index)
		{
			return _transform.position;
		}

		void OnSetPosition(int index, object value)
		{
            if (value != null)
            {
                _transform.position = (Vector3)value;
                pb_Selection.OnExternalUpdate();

                pb_ComponentDiff.AddDiff(target, "position", _transform.position);
            }
		}

		object UpdateRotation(int index)
		{
			return _transform.eulerAngles;
		}

		void OnSetRotation(int index, object value) 
		{
			_transform.localRotation = Quaternion.Euler( (Vector3) value );
			pb_Selection.OnExternalUpdate();
		}

		object UpdateScale(int index)
		{
			return _transform.localScale;
		}

		void OnSetScale(int index, object value)
		{
			_transform.localScale = (Vector3) value;
			pb_Selection.OnExternalUpdate();
		}

		object UpdateMaterial(int index)
		{
			return _renderer.material;
		}

		void OnSetMaterial(int index, object value)
		{
			_renderer.material = (Material) value;
			pb_Selection.OnExternalUpdate();
		}

	}
}