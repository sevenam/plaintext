using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using NHotkey.Wpf;
using NHotkey;

namespace plaintext.infrastructure
{
    public static class HotkeyService
    {
        //public static void Register(Key key, ModifierKeys modifierKeys, EventHandler<NHotkey.HotkeyEventArgs> eventHandler, string name)
        public static void Register(Key key, ModifierKeys modifierKeys, EventHandler<HotkeyServiceEventArgs> eventHandler, string name)
        {
            HotkeyManager.Current.AddOrReplace(name, key, modifierKeys | ModifierKeys.Alt, (HotkeyEventArgs)eventHandler);
        }
    }
}
