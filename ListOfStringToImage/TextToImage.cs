using System;
using System.Drawing;
using System.Drawing.Imaging;

namespace ListOfStringToImage
{
    public class TextToImage
    {
        private readonly TextToImageConfiguration _configuration;
        /// <summary>
        /// Sets custom configuration for the generation of images.
        /// </summary>
        /// <param name="configuration">Custom configuration</param>
        public TextToImage(TextToImageConfiguration configuration)
        {
            _configuration = configuration;
        }
        /// <summary>
        /// Creates TextToImage with default configuration
        /// </summary>
        public TextToImage()
        {
            _configuration = new TextToImageConfiguration();
            _configuration.Font = new Font("Calibri", 12.0f, FontStyle.Bold);
            _configuration.TextColor = Color.Black;
            _configuration.BackColor = Color.White;
            _configuration.Height = 64;
            _configuration.Width = 78;
        }
        public Image DrawAndSave(string text, string fileName, bool centerAlign = true)
        {
            Image image = new Bitmap(1, 1);
            Graphics drawing = Graphics.FromImage(image);
            image.Dispose();
            drawing.Dispose();
            image = new Bitmap(_configuration.Width, _configuration.Height);
            drawing = Graphics.FromImage(image);
            drawing.Clear(_configuration.BackColor);
            Brush textBrush = new SolidBrush(_configuration.TextColor);

            StringFormat stringFormat = new StringFormat()
            {
                Alignment = StringAlignment.Center,
                LineAlignment = StringAlignment.Center
            };
            if (centerAlign)
            {
                SizeF s = drawing.MeasureString(text, _configuration.Font);
                float fontScale = Math.Max(s.Width / _configuration.Width , s.Height / _configuration.Height );
                _configuration.Font = new Font(_configuration.Font.FontFamily, _configuration.Font.SizeInPoints / fontScale, GraphicsUnit.Point);
            }

            drawing.DrawString(text.Replace(' ', '\n'), _configuration.Font, textBrush, _configuration.Width / 2, _configuration.Height / 2, stringFormat);

            drawing.Save();
            image.Save(fileName, ImageFormat.Jpeg);
            textBrush.Dispose();
            drawing.Dispose();
            return image;
        }
    }
}
