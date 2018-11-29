using UnityEngine;

// Zoom forward and backward with mousewheel, Attach this script to camera

namespace UnityLibrary
{
    public class ZoomWithMouse : MonoBehaviour
    {
        public float zoomSpeed = 20;

        void Update()
        {
            var mouseScroll = Input.GetAxis("Mouse ScrollWheel");

            if (mouseScroll != 0)
            {
                transform.Translate(transform.forward * mouseScroll * zoomSpeed * Time.deltaTime, Space.Self);
            }
        }
    }
}
