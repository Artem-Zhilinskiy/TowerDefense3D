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

        private TurretShablon _turretToBuild;

        public bool _canBuild { get { return _turretToBuild != null; } }

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

            Debug.Log("Turret is built! Money left: " + PlayerStats._money);
        }

        public void SelectTurretToBuild(TurretShablon _turret)
        {
            _turretToBuild = _turret;
        }
    }
}