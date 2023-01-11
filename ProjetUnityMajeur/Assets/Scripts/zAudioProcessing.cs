// using UnityEngine;
// using System.Collections;
// using UnityEngine.Audio;
// using System;
// using AForge.Math;

// public class AudioProcessing : MonoBehaviour
// {
//     public AudioClip audioClip;
//     public float BPM;

//     private Complex[] fft_filtered;

//     void Start()
//     {
//         float[] audio = new float[audioClip.samples];
//         audioClip.GetData(audio, 0);

//         // Apply a low-pass filter to the audio
//         float[] filteredAudio = ApplyLowPassFilter(audio, 44100, 1000);

//         // Apply a Fast Fourier Transform to the audio
//         Complex[] fft_filtered = ApplyFFT(filteredAudio);
//         BPM = CalculateBPM();

//         // Display the frequency profile of the original and filtered audio
//         // DisplayFrequencyProfile(audio, 44100);
//         // DisplayFrequencyProfile(filteredAudio, 44100);
//     }

//     float[] ApplyLowPassFilter(float[] audio, int sr, int lowpass)
//     {
//         // Create a low-pass filter with a cutoff frequency of 1000 Hz
//         double nyquist = sr / 2.0;
//         double low = lowpass / nyquist;
//         double[] a = { 1, -2.562915447484845, 2.5668312247779, -1.0614612065333, 0.182418570959980 };
//         double[] b = { 0.006670309995360, 0, -0.019910929986080, 0, 0.019910929986080, 0, -0.006670309995360 };
//         int taps = b.Length;
//         float[] filteredAudio = new float[audio.Length];
//         Array.Copy(audio, filteredAudio, audio.Length);
//         float[] w = new float[taps];

//         for (int i = 0; i < filteredAudio.Length - taps; i++)
//         {
//             Array.Copy(w, 0, w, 1, taps - 1);
//             w[0] = filteredAudio[i];

//             for (int j = 0; j < taps; j++)
//             {
//                 filteredAudio[i + j] = (float)(filteredAudio[i + j] + b[j] * w[j] - a[j] * filteredAudio[i + j - taps]);
//             }
//         }
//         return filteredAudio;
//     }

//     float CalculateBPM()
//     {
//         int maxIndex = Array.IndexOf(fft_filtered, fft_filtered.Max());
//         float frequencyOfMax = maxIndex * sr / fft_filtered.Length;
//         float bpm = frequencyOfMax * 60;
//         return bpm;
//     }

//     Complex[] ApplyFFT(float[] audio)
//     {
//         Complex[] fft = new Complex[audio.Length];
//         for (int i = 0; i < audio.Length; i++)
//         {
//             fft[i].x = audio[i];
//         }
//         Mathf.FFT(fft, true);
//         return fft;
//     }

// }
