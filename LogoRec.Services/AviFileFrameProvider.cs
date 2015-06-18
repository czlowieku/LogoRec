using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Emgu.CV;
using Emgu.CV.Structure;
using Shared;

namespace LogoRec.Services
{
    public class AviFileFrameProvider : IFrameProvider<Frame>
    {
        public IEnumerable<Frame> GetFrames(string path)
        {
            var capture = new Capture(path);
            Image<Bgr, Byte> img = capture.QueryFrame();
            while (img != null)
            {
                img = capture.QueryFrame();
                yield return new Frame(string.Empty, string.Empty, string.Empty, img);
            }
            capture.Dispose();
        }


    }
}


