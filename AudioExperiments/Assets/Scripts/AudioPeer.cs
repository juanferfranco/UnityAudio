using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;


[RequireComponent(typeof(AudioSource))]
public class AudioPeer : MonoBehaviour
{
    AudioSource m_AudioSource;
    private static float[] _audioSamples;
    void Start()
    {
        _audioSamples = new float[512];
        m_AudioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        GetSpectrumData();
    }

    void GetSpectrumData()
    {
        m_AudioSource.GetSpectrumData(_audioSamples, 0, FFTWindow.Blackman);
    }

    public static float GetSample(int sample)
    {
        return _audioSamples[sample];
    }

}
