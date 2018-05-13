using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using NHotkey.Wpf;

namespace plaintext.services
{
    public static class HotkeyService
    {
        public static void Register(Key key, ModifierKeys modifierKeys, EventHandler<NHotkey.HotkeyEventArgs> eventHandler, string name)
        {
            HotkeyManager.Current.AddOrReplace(name, key, modifierKeys | ModifierKeys.Alt, eventHandler);
        }
    }
}
