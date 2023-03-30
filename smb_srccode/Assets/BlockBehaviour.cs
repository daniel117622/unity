using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockBehaviour : MonoBehaviour
{
    public bool hasCoin = false;
    public bool hasMushroom = false;
    public bool isDestroyable = false;
    public bool isInactive = false;
    public bool noUpdate = false;
    public Texture pTex;
    public static Texture staticTex;

    public SoundMaster SM;

    void Start()
    {
        if (pTex != null)
        {
            staticTex = pTex;
        }      
        SM = GameObject.FindGameObjectsWithTag("MainCamera")[0].GetComponent<SoundMaster>();
    }

    // Update is called once per frame
    void Update()
    {       
        if (noUpdate) { return; }
        if (isInactive)
        {
            GetComponent<Renderer>().material.SetTexture("_MainTex", staticTex );
            noUpdate = true;
            return;
        }        
    }

    public void endAction() // This is called when mario presses the block
    {
        Debug.Log(this.isInactive.ToString() + '\n' + this.hasCoin.ToString() + '\n' + this.hasMushroom.ToString() + '\n' );

        if (isDestroyable)
        {
            SM.PlaySound("Break");
        }
        if ( hasCoin )
        {
            TimerAndScore._score = 100;
            SM.PlaySound("Coin");
            Debug.Log("Coin collcted!");
            hasCoin = false;
        }
        if ( hasMushroom )
        {
            Debug.Log("Mushroom spawned");
        }
        if (isInactive)
        {
            SM.PlaySound("Hit");
        }
    }

}
