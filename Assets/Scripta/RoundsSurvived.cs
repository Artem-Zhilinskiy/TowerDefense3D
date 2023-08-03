using UnityEngine;
using TMPro;
using System.Collections;

namespace TowerDefense3D
{
    public class RoundsSurvived : MonoBehaviour
    {
        [SerializeField]
        private TextMeshProUGUI _roundsText;

        private void OnEnable()
        {
            //_roundsText.text = PlayerStats._rounds.ToString();
            StartCoroutine(AnimateText());
        }

        private IEnumerator AnimateText()
        {
            _roundsText.text = "0";
            int round = 0;

            yield return new WaitForSeconds(0.7f);

            while (round < PlayerStats._rounds)
            {
                round++;
                _roundsText.text = round.ToString();

                yield return new WaitForSeconds(0.05f);
            }
        }
    }
}