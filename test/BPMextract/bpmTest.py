import scipy.signal
import librosa
import matplotlib.pyplot as plt
import numpy as np

audio, sr = librosa.load("purple.mp3", sr=None, mono=True)
t = np.linspace(0, len(audio) / sr, len(audio))
plt.plot(t, audio)
plt.show()

# Créer un filtre passe-bas de second ordre avec une fréquence de coupure de 1000 Hz
cutoff = 5.0
nyquist = sr / 2
low = cutoff / nyquist
order = 5 
b, a = scipy.signal.butter(order, low, btype='low')

# Appliquer le filtre au signal audio
filtered_audio = scipy.signal.lfilter(b, a, audio)


# calculer la transformée de Fourier pour le signal audio original
fft_audio = np.fft.fft(audio)
freq = np.fft.fftfreq(audio.size, d=1/sr)

# afficher la transformée de Fourier
plt.plot(freq, np.abs(fft_audio))

# calculer la transformée de Fourier pour le signal filtré
fft_filtered_audio = np.fft.fft(filtered_audio)
freq = np.fft.fftfreq(filtered_audio.size, d=1/sr)

# afficher la transformée de Fourier
plt.plot(freq, np.abs(fft_filtered_audio))
plt.show()

# plt.figure(2)
# plt.plot(audio)
plt.plot(filtered_audio)
plt.show()

index_bpm_Hz = np.argmax(np.abs(fft_filtered_audio))
bpm_Hz = freq[index_bpm_Hz]
bpm = bpm_Hz * 60
print(bpm)