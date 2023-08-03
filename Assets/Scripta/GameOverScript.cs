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

        private string _menuSceneName = "MainMenu";

        public void Retry()
        {
            _sceneFader.FadeTo(SceneManager.GetActiveScene().name);
        }

        public void Menu()
        {
            _sceneFader.FadeTo(_menuSceneName);
        }
    }
}