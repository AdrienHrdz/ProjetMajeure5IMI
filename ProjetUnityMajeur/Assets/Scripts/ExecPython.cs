using System.Diagnostics;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExecPython : MonoBehaviour {

    public int BPM;
    private void Start() {
        var process = new Process
        {
            StartInfo = new ProcessStartInfo
            {
                FileName = "python",
                Arguments = "C:\\Users\\adrie\\CPE\\5ETI\\ProjetMajeure5IMI_2\\ProjetUnityMajeur\\Assets\\Scripts\\script.py",
                RedirectStandardOutput = true,
                UseShellExecute = false,
                CreateNoWindow = true
            }
        };
        process.Start();
        string output = process.StandardOutput.ReadToEnd();
        process.WaitForExit();

        UnityEngine.Debug.Log(output);
        BPM = int.Parse(output);
        // process.StandardOutput.BaseStream.Flush();
        // string line;
        // while ((line = process.StandardOutput.ReadLine()) != null)
        // {
        //     UnityEngine.Debug.Log(line);
        // }
    }
}
