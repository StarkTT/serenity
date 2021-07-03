using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace Serenity.UI
{
	public class UnityButton : SButton
	{
		public override string Text {
			get => text.text;
			set => text.text = value;
		}

		public override bool Interactable {
			get => button.interactable;
			set => button.interactable = value;
		}

		public override void Listen(UnityAction listener) {
			button.onClick.AddListener(listener);
		}

		public override void Forget(UnityAction listener) {
			button.onClick.RemoveListener(listener);
		}

		private void OnValidate() {
			if (button == null) {
				button = GetComponentInChildren<Button>();
			}
			if (text == null) {
				text = GetComponentInChildren<Text>();
			}
		}

		[SerializeField] private Button button;
		[SerializeField] private Text text;
	}
}
