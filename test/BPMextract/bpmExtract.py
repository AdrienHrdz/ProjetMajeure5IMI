import librosa
import numpy as np
import matplotlib.pyplot as plt

# Charger le fichier audio en utilisant Librosa
audio, sr = librosa.load("songTest.mp3", sr=None, mono=False)
print('1')
# Effectuer une FFT sur l'audio
fft = np.fft.fft(audio)
print('2')
# Obtenir les fréquences en utilisant la fonction fftfreq de Numpy
freqs = np.fft.fftfreq(len(fft), d=1/sr)
print('3')
# Afficher les fréquences obtenues
print(freqs)
print('4')
# Afficher le spectre

plt.plot()
print('5') 
# Ajouter des étiquettes et un titre aux axes
# plt.xlabel('Fréquence (Hz)')
# plt.ylabel('Amplitude')
# plt.title('Spectre de l\'audio')

# Afficher le graphe
plt.show()
print('6')