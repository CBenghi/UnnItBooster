using StudentsFetcher.StudentMarking;
using System;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace StudentsFetcher
{
	static class Program
	{
		/// <summary>
		/// The main entry point for the application.
		/// </summary>
		[STAThread]
		static void Main(string[] args)
		{
			Application.EnableVisualStyles();
			Application.SetCompatibleTextRenderingDefault(false);

			if (args.Length > 1 && args[0] == "-mm" && File.Exists(args[1]))
			{
				FrmMarkingMachine machine  = new FrmMarkingMachine();
				machine.SetSqlFile(args[1]);
				if (args.Contains("-max"))
					machine.WindowState = FormWindowState.Maximized;
				Application.Run(machine);
			}
			else
				Application.Run(new frmMenu());
		
		}
	}
}
