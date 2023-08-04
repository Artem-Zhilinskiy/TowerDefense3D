using UnityEngine;
using System.IO;

namespace TowerDefense3D
{

    public class CompleteLevel : MonoBehaviour
    {
        [SerializeField]
        private SceneFader _sceneFader;

        private int _menuSceneIndex = 0;

        [SerializeField]
        private int _nextScene;
        [SerializeField]
        private byte _levelToUnlock;

        public void Continue()
        {
            //PlayerPrefs.SetInt("levelReached", _levelToUnlock);
            byte[] _save = new byte[] { _levelToUnlock };
            File.WriteAllBytes(Path.Combine(Application.persistentDataPath, "TowerDefense3D"), _save);
            _sceneFader.FadeTo(_nextScene);
        }

        public void Menu()
        {
            _sceneFader.FadeTo(_menuSceneIndex);
        }
    }
}