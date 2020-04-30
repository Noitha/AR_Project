using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
[CustomEditor(typeof(Cypher))]
public class CypherEditor : Editor
{
    private Cypher _target;
    private int defaultSpacing = 8;

    void OnEnable()
    {
        _target = (Cypher) target;
    }

    public override void OnInspectorGUI()
    {
        DrawDefaultInspector();
        
        GUILayout.Space(defaultSpacing);

        if (GUILayout.Button("Left Dial Up"))
        {
            if(_target.leftDial != null) _target.leftDial.Up();
            else Debug.Log("You have to set the value of the Left Dial first!");
        }
        
        else if (GUILayout.Button("Left Dial Down"))
        {
            if(_target.leftDial != null) _target.leftDial.Down();
            else Debug.Log("You have to set the value of the Left Dial first!");
        }
        
        GUILayout.Space(defaultSpacing);

        if (GUILayout.Button("Middle Dial Up"))
        {
            if(_target.middleDial != null) _target.middleDial.Up();
            else Debug.Log("You have to set the value of the Middle Dial first!");
        }
        
        else if (GUILayout.Button("Middle Dial Down"))
        {
            if(_target.middleDial != null) _target.middleDial.Down();
            else Debug.Log("You have to set the value of the Middle Dial first!");
        }
        
        GUILayout.Space(defaultSpacing);
        
        if (GUILayout.Button("Right Dial Up"))
        {
            if(_target.rightDial != null) _target.rightDial.Up();
            else Debug.Log("You have to set the value of the Right Dial first!");
            
        }
        
        else if (GUILayout.Button("Right Dial Down"))
        {
            if(_target.rightDial != null) _target.rightDial.Down();
            else Debug.Log("You have to set the value of the Right Dial first!");
        }
        
    }
}
