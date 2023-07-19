using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TowerDefense3D
{
    public class GameManager : MonoBehaviour
    {
        private bool _gameEnded = false;

        private void Update()
        {
            if (_gameEnded) return;
            if (PlayerStats._lives <= 0)
            {
                EndGame();
            }
        }

        private void EndGame()
        {
            _gameEnded = true;
            Debug.Log("Game over!");
        }
    }
}