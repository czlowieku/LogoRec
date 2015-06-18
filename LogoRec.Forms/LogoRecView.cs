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

           
            imageBox2.DataBindings.Add("Image", model, "ViewedImage", true, DataSourceUpdateMode.OnPropertyChanged);

            textBoxHessian.DataBindings.Add("Text", model, "HessianThresh", true,
                DataSourceUpdateMode.OnPropertyChanged);

            textBoxK.DataBindings.Add("Text", model, "K", true,
                DataSourceUpdateMode.OnPropertyChanged);

            textBoxUniqness.DataBindings.Add("Text", model, "UniquenessThreshold", true,
                DataSourceUpdateMode.OnPropertyChanged);

        }

        public void ShowDialogg()
        {
            ShowDialog();
        }

        public event EventHandler GoButtonPressed;
        public event EventHandler StopButtonPressed;

        private void button1_Click(object sender, EventArgs e)
        {
            var h = GoButtonPressed;
            if (h != null)
                h(sender, e);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            var h = StopButtonPressed;
            if (h != null)
                h(sender, e);
        }
    }

    public interface ILogoRecView
    {
        void Bind(LogoRecViewModel model);
        void ShowDialogg    ();
        event EventHandler GoButtonPressed;
        event EventHandler StopButtonPressed;
        
 
    }

}
