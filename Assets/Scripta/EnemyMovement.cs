using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TowerDefense3D
{
    [RequireComponent(typeof(Enemy))]
    public class EnemyMovement : MonoBehaviour
    {
        private Transform _target;
        private int _wavePointIndex = 0;

        private Enemy _enemy;

        private void Start()
        {
            _target = Waypoints.points[0];
            _enemy = GetComponent<Enemy>();
        }

        private void Update()
        {
            Vector3 _direction = _target.position - transform.position;
            transform.Translate(_direction.normalized * _enemy._speed * Time.deltaTime, Space.World);

            if (Vector3.Distance(transform.position, _target.position) <= 0.4f)
            {
                GetNextWayPoint();
            }
            _enemy._speed = _enemy._startSpeed;
        }

        private void GetNextWayPoint()
        {
            if (_wavePointIndex >= Waypoints.points.Length - 1)
            {
                EndPath();
                return;
            }

            _wavePointIndex++;
            _target = Waypoints.points[_wavePointIndex];
        }

        private void EndPath()
        {
            PlayerStats._lives--;
            WaveSpawner._enemiesAlive--;
            Destroy(gameObject);
        }
    }
}