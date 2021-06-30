using UnityEngine;

namespace Serenity.Probability
{
	public class UniformDie : Die
	{
		public int Roll() {
			return Random.Range(0, sides);
		}

		public UniformDie(int sides) {
			this.sides = sides;
		}

		private readonly int sides;
	}
}
