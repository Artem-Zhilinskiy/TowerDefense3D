using UnityEngine;
using UnityEngine.SceneManagement;

namespace TowerDefense3D
{

    public class PauseMenu : MonoBehaviour
    {
        [SerializeField]
        private GameObject _UI;
        [SerializeField]
        private SceneFader _sceneFader;

        private string _menuSceneName = "MainMenu";

        public void Update()
        {
            if (Input.GetKeyDown(KeyCode.Escape) || Input.GetKeyDown(KeyCode.P))
            {
                Toggle();
            }
        }

        private void Toggle()
        {
            _UI.SetActive(!_UI.activeSelf);

            if (_UI.activeSelf)
            {
                Time.timeScale = 0f;
            }
            else
            {
                Time.timeScale = 1f;
            }
        }

        public void Retry()
        {
            Toggle();
            _sceneFader.FadeTo(SceneManager.GetActiveScene().name);
            //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }

        public void Menu()
        {
            Toggle();
            _sceneFader.FadeTo(_menuSceneName);
        }
    }
}