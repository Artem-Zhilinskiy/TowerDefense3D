using UnityEngine;

namespace TowerDefense3D
{
    public class Node : MonoBehaviour
    {
        [SerializeField]
        private Color _hoverColor;

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

            //Build a turret
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