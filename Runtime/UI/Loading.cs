using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace Serenity.UI
{
	public class Loading : MonoBehaviour
	{
		public void Load(int sceneIndex) {
			StartCoroutine(LoadAsync(sceneIndex));
		}

		public void Load(string sceneName) {
			var scene = SceneManager.GetSceneByName(sceneName);
			StartCoroutine(LoadAsync(scene.buildIndex));
		}

		private IEnumerator LoadAsync(int sceneIndex) {
			DontDestroyOnLoad(gameObject);

			UpdateProgress(0f);
			yield return null;

			AsyncOperation operation = SceneManager.LoadSceneAsync(sceneIndex);
			while (!operation.isDone) {
				UpdateProgress(operation.progress);
				yield return null;
			}
			UpdateProgress(1f);

			if (canvasGroup != null) {
				float t = 1f;
				while (t > 0) {
					canvasGroup.alpha = Mathf.Max(t, 0f);
					t -= Time.deltaTime * fadeSpeed;

					if (t > 0) {
						yield return null;
					}
				}
			}
			else {
				yield return new WaitForSeconds(0.2f);
			}

			Destroy(gameObject);
			Resources.UnloadUnusedAssets();
			yield return new WaitForEndOfFrame();
		}

		private void UpdateProgress(float progress) {
			if (filler != null)
				filler.fillAmount = progress;

			if (text != null)
				text.text = Mathf.RoundToInt(progress * 100f) + "%";
		}


		[SerializeField] private Image filler;
		[SerializeField] private Text text;
		[SerializeField] private CanvasGroup canvasGroup;
		[SerializeField] private float fadeSpeed = 2f;
	}
}
