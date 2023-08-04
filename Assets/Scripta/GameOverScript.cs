using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

namespace TowerDefense3D
{
    public class GameOverScript : MonoBehaviour
    {
        [SerializeField]
        private TextMeshProUGUI _roundsText;

        [SerializeField]
        private SceneFader _sceneFader;

        private int _menuSceneIndex = 0;

        public void Retry()
        {
            WaveSpawner._enemiesAlive = 0;
            _sceneFader.FadeTo(SceneManager.GetActiveScene().buildIndex);
        }

        public void Menu()
        {
            _sceneFader.FadeTo(_menuSceneIndex);
        }
    }
}