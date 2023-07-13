using UnityEngine;

namespace TowerDefense3D
{
    public class ShopScript : MonoBehaviour
    {
        BuildManager _buildManager;

        private void Start()
        {
            _buildManager = BuildManager._instance;
        }
        public void PurchaseStandardTurret()
        {
            Debug.Log("Standard turret selected");
            _buildManager.SetTurretRoBuild(_buildManager._standardTurretPrefab);
        }

        public void PurchaseMissileLauncher()
        {
            Debug.Log("Missile launcher selected");
            _buildManager.SetTurretRoBuild(_buildManager._missileLauncherPrefab);
        }
    }
}