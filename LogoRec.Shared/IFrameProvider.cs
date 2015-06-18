using System.Collections;
using System.Collections.Generic;
using Emgu.CV;

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
        public Mat Img { get; set; }

        public Frame(Mat img)
        {
            Img = img;
        }
    }

    public class AnalyzeResult  
    {

    }
}