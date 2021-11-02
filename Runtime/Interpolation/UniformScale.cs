using UnityEngine;

namespace Serenity
{
	public class UniformScale : Interpolation
	{
		public override void Interpolate(float t) {
			target.localScale = Vector3.one * (from + (to - from) * t);
		}

		private void OnValidate() {
			if (target == null) {
				target = transform;
			}
		}

		[SerializeField] private Transform target;
		[SerializeField] private float from;
		[SerializeField] private float to;
	}
}
