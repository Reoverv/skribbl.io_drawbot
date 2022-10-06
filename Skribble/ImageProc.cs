using System.Drawing;
using Emgu;
using Emgu.CV;
using Emgu.CV.CvEnum;
using Emgu.CV.Structure;

namespace Skribble;



public class ImageProc{

    public int imageWidth = 272 ;
    public int imageHeight = 154;
    
    public Image<Bgr, byte> ImageToArray(){
        
        Mat frame = new Mat();

        string path =
            @"C:\Users\remco\OneDrive - De Haagse Hogeschool\Programming stuff\Rider Projects\Skribble\Images\ExampleImage.png";

        int width = imageWidth, height = imageHeight;
        frame = CvInvoke.Imread(path, ImreadModes.Color);
        CvInvoke.Resize(frame, frame, new Size(width, height), 0, 0, Inter.Cubic);
        
        Image<Bgr, Byte> img = frame.ToImage<Bgr, Byte>();
        img.Save(@"C:\Users\remco\OneDrive - De Haagse Hogeschool\Programming stuff\Rider Projects\Skribble\Images\DownScaledImage.png");
    
        return img;
    }

}