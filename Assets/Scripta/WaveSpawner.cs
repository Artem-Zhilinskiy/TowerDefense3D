using UnityEngine;
using System.Collections;
using UnityEngine.UI;

namespace TowerDefense3D
{
    public class WaveSpawner : MonoBehaviour
    {
        public static int _enemiesAlive;

        [SerializeField]
        private GameManager _gameManager;

        [SerializeField]
        private Wave[] _waves;

        [SerializeField]
        private Transform _enemyPrefab;

        [SerializeField]
        private Transform _spawnPoint;

        //[SerializeField]
        //private float _timeBetweenEnemies = 0.5f;

        private float _countdown = 2f;

        private int _waveIndex = 0;

        [SerializeField]
        private Text _waveCountDownText;

        [SerializeField]
        private float _timeBetweenWaves;

        private void Update()
        {
            if (_enemiesAlive > 0)
            {
                return;
            }

            if (_waveIndex == _waves.Length)
            {
                _gameManager.WinLevel();
                this.enabled = false;
            }

            if (_countdown <= 0)
            {
                StartCoroutine(SpawnWave());
                _countdown = _timeBetweenWaves;
                return;
            }
            _countdown = Mathf.Clamp(_countdown, 0f, Mathf.Infinity);
            _countdown -= Time.deltaTime;

            _waveCountDownText.text = string.Format("{0:00.00}", _countdown);
        }

        IEnumerator SpawnWave()
        {
            PlayerStats._rounds++;

            Wave _wave = _waves[_waveIndex];

            _enemiesAlive = _wave._count;

            for (int i = 0; i < _wave._count; i++)
            {
                SpawnEnemy(_wave._enemy);
                yield return new WaitForSeconds(1f/ _wave._rate);
            }
            _waveIndex++;
        }

        private void SpawnEnemy(GameObject _enemy)
        {
            Instantiate(_enemy, _spawnPoint.position, _spawnPoint.rotation);
        }
    }
}