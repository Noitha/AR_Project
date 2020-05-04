using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;

namespace AR
{
    public class PrefabTracker : MonoBehaviour
    {
        public List<Symbol> symbols = new List<Symbol>();
        private ARTrackedImageManager _trackedImageManager;

        private bool bookOnlyMode = false;

        public SymbolColumn middlePiece;

        public TextMeshProUGUI trackedAmountDebugText;

        private void Awake()
        {
            _trackedImageManager = GetComponent<ARTrackedImageManager>();
            _trackedImageManager.trackedImagesChanged += OnTrackedImagesChanged;
        }

        private void OnDisable()
        {
            _trackedImageManager.trackedImagesChanged -= OnTrackedImagesChanged;
        }

        public void BookOnlyMode()
        {
            bookOnlyMode = true;
            foreach (var symbol in symbols)
            {
                symbol.gameObject.SetActive(false);
            }
        }

        private void OnTrackedImagesChanged(ARTrackedImagesChangedEventArgs eventArgs)
        {
            int tracked = 0;
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

                        if (bookOnlyMode && !symbol.isBook)
                        {
                            return;
                        }

                        /* Set the corresponding prefab to active at the center of the tracked image */
                        symbol.gameObject.SetActive(true);
                        tracked++;
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

            middlePiece.GetCurrentActiveSymbol().gameObject.SetActive(tracked >= 2);
            trackedAmountDebugText.text = "SymRec : " + tracked;
        }
    }
}