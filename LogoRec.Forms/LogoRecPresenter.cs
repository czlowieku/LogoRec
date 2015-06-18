using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Linq;
using System.Runtime.InteropServices;
using System.Threading;
using Shared;

namespace LogoRec.Forms
{
    public interface ILogoRecPresenter
    {
        void Show();
    }

    public class LogoRecPresenter : ILogoRecPresenter
    {
        private readonly ILogoRecView _view;
        private LogoRecViewModel _model;
  
        public LogoRecPresenter(ILogoRecView view, LogoRecViewModel model)
        {
          
            _view = view;
            _model = model;
            _view.Bind(_model);
            _model.PropertyChanged += _model_PropertyChanged;

        }

      

        public void Show()
        {
            _view.ShowDialogg();
        }


        void _model_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
          

        }


    }
}