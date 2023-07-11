using UnityEngine;

namespace TowerDefense3D
{

    public class CameraController : MonoBehaviour
    {
        [SerializeField]
        private float _panSpeed;
        [SerializeField]
        private float _panBorderThickness;

        [SerializeField]
        private float _scrollSpeed;

        [Header("Ограничение движения камеры")]
        [SerializeField]
        private float minY;
        [SerializeField]
        private float maxY;
        [SerializeField]
        private float minX;
        [SerializeField]
        private float maxX;
        [SerializeField]
        private float minZ;
        [SerializeField]
        private float maxZ;

        private void Update()
        {
            if (Input.GetKey("w")/* || (Input.mousePosition.y >= Screen.height - _panBorderThickness)*/)
            {
                transform.Translate(Vector3.forward * _panSpeed * Time.deltaTime, Space.World);
            }
            if (Input.GetKey("s") /* || (Input.mousePosition.y <= _panBorderThickness)*/)
            {
                transform.Translate(Vector3.back * _panSpeed * Time.deltaTime, Space.World);
            }
            if (Input.GetKey("d")/* || (Input.mousePosition.x >= Screen.width - _panBorderThickness)*/)
            {
                transform.Translate(Vector3.right * _panSpeed * Time.deltaTime, Space.World);
            }
            if (Input.GetKey("a")/* || (Input.mousePosition.x <=  _panBorderThickness)*/)
            {
                transform.Translate(Vector3.left * _panSpeed * Time.deltaTime, Space.World);
            }

            float _scroll = Input.GetAxis("Mouse ScrollWheel");
            Vector3 _position = transform.position;
            _position.y -= _scroll * _scrollSpeed * Time.deltaTime * 1000;
            _position.y = Mathf.Clamp(_position.y, minY, maxY);
            _position.x = Mathf.Clamp(_position.x, minX, maxX);
            _position.z = Mathf.Clamp(_position.z, minZ, maxZ);
            transform.position = _position;
        }

    }
}