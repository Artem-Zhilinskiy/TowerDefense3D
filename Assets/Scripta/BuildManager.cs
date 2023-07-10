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
            }
            _instance = this;
        }

        private GameObject _turretToBuild;
        public GameObject GetTurretToBuild()
        {
            return _turretToBuild;
        }
    }
}