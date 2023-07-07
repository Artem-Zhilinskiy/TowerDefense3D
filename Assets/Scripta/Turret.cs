using UnityEngine;
using System.Collections;

namespace TowerDefense3D
{
	public class Turret : MonoBehaviour
	{
		private Transform _target;

		[Header ("Attributes")]
		[SerializeField]
		private float _range;
		[SerializeField]
		private float _fireRate;
		private float _fireCountDown = 0f;


		[Header("Setup fields")]

		[SerializeField]
		private string enemyTag = "Enemy";
		[SerializeField]
		private Transform _partToRotate;
		[SerializeField]
		private float _rotateSpeed;


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
			if (_target == null) return;

			Vector3 _direction = _target.position - transform.position;
			Quaternion _lookRotation = Quaternion.LookRotation(_direction);
			Vector3 _rotation = Quaternion.Lerp(_partToRotate.rotation, _lookRotation, Time.deltaTime * _rotateSpeed).eulerAngles;
			_partToRotate.rotation = Quaternion.Euler(0f, _rotation.y, 0f);

			if (_fireCountDown <= 0)
            {
				Shoot();
				_fireCountDown = 1f / _fireRate;
            }

			_fireCountDown -= Time.deltaTime;
        }

		private void Shoot()
        {
			Debug.Log("Shoot!");
        }


        private void OnDrawGizmosSelected()
        {
			Gizmos.color = Color.red;
			Gizmos.DrawWireSphere(transform.position, _range);
        }
        /*
		private Transform target;
		private Enemy targetEnemy;

		[Header("General")]

		public float range = 15f;

		[Header("Use Bullets (default)")]
		public GameObject bulletPrefab;
		public float fireRate = 1f;
		private float fireCountdown = 0f;

		[Header("Use Laser")]
		public bool useLaser = false;

		public int damageOverTime = 30;
		public float slowAmount = .5f;

		public LineRenderer lineRenderer;
		public ParticleSystem impactEffect;
		public Light impactLight;

		[Header("Unity Setup Fields")]

		public string enemyTag = "Enemy";

		public Transform partToRotate;
		public float turnSpeed = 10f;

		public Transform firePoint;

		// Use this for initialization
		void Start()
		{
			InvokeRepeating("UpdateTarget", 0f, 0.5f);
		}

		void UpdateTarget()
		{
			GameObject[] enemies = GameObject.FindGameObjectsWithTag(enemyTag);
			float shortestDistance = Mathf.Infinity;
			GameObject nearestEnemy = null;
			foreach (GameObject enemy in enemies)
			{
				float distanceToEnemy = Vector3.Distance(transform.position, enemy.transform.position);
				if (distanceToEnemy < shortestDistance)
				{
					shortestDistance = distanceToEnemy;
					nearestEnemy = enemy;
				}
			}

			if (nearestEnemy != null && shortestDistance <= range)
			{
				target = nearestEnemy.transform;
				targetEnemy = nearestEnemy.GetComponent<Enemy>();
			}
			else
			{
				target = null;
			}

		}

		// Update is called once per frame
		void Update()
		{
			if (target == null)
			{
				if (useLaser)
				{
					if (lineRenderer.enabled)
					{
						lineRenderer.enabled = false;
						impactEffect.Stop();
						impactLight.enabled = false;
					}
				}

				return;
			}

			LockOnTarget();

			if (useLaser)
			{
				Laser();
			}
			else
			{
				if (fireCountdown <= 0f)
				{
					Shoot();
					fireCountdown = 1f / fireRate;
				}

				fireCountdown -= Time.deltaTime;
			}

		}

		void LockOnTarget()
		{
			Vector3 dir = target.position - transform.position;
			Quaternion lookRotation = Quaternion.LookRotation(dir);
			Vector3 rotation = Quaternion.Lerp(partToRotate.rotation, lookRotation, Time.deltaTime * turnSpeed).eulerAngles;
			partToRotate.rotation = Quaternion.Euler(0f, rotation.y, 0f);
		}

		void Laser()
		{
			targetEnemy.TakeDamage(damageOverTime * Time.deltaTime);
			targetEnemy.Slow(slowAmount);

			if (!lineRenderer.enabled)
			{
				lineRenderer.enabled = true;
				impactEffect.Play();
				impactLight.enabled = true;
			}

			lineRenderer.SetPosition(0, firePoint.position);
			lineRenderer.SetPosition(1, target.position);

			Vector3 dir = firePoint.position - target.position;

			impactEffect.transform.position = target.position + dir.normalized;

			impactEffect.transform.rotation = Quaternion.LookRotation(dir);
		}

		void Shoot()
		{
			GameObject bulletGO = (GameObject)Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
			Bullet bullet = bulletGO.GetComponent<Bullet>();

			if (bullet != null)
				bullet.Seek(target);
		}


			void OnDrawGizmosSelected()
			{
				Gizmos.color = Color.red;
				Gizmos.DrawWireSphere(transform.position, range);
			}
		}
	}
	*/
    }
}