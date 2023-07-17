using UnityEngine;
using System.Collections;
using UnityEngine.UI;

namespace TowerDefense3D
{
    public class WaveSpawner : MonoBehaviour
    {
        [SerializeField]
        private Transform _enemyPrefab;

        [SerializeField]
        private Transform _spawnPoint;

        [SerializeField]
        private float _timeBetweenEnemies = 0.5f;

        private float _countdown = 2f;

        private int _waveIndex = 0;

        [SerializeField]
        private Text _waveCountDownText;

        [SerializeField]
        private float _timeBetweenWaves;

        private void Update()
        {
            if (_countdown <= 0)
            {
                StartCoroutine(SpawnWave());
                _countdown = _timeBetweenWaves;
            }
            _countdown = Mathf.Clamp(_countdown, 0f, Mathf.Infinity);
            _countdown -= Time.deltaTime;

            _waveCountDownText.text = string.Format("{0:00.00}", _countdown);
        }

        IEnumerator SpawnWave()
        {
            _waveIndex++;

            for (int i = 0; i < _waveIndex; i++)
            {
                SpawnEnemy();
                yield return new WaitForSeconds(_timeBetweenEnemies);
            }
        }

        private void SpawnEnemy()
        {
            Instantiate(_enemyPrefab, _spawnPoint.position, _spawnPoint.rotation);
        }
    }
}