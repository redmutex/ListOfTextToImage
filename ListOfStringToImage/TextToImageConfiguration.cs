using System;
using System.Drawing;

namespace ListOfStringToImage
{
    public class TextToImageConfiguration
    {
        public int Width { get; set; }
        public int Height { get; set; }
        public Color TextColor { get; set; }
        public Color BackColor { get; set; }
        public Font Font { get; set; }
    }
}
