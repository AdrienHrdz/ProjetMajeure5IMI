using System.Diagnostics;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExecPython : MonoBehaviour {

    private void Start() {
        var process = new Process
        {
            StartInfo = new ProcessStartInfo
            {
                FileName = "python",
                Arguments = "script.py",
                RedirectStandardOutput = true,
                UseShellExecute = false,
                CreateNoWindow = true
            }
        };
        process.Start();
        string output = process.StandardOutput.ReadToEnd();
        process.WaitForExit();
        UnityEngine.Debug.Log(output);
    }
}
