using UnityEngine;
using UnityEngine.UI;

namespace TowerDefense3D
{
    public class LivesUI : MonoBehaviour
    {
        [SerializeField]
        private Text _livesText;

        private void Update()
        {
            _livesText.text = PlayerStats._lives.ToString() + " lives";
        }
    }
}