using Microsoft.Extensions.Logging;
using NPOI.POIFS.FileSystem;
using NPOI.SS.Formula.Functions;
using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using System.IO.Hashing;
using System.Linq;
using System.Text;

namespace UnnFunctions.Powerpoint
{
	public class MediaWork : FontWorkBase
	{
		public static MediaWork? FromFile(string file)
		{
			if (!File.Exists(file))
				return null;
			var work = new MediaWork(file);
			return work;
		}

		public MediaWork(string file) : base(file)
		{

		}

		public void ReplaceMedia(FileInfo toRemove, FileInfo ToUseInstead, ILogger? logger = null)
		{
			var fullName = FindMedia(toRemove, logger);
			if (string.IsNullOrEmpty(fullName))
				return;
			using var p = pptx();
			var entry = p.GetEntry(fullName);
			entry.Delete();
			p.CreateEntryFromFile(ToUseInstead.FullName, fullName);
			logger?.LogInformation("file {fn} replaced", fullName);
		}

		private string? FindMedia(FileInfo toRemove, ILogger? logger)
		{
			var crc = new Crc32();
			using (var str = toRemove.OpenRead())
			{
				crc.Append(str);
			}
			var hsh = crc.GetCurrentHashAsUInt32();
			string? fn = null;
			using (var p = pptx())
			{
				foreach (var entry in p.Entries.Where(x => x.FullName.Contains("ppt/media")).ToList())
				{
					var zipHash = new Crc32();
					using (var zStr = entry.Open())
					{
						zipHash.Append(zStr);
					}
					if (zipHash.GetCurrentHashAsUInt32() != hsh)
						continue;
					fn = entry.FullName;
					logger?.LogInformation("Found file @ {fn}", fn);
				}
			}
			return fn;
		}
	}
}
