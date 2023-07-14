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

        [Header("Optional")]
        public GameObject _turret = null;

        private Renderer _renderer;
        private Color _startColor;

        BuildManager _buildManager;

        private void Start()
        {
            _renderer = GetComponent<Renderer>();
            _startColor = _renderer.material.color;

            _buildManager = BuildManager._instance;
        }

        public Vector3 GetBuildPosition()
        {
            return transform.position + _positionOffset;
        }

        private void OnMouseDown()
        {
            if (!_buildManager._canBuild)
            {
                return;
            }

            if (_turret != null)
            {
                Debug.Log("Can't build there");
                return;
            }
            _buildManager.BuildTurretOn(this);
        }
        private void OnMouseEnter()
        {
            if (EventSystem.current.IsPointerOverGameObject())
                return;

            if (!_buildManager._canBuild)
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