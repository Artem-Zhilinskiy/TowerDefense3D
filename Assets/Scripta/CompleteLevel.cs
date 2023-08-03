using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TowerDefense3D
{

    public class CompleteLevel : MonoBehaviour
    {
        [SerializeField]
        private SceneFader _sceneFader;

        private string _menuSceneName = "MainMenu";

        [SerializeField]
        private string _nextLevel = "Level2";
        [SerializeField]
        private int _levelToUnlock = 2;

        public void Continue()
        {
            PlayerPrefs.SetInt("levelReached", _levelToUnlock);
            _sceneFader.FadeTo(_nextLevel);
        }

        public void Menu()
        {
            _sceneFader.FadeTo(_menuSceneName);
        }
    }
}