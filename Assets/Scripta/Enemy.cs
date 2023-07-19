using UnityEngine;


namespace TowerDefense3D
{
    public class Enemy : MonoBehaviour
    {
        public float _speed = 10f;

        [SerializeField]
        private int _health;

        [SerializeField]
        private int _value;

        [SerializeField]
        private GameObject _deathEffect;

        private Transform _target;
        private int _wavePointIndex = 0;

        private void Start()
        {
            _target = Waypoints.points[0];
        }

        public void TakeDamage(int amount)
        {
            _health -= amount;
            if (_health <= 0)
            {
                Die();
            }
        }

        private void Die()
        {
            PlayerStats._money += _value;
            GameObject _effect = (GameObject)Instantiate(_deathEffect, transform.position, Quaternion.identity);
            Destroy(_effect, 5f);
            Destroy(gameObject);
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
                EndPath();
                return;
            }    

            _wavePointIndex++;
            _target = Waypoints.points[_wavePointIndex];
        }

        private void EndPath()
        {
            PlayerStats._lives--;
            Destroy(gameObject);
        }
    }
}