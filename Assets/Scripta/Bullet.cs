using UnityEngine;

namespace TowerDefense3D
{

    public class Bullet : MonoBehaviour
    {
        private Transform _target;

        [SerializeField]
        private float _speed;
        [SerializeField]
        private int _damage;
        [SerializeField]
        private float _explosionRadius;

        [SerializeField]
        private GameObject _impactEffect;

        public void SeekTarget(Transform _transferredTarget)
        {
            _target = _transferredTarget;
        }

        private void Update()
        {
            if (_target == null)
            {
                Destroy(gameObject);
                return;
            }

            Vector3 _direction = _target.position - transform.position;
            float _distanceThisFrame = _speed * Time.deltaTime;

            if (_direction.magnitude <= _distanceThisFrame)
            {
                HitTarget();
                return;
            }

            transform.Translate(_direction.normalized * _distanceThisFrame, Space.World);
            transform.LookAt(_target);
        }

        private void HitTarget()
        {
            GameObject _effectInstant = (GameObject)Instantiate(_impactEffect, transform.position, transform.rotation);
            Destroy(_effectInstant, 5f);

            if (_explosionRadius > 0f)
            {
                Explode();
            }
            else
            {
                Damage(_target);
            }
            Destroy(gameObject);
        }

        private void Explode()
        {
            Collider[] _colliders = Physics.OverlapSphere(transform.position, _explosionRadius);
            foreach (Collider collider in _colliders)
            {
                if (collider.tag == "Enemy")
                {
                    Damage(collider.transform);
                }
            }
        }

        private void Damage(Transform enemy)
        {
            Enemy e = enemy.GetComponent<Enemy>();
            if (e != null)
            {
                e.TakeDamage(_damage);
            }
        }

        private void OnDrawGizmosSelected()
        {
            Gizmos.color = Color.red;
            Gizmos.DrawWireSphere(transform.position, _explosionRadius);
        }

    }
}