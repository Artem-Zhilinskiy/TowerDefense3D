using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine;

namespace TowerDefense3D
{
    public class SceneFader : MonoBehaviour
    {
        [SerializeField]
        private Image _image;
        [SerializeField]
        private AnimationCurve _curve;

        private void Start()
        {
            StartCoroutine(FadeIn());
        }

        public void FadeTo(string scene)
        {
            StartCoroutine(FadeOut(scene));
        }

        private IEnumerator FadeIn()
        {
            float t = 1f;

            while (t > 0)
            {
                t -= Time.deltaTime;
                float a = _curve.Evaluate(t);
                _image.color = new Color(0f, 0f, 0f, a);
                yield return 0;
            }
        }

        private IEnumerator FadeOut(string scene)
        {
            float t = 0f;

            while (t < 1f)
            {
                t += Time.deltaTime;
                float a = _curve.Evaluate(t);
                _image.color = new Color(0f, 0f, 0f, a);
                yield return 0;
            }

            SceneManager.LoadScene(scene);
        }
    }
}