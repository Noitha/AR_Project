using UnityEngine;
using UnityEngine.XR.ARFoundation;

namespace AR
{
    public class PlayerScript : MonoBehaviour
    {
        private ARSessionOrigin _arSessionOrigin;
        private ARRaycastManager _arRaycastManager;

        private GameObject HitGameObject;
        private Vector2 lastTouchPos;
        private Quaternion rotation;

        // Start is called before the first frame update
        void Start()
        {
            _arSessionOrigin = FindObjectOfType<ARSessionOrigin>();
            _arSessionOrigin.GetComponent<ARRaycastManager>();
        }

        // Update is called once per frame
        void Update()
        {
            if (HitGameObject != null) HitGameObject.transform.rotation = rotation;

            if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began)
            {
                Tap();
                //lastTouchPos = Input.GetTouch(0).position;
            }

            /*
            if (HitGameObject != null && Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Moved)
            {
                HitGameObject.transform.Rotate(Vector3.up,(lastTouchPos - Input.GetTouch(0).position).x);
                rotation= new Quaternion(HitGameObject.transform.rotation.x,HitGameObject.transform.rotation.y,HitGameObject.transform.rotation.z,HitGameObject.transform.rotation.w);
                lastTouchPos = Input.GetTouch(0).position;
            }*/
        }

        void Tap()
        {
            Ray cameraRay = Camera.main.ScreenPointToRay(Input.GetTouch(0).position);

            if (Physics.Raycast(cameraRay, out RaycastHit hit))
            {
                if (hit.collider.CompareTag("ARRotate"))
                {
                    hit.collider.gameObject.GetComponent<Sign>().changeSign();
                }
            }

        }
    }
}