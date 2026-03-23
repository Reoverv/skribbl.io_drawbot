namespace Skribble;

public static class MouseClick{
    [System.Runtime.InteropServices.DllImport("user32.dll")]
    private static extern bool SetCursorPos(int x, int y);

    [System.Runtime.InteropServices.DllImport("user32.dll")]
    public static extern void mouse_event(int dwFlags);

    public const int MOUSEEVENTF_LEFTDOWN = 0x02;
    public const int MOUSEEVENTF_LEFTUP = 0x04;


    public static void LeftMouseClick(int xpos, int ypos, bool Hold){
        SetCursorPos(xpos, ypos);
        //System.Threading.Thread.Sleep(100);
        mouse_event(MOUSEEVENTF_LEFTDOWN);
        if (!Hold){
            mouse_event(MOUSEEVENTF_LEFTUP);
        }

    }

    public static void drawLine(Line line, int width){

        SetCursorPos(line.Start.X, line.Start.Y);

        //  SetCursorPos(line.Start.Y, line.Start.X);
        mouse_event(MOUSEEVENTF_LEFTDOWN);


        Task.Delay(10).Wait();



        SetCursorPos(line.Start.X + (line.Lenght * width), line.Start.Y);
       // Console.WriteLine(line.Start.X + (line.Lenght * 4) + " " + line.Start.Y);

        Task.Delay(10).Wait();

        mouse_event(MOUSEEVENTF_LEFTUP);


    }
}