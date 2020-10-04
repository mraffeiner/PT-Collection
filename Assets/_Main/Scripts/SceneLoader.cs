using System;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace PTCollection
{
    public class SceneLoader : MonoBehaviour
    {
        public event Action BeforeSceneUnload;
        public event Action AfterSceneLoad;

        [SerializeField] private CanvasGroup faderCanvasGroup = null;
        [SerializeField] private float fadeDuration = 1f;
        [SerializeField] private string startingSceneName = "Main";

        private bool isFading;

        public void ReloadCurrentScene() => FadeAndLoadScene(SceneManager.GetActiveScene().name);

        private IEnumerator Start()
        {
            faderCanvasGroup.alpha = 1f;

            yield return StartCoroutine(LoadSceneAndSetActive(startingSceneName));

            StartCoroutine(Fade(0f));
        }

        public void FadeAndLoadScene(string sceneName)
        {
            if (!isFading)
                StartCoroutine(FadeAndSwitchScenes(sceneName));
        }

        private IEnumerator FadeAndSwitchScenes(string sceneName)
        {
            if (GameSpeed.Factor != 1f)
                GameSpeed.Factor = 1f;

            yield return StartCoroutine(Fade(1f));

            if (BeforeSceneUnload != null)
                BeforeSceneUnload();

            yield return SceneManager.UnloadSceneAsync(SceneManager.GetActiveScene().buildIndex);

            yield return StartCoroutine(LoadSceneAndSetActive(sceneName));

            if (AfterSceneLoad != null)
                AfterSceneLoad();

            yield return StartCoroutine(Fade(0f));
        }


        private IEnumerator LoadSceneAndSetActive(string sceneName)
        {
            yield return SceneManager.LoadSceneAsync(sceneName, LoadSceneMode.Additive);

            SceneManager.SetActiveScene(SceneManager.GetSceneAt(SceneManager.sceneCount - 1));
        }


        private IEnumerator Fade(float finalAlpha)
        {
            isFading = true;
            faderCanvasGroup.blocksRaycasts = true;

            float fadeSpeed = Mathf.Abs(faderCanvasGroup.alpha - finalAlpha) / fadeDuration;
            while (!Mathf.Approximately(faderCanvasGroup.alpha, finalAlpha))
            {
                faderCanvasGroup.alpha = Mathf.MoveTowards(faderCanvasGroup.alpha, finalAlpha, fadeSpeed * Time.deltaTime);

                yield return null;
            }

            faderCanvasGroup.blocksRaycasts = false;
            isFading = false;
        }

        public void Exit() => Application.Quit();
    }
}
