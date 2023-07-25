using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioRMS : MonoBehaviour
{
    public GameObject m_Level;
    private bool m_IsOk = false;
    private int m_NumSamples = 256;
    private float[] m_Samples;
    public Vector3 scale;
    public float volume = 10.0f;
    private Color color;
    public float rms;
    public float rms_max = 0;
    public float rms_min = 0;
    private AudioSource _audioSource;
    
    void Start()
    {
        if (m_Level != null) {
            m_Samples = new float[m_NumSamples];
            scale = m_Level.transform.localScale;
            m_IsOk = true;
            _audioSource = GetComponent<AudioSource>();
            _audioSource.Play();
            m_Level.GetComponent<Renderer>().material.color = Color.green;
        }
        else
        {
            Debug.Log("Level game object is null");
            GetComponent<AudioSource>().Stop();
        }
            
        
    }
    void Update () {
        if (m_IsOk) {
            _audioSource.GetOutputData(m_Samples, 0);
            float sum = 0.0f;
            for (int i = 0; i < m_NumSamples; i++) {
                sum = m_Samples[i] * m_Samples[i];
            }
            rms = Mathf.Sqrt(sum/m_NumSamples);
            if (rms > rms_max) rms_max = rms;
            else if (rms < rms_min) rms_min = rms;
            scale.y = rms*volume;
            m_Level.transform.localScale = scale;
        }
    }
}
