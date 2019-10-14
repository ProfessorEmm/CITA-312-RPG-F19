using System.Collections;
using UnityEngine;

namespace RPG.SceneManagement
{
    public class Fader : MonoBehaviour
    {
        CanvasGroup canvasGroup;

        private void Start()
        {
            canvasGroup = GetComponent<CanvasGroup>();
            // for testing purposes
            StartCoroutine(FadeOutIn());
        }

        IEnumerator FadeOutIn()
        {
            yield return FadeOut(3f);
            yield return FadeIn(1f);
        }
        public IEnumerator FadeIn(float time)
        {
            while (canvasGroup.alpha > 0) 
            {
                // moving alpha towards 0
                canvasGroup.alpha -= Time.deltaTime / time;
                yield return null;
            }
        } // FadeIn
        public IEnumerator FadeOut(float time)
        {
            while (canvasGroup.alpha < 1) 
            {
                // moving alpha towards 1
                canvasGroup.alpha += Time.deltaTime / time;
                yield return null;
            }
        } // FadeOut
    } // class Fader
}
