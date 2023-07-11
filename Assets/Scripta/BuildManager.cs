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

        [SerializeField]
        private GameObject _standardTurretPrefab;

        private void Start()
        {
            _turretToBuild = _standardTurretPrefab;
        }

        private GameObject _turretToBuild;
        public GameObject GetTurretToBuild()
        {
            return _turretToBuild;
        }
    }
}