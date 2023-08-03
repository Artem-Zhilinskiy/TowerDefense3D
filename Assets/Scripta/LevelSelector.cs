using UnityEngine;
using UnityEngine.UI;


namespace TowerDefense3D
{
    public class LevelSelector : MonoBehaviour
    {
        [SerializeField]
        private SceneFader _sceneFader;

        public Button[] _levelButtons;

        private void Start()
        {
            int _levelReached = PlayerPrefs.GetInt("levelReached", 1); //Переделать на WryteAllBytes
            for (int i = 0; i < _levelButtons.Length; i++)
            {
                if (i+1 > _levelReached)
                {
                    _levelButtons[i].interactable = false;
                }
                else
                {
                    _levelButtons[i].interactable = true;
                }
            }
        }

        public void Select (string _levelName)
        {
            _sceneFader.FadeTo(_levelName);
        }
    }
}