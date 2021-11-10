using UnityEngine;

namespace Sources.ExtensionMethods
{
    public static class CameraExtension
    {
        public static float GetXAxisVisibility(this Camera camera)
        {
            return GetCameraVisibility(camera).x - camera.transform.position.x;
        }

        public static float GetYAxisVisibility(this Camera camera)
        {
            return GetCameraVisibility(camera).y - camera.transform.position.y;
        }

        public static Vector3 GetCameraVisibility(this Camera camera)
        {
            return camera.ViewportToWorldPoint(new Vector3(1, 1, camera.nearClipPlane));
        }
    }
}