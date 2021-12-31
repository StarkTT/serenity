using UnityEngine;
using UnityEngine.UI;

namespace Serenity.UI
{
	public class ButtonItem : ListItem
	{
		protected override void OnInited() {
			button.onClick.AddListener(FireInteractionEvent);
		}

		[SerializeField] private Button button;
	}
}
