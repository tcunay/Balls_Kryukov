using UnityEngine;

namespace Sources.ExtensionMethods
{
    public static class CameraExtension
    {
        public static float GetXAxisVisibility(this Camera camera)
        {
            return camera.ViewportToWorldPoint(new Vector3(0, 0, camera.nearClipPlane)).x;
        }
    }
}