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
using WindowsInput;

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
			var hotkey = new HotkeyService(Key.Escape, KeyModifier.Win, OnHotKeyHandler); //todo: would like this to use Win+V - but not working on mac at least
		}

		private void OnHotKeyHandler(HotkeyService hotKey)
		{
			var clipboardService = new ClipboardService();
			var text = clipboardService.GetText();
            clipboardService.SetText(text);
			Debug.WriteLine($"clipboard data:" + text);
            var test = new InputSimulator();
            test.Keyboard.ModifiedKeyStroke(WindowsInput.Native.VirtualKeyCode.SHIFT, WindowsInput.Native.VirtualKeyCode.INSERT);

        }

	}
}
