using System.Runtime.InteropServices;

namespace FuckingSleepAsshole;

public static class TimeToSleep 
{
    [DllImport("PowrProf.dll", SetLastError = true)]
    [return: MarshalAs(UnmanagedType.Bool)]
    private static extern bool SetSuspendState(bool hibernate, bool forceCritical, bool disableWakeEvent);

    public static void Now()
    {
        SetSuspendState(false, true, false);
    }
}
