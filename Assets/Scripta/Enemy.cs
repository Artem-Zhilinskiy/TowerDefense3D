using UnityEngine;
using UnityEngine.UI;


namespace TowerDefense3D
{
    public class Enemy : MonoBehaviour
    {
        [SerializeField]
        private float _startHealth;
        private float _health;

        [SerializeField]
        private int _worth;

        [SerializeField]
        private GameObject _deathEffect;

        public float _startSpeed;
        [HideInInspector]
        public float _speed;

        [SerializeField]
        private Image _healthBar;

        private bool _isDead = false;

        public void TakeDamage(float amount)
        {
            _health -= amount;
            _healthBar.fillAmount = _health / _startHealth;
            if (_health <= 0 && !_isDead)
            {
                Die();
            }
        }

        private void Start()
        {
            _speed = _startSpeed;
            _health = _startHealth;
        }

        public void Slow(float _pct)
        {
            _speed = _startSpeed * (1f - _pct);
        }

        private void Die()
        {
            _isDead = true;
            PlayerStats._money += _worth;
            GameObject _effect = (GameObject)Instantiate(_deathEffect, transform.position, Quaternion.identity);
            Destroy(_effect, 5f);
            WaveSpawner._enemiesAlive--;
            Destroy(gameObject);
        }


    }
}