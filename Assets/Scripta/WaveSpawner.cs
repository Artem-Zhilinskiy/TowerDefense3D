using UnityEngine;

namespace TowerDefense3D
{
    public class WaveSpawner : MonoBehaviour
    {
        public Transform _enemyPrefab;

        [SerializeField]
        private float _timeBetweenWaves;
    }
}