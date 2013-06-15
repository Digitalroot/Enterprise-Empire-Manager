using System;
using System.IO;

namespace EEM.Plugin.Notifications
{
  public class Logger
  {
    private const string Filename = "PS-Notifier.log";

    public static void Log(string message)
    {
      using (StreamWriter streamWriter = new StreamWriter(File.Open(Filename, FileMode.Append)))
      {
        streamWriter.WriteLine(DateTime.Now + " : " + message);
      }
    }

    public static void Log(string message, params object[] arguments)
    {
      using (
        StreamWriter streamWriter =
          new StreamWriter(File.Open(Filename, FileMode.Append, FileAccess.Write, FileShare.ReadWrite)))
      {
        streamWriter.WriteLine(DateTime.Now + " : " + string.Format(message, arguments));
      }
    }

    public static void Log(Exception exception, string message)
    {
      using (
        StreamWriter streamWriter =
          new StreamWriter(File.Open(Filename, FileMode.Append, FileAccess.Write, FileShare.ReadWrite)))
      {
        streamWriter.WriteLine(DateTime.Now + " : " + message);
        streamWriter.WriteLine(DateTime.Now + " : " + exception.Message);
        streamWriter.WriteLine(DateTime.Now + " : " + exception.StackTrace);
      }
    }

    public static void Log(Exception exception, string message, params object[] arguments)
    {
      using (
        StreamWriter streamWriter =
          new StreamWriter(File.Open(Filename, FileMode.Append, FileAccess.Write, FileShare.ReadWrite)))
      {
        streamWriter.WriteLine(DateTime.Now + " : " + string.Format(message, arguments));
        streamWriter.WriteLine(DateTime.Now + " : " + exception.Message);
        streamWriter.WriteLine(DateTime.Now + " : " + exception.StackTrace);
      }
    }
  }
}
