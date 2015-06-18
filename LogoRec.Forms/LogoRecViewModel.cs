using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Drawing;
using System.Runtime.CompilerServices;
using Emgu.CV;
using Emgu.CV.Structure;
using LogoRec.Forms.Annotations;
using Shared;

namespace LogoRec.Forms
{
    public class LogoRecViewModel:INotifyPropertyChanged
    {
        private Image<Bgr, byte> _viewedImage;

        public Image<Bgr, byte> ViewedImage 
        {
            get { return _viewedImage; }
            set
            {
                if (Equals(value, _viewedImage)) return;
                _viewedImage = value;
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