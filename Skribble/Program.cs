using System.Drawing;
using System.Globalization;
using System.Net.Mime;
using System.Reflection;
using Emgu.CV;
using Emgu.CV.Cuda;
using Emgu.CV.CvEnum;
using Skribble;

class program{

    public static void Main(string[] args){
        GetColor color = new();
        Canvas canvas = new();
        ImageProc proc = new();
        var white = new colorCoords(585, 897, "White");
        var lightGray = new colorCoords(610, 897, "LightGray");
        var red = new colorCoords(634, 895, "Red");
        var orange = new colorCoords(657, 895, "Orange");
        var yellow = new colorCoords(678, 895, "Yellow");
        var green = new colorCoords(705, 895, "Green");
        var lightBlue = new colorCoords(728, 895, "Aqua");
        var blue = new colorCoords(752, 895, "Blue");
        var purple = new colorCoords(776, 895, "Purple");
        var pink = new colorCoords(801, 895, "Pink");
        var brown = new colorCoords(824, 895, "Brown");
        var DarkRed = new colorCoords(634, 919, "DarkRed");
        var DarkOrange = new colorCoords(657, 919, "DarkOrange");
        var DarkYellow = new colorCoords(678, 919, "DarkYellow");
        var DarkGreen = new colorCoords(705, 919, "DarkGreen");
        var DarkAqua = new colorCoords(728, 919, "DarkAqua");
        var DarkBlue = new colorCoords(752, 919, "DarkBlue");
        var DarkPurple = new colorCoords(776, 919, "DarkPurple");
        var DarkPink = new colorCoords(801, 919, "DarkPink");
        var DarkBrown = new colorCoords(824, 919, "DarkBrown");
        var Gray = new colorCoords(610, 919, "DarkGray");
        var Black = new colorCoords(585, 919, "Black");


        List<colorCoords> ColorList = new List<colorCoords>(){
            //white,

            red,
            orange,
            yellow,
            green,
            lightBlue,
            blue,
            purple,
            pink,
            brown,
            DarkRed,
            DarkOrange,
            DarkYellow,
            DarkGreen,
            DarkAqua,
            DarkBlue,
            DarkPurple,
            DarkPink,
            DarkBrown,
            Gray,
            lightGray,
            Black
        };

        var array = new string[proc.imageHeight, proc.imageWidth];

        int startX = canvas.XUp, startY = canvas.YUp;


        for (int i = 0; i < proc.imageHeight; i++){
            for (int j = 0; j < proc.imageWidth; j++){
                array[i, j] = color.GetSkribbleColor(i, j);
                //Console.WriteLine(array[i, j]);
            }
        }

        Console.ReadLine();
        const bool run = true;
        if (run)
            foreach (var coords in ColorList){
                startY = canvas.YUp;
                MouseClick.LeftMouseClick(coords.x, coords.y, false);

                for (int i = 0; i < proc.imageHeight; i++){
                    startY += 3;
                    startX = canvas.XUp;

                    for (int j = 0; j < proc.imageWidth; j++){
                        if (coords.name == array[i, j]){
                            Console.WriteLine();
                            MouseClick.LeftMouseClick(startX, startY, false);
                        }

                        startX += 3;
                    }
                }

            }

        Console.ReadLine();
    }


}


//MouseClick.LeftMouseClick(0, 1000, true);