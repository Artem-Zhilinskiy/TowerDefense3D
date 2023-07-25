using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

namespace TowerDefense3D
{
    public class GameOverScript : MonoBehaviour
    {
        [SerializeField]
        private TextMeshProUGUI _roundsText;

        private void OnEnable()
        {
            _roundsText.text = PlayerStats._rounds.ToString();
        }

        public void Retry()
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }

        public void Menu()
        {
            Debug.Log("Menu");
        }
    }
}