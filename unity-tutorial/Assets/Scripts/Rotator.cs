using UnityEngine;

namespace Lean.Touch
{
    // This script allows you to translate the current GameObject relative to the camera
    public class Rotator : MonoBehaviour
    {
        public bool is_x_axis;
        public bool is_y_axis;
        public bool is_z_axis;


        [Tooltip("Ignore fingers with StartedOverGui?")]
        public bool IgnoreStartedOverGui = true;

        [Tooltip("Ignore fingers with IsOverGui?")]
        public bool IgnoreIsOverGui;

        [Tooltip("Ignore fingers if the finger count doesn't match? (0 = any)")]
        public int RequiredFingerCount;

        [Tooltip("Does translation require an object to be selected?")]
        public LeanSelectable RequiredSelectable;

        [Tooltip("The camera the translation will be calculated using (None = MainCamera)")]
        public Camera Camera;

#if UNITY_EDITOR
        protected virtual void Reset()
        {
            Start();
        }
#endif

        protected virtual void Start()
        {
            if (RequiredSelectable == null)
            {
                RequiredSelectable = GetComponent<LeanSelectable>();
            }
        }

        protected virtual void Update()
        {
            // Get the fingers we want to use
            var fingers = LeanSelectable.GetFingers(IgnoreStartedOverGui, IgnoreIsOverGui, RequiredFingerCount, RequiredSelectable);

            // Calculate the screenDelta value based on these fingers
            var screenDelta = LeanGesture.GetScreenDelta(fingers);

            if (screenDelta != Vector2.zero)
            {
                // Perform the translation
                if (transform is RectTransform)
                {
                    TranslateUI(screenDelta);
                }
                else
                {
                    Translate(screenDelta);
                }
            }
        }

        protected virtual void TranslateUI(Vector2 screenDelta)
        {
            // Screen position of the transform
            var screenPoint = RectTransformUtility.WorldToScreenPoint(Camera, transform.position);

            // Add the deltaPosition
            screenPoint += screenDelta;

            // Convert back to world space
            var worldPoint = default(Vector3);

            if (RectTransformUtility.ScreenPointToWorldPointInRectangle(transform.parent as RectTransform, screenPoint, Camera, out worldPoint) == true)
            {
                transform.position = worldPoint;
            }
        }

        protected virtual void Translate(Vector2 screenDelta)
        {
            // Make sure the camera exists
            var camera = LeanTouch.GetCamera(Camera, gameObject);

            if (camera != null)
            {
                // Screen position of the transform
                var screenPoint = camera.WorldToScreenPoint(transform.position);

                // Add the deltaPosition
                screenPoint += (Vector3)screenDelta;

                // Convert back to world space
                transform.Rotate(
                    new Vector3(
                        is_x_axis ? screenDelta.y : 0.0f,
                        is_y_axis ? screenDelta.x : 0.0f,
                        is_z_axis ? screenDelta.x : 0.0f));
            }
            else
            {
                Debug.LogError("Failed to find camera. Either tag your cameras MainCamera, or set one in this component.", this);
            }
        }
    }
}
