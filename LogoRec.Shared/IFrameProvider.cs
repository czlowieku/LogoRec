using System.Collections;
using System.Collections.Generic;

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

    public class AnalyzeResult  
    {

    }
}