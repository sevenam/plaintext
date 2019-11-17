using NonInvasiveKeyboardHookLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;


namespace plaintext.infrastructure
{
    public class HotkeyService : IHotkeyService
    {
        private KeyboardHookManager keyboardHookManager;
        //public KeyboardHookManager Instance => keyboardHookManager ?? (keyboardHookManager = new KeyboardHookManager());

        public HotkeyService()
        {
            keyboardHookManager = new KeyboardHookManager();
            keyboardHookManager.Start();
        }

        public Guid Register(System.Windows.Input.ModifierKeys[] modifiers, Key virtualKeyCode, Action action)
        {
            var modifierKeys = TranslateModifierKeys(modifiers);
            //var guid = Instance.RegisterHotkey(modifierKeys, (int) virtualKeyCode, action);
            
            var guid = keyboardHookManager.RegisterHotkey(modifierKeys, 0x13, action);
            return guid;
        }

        public void UnregisterAll()
        {
            try
            {
                keyboardHookManager.UnregisterAll();
            }
            catch(Exception ex) { }
        }

        private NonInvasiveKeyboardHookLibrary.ModifierKeys[] TranslateModifierKeys(System.Windows.Input.ModifierKeys[] modifiers)
        {
            var translatedKeys = new NonInvasiveKeyboardHookLibrary.ModifierKeys[modifiers.Length];

            for(var i = 0; i < modifiers.Length; i++)
            {
                switch(modifiers[i])
                {
                    case System.Windows.Input.ModifierKeys.Alt:
                        translatedKeys[i] = NonInvasiveKeyboardHookLibrary.ModifierKeys.Alt;
                        break;
                    case System.Windows.Input.ModifierKeys.Control:
                        translatedKeys[i] = NonInvasiveKeyboardHookLibrary.ModifierKeys.Control;
                        break;
                    case System.Windows.Input.ModifierKeys.Shift:
                        translatedKeys[i] = NonInvasiveKeyboardHookLibrary.ModifierKeys.Shift;
                        break;
                    case System.Windows.Input.ModifierKeys.Windows:
                        translatedKeys[i] = NonInvasiveKeyboardHookLibrary.ModifierKeys.WindowsKey;
                        break;
                }
            }

            return translatedKeys;
        }

    }
}
