using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace AutoClickPro.Models
{

    public enum TypeClick
    {
        Click,
        MouseDown,
        MouseUp,
        MouseMove
    }
    public enum MouseButton
    {
        Left,
        Right
    }
   
    public class MouseClick:Action
    {
        public TypeClick typeClick;
        public MouseButton mouseButton;
        public float delay;
        public int repeatTime;
        public string postion;

        public MouseClick(TypeClick typeClick, MouseButton mouseButton, float delay, int repeatTime, string postion)
        {
            this.typeClick = typeClick;
            this.mouseButton = mouseButton;
            this.delay = delay;
            this.repeatTime = repeatTime;
            this.postion = postion;
        }

        [DllImport("user32")]
        public static extern int SetCursorPos(int x, int y);
        const uint MOUSEEVENTF_ABSOLUTE = 0x8000;
        const uint MOUSEEVENTF_LEFTDOWN = 0x0002;
        const uint MOUSEEVENTF_LEFTUP = 0x0004;
        const uint MOUSEEVENTF_MIDDLEDOWN = 0x0020;
        const uint MOUSEEVENTF_MIDDLEUP = 0x0040;
        const uint MOUSEEVENTF_MOVE = 0x0001;
        const uint MOUSEEVENTF_RIGHTDOWN = 0x0008;
        const uint MOUSEEVENTF_RIGHTUP = 0x0010;
        const uint MOUSEEVENTF_XDOWN = 0x0080;
        const uint MOUSEEVENTF_XUP = 0x0100;
        const uint MOUSEEVENTF_WHEEL = 0x0800;
        const uint MOUSEEVENTF_HWHEEL = 0x01000;

        [DllImport("user32.dll", CharSet = CharSet.Auto, CallingConvention= CallingConvention.StdCall)]
        public static extern void mouse_event(uint dwFlags, int dx, int dy, int cButtons, int dwExtraInfo);
        Point findPoint(string s)
        {
            return new Point(100, 100);
        }
        public override void Run()
        {
            for (int i = 0; i < repeatTime; i++)
            {
                Thread.Sleep((int)(this.delay * 1000));
                Point point_click = findPoint(postion);
                SetCursorPos(point_click.x, point_click.y);
                switch (typeClick)
                {
                    case TypeClick.Click:
                        if (mouseButton==MouseButton.Left)
                        {
                            mouse_event(MOUSEEVENTF_LEFTDOWN, 0, 0, 0, 0);
                            mouse_event(MOUSEEVENTF_LEFTUP, 0, 0, 0, 0);
                        }
                        if (mouseButton == MouseButton.Right)
                        {
                            mouse_event(MOUSEEVENTF_RIGHTDOWN, 0, 0, 0, 0);
                            mouse_event(MOUSEEVENTF_RIGHTUP, 0, 0, 0, 0);
                        }
                        break;
                    case TypeClick.MouseDown:
                        if (mouseButton == MouseButton.Left)
                        {
                            mouse_event(MOUSEEVENTF_LEFTDOWN, 0, 0, 0, 0);
                        }
                        if (mouseButton == MouseButton.Right)
                        {
                            mouse_event(MOUSEEVENTF_RIGHTDOWN, 0, 0, 0, 0);
                        }
                        break;
                    case TypeClick.MouseUp:
                        if (mouseButton == MouseButton.Left)
                        {
                            mouse_event(MOUSEEVENTF_LEFTUP, 0, 0, 0, 0);
                        }
                        if (mouseButton == MouseButton.Right)
                        {
                            mouse_event(MOUSEEVENTF_RIGHTUP, 0, 0, 0, 0);
                        }
                        break;
                    case TypeClick.MouseMove:
                        mouse_event(MOUSEEVENTF_MOVE, 0, 0, 0, 0);
                        break;
                    default:
                        break;
                }

            }
        }
    }
    public class Point
    {
        public int x { get; set; }
        public int y { get; set; }

        public Point(int x, int y)
        {
            this.x = x;
            this.y = y;
        }
    }
}
