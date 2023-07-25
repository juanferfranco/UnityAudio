using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;


[RequireComponent(typeof(AudioSource))]
public class AudioPeer : MonoBehaviour
{
    AudioSource m_AudioSource;
    private static float[] _audioSamples;
    private static float[] _frequencyBands = new float[8];
    void Start()
    {
        _audioSamples = new float[512];
        m_AudioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        GetSpectrumData();
        MakeFrequencyBands();
    }

    void GetSpectrumData()
    {
        m_AudioSource.GetSpectrumData(_audioSamples, 0, FFTWindow.Blackman);
    }

    public static float GetSample(int sample)
    {
        return _audioSamples[sample];
    }
    public static float GetBand(int band)
    {
        return _frequencyBands[band];
    }
    
    public void MakeFrequencyBands()
    {

        int count = 0;
        for (int i = 0; i < 8; i++)
        {
            float average = 0;
            int sampleCount = (int)Mathf.Pow(2, i) * 2;
            if (i == 7) sampleCount += 2;

            for (int j = 0; j < sampleCount; j++)
            {
                average += _audioSamples[count] * (count + 1);
                count++;
            }
            average /= count;
            _frequencyBands[i] = average * 10;
        }
    }
}
