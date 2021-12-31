using System;
using System.Collections.Generic;
using UnityEngine;

namespace Serenity.UI
{
	public class ListOfItems : MonoBehaviour
	{
		public int Count => list.Count;

		public event Action<ListItem> InteractedWithItem;

		public List<ListItem> Items() {
			return list;
		}

		public ListItem AddItem(int id) {
			ListItem item = Instantiate(template, template.transform.parent);
			item.Init(id, list.Count);
			item.Interacted += OnInteracted;
			item.gameObject.SetActive(true);
			list.Add(item);
			return item;
		}

		public void HideTemplate() {
			template.gameObject.SetActive(false);
		}

		public ListItem ItemWithId(int id) {
			foreach (var item in list) {
				if (item.Id == id) {
					return item;
				}
			}
			return null;
		}

		public ListItem ItemWithIndex(int index) {
			return list[index];
		}

		public void Clear() {
			foreach (var item in list) {
				Destroy(item.gameObject);
			}
			list.Clear();
		}

		private void OnInteracted(ListItem item) => InteractedWithItem?.Invoke(item);


		[SerializeField] private ListItem template;

		private List<ListItem> list = new List<ListItem>();
	}
}
