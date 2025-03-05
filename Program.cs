// Create a sine wave generator

using NAudio.Wave;
using NAudio.Wave.SampleProviders;
using Synthesizer;

using var waveOut = new WaveOutEvent()
{
    DesiredLatency = 60,
    NumberOfBuffers = 2
};

var mixer = new MixingSampleProvider(WaveFormat.CreateIeeeFloatWaveFormat(44100, 1))
{
    ReadFully = true
};

waveOut.Init(mixer);
waveOut.Play();

var song = DemoSong.TestSong();
var songPlayer = new SongPlayer(song, mixer);
songPlayer.Play();

Console.WriteLine("Pattern playback finished. Press any key to exit...");
Console.ReadKey();