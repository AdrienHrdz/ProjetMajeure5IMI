import numpy as np
import librosa
import scipy

filename = "C:\\Users\\adrie\\CPE\\5ETI\\ProjetMajeure5IMI_2\\ProjetUnityMajeur\\Assets\\Audio\\PREMIERE _ BICEP - Glue (ACOR HT Rework) [MORC014].mp3"
audio, sr = librosa.load(filename, sr=None, mono=True)
t = np.linspace(0, len(audio) / sr, len(audio))

# Filtre
cutoff = 5.0
nyquist = sr / 2
low = cutoff / nyquist
order = 5
b, a = scipy.signal.butter(order, low, btype='low')

s = 10
k1 = int(0)

bpmList = list()

while k1 < len(audio):
    # sliding window
    k2 = k1 + int(s*sr)
    if k2 > len(audio):
        k2 = len(audio)
    audio_crop = audio[k1:k2]
    # filter
    # apod = scipy.signal.windows.hann(k2 - k1)
    apod = scipy.signal.windows.blackmanharris(k2 - k1)
    audio_crop = audio_crop * apod
    filtered_audio = scipy.signal.lfilter(b, a, audio_crop)
    # fft
    fft_filtered_audio = np.fft.fft(filtered_audio)
    freq = np.fft.fftfreq(filtered_audio.size, d=1/sr)
    # bpm
    index_bpm_Hz = np.argmax(np.abs(fft_filtered_audio))
    if index_bpm_Hz == 0:
        fft_filtered_audio[0] = 0
    index_bpm_Hz = np.argmax(np.abs(fft_filtered_audio))
    bpm_Hz = freq[index_bpm_Hz]
    bpm = bpm_Hz * 60
    bpmList.append(abs(bpm))
    k1 += sr


bins = np.arange(90, 250, 1)
bpmHist, bin_edges = np.histogram(bpmList, bins=bins)

id = np.argmax(bpmHist)
BPM = bin_edges[id+1]
print(BPM)