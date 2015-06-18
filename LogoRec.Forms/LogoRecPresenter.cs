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

        public LogoRecPresenter(ILogoRecView view, LogoRecViewModel model,IFrameAnalyzer analyzer, IFrameProvider frameProvider )
        {
          
            _view = view;
            _model = model;
            _analyzer = analyzer;
            _frameProvider = frameProvider;
          
            _view.Bind(_model);
            _model.PropertyChanged += _model_PropertyChanged;

            _view.GoButtonPressed += (sender, args) =>
            {
               DrawMatches draw=new DrawMatches();
               var m = new Image<Gray, Byte>(@"E:\Dev\LogoRec\LogoRec.Forms\bin\Debug\box.png");
                new Thread(() =>
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
                           
                            long mt;
                            var res = draw.Draw(m, a, out mt);
                            model.ViewedImage = res;
                        }
                        catch (Exception E)
                        {
                            model.ViewedImage = a.Mat;
                          
                        }
                       
                       // Thread.Sleep(1000);
                    }
                }).Start();


            };

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