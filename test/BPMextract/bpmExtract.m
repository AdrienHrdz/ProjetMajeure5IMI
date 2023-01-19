clear variables;
close all;
clc;

[y,Fs] = audioread("songTest.mp3");

L = y(:,1) ;%/ max(y(:,1));
R = y(:,2) ;%/ max(y(:,2));
Mono = L+R;
figure(1)
% plot(L)
plot(Mono);
hold on 
% plot(R)
N = 2048;
TFMono = fft(Mono);
figure(2)
% stem(1:1:N/2, abs(TFMono(1:1:N/2)));
stem( abs(TFMono));

n = 73;

nu = n/N * Fs