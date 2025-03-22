using UnityEngine;
using System.Runtime.InteropServices;

public class WindowsSleepPreventer : MonoBehaviour
{
    [DllImport("kernel32.dll", SetLastError = true)]
    private static extern uint SetThreadExecutionState(uint esFlags);

    private const uint ES_CONTINUOUS = 0x80000000;
    private const uint ES_SYSTEM_REQUIRED = 0x00000001;
    private const uint ES_DISPLAY_REQUIRED = 0x00000002;

    void Start()
    {
        // Prevent the system and display from sleeping
        SetThreadExecutionState(ES_CONTINUOUS | ES_SYSTEM_REQUIRED | ES_DISPLAY_REQUIRED);
    }

    // Optionally, restore normal behavior on exit
    void OnApplicationQuit()
    {
        SetThreadExecutionState(ES_CONTINUOUS);
    }
}
