using UnityEngine;
using UnityEngine.EventSystems;

namespace TowerDefense3D
{
    public class Node : MonoBehaviour
    {
        [SerializeField]
        private Color _hoverColor;
        [SerializeField]
        private Color _notEnoughMoneyColor;
        [SerializeField]
        Vector3 _positionOffset;

        [HideInInspector]
        public GameObject _turret;
        [HideInInspector]
        public TurretShablon turretShablon;
        [HideInInspector]
        public bool _isUpgraded = false;

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
            if (_turret != null)
            {
                _buildManager.SelectNode(this);
                return;
            }

            if (!_buildManager._canBuild)
            {
                return;
            }
            BuildTurret(_buildManager.GetTurretToBuild());
        }

        private void BuildTurret(TurretShablon _turretShablon)
        {
            if (PlayerStats._money < _turretShablon._cost)
            {
                Debug.Log("Not enough money to build that");
                return;
            }
            PlayerStats._money -= _turretShablon._cost;
            GameObject _turretToBuild = (GameObject)Instantiate(_turretShablon._prefab, GetBuildPosition(), Quaternion.identity);
            _turret = _turretToBuild;
            turretShablon = _turretShablon;
            GameObject _effect = (GameObject)Instantiate(_buildManager._buildEffect, GetBuildPosition(), Quaternion.identity);
            Destroy(_effect, 5f);
            Debug.Log("Turret is built!");
        }

        public void UpgradeTurret()
        {
            if (PlayerStats._money < turretShablon._upgradeCost)
            {
                Debug.Log("Not enough money to upgrade that");
                return;
            }
            PlayerStats._money -= turretShablon._upgradeCost;
            //Get rid of the old turret.
            Destroy(_turret);
            //Build an upgraded one.
            GameObject _turretToBuild = (GameObject)Instantiate(turretShablon._upgradedPrefab, GetBuildPosition(), Quaternion.identity);
            _turret = _turretToBuild;
            GameObject _effect = (GameObject)Instantiate(_buildManager._buildEffect, GetBuildPosition(), Quaternion.identity);
            Destroy(_effect, 5f);
            _isUpgraded = true;
            Debug.Log("Turret upgraded!");
        }

        public void SellTurret()
        {
            PlayerStats._money += turretShablon.GetSellAmount();
            GameObject _effect = (GameObject)Instantiate(_buildManager._sellEffect, GetBuildPosition(), Quaternion.identity);
            Destroy(_effect, 5f);
            Destroy(_turret);
            turretShablon = null;
        }

        private void OnMouseEnter()
        {
            if (EventSystem.current.IsPointerOverGameObject())
                return;

            if (!_buildManager._canBuild)
            {
                return;
            }

            if (_buildManager._hasMoney)
            {
                _renderer.material.color = _hoverColor;
            }
            else
            {
                _renderer.material.color = _notEnoughMoneyColor;
            }
        }

        private void OnMouseExit()
        {
            _renderer.material.color = _startColor;
        }
    }
}