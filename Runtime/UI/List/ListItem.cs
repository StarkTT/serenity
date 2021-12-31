using System;
using UnityEngine;

namespace Serenity.UI
{
	public abstract class ListItem : MonoBehaviour
	{
		public bool Interactable { get; set; }
		public RectTransform RectTransform => rectTransform;

		public int Id => id;
		public int Index => index;

		public event Action<ListItem> Interacted;

		public void Init(int id, int index) {
			this.id = id;
			this.index = index;
			rectTransform = GetComponent<RectTransform>();
			OnInited();
		}

		protected abstract void OnInited();

		protected void FireInteractionEvent() => Interacted?.Invoke(this);

		private int id;
		private int index;
		private RectTransform rectTransform;
	}
}
