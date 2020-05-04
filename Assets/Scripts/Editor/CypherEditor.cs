using CipherSimulation;
using UnityEditor;
using UnityEngine;

namespace Editor
{

    [CustomEditor(typeof(Cipher))]
    public class CypherEditor : UnityEditor.Editor
    {
        private Cipher _target;
        private int defaultSpacing = 8;

        void OnEnable()
        {
            _target = (Cipher) target;
        }

        public override void OnInspectorGUI()
        {
            DrawDefaultInspector();

            GUILayout.Space(defaultSpacing);

            if (GUILayout.Button("Left Dial Up"))
            {
                if (_target.leftDial != null) _target.leftDial.Up();
                else Debug.Log("You have to set the value of the Left Dial first!");
            }

            else if (GUILayout.Button("Left Dial Down"))
            {
                if (_target.leftDial != null) _target.leftDial.Down();
                else Debug.Log("You have to set the value of the Left Dial first!");
            }

            GUILayout.Space(defaultSpacing);

            if (GUILayout.Button("Right Dial Up"))
            {
                if (_target.rightDial != null) _target.rightDial.Up();
                else Debug.Log("You have to set the value of the Right Dial first!");

            }

            else if (GUILayout.Button("Right Dial Down"))
            {
                if (_target.rightDial != null) _target.rightDial.Down();
                else Debug.Log("You have to set the value of the Right Dial first!");
            }

        }
    }
}