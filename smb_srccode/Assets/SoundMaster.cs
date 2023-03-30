using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundMaster : MonoBehaviour
{
    public static AudioSource AudioSource; 
    // private AudioClip clipcoin;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PlaySound( string soundName )
    {
        if (soundName == "Coin") 
        {
            GameObject sp = Resources.Load<GameObject>("coin_sound"); 
            Instantiate(sp);
            sp.SetActive(true);
            Debug.Log("Playing Coin");
        }
        else if (soundName == "Break") 
        {
            GameObject sp = Resources.Load<GameObject>("block_break"); 
            Instantiate(sp);
            sp.SetActive(true);
        } 
        else if (soundName == "Hit") 
        {
            GameObject sp = Resources.Load<GameObject>("block_hit"); 
            Instantiate(sp);
            sp.SetActive(true);
        }   
        else if (soundName == "Jump") 
        {
            GameObject sp = Resources.Load<GameObject>("jump_sound"); 
            Instantiate(sp);
            sp.SetActive(true);
        }                            
    }
}
