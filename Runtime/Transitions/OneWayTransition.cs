using System;
using Serenity.Easings;
using UnityEngine;

namespace Serenity
{
	public class OneWayTransition : MonoBehaviour
	{
		public bool Playing => inTransition;

		public void Play(Action OnComplete) {
			this.OnComplete = OnComplete;
			inTransition = true;
			t = 0f;
			interpolation.Interpolate(t);
		}

		private void Update() {
			if (!inTransition)
				return;

			t += speed * Time.deltaTime;

			if (t >= 1f) {
				t = 1f;
				inTransition = false;
			}

			float v = easing.Ease(t);
			interpolation.Interpolate(t);

			if (!inTransition) {
				OnComplete?.Invoke();
				OnComplete = null;
			}
		}

		[SerializeField] private Interpolation interpolation;
		[SerializeField] private Easing easing;
		[SerializeField] private float speed = 1f;

		private Action OnComplete;
		private bool inTransition;
		private float t;
	}
}
