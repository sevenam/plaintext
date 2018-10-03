using NUnit.Framework;
using System.Windows.Input;
using Shouldly;
using System.Threading;
using plaintext.infrastructure;

namespace plaintext.tests
{
    [TestFixture]
    public class HotkeyServiceTests
    {
        private Key key;
        private ModifierKeys modifierKeys;
        private bool eventExecuted;

        [SetUp]
        public void SetUp()
        {
            key = Key.Escape;
            modifierKeys = ModifierKeys.Windows;
        }

        [Test]
        public void TestHotKeyServiceInit()
        {
            HotkeyService.Register(key, modifierKeys, HotkeyEvent, "hotkeyEvent");
        }

        [Test, Apartment(ApartmentState.STA)]
        public void TestHotkeyServiceExecuteKeyPress()
        {
            //todo: this test isn't working. doesn't seem to respond to the simulated key press
            //var hotkeyService = new HotkeyService();
            //hotkeyService.Register(key, modifierKeys, HotkeyEvent, "hotkeyEvent");
            //HotkeyManager.Current.AddOrReplace("shiftescape", Key.Escape, ModifierKeys.Windows, HotkeyEvent);
            //var inputSimulator = new InputSimulator();

            //eventExecuted.ShouldBeFalse();
            //inputSimulator.Keyboard.ModifiedKeyStroke(WindowsInput.Native.VirtualKeyCode.RWIN, WindowsInput.Native.VirtualKeyCode.ESCAPE);
            //eventExecuted.ShouldBeTrue();

        }


        private void HotkeyEvent(object sender, HotkeyServiceEventArgs e)
        {
            eventExecuted = true;
        }

    }
}
