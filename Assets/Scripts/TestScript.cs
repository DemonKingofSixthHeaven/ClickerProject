using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class TestScript : MonoBehaviour
{
    public CustomInspectorObjects customInspectorObjects;
}

[System.Serializable]
public class CustomInspectorObjects
{
    public bool swapCameras = false;
    public bool panCameraOnContact = false;

    [HideInInspector] public GameObject test1;
    [HideInInspector] public GameObject test2;

    [HideInInspector] public PanDirection panDirection;
    [HideInInspector] public float panDistance = 3f;
    [HideInInspector] public float panTime = 0.35f;
}

public enum PanDirection
{
    Up,
    Down,
    Left,
    Right
}

[CustomEditor(typeof(TestScript))]
public class MyScriptEditor : Editor
{
    TestScript cameraControlTrigger;

    private void OnEnable()
    {
        cameraControlTrigger = (TestScript)target;
    }

    public override void OnInspectorGUI()
    {
        DrawDefaultInspector();

        if(cameraControlTrigger.customInspectorObjects.swapCameras)
        {
            cameraControlTrigger.customInspectorObjects.test1 = EditorGUILayout.ObjectField("Camera on left",cameraControlTrigger.customInspectorObjects.test1,
            typeof(GameObject), true) as GameObject;

            cameraControlTrigger.customInspectorObjects.test2 = EditorGUILayout.ObjectField("Camera on right",cameraControlTrigger.customInspectorObjects.test2,
            typeof(GameObject), true) as GameObject;
        }

        if(cameraControlTrigger.customInspectorObjects.panCameraOnContact)
        {
            cameraControlTrigger.customInspectorObjects.panDirection = (PanDirection)EditorGUILayout.EnumPopup("Camera pan direction",
            cameraControlTrigger.customInspectorObjects.panDirection);

            cameraControlTrigger.customInspectorObjects.panDistance = EditorGUILayout.FloatField("Pan distance",cameraControlTrigger.customInspectorObjects.panDistance);
            cameraControlTrigger.customInspectorObjects.panTime = EditorGUILayout.FloatField("Pan time", cameraControlTrigger.customInspectorObjects.panTime);
        }

        if(GUI.changed)
        {
            EditorUtility.SetDirty(cameraControlTrigger);
        }
    }
}
