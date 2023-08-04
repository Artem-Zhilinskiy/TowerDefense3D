using UnityEngine;

namespace TowerDefense3D
{
    public class PlayerStats : MonoBehaviour
    {
        public static int _money;
        [SerializeField]
        private int _startMoney = 400;

        public static int _lives;

        [SerializeField]
        private int _startLives;

        public static int _rounds;

        private void Start()
        {
            _money = _startMoney;
            _lives = _startLives;

            _rounds = 0;
        }
    }
}