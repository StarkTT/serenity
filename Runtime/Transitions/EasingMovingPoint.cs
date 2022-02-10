using System;
using Serenity.Easings;

namespace Serenity
{
	public class EasingMovingPoint
	{
		public void LaunchForward(Action OnComplete, bool reset = true) {
			mp.LaunchForward(UpdateAction, speed, OnComplete, reset);
		}

		public void LaunchBackward(Action OnComplete, bool reset = true) {
			mp.LaunchBackward(UpdateAction, speed, OnComplete, reset);
		}

		public void Tick(float dt) {
			mp.Tick(dt);
		}

		private void UpdateAction(float t) {
			float v = easing.Ease(t);
			VisitAction(v);
		}

		public EasingMovingPoint(Action<float> VisitAction, float speed, Easing easing) {
			this.VisitAction = VisitAction;
			this.speed = speed;
			this.easing = easing;
			mp = new MovingPoint();
		}

		public EasingMovingPoint(Action<float> VisitAction, TransitionData data) {
			this.VisitAction = VisitAction;
			this.speed = data.Speed;
			this.easing = data.Easing;
			mp = new MovingPoint();
		}

		private readonly MovingPoint mp;
		private readonly float speed;
		private readonly Easing easing;
		private readonly Action<float> VisitAction;
	}
}
