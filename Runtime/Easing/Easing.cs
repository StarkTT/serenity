using UnityEngine;

namespace Serenity.Easings
{
	public abstract class Easing : ScriptableObject
	{
		public abstract float Ease(float t);
	}
}