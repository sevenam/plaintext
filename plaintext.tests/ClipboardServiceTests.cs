using System.Threading;
using NUnit.Framework;
using plaintext.services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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

        [Test]
        [Apartment(ApartmentState.STA)]
        public void TestClipboardServiceGetText()
        {
            TestClipboardServiceSetText();
            var text = clipboardService.GetText();
            text.ShouldBe(testText);
        }

        [Test]
        [Apartment(ApartmentState.STA)]
        public void TestClipboardServiceSetText()
        {
            clipboardService.SetText(testText);
        }
    }
}
