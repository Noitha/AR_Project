using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

namespace Old
{
    public class Cipher : MonoBehaviour
    {
        [Serializable]
        public class CipherLayer
        {
            /// <summary>
            /// List of all the symbols on the layer.
            /// </summary>
            public List<string> symbols;
            
            /// <summary>
            /// Hold the index of the current track.
            /// </summary>
            private int _currentTrack;
            
            /// <summary>
            /// What amount of rotation makes one step for a symbol.
            /// </summary>
            private int _stepRotation;
            
            /// <summary>
            /// The actual object that reads the rotation from.
            /// </summary>
            public Transform cipher;
            
            /// <summary>
            /// Display the symbol name to the text component.
            /// </summary>
            public TextMeshProUGUI display;

            /// <summary>
            /// Initialize cipher layer.
            /// </summary>
            public void Initialize()
            {
                _currentTrack = 0;
                _stepRotation = 360 / symbols.Count;
            }

            /// <summary>
            /// Get called to update the current track based on the y rotation.
            /// </summary>
            public void Track()
            {
                _currentTrack = (int) cipher.localEulerAngles.y / _stepRotation;
            }
            
            /// <summary>
            /// Return the current track index.
            /// </summary>
            /// <returns></returns>
            public int GetCurrentTrack()
            {
                return _currentTrack;
            }

            /// <summary>
            /// Return the current name of the symbol.
            /// </summary>
            /// <returns></returns>
            public string GetCurrentSymbol()
            {
                return symbols[_currentTrack];
            }
        }
        
        public List<CipherLayer> cipherLayers = new List<CipherLayer>();

        private void Start()
        {
            foreach (var cipherLayer in cipherLayers)
            {
                cipherLayer.Initialize();
            }
        }
        private void Update()
        {
            foreach (var cipherLayer in cipherLayers)
            {
                cipherLayer.Track();
                cipherLayer.display.text = cipherLayer.GetCurrentSymbol();
            }
        }
    }
}