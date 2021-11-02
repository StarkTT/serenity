using System;

namespace Tutorial
{
	public interface DialogContent
	{
		string Value { get; }
	}

	public class LocString : DialogContent
	{
		public string Value {
			get => locKey;
		}

		public LocString(string locKey) {
			this.locKey = locKey;
		}

		string locKey;
	}

	public class FormattedLocString : DialogContent
	{
		public string Value {
			get => locKey + Param();
		}

		public FormattedLocString(string locKey, Func<string> Param) {
			this.locKey = locKey;
			this.Param = Param;
		}

		string locKey;
		Func<string> Param;
	}

}
