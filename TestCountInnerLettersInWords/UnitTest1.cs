using Microsoft.VisualStudio.TestTools.UnitTesting;
using CountInnerLettersInWords;
using System;
using System.Diagnostics;
using System.IO;

namespace TestCountInnerLettersInWords
{
	[TestClass]
	public class CountInnerLettersInWordsTests
	{
		private static CountInnerLetters CountInner;
		private TestContext testContextInstance;

		/// <summary>
		///Gets or sets the test context which provides
		///information about and functionality for the current test run.
		///</summary>
		public TestContext TestContext
		{
			get { return testContextInstance; }
			set { testContextInstance = value; }
		}

		[ClassInitialize()]
		public static void ClassInit(TestContext context)
		{
			CountInner = new CountInnerLetters();
		}

		[ClassCleanup()]
		public static void ClassTeardown()
		{

		}

		[TestMethod]
		[DataRow("It was many and many a year ago", "I0t w1s m2y a1d m2y a y2r a1o")]
		[DataRow("It.was.many.and.many.a.year.ago", "I0t.w1s.m2y.a1d.m2y.a.y2r.a1o")]
		[DataRow("It--was--many--and--many--a--year--ago", "I0t--w1s--m2y--a1d--m2y--a--y2r--a1o")]
		[DataRow("Copyright,Microsoft:Corporation", "C7t,M6t:C6n")]
		[DataRow("Coooppyyright,Micccrosssoft:Coorppppooorrraaatttiion", "C7t,M6t:C6n")]
		[DataRow("It!was@many#and$many%a^year~ago", "I0t!w1s@m2y#a1d$m2y%a^y2r~a1o")]
		[DataRow("It!..<>was@@many#and$many%a^year~ago...", "I0t!..<>w1s@@m2y#a1d$m2y%a^y2r~a1o...")]
		[DataRow("", "")]
		[DataRow("...!@#", "...!@#")]
		//[DataRow("It💠was💠many💠and💠many💠a💠year💠ago", "I0t💠w1s💠m2y💠a1d💠m2y💠a💠y2r💠a1o")] // Does not currently handle unicode
		[DeploymentItem("CountInnerLettersInWords.exe")]
		public void TestLettersInWords(string input, string expectedOutput)
		{
			string exe = "CountInnerLettersInWords.exe";
			using (Process process = new Process())
			{
				process.StartInfo.FileName = exe;
				process.StartInfo.Arguments = "\"" + input + "\"";
				process.StartInfo.UseShellExecute = false;
				process.StartInfo.RedirectStandardOutput = true;
				process.Start();

				// Synchronously read the standard output of the spawned process.
				StreamReader reader = process.StandardOutput;
				string output = reader.ReadToEnd();

				if (String.Equals(expectedOutput, output) == false)
					Assert.Fail($"{output} did not match {expectedOutput}");

				process.WaitForExit();
			}
		}
	}
}
