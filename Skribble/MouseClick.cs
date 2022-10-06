namespace Skribble;

public static class MouseClick{
    [System.Runtime.InteropServices.DllImport("user32.dll")]
    private static extern bool SetCursorPos(int x, int y);

    [System.Runtime.InteropServices.DllImport("user32.dll")]
    public static extern void mouse_event(int dwFlags, int dx, int dy, int cButtons, int dwExtraInfo);

    public const int MOUSEEVENTF_LEFTDOWN = 0x02;
    public const int MOUSEEVENTF_LEFTUP = 0x04;

    //This simulates a left mouse click
    public static void LeftMouseClick(int xpos, int ypos, bool Hold){
        SetCursorPos(xpos, ypos);
        //System.Threading.Thread.Sleep(100);
        mouse_event(MOUSEEVENTF_LEFTDOWN, xpos, ypos, 0, 0);
        if (!Hold){
            mouse_event(MOUSEEVENTF_LEFTUP, xpos, ypos, 0, 0);
        }
    }
}