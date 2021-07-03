using UnityEngine;

namespace Serenity.Easings
{
	[CreateAssetMenu(fileName = "Quadratic", menuName = "Serenity/Easing/Quadratic")]
	public class Quadratic : Easing
	{
		public override float Ease(float t) {
			if (type == Type.In) {
				return t * t;
			}
			else if (type == Type.Out) {
				return t * (2f - t);
			}
			else if (type == Type.InOut) {
				t *= 2f;
				if (t < 1f) {
					return 0.5f * t * t;
				}
				else {
					t -= 1f;
					return -0.5f * (t * (t - 2f) - 1f);
				}
			}
			return t;
		}

		private enum Type { In, Out, InOut }

		[SerializeField] private Type type;
	}
}
