using UnityEngine;

namespace TowerDefense3D
{
    public class Node : MonoBehaviour
    {
        [SerializeField]
        private Color _hoverColor;
        [SerializeField]
        Vector3 _positionOffset;

        private GameObject _turret = null;

        private Renderer _renderer;
        private Color _startColor;

        private void Start()
        {
            _renderer = GetComponent<Renderer>();
            _startColor = _renderer.material.color;
        }

        private void OnMouseDown()
        {
            if (_turret != null)
            {
                Debug.Log("Can't build there");
                return;
            }

            GameObject _turretToBuild = BuildManager._instance.GetTurretToBuild();
            _turret = (GameObject)Instantiate(_turretToBuild, transform.position + _positionOffset, transform.rotation);
        }
        private void OnMouseEnter()
        {
            _renderer.material.color = _hoverColor;
        }

        private void OnMouseExit()
        {
            _renderer.material.color = _startColor;
        }
    }
}