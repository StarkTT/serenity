using System.Collections.Generic;
using UnityEngine;

namespace Serenity.UI
{
	public class TransitionalWindow : MonoBehaviour
	{
		public void Open() {
			Interactable = false;
			transition.Play(OnOpened);
			gameObject.SetActive(true);
		}

		public void Close() {
			Interactable = false;
			transition.PlayReverse(OnClosed);
		}

		private void OnOpened() {
			Interactable = true;
		}

		private void OnClosed() {
			gameObject.SetActive(false);
		}

		protected bool Interactable {
			set => canvasGroup.interactable = value;
		}

		[SerializeField] protected CanvasGroup canvasGroup;
		[SerializeField] private Transition transition;
	}
}
