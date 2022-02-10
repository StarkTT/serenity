using Serenity.Easings;
using UnityEngine;

namespace Serenity
{
	[CreateAssetMenu(fileName = "Transition Data", menuName = "Serenity/Transition Data")]
	public class TransitionData : ScriptableObject
	{
		public float Ease(float t) => easing.Ease(t);
		public float Speed => speed;
		public Easing Easing => easing;

		[SerializeField] private Easing easing;
		[SerializeField] private float speed = 1f;
	}
}
