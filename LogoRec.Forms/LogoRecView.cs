using System;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Shared;
using View = System.Windows.Forms.View;

namespace LogoRec.Forms
{
    public partial class LogoRecView : Form, ILogoRecView
    {
        public LogoRecView()
        {
            InitializeComponent();
        }

        public void Bind(LogoRecViewModel model)
        {
            this.imageBox1.DataBindings.Add("Image", model, "ViewedImage", false, DataSourceUpdateMode.OnPropertyChanged);
        }

        public void ShowDialogg()
        {
            ShowDialog();
        }
    }

    public interface ILogoRecView
    {
        void Bind(LogoRecViewModel model);
        void ShowDialogg    ();
    }

}
