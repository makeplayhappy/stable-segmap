using UnityEngine;
using System.Collections;
using System.Reflection;
using GILES.Serialization;

namespace GILES.Interface
{
	public class pb_PoseChangerEditor : pb_ComponentEditor
	{
		private PoseChanger _poseChanger;

		protected override void InitializeGUI()
		{
			_poseChanger = (PoseChanger) target;
			
			pb_GUIUtility.AddVerticalLayoutGroup(gameObject);

			pb_TypeInspector pose_inspector = pb_InspectorResolver.GetInspector(typeof(PoseChanger));


			pose_inspector.Initialize("Pose", target, UpdatePose, OnSetPose);
			pose_inspector.transform.SetParent(transform);

			//pose_inspector.poseChanger = _poseChanger;

/*
			enabled_inspector.Initialize("Enabled", UpdateEnabled, OnSetEnabled);
			enabled_inspector.onValueBeginChange = () => { Undo.RegisterState( new UndoReflection(_camera, "enabled"), "Camera Enabled" ); };
			enabled_inspector.transform.SetParent(transform);
*/
		}

		object UpdatePose(int index)
		{
			Debug.Log("Pose Update Pose:" + index);
			return _poseChanger.CurrentClip;
		}

		void OnSetPose(int index, object value)
		{
			Debug.Log("Pose OnSetPose:" + index);
			//_poseChanger.SetClip((int) index);
			//_clipChanger.enabled = (bool) value;
			//pb_ComponentDiff.AddDiff(target, "enabled", _camera.enabled);
		}
	}
}