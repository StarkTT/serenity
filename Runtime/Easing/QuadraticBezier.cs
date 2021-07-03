using UnityEngine;

namespace Serenity.Easings
{
	[CreateAssetMenu(fileName = "QuadraticBezier", menuName = "Serenity/Easing/QuadraticBezier")]
	public class QuadraticBezier : Easing
	{
		public override float Ease(float t) {
			return coeff * 2f * t * (1f - t) + t * t;
		}

		[SerializeField] private float coeff;
	}
}
