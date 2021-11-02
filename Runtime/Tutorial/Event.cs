
namespace Tutorial
{
	public struct Event
	{
		public readonly int type;
		public readonly int arg;

		public Event(int type) {
			this.type = type;
			arg = 0;
		}

		public Event(int type, int arg) {
			this.type = type;
			this.arg = arg;
		}

		public bool Succeed(int type, int arg) => this.type == type && this.arg == arg;
	}
}
