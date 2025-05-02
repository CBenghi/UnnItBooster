using SkiaSharp;
using System.IO;

namespace UnnFunctions.Models
{
	public class ImageFile
	{
		public ImageFile(string fullName) //, Image img)
		{
			Name = fullName;
			using (var stream = File.OpenRead(fullName))
			using (var codec = SKCodec.Create(stream))
			{
				var size = codec.Info;
				W = size.Width;
				H = size.Height;
			}			
		}

		public double Ratio => (double)W / H;
		public int W { get; set; } = 0;
		public int H { get; set; } = 0;
		public string Name { get; set; }
	}
}