using System;
using Serenity.Easings;
using UnityEngine;

namespace Serenity
{
	public class Transition : MonoBehaviour
	{
		public bool Finished => up == 0;

		public void Play(Action OnComplete) {
			this.OnComplete = OnComplete;
			t = 0;
			Interpolate(t);
			up = 1;
		}

		public void PlayReverse(Action OnComplete) {
			this.OnComplete = OnComplete;
			if (t < 0.001f) {
				t = 1f;
			}
			Interpolate(t);
			up = -1;
		}

		private void Update() {
			if (up == 0) {
				return;
			}

			t += Speed * Time.unscaledDeltaTime;

			bool end = false;
			if (up == 1 && t >= 1f) {
				t = 1f;
				end = true;
			}
			else if (up == -1 && t <= 0f) {
				t = 0f;
				end = true;
			}

			float v = (up == 1) ? easingFwd.Ease(t) : easingRev.Ease(t);
			Interpolate(v);

			if (end) {
				up = 0;
				OnComplete?.Invoke();
				OnComplete = null;
			}
		}

		private void Interpolate(float t) {
			foreach (var interpolation in interpolations) {
				if (interpolation != null) {
					interpolation.Interpolate(t);
				}
			}
		}

		private float Speed {
			get {
				float s = up == 1 ? speed : revSpeed;
				return s * up;
			}
		}


		[SerializeField] private Interpolation[] interpolations;
		[SerializeField] private Easing easingFwd;
		[SerializeField] private Easing easingRev;
		[SerializeField] private float speed = 1f;
		[SerializeField] private float revSpeed = 1f;

		private Action OnComplete;
		private float t;
		private int up;
	}
}
