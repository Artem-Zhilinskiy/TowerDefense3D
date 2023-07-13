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

        private GameObject _turretToBuild;
        public GameObject GetTurretToBuild()
        {
            return _turretToBuild;
        }

        public void SetTurretRoBuild(GameObject _turret)
        {
            _turretToBuild = _turret;
        }
    }
}