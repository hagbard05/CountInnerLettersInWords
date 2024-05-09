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
		[DataRow("in_a_kingdom_by_the_sea_", "i0n_a_k5m_b0y_t1e_s1a_")]
		[DataRow("...!@#", "...!@#")]
		[DataRow("418 I'm a teapot", "418 I'm a t4t")]
		[DataRow("I'm left-handed", "I'm l2t-h4d")]
		[DataRow("pneumonoultramicroscopicsilicovolcanoconiosis", "p14s")]
		[DataRow("Lopez-Garcia Smith-Kline", "L3z-G4a S3h-K3e")]
		[DataRow("high-grade four-dimensional mother-in-law ultra-violet", "h2h-g3e f2r-d7l m4r-i0n-l1w u3a-v4t")]
		[DataRow(@"Floccinaucinihilipilification?Antidisestablishmentarianism*()?|Supercalifragilisticexpialidocious", @"F11n?A12m*()?|S15s")]
		[DataRow("It💠was💠many💠and💠many💠a💠year💠ago", "I0t💠w1s💠m2y💠a1d💠m2y💠a💠y2r💠a1o")] 
		[DataRow("ߌߍߐߋ💠ߎߓߋߔߐ--", "ߌ2ߋ💠ߎ3ߐ--")]
		[DataRow("ΓΣΤΥΦΧΨΩ⇿⇾ΠΟΘΘΞ⇨", "Γ6Ω⇿⇾Π2Ξ⇨")]
		[DataRow("⇨⇾⇨⇿ΓΣΤΥΦΧΨΩ⇾ΠΟΘΘΞ⇨", "⇨⇾⇨⇿Γ6Ω⇾Π2Ξ⇨")]
		[DataRow("ΚΡΙΣΙΜΟΙ ΑΡΙΘΜΟΙ ΚΑΙ ΕΡΓΑΛΕΙΑ FIBONACCI", "Κ5Ι Α5Ι Κ1Ι Ε6Α F6I")]
		public void TestLettersInWordsDirect(string input, string expectedOutput)
		{
			string output = CountInner.ConvertToLetterCount(input);
			TestContext.WriteLine($"Comparing output for string:\n" +
				$"\"{input}\"");
			if (String.Equals(expectedOutput, output))
				TestContext.WriteLine($" Output string:\n" +
					$"\"{output}\"" +
					$"\n Matches expected output:\n" +
					$"\"{expectedOutput}\"");
			if (!String.Equals(expectedOutput, output))
				Assert.Fail($"\n" +
					$" Output string:\n" +
					$"\"{output}\"\n" +
					$" Does not match expected output:\n" +
					$"\"{expectedOutput}\"");
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
		[DataRow("in_a_kingdom_by_the_sea_", "i0n_a_k5m_b0y_t1e_s1a_")]
		[DataRow("...!@#", "...!@#")]
		[DataRow("418 I'm a teapot", "418 I'm a t4t")]
		[DataRow("I'm left-handed", "I'm l2t-h4d")]
		[DataRow("pneumonoultramicroscopicsilicovolcanoconiosis", "p14s")]
		[DataRow("Lopez-Garcia Smith-Kline", "L3z-G4a S3h-K3e")]
		[DataRow("high-grade four-dimensional mother-in-law ultra-violet", "h2h-g3e f2r-d7l m4r-i0n-l1w u3a-v4t")]
		[DataRow(@"Floccinaucinihilipilification?Antidisestablishmentarianism*()?|Supercalifragilisticexpialidocious", @"F11n?A12m*()?|S15s")]
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
				
				TestContext.WriteLine($"Comparing output for string:\n" +
					$"\"{input}\"");
				if (String.Equals(expectedOutput, output))
					TestContext.WriteLine($" Output string:\n" +
						$"\"{output}\"" +
						$"\n Matches expected output:\n" +
						$"\"{expectedOutput}\"");
				if (!String.Equals(expectedOutput, output))
					Assert.Fail($"\n" +
						$" Output string:\n" +
						$"\"{output}\"\n" +
						$" Does not match expected output:\n" +
						$"\"{expectedOutput}\"");

				process.WaitForExit();
			}
		}
	}
}
