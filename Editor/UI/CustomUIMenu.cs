using UnityEditor;
using UnityEngine;

namespace Serenity.Editor.UI
{
	public static class CustomUIMenu
	{
		[MenuItem("GameObject/Serenity UI/Button", false)]
		private static void CreateButton() {
			var template = AssetDatabase.LoadAssetAtPath<GameObject>("Packages/com.serenity.common/Editor/UI/Templates/Button.prefab");//"Assets/Packages/com.serenity.common/Editor/UI/Templates/Button.prefab");
			var go = PrefabUtility.InstantiatePrefab(template) as GameObject;
			if (Selection.activeGameObject != null) {
				go.transform.SetParent(Selection.activeGameObject.transform);
			}
			Undo.RegisterCreatedObjectUndo(go, "Create UI Button");
		}
	}
}
