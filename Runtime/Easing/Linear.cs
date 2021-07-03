using UnityEngine;

namespace Serenity.Easings
{
	[CreateAssetMenu(fileName = "Linear", menuName = "Serenity/Easing/Linear")]
	public class Linear : Easing
	{
		public override float Ease(float t) {
			return t;
		}
	}
}