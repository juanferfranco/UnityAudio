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
    
    void Start()
    {
        if (m_Level != null) {
            m_Samples = new float[m_NumSamples];
            scale = m_Level.transform.localScale;
            m_IsOk = true;
            GetComponent<AudioSource>().Play();
        }
        else
        {
            Debug.Log("");
            GetComponent<AudioSource>().Stop();
        }
            
        
    }
    void Update () {
        // Continuing proper validation
        if (m_IsOk) {
            GetComponent<AudioSource>().GetOutputData(m_Samples, 0);
            float sum = 0.0f;
            for (int i = 0; i < m_NumSamples; i++) {
                sum = m_Samples[i] * m_Samples[i];
            }
            float rms = Mathf.Sqrt(sum/m_NumSamples);
            float rms_clamp = Mathf.Clamp01(rms);
            scale.y = rms_clamp*volume;
            m_Level.transform.localScale = scale;
            color = GetVolumeColor(rms_clamp);
            m_Level.GetComponent<Renderer>().material.color = color;
        }
    }
	
    Color GetVolumeColor (float volume) {
        if (volume > 0.7f)
            return Color.red;
        if (volume > 0.5f)
            return Color.yellow;
        return Color.green;
    }
}
