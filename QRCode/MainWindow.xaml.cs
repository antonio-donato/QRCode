using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
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
using System.Windows.Navigation;
using System.Windows.Shapes;
using KeepAutomation.Barcode;
using KeepAutomation.Barcode.Bean;
using Orientation = KeepAutomation.Barcode.Orientation;

namespace QRCode
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            if (textBox.Text == null) return;
            BarCode qrcode = new BarCode();
            qrcode.Symbology = Symbology.QRCode;

            //Select a QR Code supported data mode according to your code:
            //AlphaNumeric: for 0 - 9, upper case letters A - Z, and nine punctuation characters space, $ % * + - . / :
            //Byte data: for (ISO/IEC 8859-1) encoding characters at 8 bits per character
            //Kanji Characters (JIS)
            //Numeric: for digits 0 - 9
            qrcode.QRCodeDataMode = QRCodeDataMode.Auto;

            //Input your QR Code encoding data:
            qrcode.CodeToEncode = textBox.Text;

            // Unit of measure, pixel, cm and inch supported.
            qrcode.BarcodeUnit = BarcodeUnit.Pixel;
            // QR Code image resolution in dpi
            qrcode.DPI = 72;
            // QR Code bar module width (X dimention)
            qrcode.X = 3;
            // QR Code bar module height (Y dimention), Y=X
            qrcode.Y = 3;

            // QR Code image left margin size, the minimum value is 4X.
            qrcode.LeftMargin = 12;
            // Image right margin size, minimum value is 4X.
            qrcode.RightMargin = 12;
            // Image top margin size, minimum value is 4X.
            qrcode.TopMargin = 12;
            // Image bottom margin size, minimum value is 4X.
            qrcode.BottomMargin = 12;

            // QR Code orientation, 90, 180, 270 degrees supported.
            qrcode.Orientation = Orientation.Degree0;

            // QR Code barcode version, valid from V1-V40
            qrcode.QRCodeVersion = QRCodeVersion.V5;

            // QR Code barcode Error Correction Lever, supporting H, L, M, Q.
            qrcode.QRCodeECL = QRCodeECL.H;

            // QR Code image formats, supporting Png, Jpeg, Gif, Tiff, Bmp, etc.
            qrcode.ImageFormat = ImageFormat.Png;

            // Generate QR Code barcodes in image format GIF
            qrcode.generateBarcodeToImageFile("D://barcode-qrcode-csharp.png");

            //Bitmap myBitmap = new Bitmap("D://barcode-qrcode-csharp.png");
            //var g = Graphics.FromImage(myBitmap);

            //qrcode.generateBarcodeToGraphics(g);


            /* Create QR Code barcodes in Stream object
            qrcode.generateBarcodeToStream(".NET System.IO.Stream Object");

            Draw & Print QR Code barcodes to Graphics object
            qrcode.generateBarcodeToGraphics(".NET System.Drawing.Graphics Object");

            Generate QR Code barcodes & write to byte[]
            byte[] barcodeInBytes = qrcode.generateBarcodeToByteArray();

            Generate QR Code barcodes & encode to System.Drawing.Bitmap object
            Bitmap barcodeInBitmap = qrcode.generateBarcodeToBitmap();
            */
        }
    }
}
