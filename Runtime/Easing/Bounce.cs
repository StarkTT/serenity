using System.Collections.Generic;
using UnityEngine;

namespace Serenity.Easings
{
	public class Bounce : Easing
	{
		public override float Ease(float t) {
			return t;
		}
	}
}
