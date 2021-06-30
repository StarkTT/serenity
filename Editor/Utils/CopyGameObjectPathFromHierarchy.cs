using UnityEditor;
using UnityEngine;

namespace Serenity.Editor
{
	public static class CopyGameObjectPathFromHierarchy
	{
		[MenuItem("GameObject/Copy Path", false)]
		private static void CopyPath() {
			GameObject active = Selection.activeGameObject;

			if (active == null) {
				return;
			}

			string path = active.name;

			while (active.transform.parent != null) {
				active = active.transform.parent.gameObject;

				path = $"{active.name}/{path}";
			}

			Debug.Log(path);
			EditorGUIUtility.systemCopyBuffer = path;
		}

		[MenuItem("GameObject/Copy Path", true)]
		private static bool CopyPathValidation() {
			return Selection.gameObjects.Length == 1;
		}
	}
}
