using UnityEngine;

namespace Serenity
{
	public class Interpolations : Interpolation
	{
		public override void Interpolate(float t) {
			foreach (var interpolation in interpolations) {
				if (interpolation != null) {
					interpolation.Interpolate(t);
				}
			}
		}

		[SerializeField] private Interpolation[] interpolations;
	}
}
