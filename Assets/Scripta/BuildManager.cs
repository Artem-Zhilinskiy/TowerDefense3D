using UnityEngine;

namespace TowerDefense3D
{
    public class BuildManager : MonoBehaviour
    {
        public static BuildManager _instance;

        private void Awake()
        {
            if (_instance != null)
            {
                Debug.LogError("More than one BuildManager in scene");
                return;
            }
            _instance = this;
        }

        public GameObject _standardTurretPrefab;
        public GameObject _missileLauncherPrefab;
        [SerializeField]
        private GameObject _buildEffect;

        private TurretShablon _turretToBuild;

        public bool _canBuild { get { return _turretToBuild != null; } }
        public bool _hasMoney { get { return PlayerStats._money >= _turretToBuild._cost;} }

        public void BuildTurretOn(Node node)
        {
            if (PlayerStats._money < _turretToBuild._cost)
            {
                Debug.Log("Not enough money to build that");
                return;
            }

            PlayerStats._money -= _turretToBuild._cost;

            GameObject _turret = (GameObject)Instantiate(_turretToBuild._prefab, node.GetBuildPosition(), Quaternion.identity);
            node._turret = _turret;

            GameObject _effect = (GameObject)Instantiate(_buildEffect, node.GetBuildPosition(), Quaternion.identity);
            Destroy(_effect, 5f);

            Debug.Log("Turret is built! Money left: " + PlayerStats._money);
        }

        public void SelectTurretToBuild(TurretShablon _turret)
        {
            _turretToBuild = _turret;
        }
    }
}