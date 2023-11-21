using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(EnnemiFSM))]
public class EnnemiFSMEditor : Editor
{

    public override void OnInspectorGUI()
    {
        EnnemiFSM Target = (EnnemiFSM)target;

        //EditorGUILayout.LabelField(Target.GetState().ToString());
        GUILayout.Box(Target.GetState().ToString());

        DrawDefaultInspector();

    }

}
