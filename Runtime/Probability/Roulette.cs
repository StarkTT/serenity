using System.Linq;
using UnityEngine;

namespace Serenity.Probability
{
	public class Roulette
	{
		public int Roll(float[] chances) {
			float sum = chances.Sum();
			float roll = Random.Range(0f, sum);

			int opt = 0;
			float slider = chances[0];
			for (int i = 1; i < chances.Length; i++) {
				if (roll > slider) {
					slider += chances[i];
					opt++;
				}
			}
			return opt;
		}

		public int Roll(double[] chances, int start, int end) {
			double sum = 0;
			for (int i = start; i < end; i++) {
				sum += chances[i];
			}

			double roll = Random.Range(0f, (float)sum);

			int opt = 0;
			double slider = chances[start];
			for (int i = start + 1; i < end; i++) {
				if (roll > slider) {
					slider += chances[i];
					opt++;
				}
			}
			return opt;
		}
	}
}
