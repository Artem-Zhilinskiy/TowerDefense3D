using UnityEngine;
using UnityEngine.EventSystems;

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

        BuildManager _buildManager;

        private void Start()
        {
            _renderer = GetComponent<Renderer>();
            _startColor = _renderer.material.color;

            _buildManager = BuildManager._instance;
        }

        private void OnMouseDown()
        {
            if (_buildManager.GetTurretToBuild() == null)
            {
                return;
            }

            if (_turret != null)
            {
                Debug.Log("Can't build there");
                return;
            }

            GameObject _turretToBuild = _buildManager.GetTurretToBuild();
            _turret = (GameObject)Instantiate(_turretToBuild, transform.position + _positionOffset, transform.rotation);
        }
        private void OnMouseEnter()
        {
            if (EventSystem.current.IsPointerOverGameObject())
                return;

            if (_buildManager.GetTurretToBuild() == null)
            {
                return;
            }
            _renderer.material.color = _hoverColor;
        }

        private void OnMouseExit()
        {
            _renderer.material.color = _startColor;
        }
    }
}