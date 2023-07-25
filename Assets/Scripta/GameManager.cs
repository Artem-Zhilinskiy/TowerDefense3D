using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TowerDefense3D
{
    public class GameManager : MonoBehaviour
    {
        public static bool _gameIsOver;

        [SerializeField]
        private GameObject _gameOverUI;

        private void Start()
        {
            _gameIsOver = false;
        }

        private void Update()
        {
            if (_gameIsOver) return;
            if (PlayerStats._lives <= 0)
            {
                EndGame();
            }
        }

        private void EndGame()
        {
            _gameIsOver = true;
            _gameOverUI.SetActive(true);
        }
    }
}