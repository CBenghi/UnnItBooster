﻿using StudentMarking;
using System;
using System.Windows.Forms;

namespace StudentsFetcher
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
			Application.Run(new frmMenu());
		}
	}
}
