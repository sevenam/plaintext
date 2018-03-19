using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace plaintext
{
	public class ClipboardService
	{
		public ClipboardService()
		{

		}

		public string GetText()
		{
			return Clipboard.GetText();
		}

	}
}
