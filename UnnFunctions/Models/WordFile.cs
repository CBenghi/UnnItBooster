using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.IO.Compression;
using System.Linq;

namespace UnnFunctions.Models
{
	public class ImageFile
	{
		public ImageFile(string fullName, Image img)
		{
			Name = fullName;
			W = img.Width;
			H = img.Height;
		}

		public double Ratio => (double)W / H;
		public int W { get; set; } = 0;
		public int H { get; set; } = 0;
		public string Name { get; set; }
	}

	public class WordFile
	{
		private FileInfo file;
		public WordFile(FileInfo f) 
		{
			file = f;
		}

		public bool Exists
		{
			get { 
				if (!file.Exists)
					return false;
				return file.Extension.ToLower() == ".docx";
			}
		}

		public IEnumerable<ImageFile> GetImages()
		{
			using ZipArchive archive = ZipFile.OpenRead(file.FullName);
			foreach (ZipArchiveEntry entry in archive.Entries)
			{
				if (!IsImageName(entry.FullName))
					continue;
				var tempName = Path.Combine(
						Path.GetTempPath(),
						$"{Guid.NewGuid()}{Path.GetExtension(entry.Name)}"
						);
				entry.ExtractToFile(tempName);
				using (var img = Image.FromFile(tempName))
				{
					var t = new ImageFile(entry.FullName, img);
					yield return t;
				}
				File.Delete(tempName);
			}
		}

		internal IEnumerable<string> WriteTempImages(IEnumerable<ImageFile> fnd)
		{
			using ZipArchive archive = ZipFile.OpenRead(file.FullName);
			var names = fnd.Select(x => x.Name);
			foreach (ZipArchiveEntry entry in archive.Entries)
			{
				if (!names.Contains(entry.FullName))
					continue;
				var tempName = Path.Combine(
						Path.GetTempPath(),
						$"{Guid.NewGuid()}{Path.GetExtension(entry.Name)}"
						);
				entry.ExtractToFile(tempName);
				yield return tempName;
			}
		}

		private bool IsImageName(string fullName)
		{
			var ext = Path.GetExtension(fullName).ToLowerInvariant();
			switch (ext)
			{
				case ".gif":
				case ".png":
				case ".bmp":
				case ".jpg":
				case ".jpeg":
					return true;
				default:
					break;
			}
			return false;

		}
	}
}
