using System.Diagnostics;

namespace WorkStationLocker.ConsoleApp.Core
{
    public static class CommandManager
    {
        public static void LockWorkStation()
        {
            Process.Start("cmd.exe", "/C rundll32.exe user32.dll, LockWorkStation");
        }
    }
}
