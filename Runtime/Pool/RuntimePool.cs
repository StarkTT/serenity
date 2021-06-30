using System.Collections.Generic;
using UnityEngine;

namespace Serenity
{
	public class RuntimePool<T> where T : Component
	{
		public int Size { get { return list.Count; } }

		public T Spawn(Vector3 pos, Quaternion rot) {
			T item = Spawn();
			item.transform.SetPositionAndRotation(pos, rot);
			return item;
		}

		public T Spawn() {
			foreach (var item in list) {
				if (!item.gameObject.activeSelf) {
					item.gameObject.SetActive(true);
					return item;
				}
			}
			T newItem = NewItem();
			newItem.gameObject.SetActive(true);
			return newItem;
		}

		private T NewItem() {
			T item = useParent ? Object.Instantiate(prefab, parent) : Object.Instantiate(prefab);
			item.gameObject.SetActive(false);
			list.Add(item);
			return item;
		}

		public RuntimePool(T prefab, int initSize) : this(prefab, initSize, null) { }

		public RuntimePool(T prefab, int initSize, Transform parent) {
			this.prefab = prefab;
			this.parent = parent;
			useParent = parent != null;

			list = new List<T>(initSize);
			for (int i = 0; i < initSize; i++) {
				NewItem();
			}
		}

		private readonly List<T> list;
		private readonly T prefab;
		private readonly Transform parent;
		private readonly bool useParent;
	}
}
