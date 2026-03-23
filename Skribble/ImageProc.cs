using System.Drawing;
using System.Drawing.Imaging;
using System.Net;
using Emgu;
using Emgu.CV;
using Emgu.CV.CvEnum;
using Emgu.CV.Structure;
using cmdwtf.Dithering;

namespace Skribble;

public class ImageProc{

    public int[] imageWidth ={231, 63};
    public int[] imageHeight ={125, 35};

    public string path =
        @"D:\onedrive school\OneDrive - De Haagse Hogeschool\Programming stuff\Rider Projects\Skribble\Images\Download.png";


    public ImageProc(string imageUrl){
        WebClient client = new WebClient();
        Stream stream = client.OpenRead(imageUrl);
        Bitmap bitmap;
        bitmap = new Bitmap(stream);

        if (bitmap != null){
            bitmap.Save(path, ImageFormat.Png);
        }

        stream.Flush();
        stream.Close();
        client.Dispose();
    }

    public ImageProc(){
    }

    public Image<Bgr, byte> ImageToArray(int index){


        Mat image = CvInvoke.Imread(path, ImreadModes.Color);

        if (index == 1)
            CvInvoke.GaussianBlur(image, image, new Size(imageWidth[index], imageHeight[index]), 2);
        CvInvoke.Resize(image, image, new Size(imageWidth[index], imageHeight[index]), 200, 453, Inter.Area);


        Image<Bgr, byte> img = image.ToImage<Bgr, byte>();
        img.Save(
            @"D:\onedrive school\OneDrive - De Haagse Hogeschool\Programming stuff\Rider Projects\Skribble\Images\DownScaledImage.png");


        return img;
    }
}