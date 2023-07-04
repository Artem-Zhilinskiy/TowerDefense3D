using UnityEngine;


namespace TowerDefense3D
{
    public class Enemy : MonoBehaviour
    {
        public float _speed = 10f;

        private Transform _target;
        private int _wavePointIndex = 0;

        private void Start()
        {
            _target = Waypoints.points[0];
        }

        private void Update()
        {
            Vector3 _direction = _target.position - transform.position;
            transform.Translate(_direction.normalized * _speed * Time.deltaTime, Space.World);

            if (Vector3.Distance(transform.position, _target.position) <= 0.4f)
            {
                GetNextWayPoint();
            }
        }

        private void GetNextWayPoint()
        {
            if (_wavePointIndex >= Waypoints.points.Length - 1)
            {
                Destroy(gameObject);
                return;
            }    

            _wavePointIndex++;
            _target = Waypoints.points[_wavePointIndex];
        }
    }
}