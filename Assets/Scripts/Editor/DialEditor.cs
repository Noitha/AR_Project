using System.Collections;
using System.Collections.Generic;
using CipherSimulation;
using UnityEditor;
using UnityEngine;

namespace Editor
{
    [CustomEditor(typeof(Dial))]
    [CanEditMultipleObjects]
    public class DialEditor : UnityEditor.Editor
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
}