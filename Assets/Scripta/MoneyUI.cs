using UnityEngine;
using UnityEngine.UI;

namespace TowerDefense3D
{

    public class MoneyUI : MonoBehaviour
    {

        [SerializeField]
        private Text _moneyText;

        private void Update()
        {
            _moneyText.text ="$" + PlayerStats._money.ToString();
        }

    }
}