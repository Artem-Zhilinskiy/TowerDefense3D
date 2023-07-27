using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

namespace TowerDefense3D
{
    public class NodeUI : MonoBehaviour
    {
        [SerializeField]
        private GameObject _ui;
        private Node _target;

        [SerializeField]
        private TextMeshProUGUI _upgradeCost;
        [SerializeField]
        private Button _upgradeButton;

        public void SetTarget(Node _setTarget)
        {
            _target = _setTarget;
            transform.position = _target.GetBuildPosition();
            if (!_target._isUpgraded)
            {
                _upgradeCost.text = "$" + _target.turretShablon._upgradeCost;
                _upgradeButton.interactable = true;
            }
            else
            {
                _upgradeCost.text = "Done";
                _upgradeButton.interactable = false;
            }
            _ui.SetActive(true);
        }

        public void Hide()
        {
            _ui.SetActive(false);
        }

        public void Upgrade()
        {
            _target.UpgradeTurret();
            BuildManager._instance.DeselectNode();
        }
    }
}