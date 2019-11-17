using NUnit.Framework;
using System.Windows.Input;
using Shouldly;
using System.Threading;
using plaintext.infrastructure;
using System;
using System.Diagnostics;
using WindowsInput;

namespace plaintext.tests
{
    [TestFixture]
    public class HotkeyServiceTests
    {
        private IHotkeyService hotkeyService;
        private Key key;
        private readonly ModifierKeys[] modifierKeys = new ModifierKeys[1];

        [SetUp]
        public void SetUp()
        {
            key = Key.Escape;
            modifierKeys[0] = ModifierKeys.Windows;
            hotkeyService = new HotkeyService();
        }

        [Test]
        public void TestHotKeyServiceInit()
        {
            hotkeyService.Register(modifierKeys,key, HotkeyEvent);
        }

        [Test]
        public void TestHotKeyServiceUnregisterAll()
        {
            hotkeyService.UnregisterAll();
        }

        [Test, Apartment(ApartmentState.STA)]
        public void TestHotkeyServiceExecuteKeyPress()
        {
            hotkeyService.UnregisterAll();
            //todo: this test isn't working. doesn't seem to respond to the simulated key press
            var guid = hotkeyService.Register(modifierKeys, key, HotkeyEvent);
            var inputSimulator = new InputSimulator();
            inputSimulator.Keyboard.ModifiedKeyStroke(WindowsInput.Native.VirtualKeyCode.LWIN, WindowsInput.Native.VirtualKeyCode.ESCAPE);
            Console.WriteLine("guid -->" + guid);
        }


        private readonly Action HotkeyEvent = delegate() { Process.Start("CMD.exe"); };

    }
}
