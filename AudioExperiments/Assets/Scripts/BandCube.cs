using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BandCube : MonoBehaviour
{
    public int _band;
    public float _startScale;
    public float _scaleMultiplier;
    void Update()
    {
        float yBand = (AudioPeer.GetBand(_band)*_scaleMultiplier) + _startScale;
        this.transform.localScale = new Vector3(transform.localScale.x, yBand, transform.localScale.z);
    }
}
