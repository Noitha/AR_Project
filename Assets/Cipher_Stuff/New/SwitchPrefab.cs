using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;

namespace Cipher_Stuff.New
{
    public class SwitchPrefab : MonoBehaviour
    {
        public List<Symbol> symbols = new List<Symbol>();
        private ARTrackedImageManager _trackedImageManager;
 
        private void Awake()
        {
            _trackedImageManager = GetComponent<ARTrackedImageManager>();
            _trackedImageManager.trackedImagesChanged += OnTrackedImagesChanged;
        }
 
        private void OnDisable()
        {
            _trackedImageManager.trackedImagesChanged -= OnTrackedImagesChanged;
        }
 
        private void OnTrackedImagesChanged(ARTrackedImagesChangedEventArgs eventArgs)
        {
            foreach (var trackedImage in eventArgs.updated)
            {
                //If an image is properly tracked
                if (trackedImage.trackingState == TrackingState.Tracking)
                {
                    //Loop through image/prefab-combo array
                    foreach (var symbol in symbols)
                    {
                        /* If trackedImage matches an image in the array */
                        if (symbol.symbolMeaning != trackedImage.referenceImage.name)
                        {
                            continue;
                        }

                        if (symbol.isChangeable)
                        {
                            return;
                        }
                        
                        /* Set the corresponding prefab to active at the center of the tracked image */                    
                        symbol.gameObject.SetActive(true);
                        symbol.SetPosition(trackedImage.transform.position);
                    }
                } 
                else
                {
                    foreach (var symbol in symbols)
                    {
                        /* If trackedImage matches an image in the array */
                        if (symbol.symbolMeaning == trackedImage.referenceImage.name)
                        {
                            /* Set the corresponding prefab to active at the center of the tracked image */                    
                            symbol.gameObject.SetActive(false);
                        }
                    }
                }
            }
        }
    }
}