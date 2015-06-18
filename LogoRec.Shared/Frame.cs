using System;
using Emgu.CV;
using Emgu.CV.Structure;

namespace Shared
{
    public class Frame
    {
        public Mat Img { get; set; }

        public Frame(Mat img)
        {
            Img = img;
        }
    }

//    public class Frame
//    {
//        private readonly string _date;
//        private readonly string _time;
//        private readonly string _channel;
//        private readonly Image<Bgr, byte> _image;
//
//        public Frame( string channel, string date, string time, Image<Bgr, byte> image)
//        {
//            if (image == null) 
//                throw new ArgumentNullException("image");
//            _channel = channel;
//            _date = date;
//            _time = time;
//            _image = image;
//        }
//
//        public string Channel
//        {
//            get { return _channel; }
//        }
//
//        public string Date
//        {
//            get { return _date; }
//        }
//
//        public string Time
//        {
//            get { return _time; }
//        }
//
//        public Image<Bgr, byte> Image
//        {
//            get { return _image; }
//        }
//    }
}