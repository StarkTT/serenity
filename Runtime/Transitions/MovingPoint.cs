using System;

namespace Serenity
{
	public class MovingPoint
	{
		public bool Moving => dir != 0;
		public int Dir => dir;
		public float T => t;

		public void LaunchForward(Action<float> VisitAction, float speed, Action OnComplete, bool reset = true) {
			this.VisitAction = VisitAction;
			this.speed = speed;
			this.OnComplete = OnComplete;
			dir = forwardDir;

			if (reset) {
				t = min;
			}
			VisitAction(t);
		}

		public void LaunchBackward(Action<float> VisitAction, float speed, Action OnComplete, bool reset = false) {
			this.VisitAction = VisitAction;
			this.speed = speed;
			this.OnComplete = OnComplete;
			dir = backwardDir;

			if (reset) {
				t = max;
			}
			VisitAction(t);
		}

		public void Tick(float dt) {
			if (dir == 0)
				return;

			t += speed * dt * dir;

			bool end = false;
			if (dir == forwardDir && t >= max) {
				t = max;
				end = true;
			}
			else if (dir == backwardDir && t <= min) {
				t = min;
				end = true;
			}

			VisitAction(t);
			if (end) {
				dir = 0;
				OnComplete?.Invoke();
				OnComplete = null;
			}
		}

		public MovingPoint() {
			min = 0f;
			max = 1f;
		}

		public MovingPoint(float min, float max) {
			this.min = min;
			this.max = max;
		}

		private readonly float min;
		private readonly float max;

		private float t;
		private float speed;
		private int dir;
		private Action<float> VisitAction;
		private Action OnComplete;

		private const int forwardDir = 1;
		private const int backwardDir = -1;
	}
}