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
				if (t < 0.5f) {
					return 2f * t * t;
				}
				else {
					t = -2f * t + 2f;
					return 1f - t * t * 0.5f;
				}
			}
			return t;
		}

		private enum Type { In, Out, InOut }

		[SerializeField] private Type type;
	}
}
