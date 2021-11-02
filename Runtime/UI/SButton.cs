using UnityEngine;
using UnityEngine.Events;

namespace Serenity.UI
{
	public abstract class SButton : MonoBehaviour
	{
		public abstract string Text { get; set; }
		public abstract bool Interactable { get; set; }

		public abstract void AddListener(UnityAction listener);
		public abstract void RemoveListener(UnityAction listener);
	}
}
