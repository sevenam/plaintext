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
        private InputSimulator inputSimulator;
        private ClipboardService clipboardService;

		public MainWindow()
		{
			InitializeComponent();
			Hide();

            var pasteHotkey = new HotkeyService(Key.Escape, KeyModifier.Win, OnPaste);
            inputSimulator = new InputSimulator();
            clipboardService = new ClipboardService();

            if (!pasteHotkey.SuccessfullyRegistered)
            {
                MessageBox.Show("Failed to register hotkey. Must be changed in config.");
            }

		}

        private void OnPaste(HotkeyService hotKey)
        {
            clipboardService = new ClipboardService();
            var originalText = clipboardService.GetText(true);
            var text = clipboardService.GetText();
            
            Debug.WriteLine($"Trying to paste: {text}");
            //clipboardService.SetText(text);

            inputSimulator.Keyboard.ModifiedKeyStroke(WindowsInput.Native.VirtualKeyCode.SHIFT, WindowsInput.Native.VirtualKeyCode.INSERT);

            clipboardService.SetText(originalText, formatted: true);
        }

	}
}
