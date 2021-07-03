using UnityEngine;

namespace Serenity.Easings
{
	[CreateAssetMenu(fileName = "Curve", menuName = "Serenity/Easing/Curve")]
	public class Curve : Easing
	{
		public override float Ease(float t) {
			return curve.Evaluate(t);
		}

		[SerializeField] private AnimationCurve curve;
	}
}