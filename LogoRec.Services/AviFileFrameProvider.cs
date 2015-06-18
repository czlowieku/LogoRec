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
    public class AviFileFrameProvider : IFrameProvider
    {
        public IEnumerable<Frame> GetFrames(string path)
        {
            var capture = new Capture(path);
            Mat img = capture.QueryFrame();
            while (img != null)
            {
                img = capture.QueryFrame();
                yield return new Frame(img);
            }
            capture.Dispose();
        }


    }
    public class EmguCvFrameAnalyzer:IFrameAnalyzer
    {
        public IEnumerable<AnalyzeResult> AnalyzeFrames(IEnumerable<Frame> frames)
        {


            return null;
        }
    }

}


