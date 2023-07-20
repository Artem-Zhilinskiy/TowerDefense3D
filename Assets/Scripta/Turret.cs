using UnityEngine;
using System.Collections;

namespace TowerDefense3D
{
	public class Turret : MonoBehaviour
	{
		private Transform _target;

		[Header ("General")]
		[SerializeField]
		private float _range;
		[Header("Use Bullets (default)")]
		[SerializeField]
		private float _fireRate;
		[SerializeField]
		private GameObject _bulletPrefab;
		private float _fireCountDown = 0f;

		[Header("Use Laser")]
		[SerializeField]
		private bool _useLaser = false;
		[SerializeField]
		private LineRenderer _lineRenderer;

		[Header("Setup fields")]

		[SerializeField]
		private string enemyTag = "Enemy";
		[SerializeField]
		private Transform _partToRotate;
		[SerializeField]
		private float _rotateSpeed;
		[SerializeField]
		private Transform _firePoint;


        private void Start()
        {
			InvokeRepeating("UpdateTarget", 0f, 0.5f);
        }

        private void UpdateTarget()
        {
			GameObject[] _enemies = GameObject.FindGameObjectsWithTag(enemyTag);
			float _shortestDistance = Mathf.Infinity;
			GameObject _nearestEnemy = null;

			foreach (GameObject _enemy in _enemies)
            {
				float _distanceToEnemy = Vector3.Distance(transform.position, _enemy.transform.position);
				if (_distanceToEnemy < _shortestDistance)
                {
					_shortestDistance = _distanceToEnemy;
					_nearestEnemy = _enemy;
                }
            }

			if (_nearestEnemy != null && _shortestDistance <= _range)
            {
				_target = _nearestEnemy.transform;
            }
			else
            {
				_target = null;
            }
        }

        private void Update()
        {
			if (_target == null)
			{
				if (_useLaser == true)
                {
					if (_lineRenderer.enabled)
                    {
						_lineRenderer.enabled = false;
                    }
                }
				return;
			}

			LockOnTarget();

			if (_useLaser)
            {
				LaserShoot();
            }
			else
            {
				if (_fireCountDown <= 0)
				{
					Shoot();
					_fireCountDown = 1f / _fireRate;
				}

				_fireCountDown -= Time.deltaTime;
			}
        }

		private void LockOnTarget()
        {
			Vector3 _direction = _target.position - transform.position;
			Quaternion _lookRotation = Quaternion.LookRotation(_direction);
			Vector3 _rotation = Quaternion.Lerp(_partToRotate.rotation, _lookRotation, Time.deltaTime * _rotateSpeed).eulerAngles;
			_partToRotate.rotation = Quaternion.Euler(0f, _rotation.y, 0f);
		}

		private void Shoot()
        {
			GameObject _bulletGO = (GameObject)Instantiate(_bulletPrefab, _firePoint.position, _firePoint.rotation);
			Bullet _bullet = _bulletGO.GetComponent<Bullet>();

			if (_bullet != null)
            {
				_bullet.SeekTarget(_target);
            }
        }

		private void LaserShoot()
        {
			if (!_lineRenderer.enabled)
			{
				_lineRenderer.enabled = true;
			}
				_lineRenderer.SetPosition(0, _firePoint.position);
				_lineRenderer.SetPosition(1, _target.position);
        }

        private void OnDrawGizmosSelected()
        {
			Gizmos.color = Color.red;
			Gizmos.DrawWireSphere(transform.position, _range);
        }
    }
}