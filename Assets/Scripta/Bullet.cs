using UnityEngine;

namespace TowerDefense3D
{

	public class Bullet : MonoBehaviour
	{
		private Transform _target;

        [SerializeField]
        private float _speed;

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
        }

        private void HitTarget()
        {
            GameObject _effectInstant = (GameObject)Instantiate(_impactEffect, transform.position, transform.rotation);
            Destroy(_effectInstant, 2f);

            Destroy(_target.gameObject);
            Destroy(gameObject);
        }

    }
}