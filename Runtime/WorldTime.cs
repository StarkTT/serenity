using System;
using System.Collections;
using System.Globalization;
using UnityEngine;
using UnityEngine.Networking;

namespace Serenity
{
	public class WorldTime : MonoBehaviour
	{
		public bool Loaded => timeLoaded;

		public DateTime CurrentDateTime() {
			return currentDateTime.AddSeconds(Time.realtimeSinceStartup);
		}

		public static WorldTime Instance {
			get {
				if (instance == null) {
					GameObject gameObject = new GameObject("WorldTime");
					instance = gameObject.AddComponent<WorldTime>();
					DontDestroyOnLoad(gameObject);
				}
				return instance;
			}
		}

		private void Awake() {
			if (instance == null) {
				instance = this;
				DontDestroyOnLoad(gameObject);
			}
			else if (instance != this) {
				Destroy(gameObject);
			}
		}

		private void Start() {
			StartCoroutine(GetRealDateTime());
		}

		private IEnumerator GetRealDateTime() {
			Debug.Log("getting real datetime...");
			int tryCount = 0;
			while (!timeLoaded) {
				UnityWebRequest webRequest = UnityWebRequest.Get(API_URL);
				yield return webRequest.SendWebRequest();

				if (webRequest.result == UnityWebRequest.Result.ConnectionError || webRequest.result == UnityWebRequest.Result.ProtocolError) {
					Debug.Log("Error: " + webRequest.error);
				}
				else {
					string date = webRequest.GetResponseHeader("date");
					currentDateTime = DateTime.ParseExact(date, "ddd, dd MMM yyyy HH:mm:ss 'GMT'", CultureInfo.InvariantCulture.DateTimeFormat, DateTimeStyles.AssumeUniversal);
					Debug.Log(currentDateTime);
					timeLoaded = true;
				}

				tryCount++;
				double delay = Math.Pow(2, Math.Min(6, tryCount));
				yield return new WaitForSecondsRealtime((float)delay);
			}
		}


		private bool timeLoaded;
		private DateTime currentDateTime = DateTime.Now;

		private static WorldTime instance;

		private const string API_URL = "http://www.google.com";
	}
}