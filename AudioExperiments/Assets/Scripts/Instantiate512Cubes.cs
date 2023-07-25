using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Instantiate512Cubes : MonoBehaviour
{
    public GameObject _sampleCubePrefab;
    private GameObject[] _sampleCubes = new GameObject[512];
    public float _maxScale = 1000;

    void Start()
    {
        for(int i = 0; i< 512; i++)
        {
            GameObject _instantieateCube = (GameObject) Instantiate( _sampleCubePrefab );
            _instantieateCube.transform.position = this.transform.position;
            _instantieateCube.transform.parent = this.transform;
            _instantieateCube.name = "SampleCube" + i;
            this.transform.eulerAngles = new Vector3(0, -0.703125f*i,0);
            _instantieateCube.transform.position = Vector3.forward * 100;
            _sampleCubes[i] = _instantieateCube;
        }
    }

    // Update is called once per frame
    void Update()
    {
        for(int i = 0; i < 512; i++)
        {
            if(_sampleCubes != null)
            {
                float cubeYScale = AudioPeer.GetSample(i)* _maxScale + 2;
                _sampleCubes[i].transform.localScale = new Vector3(1, cubeYScale , 1);
            }
        }

    }
}
