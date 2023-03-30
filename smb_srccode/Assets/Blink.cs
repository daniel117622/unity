using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Blink : MonoBehaviour
{
    public Texture[] qBlink;
    float _time;
    float _interval;
    Renderer rd;
    int _current;
    BlockBehaviour state;
    // Start is called before the first frame update
    void Start()
    {
        _time = 0.0f;
        _interval = 0.5f;
        rd = GetComponent<Renderer>();
        _current = 0;
        state = GetComponent<BlockBehaviour>();
    }

    // Update is called once per frame
    void Update()
    {


        while( _time >= _interval )
        {
            rd.material.SetTexture("_MainTex", qBlink[_current % qBlink.Length] );
            _time = _time - _interval;
            _current += 1;
        }

    }
}
