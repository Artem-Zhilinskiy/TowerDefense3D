using UnityEngine;

namespace TowerDefense3D
{
    public class MainMenu : MonoBehaviour
    {
        [SerializeField]
        private int _levelToLoad;

        [SerializeField]
        private SceneFader _sceneFader;

        public void Play()
        {
            _sceneFader.FadeTo(_levelToLoad);
        }

        public void Quit()
        {
            Debug.Log("Quit");
            Application.Quit();
        }
    }
}