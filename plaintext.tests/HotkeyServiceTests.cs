using NUnit.Framework;
using plaintext.services;
using System.Windows.Input;
using Shouldly;
using WindowsInput;

namespace plaintext.tests
{
    [TestFixture]
    public class HotkeyServiceTests
    {
        private Key key;
        private KeyModifier keyModifier;
        private bool eventExecuted;

        [SetUp]
        public void SetUp()
        {
            key = Key.Escape;
            keyModifier = KeyModifier.Win;
        }

        [Test]
        public void TestHotKeyServiceInit()
        {
            var hotkeyService = new HotkeyService(key, keyModifier, HotkeyEvent, true);
            hotkeyService.Key.ShouldBe(key);
            hotkeyService.KeyModifiers.ShouldBe(keyModifier);
            hotkeyService.SuccessfullyRegistered.ShouldBeTrue();
            hotkeyService.Dispose();
        }

        [Test]
        public void TestHotkeyServiceDispose()
        {
            var hotkeyService = new HotkeyService(key, keyModifier, HotkeyEvent, true);
            hotkeyService.SuccessfullyRegistered.ShouldBeTrue();

            hotkeyService.Dispose();
            hotkeyService.SuccessfullyRegistered.ShouldBeFalse();
        }

        [Test]
        public void TestHotkeyServiceExecuteKeyPress()
        {
            //todo: this test isn't working
            var hotkeyService = new HotkeyService(key, keyModifier, HotkeyEvent, true);
            hotkeyService.SuccessfullyRegistered.ShouldBeTrue();
            var inputSimulator = new InputSimulator();

            eventExecuted.ShouldBeFalse();
            inputSimulator.Keyboard.ModifiedKeyStroke(WindowsInput.Native.VirtualKeyCode.LWIN, WindowsInput.Native.VirtualKeyCode.ESCAPE);
            eventExecuted.ShouldBeTrue();

            hotkeyService.Dispose();
        }

        private void HotkeyEvent(HotkeyService hotKey)
        {
            eventExecuted = true;
        }

    }
}
