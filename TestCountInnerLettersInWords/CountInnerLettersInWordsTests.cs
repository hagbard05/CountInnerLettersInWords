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
		private TestContext testContextInstance;

		/// <summary>
		/// Provides information about and functionality for the current test run.
		/// </summary>
		public TestContext TestContext { get { return testContextInstance; } set { testContextInstance = value; } }

		[TestMethod]
		[Description("Tests the ConvertToLetterCount(string) Method of the CountInnerLetters class in the assembly CountInnerLettersInWords.exe passing in a test string and verifying the returned string is as expected")]
		[DataRow("", "")]
		[DataRow("It was many and many a year ago", "I0t w1s m2y a1d m2y a y2r a1o")]
		[DataRow("Copyright,Microsoft:Corporation", "C7t,M6t:C6n")]
		[DataRow("It.was.many.and.many.a.year.ago", "I0t.w1s.m2y.a1d.m2y.a.y2r.a1o")]
		[DataRow("It--was--many--and--many--a--year--ago", "I0t--w1s--m2y--a1d--m2y--a--y2r--a1o")]
		[DataRow("It!was@many#and$many%a^year~ago", "I0t!w1s@m2y#a1d$m2y%a^y2r~a1o")]
		[DataRow("It!..<>was@@many#and$many%a^year~ago...", "I0t!..<>w1s@@m2y#a1d$m2y%a^y2r~a1o...")]
		[DataRow("Coooppyyright,Micccrosssoft:Coorppppooorrraaatttiion", "C7t,M6t:C6n")]
		[DataRow("in_a_kingdom_by_the_sea_", "i0n_a_k5m_b0y_t1e_s1a_")]
		[DataRow("...!@#", "...!@#")]
		[DataRow("418 I'm a teapot", "418 I'm a t4t")]
		[DataRow("I'm left-handed", "I'm l2t-h4d")]
		[DataRow("pneumonoultramicroscopicsilicovolcanoconiosis", "p14s")]
		[DataRow("Lopez-Garcia Smith-Kline", "L3z-G4a S3h-K3e")]
		[DataRow("high-grade four-dimensional mother-in-law ultra-violet", "h2h-g3e f2r-d7l m4r-i0n-l1w u3a-v4t")]
		[DataRow(@"Floccinaucinihilipilification?Antidisestablishmentarianism*()?|Supercalifragilisticexpialidocious", @"F11n?A12m*()?|S15s")]
		[DataRow("I am fun good happy joyjoy", "I a0m f1n g1d h2y j3y")]
		[DataRow("a ab abc abcd abcde abcdef", "a a0b a1c a2d a3e a4f")]
		[DataRow("It💠was💠many💠and💠many💠a💠year💠ago", "I0t💠w1s💠m2y💠a1d💠m2y💠a💠y2r💠a1o")] 
		[DataRow("ߌߍߐߋ💠ߎߓߋߔߐ--", "ߌ2ߋ💠ߎ3ߐ--")]
		[DataRow("ΓΣΤΥΦΧΨΩ⇿⇾ΠΟΘΘΞ⇨", "Γ6Ω⇿⇾Π2Ξ⇨")]
		[DataRow("⇨⇾⇨⇿ΓΣΤΥΦΧΨΩ⇾ΠΟΘΘΞ⇨", "⇨⇾⇨⇿Γ6Ω⇾Π2Ξ⇨")]
		[DataRow("ΚΡΙΣΙΜΟΙ ΑΡΙΘΜΟΙ ΚΑΙ ΕΡΓΑΛΕΙΑ FIBONACCI", "Κ5Ι Α5Ι Κ1Ι Ε6Α F6I")]
		public void TestLettersInWordsDirect(string input, string expectedOutput)
		{
			CountInnerLetters CountInner = new CountInnerLetters();
			string output = CountInner.ConvertToLetterCount(input);
#if DEBUG
			TestContext.WriteLine($"Comparing returned for string:\n\"{input}\"");
			if (String.Equals(expectedOutput, output))
				TestContext.WriteLine($" Returned string:\n\"{output}\"\n" +
					$" Matches expected:\n\"{expectedOutput}\"");
#endif
			Assert.AreEqual(expectedOutput, output, $"\nReturned string for passed in string:\n\"{input}\"\ndoes not match expected:\n" +
					$"Returned:\t\"{output}\"\n" +
					$"Expected:\t\"{expectedOutput}\"");
		}

		[TestMethod]
		[Description("Tests the CountInnerLettersInWords.exe passing in a test string as a command line paramater and verifying the output is as expected")]
		[DataRow("", "")]
		[DataRow("It was many and many a year ago", "I0t w1s m2y a1d m2y a y2r a1o")]
		[DataRow("Copyright,Microsoft:Corporation", "C7t,M6t:C6n")]
		[DataRow("It.was.many.and.many.a.year.ago", "I0t.w1s.m2y.a1d.m2y.a.y2r.a1o")]
		[DataRow("It--was--many--and--many--a--year--ago", "I0t--w1s--m2y--a1d--m2y--a--y2r--a1o")]
		[DataRow("It!was@many#and$many%a^year~ago", "I0t!w1s@m2y#a1d$m2y%a^y2r~a1o")]
		[DataRow("It!..<>was@@many#and$many%a^year~ago...", "I0t!..<>w1s@@m2y#a1d$m2y%a^y2r~a1o...")]
		[DataRow("Coooppyyright,Micccrosssoft:Coorppppooorrraaatttiion", "C7t,M6t:C6n")]
		[DataRow("in_a_kingdom_by_the_sea_", "i0n_a_k5m_b0y_t1e_s1a_")]
		[DataRow("...!@#", "...!@#")]
		[DataRow("418 I'm a teapot", "418 I'm a t4t")]
		[DataRow("I'm left-handed", "I'm l2t-h4d")]
		[DataRow("pneumonoultramicroscopicsilicovolcanoconiosis", "p14s")]
		[DataRow("Lopez-Garcia Smith-Kline", "L3z-G4a S3h-K3e")]
		[DataRow("high-grade four-dimensional mother-in-law ultra-violet", "h2h-g3e f2r-d7l m4r-i0n-l1w u3a-v4t")]
		[DataRow(@"Floccinaucinihilipilification?Antidisestablishmentarianism*()?|Supercalifragilisticexpialidocious", @"F11n?A12m*()?|S15s")]
		[DataRow("I am fun good happy joyjoy", "I a0m f1n g1d h2y j3y")]
		[DataRow("a ab abc abcd abcde abcdef", "a a0b a1c a2d a3e a4f")]
		[DeploymentItem("CountInnerLettersInWords.exe")]
		public void TestLettersInWords(string input, string expectedOutput)
		{
			using (Process process = new Process())
			{
				process.StartInfo.FileName = "CountInnerLettersInWords.exe";
				process.StartInfo.Arguments = "\"" + input + "\"";
				process.StartInfo.UseShellExecute = false;
				process.StartInfo.RedirectStandardOutput = true;
				process.Start();

				// Synchronously read the standard output of the spawned process.
				StreamReader reader = process.StandardOutput;
				string output = reader.ReadToEnd();
#if DEBUG
				TestContext.WriteLine($"Comparing output for string:\n\"{input}\"");
				if (String.Equals(expectedOutput, output))
					TestContext.WriteLine($" Output string:\n\"{output}\"\n" +
						$" Matches expected output:\n\"{expectedOutput}\"");
#endif
				Assert.AreEqual(expectedOutput, output, $"\nOutput string for input string:\n\"{input}\"\ndoes not match expected:\n" +
						$"Returned:\t\"{output}\"\n" +
						$"Expected:\t\"{expectedOutput}\"");
				process.WaitForExit();
			} // End of using statement handles cleanup for process object
		}
	}
}
