using System;
using System.Diagnostics;
using System.Drawing;
using Emgu.CV;
using Emgu.CV.Cuda;
using Emgu.CV.CvEnum;
using Emgu.CV.Features2D;
using Emgu.CV.Structure;
using Emgu.CV.Util;
using Emgu.CV.XFeatures2D;

namespace LogoRec.Services
{
    public class DrawMatches
    {



        public void FindMatch(Image<Gray, byte> modelImage, Image<Gray, byte> observedImage, double hessianThresh, int k,
            double uniquenessThreshold, VectorOfVectorOfDMatch matches, out VectorOfKeyPoint modelKeyPoints,
            out VectorOfKeyPoint observedKeyPoints, out Mat mask, out Mat homography)
        {
            homography = null;
            modelKeyPoints = new VectorOfKeyPoint();
            observedKeyPoints = new VectorOfKeyPoint();

            CudaSURFDetector surfCuda = new CudaSURFDetector((float) hessianThresh);
            using (GpuMat gpuModelImage = new GpuMat(modelImage))
                //extract features from the object image
            using (GpuMat gpuModelKeyPoints = surfCuda.DetectKeyPointsRaw(gpuModelImage, null))
            using (
                GpuMat gpuModelDescriptors = surfCuda.ComputeDescriptorsRaw(gpuModelImage, null, gpuModelKeyPoints))
            using (CudaBFMatcher matcher = new CudaBFMatcher(DistanceType.L2))
            {
                surfCuda.DownloadKeypoints(gpuModelKeyPoints, modelKeyPoints);

                // extract features from the observed image
                using (GpuMat gpuObservedImage = new GpuMat(observedImage))
                using (GpuMat gpuObservedKeyPoints = surfCuda.DetectKeyPointsRaw(gpuObservedImage, null))
                using (
                    GpuMat gpuObservedDescriptors = surfCuda.ComputeDescriptorsRaw(gpuObservedImage, null,
                        gpuObservedKeyPoints))
                {
                    matcher.KnnMatch(gpuObservedDescriptors, gpuModelDescriptors, matches, k);

                    surfCuda.DownloadKeypoints(gpuObservedKeyPoints, observedKeyPoints);

                    mask = new Mat(matches.Size, 1, DepthType.Cv8U, 1);
                    mask.SetTo(new MCvScalar(255));
                    Features2DToolbox.VoteForUniqueness(matches, uniquenessThreshold, mask);

                    int nonZeroCount = CvInvoke.CountNonZero(mask);
                    if (nonZeroCount >= 4)
                    {
                        nonZeroCount = Features2DToolbox.VoteForSizeAndOrientation(modelKeyPoints, observedKeyPoints,
                            matches, mask, 1.5, 20);
                        if (nonZeroCount >= 4)
                            homography = Features2DToolbox.GetHomographyMatrixFromMatchedFeatures(modelKeyPoints,
                                observedKeyPoints, matches, mask, 2);
                    }
                }
            }

        }

        /// <summary>
        /// Draw the model image and observed image, the matched features and homography projection.
        /// </summary>
        /// <param name="modelImage">The model image</param>
        /// <param name="observedImage">The observed image</param>
        /// <param name="matchTime">The output total time for computing the homography matrix.</param>
        /// <returns>The model image and observed image, the matched features and homography projection.</returns>
              public Mat Draw(Image<Gray, byte> modelImage, Image<Gray, byte> observedImage, int k, double uniquenessThreshold, double hessianThresh)

        {
            Mat homography;
            VectorOfKeyPoint modelKeyPoints;
            VectorOfKeyPoint observedKeyPoints;
            using (VectorOfVectorOfDMatch matches = new VectorOfVectorOfDMatch())
            {
                Mat mask;

                FindMatch(modelImage, observedImage, hessianThresh, k, uniquenessThreshold, matches, out modelKeyPoints, out observedKeyPoints, out mask, out homography);

                //Draw the matched keypoints
                Mat result = new Mat();
                Features2DToolbox.DrawMatches(modelImage, modelKeyPoints, observedImage, observedKeyPoints,
                    matches, result, new MCvScalar(255, 255, 255), new MCvScalar(255, 255, 255), mask);

                #region draw the projected region on the image

                if (homography != null)
                {
                    //draw a rectangle along the projected model
                    Rectangle rect = modelImage.ROI;
                    PointF[] pts = new PointF[]
                    {
                        new PointF(rect.Left, rect.Bottom),
                        new PointF(rect.Right, rect.Bottom),
                        new PointF(rect.Right, rect.Top),
                        new PointF(rect.Left, rect.Top)
                    };
                    pts = CvInvoke.PerspectiveTransform(pts, homography);

                    Point[] points = Array.ConvertAll<PointF, Point>(pts, Point.Round);
                    using (VectorOfPoint vp = new VectorOfPoint(points))
                    {
                        CvInvoke.Polylines(result, vp, true, new MCvScalar(255, 0, 0, 255), 5);
                    }
                    //result.DrawPolyline(, true, new Bgr(Color.Red), 5);
                }

                #endregion

                return result;

            }
        }
    }
}
