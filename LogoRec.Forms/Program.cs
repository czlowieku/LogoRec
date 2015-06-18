using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using Castle.MicroKernel.Registration;
using Castle.Windsor;
using LogoRec.Services;
using Shared;

namespace LogoRec.Forms
{
    internal static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        private static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            var container = GetContainer();
            var pres = container.Resolve<ILogoRecPresenter>();
            pres.Show();
        }

        private static WindsorContainer GetContainer()
        {
            var container = new WindsorContainer();

            container.Register(Component.For<ILogoRecPresenter>().ImplementedBy<LogoRecPresenter>());
            container.Register(Component.For<ILogoRecView>().ImplementedBy<LogoRecView>());
            container.Register(Component.For<LogoRecViewModel>());


            container.Register(Component.For<IFrameProvider<Frame>>().ImplementedBy<AviFileFrameProvider>());

//            container.Register(Component.For<IFramesProcessor>().ImplementedBy<FramesProcessor>());
//            container.Register(Component.For<IFrameAnalyzer>().ImplementedBy<AForgeSimpleFrameAnalyzer>());
//            container.Register(Component.For<IFrameFactory>().ImplementedBy<FrameFactory>());
            return container;
        }
    }
}
