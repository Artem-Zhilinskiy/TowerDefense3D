using UnityEngine;

namespace TowerDefense3D
{
    public class ShopScript : MonoBehaviour
    {
        [SerializeField]
        private TurretShablon _standardTurret;
        [SerializeField]
        private TurretShablon _missileLauncher;

        BuildManager _buildManager;

        private void Start()
        {
            _buildManager = BuildManager._instance;
        }
        public void SelectStandardTurret()
        {
            Debug.Log("Standard turret selected");
            _buildManager.SelectTurretToBuild(_standardTurret);
        }

        public void SelectMissileLauncher()
        {
            Debug.Log("Missile launcher selected");
            _buildManager.SelectTurretToBuild(_missileLauncher);
        }
    }
}