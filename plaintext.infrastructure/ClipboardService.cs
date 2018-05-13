using System.Windows;

namespace plaintext.infrastructure
{
	public class ClipboardService
	{
		public ClipboardService()
		{

		}

		public string GetText(bool formatted = false)
		{
			var text = string.Empty;

			if(formatted)
			{
				text = Clipboard.GetText(TextDataFormat.Rtf);
			}
			else
			{
				text = Clipboard.GetText();
			}

			return text;
		}

		public void SetText(string text, bool formatted = false)
		{
			if (formatted)
			{
				text = FormatText(text);
				Clipboard.SetText(text, TextDataFormat.Rtf);
			}
			else
			{
				Clipboard.SetText(text);
			}
		}

		private string FormatText(string text)
		{
			return text.Replace("\\\\", "\\");
		}

	}
}
