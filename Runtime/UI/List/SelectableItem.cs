using UnityEngine.EventSystems;

namespace Serenity.UI
{
	public class SelectableItem : ListItem, IPointerDownHandler, IPointerUpHandler
	{
		protected override void OnInited() {
		}

		void IPointerDownHandler.OnPointerDown(PointerEventData eventData) { }

		void IPointerUpHandler.OnPointerUp(PointerEventData eventData) {
			if (Interactable && !eventData.dragging) {
				FireInteractionEvent();
			}
		}
	}
}
