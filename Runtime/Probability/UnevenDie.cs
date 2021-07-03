﻿using System.Linq;
using UnityEngine;

namespace Serenity.Probability
{
	public class UnevenDie : Die
	{
		public int Roll() {
			float sum = chances.Sum();
			float roll = Random.Range(0f, sum);

			int side = 0;
			float slider = chances[0];
			for (int i = 1; i < chances.Length; i++) {
				if (roll > slider) {
					slider += chances[i];
					side++;
				}
			}
			return side;
		}

		public UnevenDie(float[] chances) {
			this.chances = chances;
		}

		private readonly float[] chances;
	}
}
