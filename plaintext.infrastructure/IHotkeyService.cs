using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace plaintext.infrastructure
{
    public interface IHotkeyService
    {
        Guid Register(ModifierKeys[] modifiers, Key virtualKeyCode, Action action);
        //void Unregister();
        //Key Key { get; }
        //bool SuccessfullyRegistered { get; }
        //int Id { get; set; }
        void UnregisterAll();

    }
}
