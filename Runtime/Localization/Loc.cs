using System.Collections.Generic;
using UnityEngine;

public class Loc
{
	public static string Text(string id) {
		if (string.IsNullOrEmpty(id)) {
			Debug.Log("Empty id");
			return id;
		}
		string str;
		if (dict.TryGetValue(id, out str)) {
			return str;
		}
		else {
			Debug.LogWarning("Wrong text key: " + id);
			return id;
		}
	}

	public static string FormattedText(string id, params object[] args) {
		if (string.IsNullOrEmpty(id)) {
			Debug.Log("Empty id");
			return id;
		}
		return string.Format(Text(id), args);
	}

	public static bool ContainsKey(string key) {
		return dict.ContainsKey(key);
	}

	public static void Init(LocDictionary data) {
		if (loaded) { return; }
		dict = data.Dictionary();
		loaded = true;
	}

	public static void Unload() {
		dict = null;
		loaded = false;
	}


	private static bool loaded = false;
	private static Dictionary<string, string> dict;
}