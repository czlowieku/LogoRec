using System.Collections;
using System.Collections.Generic;
using Emgu.CV;
using Emgu.CV.Structure;

namespace Shared
{
    public interface IFrameProvider
    {
        IEnumerable<Frame> GetFrames(string path);
    }

    public interface IFrameAnalyzer
    {
        IEnumerable<AnalyzeResult> AnalyzeFrames(IEnumerable<Frame> frames);
    }

    public class Frame
    {
        public Image<Bgr, byte> Img { get; set; }

        public Frame(Image<Bgr,byte> img)
        {
            Img = img;
        }
    }

    public class AnalyzeResult  
    {
    }
}