using System.Collections;
using System.Net.Mail;
using Microsoft.VisualBasic;
using Skribble;

class program{

    public static void Main(string[] args){
        Console.Write("Image link: ");
        var url = Console.ReadLine();
        // var url =
        //     "https://steamuserimages-a.akamaihd.net/ugc/2008094604191140266/E46C53A36D8188A60C9D31E7E04ADBCE6AC410B2/";
        string path =
            @"D:\onedrive school\OneDrive - De Haagse Hogeschool\Programming stuff\Rider Projects\Skribble\Images\Download.png";

        Console.Clear();
        var start = DateTime.Now;

        ImageProc proc = new(url);
        GetColor colorSmall = new(1);
        GetColor colorBig = new(0);
        Canvas canvas = new();

        var pixel = proc.imageHeight[0] * proc.imageWidth[0];

        int StartY = canvas.XUp, StartX = canvas.YUp;


        var big = GenerateColorArray(proc, colorBig, 0);
        string[,] small = new string[proc.imageHeight[1], proc.imageWidth[0]];
        //string[,] small = GenerateColorArray(proc, colorSmall, 1);

        const bool run = true;


        var oldColor = new ColorPalette("White", 255, 255, 255);


        ArrayList lineListBig = GenerateColorLines(big, small, proc, 0, 4);
        //ArrayList lineListSmall = GenerateColorLines(small, proc, 1, 15);


        if (true){

            ClearCanvas();

            var setUp = DateTime.Now;
            Console.WriteLine("setup time: " + (setUp - start));
            start = DateTime.Now;

            MouseClick.LeftMouseClick(1485, 640, false);
            MouseClick.LeftMouseClick(796, 925, false);


            foreach (ColorPalette colorList in colorSmall.GetAllColorPalette()){
                var pixelCount = small.Cast<string?>().Count(colorName => colorList.Name == colorName);
                //var lineCount = lineListSmall.Cast<Line>().Count((colorName) => colorList.Name.Equals(colorName.Color));
                if (pixelCount == 0 )
                    continue;


                colorSmall.ClickColor(colorList.R, colorList.G, colorList.B, oldColor.R, oldColor.G, oldColor.B);
                oldColor = colorList;
                StartX = canvas.XUp;


                for (int i = 0; i < proc.imageHeight[1]; i++){


                    StartX += 16;
                    StartY = canvas.YUp;
                    //  Thread.Sleep(80);

                    for (int j = 0; j < proc.imageWidth[1]; j++){
                        if (colorList.Name.Equals(small[i, j])){
                            Thread.SpinWait(55_000);

                            MouseClick.LeftMouseClick(StartY, StartX, false);
                        }

                        StartY += 16;
                    }
                }

            }


            var endUnderPaint = DateTime.Now;
            Console.WriteLine("under paint time: " + (endUnderPaint - start));
            start = DateTime.Now;

            MouseClick.LeftMouseClick(609, 923, false);
            for (int i = 0; i < 10; i++){
                Console.Write("▒");
            }

            var amountOfColorsDone = 0;
            var allColors = colorBig.GetAllColorPalette();
            var colorCount = big.Cast<string?>().Distinct().Count();
            var pixelsDrawn = 0;

            foreach (ColorPalette color in allColors){
                var pixelCount = big.Cast<string?>().Count(colorName => color.Name == colorName);

                var lineCount = lineListBig.Cast<Line>().Count((colorName) => color.Name.Equals(colorName.Color));
                if (pixelCount == 0 && lineCount == 0)
                    continue;
                pixelsDrawn += pixelCount;
                WriteProgressBar(++amountOfColorsDone, colorCount, pixelsDrawn, pixel);
                var counter = 0;


                colorBig.ClickColor(color.R, color.G, color.B, oldColor.R, oldColor.G, oldColor.B);
                oldColor = color;
                StartX = canvas.XUp;


                foreach (Line line in lineListBig){
                    if (line.Color.Equals(color.Name)){

                        line.Start.X += canvas.YUp;
                        line.Start.Y += canvas.XUp;
                        MouseClick.drawLine(line, 4);
                        pixelsDrawn += line.Lenght;
                    }
                }

                // MouseClick.LeftMouseClick(1485, 416, false);
                // MouseClick.LeftMouseClick(609, 923, false);


                if (true){
                    for (int i = 0; i < proc.imageHeight[0]; i++){


                        StartX += 4;
                        StartY = canvas.YUp;
                        //  Thread.Sleep(80);

                        for (int j = 0; j < proc.imageWidth[0]; j++){
                            if (color.Name.Equals(big[i, j])){
                                Thread.SpinWait(87_000);

                                counter++;
                                if (counter > 2000){
                                    Thread.Sleep(300);
                                    counter = 0;
                                }

                                MouseClick.LeftMouseClick(StartY, StartX, false);
                            }

                            StartY += 4;
                        }
                    }
                }
            }
        }


        var endEnd = DateTime.Now;
        Console.WriteLine("\nPaiting time: " + (endEnd - start));
        // Console.Write("Press any key to exit.");
        // Console.ReadLine();
    }

    private static ArrayList GenerateColorLines(string[,] array, string[,] arraySmall, ImageProc proc, int index,
                                                int multiplier){

        var arr = array.Clone() as string[,];

        var lineList = new ArrayList();
        String lastColor = array[0, 0];
        for (int i = 0; i < proc.imageHeight[index]; i++){
            var line = new Line(new Coords(0, i), false);
            for (int j = 0; j < proc.imageWidth[index]; j++){
                if (lastColor.Equals(array[i, j])){
                    line.Lenght++;
                }
                else{
                    line.Color = lastColor;
                    if (line.Lenght > 15){
                        for (int k = 0; k < line.Lenght; k++){
                            if (line.Color.Equals("BLANK"))
                                break;

                            array[i, (line.Start.X / 4) + k] = "NIET";
                            for (int l = 0; l < proc.imageHeight[index]; l++){
                                for (int m = 0; m < proc.imageWidth[index]; m++){
                                    if (array[l, m].Equals("NIET")){
                                        arraySmall[l / 4, m / 4] = arr[l, m];
                                        try{
                                            arraySmall[(l - 1) / 4, (m - 1) / 4] = arr[l, m];
                                            arraySmall[(l + 1) / 4, (m + 1) / 4] = arr[l, m];
                                        }
                                        catch (Exception e){
                                            //ignore
                                        }

                                    }
                                }
                            }


                        }

                        lineList.Add(line);
                    }

                    line = new Line(new Coords(i * multiplier + 1, j * multiplier), false);
                }

                lastColor = array[i, j];
            }
        }

        return lineList;
    }

    static string[,] GenerateColorArray(ImageProc proc, GetColor color, int index){

        var array = new string[proc.imageHeight[0], proc.imageWidth[0]];

        for (int i = 0; i < proc.imageHeight[index]; i++){
            for (int j = 0; j < proc.imageWidth[index]; j++){
                var colour = color.getColorName(i, j);
                array[i, j] = colour;
                if (j == proc.imageWidth[index] - 1){
                    array[i, j] = "BLANK";


                }

            }
        }

        return array;
    }

    static void ClearCanvas(){
        Canvas canvas = new();
        List<Line> lineList = new List<Line>();

        MouseClick.LeftMouseClick(1549, 416, false);
        MouseClick.LeftMouseClick(794, 924, false);

        for (int i = 0; i < 35; i++){
            lineList.Add(new Line(new Coords(i * 15 + canvas.XUp + 1, 0 * 15 + canvas.YUp), 60));
        }


        foreach (Line line in lineList){
            MouseClick.drawLine(line, 15);
            line.Start.X += canvas.YUp;
            line.Start.Y += canvas.XUp;
        }

    }

    static void WriteProgressBar(double amountOfColorsDone, int allColors, int pixelsDrawn, int totalPixels){
        var percentage = amountOfColorsDone / allColors * 100;
        int amount = (int)Math.Ceiling(percentage / 10);


        Console.SetCursorPosition(amount - 1, Console.CursorTop);
        Console.Write("▓");


        Console.SetCursorPosition(11, Console.CursorTop);
        Console.Write(" colors: " + (int)(amountOfColorsDone) + "/" + (allColors - 2) + " pixelsDrawn: " + pixelsDrawn +
                      "/" + totalPixels);


    }
}