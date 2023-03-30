using System.Collections;
using System.Collections.Generic;
using UnityEngine;using UnityEngine.SceneManagement;

public class Enemy : MonoBehaviour
{
    Vector3 orV;
    int count;
    // Start is called before the first frame update
    void Start()
    {
        GetComponent<Rigidbody>().velocity = new Vector3(-5.0f,0.0f,0.0f);
        orV = new Vector3(5.0f,0.0f,0.0f);
        count = 0; 
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnCollisionEnter(Collision other)
    {
        Debug.Log(other.contacts[0].normal);
        if (other.gameObject.tag == "Player")
        {
            if (other.contacts[0].normal.y == -1 ) 
            {
                Destroy(this.gameObject);
                TimerAndScore._score += 500;
                return;
            }
            else
            {
                //Kill mario
                SceneManager.LoadScene("1");
            }
        }
        else
        {
            count++;
            Debug.Log(this.GetComponent<Rigidbody>().velocity);
            this.GetComponent<Rigidbody>().velocity = orV * Mathf.Pow(-1,count);
        }
    }
}
