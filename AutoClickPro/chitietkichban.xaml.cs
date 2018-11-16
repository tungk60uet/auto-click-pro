using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Drawing;
using System.IO;
using System.Runtime.InteropServices;

namespace AutoClickPro
{
    /// <summary>
    /// Interaction logic for chitietkichban.xaml
    /// </summary>
    public partial class chitietkichban : Window
    {
        int selectX;
        int selectY;
        int selectWidth;
        int selectHeight;
        public Pen selectPen;
        bool start = false;
        public chitietkichban(string tenkichban)
        {
            InitializeComponent();
            this.Hide();
            Take();
            this.Show();

        }
        static BitmapImage LoadImage(byte[] imageData)
        {
            if (imageData == null || imageData.Length == 0) return null;
            var image = new BitmapImage();
            using (var mem = new MemoryStream(imageData))
            {
                mem.Position = 0;
                image.BeginInit();
                image.CreateOptions = BitmapCreateOptions.PreservePixelFormat;
                image.CacheOption = BitmapCacheOption.OnLoad;
                image.UriSource = null;
                image.StreamSource = mem;
                image.EndInit();
            }
            image.Freeze();
            return image;
        }
        public static byte[] Take()
        {
            int screenWidth = Convert.ToInt32(SystemParameters.VirtualScreenWidth);
            int screenHeight = Convert.ToInt32(SystemParameters.VirtualScreenHeight);
            int screenLeft = Convert.ToInt32(SystemParameters.VirtualScreenLeft);
            int screenTop = Convert.ToInt32(SystemParameters.VirtualScreenTop);

            RenderTargetBitmap renderTarget = new RenderTargetBitmap(screenWidth, screenHeight, 96, 96, PixelFormats.Pbgra32);
            VisualBrush sourceBrush = new VisualBrush();

            DrawingVisual drawingVisual = new DrawingVisual();
            DrawingContext drawingContext = drawingVisual.RenderOpen();

            using (drawingContext)
            {
                drawingContext.PushTransform(new ScaleTransform(1, 1));
                drawingContext.DrawRectangle(sourceBrush, null, new Rect(new Point(0, 0), new Point(screenWidth, screenHeight)));
            }
            renderTarget.Render(drawingVisual);

            PngBitmapEncoder pngEncoder = new PngBitmapEncoder();
            pngEncoder.Frames.Add(BitmapFrame.Create(renderTarget));

            Byte[] _imageArray;

            using (MemoryStream outputStream = new MemoryStream())
            {
                pngEncoder.Save(outputStream);
                _imageArray = outputStream.ToArray();
            }

            using (FileStream stream = new FileStream(@"D:\test.png", FileMode.Create, FileAccess.ReadWrite))
            {
                using (BinaryWriter writer = new BinaryWriter(stream))
                {
                    writer.Write(_imageArray);
                }
            }

            return _imageArray;
        }

        private void Grid_MouseMove(object sender, MouseEventArgs e)
        {

        }

        private void picturebox_MouseMove(object sender, MouseEventArgs e)
        {

        }

        private void picturebox_MouseDown(object sender, MouseButtonEventArgs e)
        {

        }

        private void picturebox_MouseUp(object sender, MouseButtonEventArgs e)
        {

        }
    }
}
