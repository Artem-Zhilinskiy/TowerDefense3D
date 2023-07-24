using UnityEngine;


namespace TowerDefense3D
{
    public class Enemy : MonoBehaviour
    {
        [SerializeField]
        private float _health;

        [SerializeField]
        private int _worth;

        [SerializeField]
        private GameObject _deathEffect;

        public float _startSpeed;
        [HideInInspector]
        public float _speed;

        public void TakeDamage(float amount)
        {
            _health -= amount;
            if (_health <= 0)
            {
                Die();
            }
        }

        private void Start()
        {
            _speed = _startSpeed;
        }

        public void Slow(float _pct)
        {
            _speed = _startSpeed * (1f - _pct);
        }

        private void Die()
        {
            PlayerStats._money += _worth;
            GameObject _effect = (GameObject)Instantiate(_deathEffect, transform.position, Quaternion.identity);
            Destroy(_effect, 5f);
            Destroy(gameObject);
        }


    }
}