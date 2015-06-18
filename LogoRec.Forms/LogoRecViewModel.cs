using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Drawing;
using System.Runtime.CompilerServices;
using Emgu.CV;
using Emgu.CV.CvEnum;
using Emgu.CV.Structure;
using LogoRec.Forms.Annotations;
using Shared;

namespace LogoRec.Forms
{
    public class LogoRecViewModel:INotifyPropertyChanged
    {
        public LogoRecViewModel()
        {
            _viewedImage=new Mat(1,1,DepthType.Cv16S, 3);
            _k = 2;
            _uniquenessThreshold = 0.8;
            _hessianThresh = 300;
        }
        private Mat _viewedImage;
        private int _k;
        private double _uniquenessThreshold;
        private double _hessianThresh;

        public Mat ViewedImage 
        {
            get { return _viewedImage; }
            set
            {
                if (Equals(value, _viewedImage)) return;
                _viewedImage = value;
                OnPropertyChanged();
            }
        }


        public int K
        {
            get { return _k; }
            set
            {
                if (value == _k) return;
                _k = value;
                OnPropertyChanged();
            }
        }

        public double UniquenessThreshold
        {
            get { return _uniquenessThreshold; }
            set
            {
                if (value.Equals(_uniquenessThreshold)) return;
                _uniquenessThreshold = value;
                OnPropertyChanged();
            }
        }

        public double HessianThresh
        {
            get { return _hessianThresh; }
            set
            {
                if (value.Equals(_hessianThresh)) return;
                _hessianThresh = value;
                OnPropertyChanged();
            }
        }


        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            var handler = PropertyChanged;
            if (handler != null) handler(this, new PropertyChangedEventArgs(propertyName));
        }
    }


}