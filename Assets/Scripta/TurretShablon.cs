using UnityEngine;


namespace TowerDefense3D
{
    [System.Serializable]
    public class TurretShablon
    {
        public GameObject _prefab;
        public int _cost;

        public GameObject _upgradedPrefab;
        public int _upgradeCost;
    }
}