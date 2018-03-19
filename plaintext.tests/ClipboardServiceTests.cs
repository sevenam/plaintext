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
		private ClipboardService clipboardService;

		[SetUp]
		public void SetUp()
		{
			clipboardService = new ClipboardService();
		}

		[Test]
		public void TestClipboardServiceGetText()
		{
			//var text = clipboardService.GetText();
		}
	}
}
