using UnityEngine;
using UnityEngine.UI;
using System.IO;


namespace TowerDefense3D
{
    public class LevelSelector : MonoBehaviour
    {
        [SerializeField]
        private SceneFader _sceneFader;

        public Button[] _levelButtons;

        private byte[] _save = null;

        private void Start()
        {
            //int _levelReached = PlayerPrefs.GetInt("levelReached", 1); 
            if (File.Exists(Path.Combine(Application.persistentDataPath, "TowerDefense3D")))
            {
                _save = File.ReadAllBytes(Path.Combine(Application.persistentDataPath, "TowerDefense3D"));
                for (int i = 1; i < _levelButtons.Length; i++)
                {
                    //if (i+1 > _save[0])
                    if (i > _save[0])
                    {
                        _levelButtons[i].interactable = false;
                    }
                    else
                    {
                        _levelButtons[i].interactable = true;
                    }
                }
            }
        }

        public void Select (int _levelIndex)
        {
            _sceneFader.FadeTo(_levelIndex);
        }
    }
}