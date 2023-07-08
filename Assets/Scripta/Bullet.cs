using UnityEngine;

namespace TowerDefense3D
{

	public class Bullet : MonoBehaviour
	{
		private Transform _target;

        [SerializeField]
        private float _speed;

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
        }

    }
}