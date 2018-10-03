using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace plaintext.infrastructure
{
    interface IHotkeyService
    {
        bool Register();
        void Unregister();
        Key Key { get; }
        bool SuccessfullyRegistered { get; }
        int Id { get; set; }


    }
}
