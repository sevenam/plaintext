//using NHotkey;
//using NHotkey.Wpf;
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
//using WindowsInput;
using plaintext.infrastructure;

namespace plaintext.ui
{
	/// <summary>
	/// Interaction logic for MainWindow.xaml
	/// </summary>
	public partial class MainWindow : Window
	{
		//private InputSimulator inputSimulator;
		private ClipboardService clipboardService;

		public MainWindow()
		{
            InitializeComponent();
            Hide();

            //HotkeyService.Register(Key.Escape, ModifierKeys.Windows, OnPaste, "win-escape");
            //try
            //{
            //    HotkeyManager.Current.AddOrReplace("win-escape", Key.L, ModifierKeys.Windows, OnPaste); //todo: can this be made into a service? see code line above
            //}
            //catch(NHotkey.HotkeyAlreadyRegisteredException)
            //{
            //    MessageBox.Show("Failed to register hotkey. Must be changed in config.");
            //}
            

            //inputSimulator = new InputSimulator();
			clipboardService = new ClipboardService();

            //TODO: need error if fails to register:
			//if (!pasteHotkey.SuccessfullyRegistered)
			//{
			//	MessageBox.Show("Failed to register hotkey. Must be changed in config.");
			//}

		}

		//private void OnPaste(object sender, HotkeyEventArgs eventArgs)
		//{
		//	clipboardService = new ClipboardService();
		//	var originalText = clipboardService.GetText(true);
		//	var text = clipboardService.GetText();

		//	Debug.WriteLine($"Trying to paste: {text}");
  //          //clipboardService.SetText(text);

  //          inputSimulator.Keyboard.ModifiedKeyStroke(WindowsInput.Native.VirtualKeyCode.SHIFT, WindowsInput.Native.VirtualKeyCode.INSERT);

		//	clipboardService.SetText(originalText, formatted: true);
		//}

    }
}
