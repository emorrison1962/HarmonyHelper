using System;
using System.Windows.Forms;

namespace NeckDiagrams
{
	static class Program
	{
		/// <summary>
		/// The main entry point for the application.
		/// </summary>
		[STAThread]
		static void Main()
		{
			Application.EnableVisualStyles();
			Application.SetCompatibleTextRenderingDefault(false);
			Bootstrap();
			Application.Run(new Form1());
		}

		private static void Bootstrap()
		{

		}
	}
}
