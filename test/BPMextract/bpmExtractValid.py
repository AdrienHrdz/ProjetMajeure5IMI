import scipy.signal
import librosa
import matplotlib.pyplot as plt
import numpy as np

filename = "purple.mp3"

audio, sr = librosa.load(filename, sr=None, mono=True)

# Creaton filtre
cutoff = 5.0
nyquist = sr / 2
low = cutoff / nyquist
order = 5
b, a = scipy.signal.butter(order, low, btype='low')

# Application du filtre
filtered_audio = scipy.signal.lfilter(b, a, audio)

# Calcul de la transformée de Fourier du signal filtre
fft_filtered_audio = np.fft.fft(filtered_audio)
freq = np.fft.fftfreq(filtered_audio.size, d=1/sr)

# Calcul du BPM
index_bpm_Hz = np.argmax(np.abs(fft_filtered_audio))
bpm_Hz = freq[index_bpm_Hz]
bpm = bpm_Hz * 60
print(bpm)