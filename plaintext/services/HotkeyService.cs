using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Windows.Input;
using System.Windows.Interop;

namespace plaintext.services
{
	public class HotkeyService : IDisposable
	{
		[DllImport("user32.dll")]
		private static extern bool RegisterHotKey(IntPtr hWnd, int id, UInt32 fsModifiers, UInt32 vlc);
		[DllImport("user32.dll")]
		private static extern bool UnregisterHotKey(IntPtr hWnd, int id);

		private static Dictionary<int, HotkeyService> dictHotKeyToCalBackProc;
		public const int WmHotKey = 0x0312;
		private bool disposed;

		public Key Key { get; private set; }
		public KeyModifier KeyModifiers { get; private set; }
		public Action<HotkeyService> Action { get; private set; }
		public bool SuccessfullyRegistered { get; private set; }
		public int Id { get; set; }

		public HotkeyService(Key key, KeyModifier keyModifiers, Action<HotkeyService> action, bool register = true)
		{
			Key = key;
			KeyModifiers = keyModifiers;
			Action = action;
			if (register)
			{
				SuccessfullyRegistered = Register();
			}
		}

		public bool Register()
		{
			int virtualKeyCode = KeyInterop.VirtualKeyFromKey(Key);
			Id = virtualKeyCode + ((int)KeyModifiers * 0x10000);
			bool result = RegisterHotKey(IntPtr.Zero, Id, (UInt32)KeyModifiers, (UInt32)virtualKeyCode);

			if (dictHotKeyToCalBackProc == null)
			{
				dictHotKeyToCalBackProc = new Dictionary<int, HotkeyService>();
				ComponentDispatcher.ThreadFilterMessage += ComponentDispatcherThreadFilterMessage;
			}
			dictHotKeyToCalBackProc.Add(Id, this);

			return result;
		}

		public void Unregister()
		{
			if (dictHotKeyToCalBackProc.TryGetValue(Id, out HotkeyService hotKey))
			{
				UnregisterHotKey(IntPtr.Zero, Id);
			}
		}

		private static void ComponentDispatcherThreadFilterMessage(ref MSG msg, ref bool handled)
		{
			if (!handled)
			{
				if (msg.message == WmHotKey)
				{
					if (dictHotKeyToCalBackProc.TryGetValue((int)msg.wParam, out HotkeyService hotKey))
					{
						if (hotKey.Action != null)
						{
							hotKey.Action.Invoke(hotKey);
						}
						handled = true;
					}
				}
			}
		}

		public void Dispose()
		{
			Dispose(true);
			GC.SuppressFinalize(this);
		}

		protected virtual void Dispose(bool disposing)
		{
			if (!disposed)
			{
				if (disposing)
				{
					Unregister();
				}

				disposed = true;
			}
		}
	}
}