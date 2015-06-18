using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Threading;
using Emgu.CV;
using Emgu.CV.Structure;
using LogoRec.Services;
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
        private readonly IFrameAnalyzer _analyzer;
        private readonly IFrameProvider _frameProvider;
        private Thread _thread;

        public LogoRecPresenter(ILogoRecView view, LogoRecViewModel model,IFrameAnalyzer analyzer, IFrameProvider frameProvider )
        {
          
            _view = view;
            _model = model;
            _analyzer = analyzer;
            _frameProvider = frameProvider;
          
            _view.Bind(_model);
            _model.PropertyChanged += _model_PropertyChanged;

            _view.GoButtonPressed += _view_GoButtonPressed;
            _view.StopButtonPressed += _view_StopButtonPressed;
        }

        void _view_StopButtonPressed(object sender, EventArgs e)
        {
            if (_thread != null) _thread.Abort();
        }

        void _view_GoButtonPressed(object sender, EventArgs e)
        {
            

            DrawMatches draw = new DrawMatches();
            var m = new Image<Gray, Byte>(@"E:\Dev\LogoRec\LogoRec.Forms\bin\Debug\box.png");
            if (_thread != null && _thread.IsAlive)
            {
                _thread.Abort();
            }
            _thread = new Thread(() =>
            {
                foreach (
                    var img in
                        _frameProvider.GetFrames(
                            @"G:\Sin.City.A.Dame.To.Kill.For.2014.720p.BRRip.XviD.AC3.5.1\Sin.City.A.Dame.To.Kill.For.2014.720p.BRRip.XviD.AC3.5.1.avi")
                    )
                {
                    var a = img.Img.ToImage<Gray, byte>();
                    try
                    {
                        var res = draw.Draw(m, a, _model.K, _model.UniquenessThreshold, _model.HessianThresh);
                        _model.ViewedImage = res;
                    }
                    catch (Exception E)
                    {
                        _model.ViewedImage = a.Mat;

                    }
                }
            });
            _thread.Start();

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