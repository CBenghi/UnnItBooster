using System.Drawing;

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
}