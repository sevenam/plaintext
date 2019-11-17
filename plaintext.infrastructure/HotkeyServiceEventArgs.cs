using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace plaintext.infrastructure
{
    //todo: fix event args...not sure what's up with the constructor
    public class HotkeyServiceEventArgs /*: HotkeyEventArgs, IEquatable<HotkeyServiceEventArgs>*/
    {
        public string Name { get; }
        public bool Handled { get; set; }

        public bool Equals(HotkeyServiceEventArgs other)
        {
            return Equals(other);
        }

        //public static explicit operator HotkeyEventArgs(HotkeyServiceEventArgs hotkeyServiceEventArgs)
        //{
        //    //Name property is read only and constructor is complaining about 0 arguments
        //    //also... can't set hotkeyEventArgs.Name as it is readonly

        //    HotkeyEventArgs hotkeyEventArgs;
        //    hotkeyEventArgs.Name = hotkeyServiceEventArgs.Name;

        //    return hotkeyEventArgs;
        //}
    }
}
