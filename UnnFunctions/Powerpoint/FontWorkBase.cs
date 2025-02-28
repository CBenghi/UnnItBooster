using System.IO;
using System.IO.Compression;

namespace UnnFunctions.Powerpoint
{
	public class FontWorkBase
	{
		private string file;

		public FontWorkBase(string file)
		{
			this.file = file;
		}

		protected ZipArchive pptx()
		{
			return ZipFile.Open(file, ZipArchiveMode.Update);
		}
	}
}