using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Accord.Imaging;
using Accord.Imaging.Filters;
using Accord.Math;
using AForge;

namespace LogoRec.Playground
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            this.Load+=OnLoad;
        }

        private string folder = @"D:\dev\C#\LogoRec\Frames\2015-03-01\frames\TVPSPORT_2015-03-01_23-47-46.jpeg";
        private  string firstFileName = @"TVPSPORT_2015-03-01_23-47-46.jpeg";


        private Bitmap img1 = new Bitmap(Image.FromFile(@"D:\dev\C#\LogoRec\Frames\2015-03-01\frames\TVPSPORT_2015-03-01_23-47-46.jpeg"));

        private Bitmap img2 = new Bitmap(Image.FromFile(@"duzelogo.png"));
        private SpeededUpRobustFeaturePoint[] surfPoints1;
        private SpeededUpRobustFeaturePoint[] surfPoints2;


        private IntPoint[] correlationPoints1;
        private IntPoint[] correlationPoints2; 

        private void OnLoad(object sender, EventArgs eventArgs)
        {
            pictureBox1.Image = img1;
            pictureBox2.Image = img2;
            surf();
            
           knn();
        }

        private void knn()
        {
            
            KNearestNeighborMatching matcher = new KNearestNeighborMatching(5);
            IntPoint[][] matches = matcher.Match(surfPoints1, surfPoints2);

            // Get the two sets of points
            correlationPoints1 = matches[0];
            correlationPoints2 = matches[1];

            // Concatenate the two images in a single image (just to show on screen)
            Concatenate concat = new Concatenate(img1);
            Bitmap img3 = concat.Apply(img2);

            // Show the marked correlations in the concatenated image
            PairsMarker pairs = new PairsMarker(
                correlationPoints1, // Add image1's width to the X points to show the markings correctly
                correlationPoints2.Apply(p => new IntPoint(p.X + img1.Width, p.Y)));
            img3 = img3.Clone(new Rectangle(0, 0, img3.Width, img3.Height), PixelFormat.Format24bppRgb);

            var pic = pairs.Apply(img3);
            pictureBox1.Image = pic;
        }

        private void surf()
        {
            var surf = new Accord.Imaging.SpeededUpRobustFeaturesDetector();
            
            surfPoints1 = surf.ProcessImage(img1).ToArray();
            surfPoints2 = surf.ProcessImage(img2).ToArray();

            // Show the marked points in the original images
            Bitmap img1mark = new FeaturesMarker(surfPoints1).Apply(img1);
            Bitmap img2mark = new FeaturesMarker(surfPoints2).Apply(img2);

            // Concatenate the two images together in a single image (just to show on screen)
            Concatenate concatenate = new Concatenate(img1mark);
            pictureBox1.Image = concatenate.Apply(img2mark);
        }
    }
}
