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
using plaintext.infrastructure;

namespace plaintext.ui
{
	/// <summary>
	/// Interaction logic for MainWindow.xaml
	/// </summary>
	public partial class MainWindow : Window
	{
        private InputSimulator inputSimulator = new InputSimulator();
        private ClipboardService clipboardService;
        private HotkeyService hotkeyService = new HotkeyService();
        private Action action;

		public MainWindow()
		{
            InitializeComponent();
            Hide();
            var modifierKeys = new ModifierKeys[] { ModifierKeys.Windows};
            action = () => { OnPaste(); };
            var guid = hotkeyService.Register(modifierKeys, Key.Escape, action);
            
            //try
            //{
                
            //}
            //catch
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

        private void OnPaste()
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
