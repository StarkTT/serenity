using UnityEngine;

namespace Serenity
{
	public class CanvasGroupAlpha : Interpolation
	{
		public override void Interpolate(float t) {
			canvasGroup.alpha = from + (to - from) * t;
		}

		private void OnValidate() {
			if (canvasGroup == null) {
				canvasGroup = GetComponent<CanvasGroup>();
			}
		}


		[SerializeField] private CanvasGroup canvasGroup;
		[SerializeField] private float from = 0f;
		[SerializeField] private float to = 1f;
	}
}