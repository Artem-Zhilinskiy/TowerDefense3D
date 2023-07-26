using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TowerDefense3D
{
    public class NodeUI : MonoBehaviour
    {
        [SerializeField]
        private GameObject _ui;
        private Node _target; 

        public void SetTarget(Node _setTarget)
        {
            _target = _setTarget;
            transform.position = _target.GetBuildPosition();
            _ui.SetActive(true);
        }

        public void Hide()
        {
            _ui.SetActive(false);
        }
    }
}