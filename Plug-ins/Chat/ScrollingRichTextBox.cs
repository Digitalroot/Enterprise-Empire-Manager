using System;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace EEM.Plugin.Chat
{
  public static class UIExtensions
  {
    private const int WM_VSCROLL = 277;
    private const int SB_LINEUP = 0;
    private const int SB_LINEDOWN = 1;
    private const int SB_TOP = 6;
    private const int SB_BOTTOM = 7;

    [DllImport("user32.dll", CharSet = CharSet.Auto)]
    private static extern IntPtr SendMessage(
      IntPtr hWnd,
      uint Msg,
      IntPtr wParam,
      IntPtr lParam);

    public static void ScrollToBottom(this TextBoxBase tb)
    {
      SendMessage(tb.Handle, WM_VSCROLL, new IntPtr(SB_BOTTOM), new IntPtr(0));
    }

    public static void ScrollToTop(this TextBoxBase tb)
    {
      SendMessage(tb.Handle, WM_VSCROLL, new IntPtr(SB_TOP), new IntPtr(0));
    }

    public static void ScrollLineDown(this TextBoxBase tb)
    {
      SendMessage(tb.Handle, WM_VSCROLL, new IntPtr(SB_LINEDOWN), new IntPtr(0));
    }

    public static void ScrollLineUp(this TextBoxBase tb)
    {
      SendMessage(tb.Handle, WM_VSCROLL, new IntPtr(SB_LINEUP), new IntPtr(0));
    }
  }
}