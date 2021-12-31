using UnityEngine;

namespace Serenity.UI
{
	public class ScreenPosition
	{
		public Vector3 FromWorldPos(Vector3 worldPos) {
			Vector3 screenPos = camera.WorldToScreenPoint(worldPos);
			return screenPos;
		}

		public ScreenPosition(Camera camera) {
			this.camera = camera;
		}

		private readonly Camera camera;
	}
}
