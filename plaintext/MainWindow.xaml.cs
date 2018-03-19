using plaintext.services;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace plaintext
{
	/// <summary>
	/// Interaction logic for MainWindow.xaml
	/// </summary>
	public partial class MainWindow : Window
	{
		public MainWindow()
		{
			InitializeComponent();
			Hide();
			var hotkey = new HotkeyService(Key.Escape, KeyModifier.Shift, OnHotKeyHandler);
		}

		private void OnHotKeyHandler(HotkeyService hotKey)
		{
			var clipboardService = new ClipboardService();
			var text = clipboardService.GetText();
			Debug.WriteLine($"clipboard data:" + text);

		}

	}
}
