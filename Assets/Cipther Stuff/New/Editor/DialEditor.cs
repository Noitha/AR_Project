using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(Dial))]
[CanEditMultipleObjects]
public class DialEditor : Editor
{
    Dial _target;
    
    void OnEnable()
    {
        _target = (Dial) target;
    }

    public override void OnInspectorGUI()
    {
        if (GUILayout.Button("Up"))
        {
            _target.Up();
        }
        
        else if (GUILayout.Button("Down"))
        {
            _target.Down();
        }

        
    }
}
