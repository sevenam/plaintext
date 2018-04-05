using System.Threading;
using NUnit.Framework;
using plaintext.services;
using Shouldly;

namespace plaintext.tests
{
    [TestFixture]
    public class ClipboardServiceTests
    {
        private const string testText = "The test text";
        private ClipboardService clipboardService;

        [SetUp]
        public void SetUp()
        {
            clipboardService = new ClipboardService();
        }

        [Test, Apartment(ApartmentState.STA)]
        public void TestClipboardServiceSetText()
        {
            clipboardService.SetText(testText);
        }

        [Test, Apartment(ApartmentState.STA)]
        public void TestClipboardServiceGetText()
        {
            TestClipboardServiceSetText();
            var text = clipboardService.GetText();
            text.ShouldBe(testText);
        }

        [Test, Apartment(ApartmentState.STA)]
        public void TestClipboardServiceSetTextRichFormat()
        {
            string rtf = @"{\\rtf\\ansi{\\fonttbl{\\f0 Consolas;}}{\\colortbl;\\red172\\green137\\blue192;\\red49\\green51\\blue53;}\\f0 \\fs19 \\cf1 \\cb2 \\highlight2 public}";
            clipboardService.SetText(rtf, formatted: true);
        }

        [Test, Apartment(ApartmentState.STA)]
        public void TestClipboardServiceGetTextRichFormat()
        {
            TestClipboardServiceSetTextRichFormat();
            var rtfText = clipboardService.GetText(formatted: true);
        }

    }
}
