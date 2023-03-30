using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;



public class MarioBehaviour : MonoBehaviour
{
    public float maxVel;
    private Rigidbody rb;
    public float speed;
    public bool isGrounded;
    public Sprite[] anims;
    private bool enableForce;
    private float _time;
    private SoundMaster SM;
    // Start is called before the first frame update
    void Start()
    {
        Physics.gravity = new Vector3(0.0f,-50.0f, 0.0f);
        rb = GetComponent<Rigidbody>();
        isGrounded = true;
        enableForce = true;
        _time = 0.0f;
        SM = GameObject.FindGameObjectsWithTag("MainCamera")[0].GetComponent<SoundMaster>();
    }

    // Update is called once per frame
    void Update()
    {
        _time += Time.deltaTime;
        HandleAnimations();
        if (gameObject.transform.position.y <= 0)
        {
            SceneManager.LoadScene("1");
        }
    }

    void FixedUpdate()
    {
        HandleInput();        
    }

    private void OnCollisionEnter(Collision other)
    {
        if ( other.contacts[0].normal.y == -1 )
        {

            other.gameObject.GetComponent<BlockBehaviour>().endAction();
            other.gameObject.GetComponent<BlockBehaviour>().isInactive = true;
            
        }
        
        if ( other.contacts[0].normal.y == 1 )
        {
               isGrounded = true;
        }
        if ( other.contacts[0].normal.x != 0 )
        {
            enableForce = true;
        }    
    }

    private void HandleInput()
    {
        if (Input.GetKey(KeyCode.D))
        {
            if ( rb.velocity.x <= maxVel && isGrounded && enableForce)
            {
                rb.AddForce(new Vector3(speed , 0.0f, 0.0f));
            }  
            if ( rb.velocity.x <= maxVel && !isGrounded && enableForce)
            {
                rb.AddForce(new Vector3(speed * 0.4f, 0.0f, 0.0f));
            }                      
        }
        if (Input.GetKey(KeyCode.W) && isGrounded)
        {
            rb.AddForce(new Vector3(0.0f, 34.0f, 0.0f), ForceMode.Impulse);
            SM.PlaySound("Jump");
            isGrounded = false;
        } 
        if (Input.GetKey(KeyCode.A))
        {
            if ( rb.velocity.x >= -maxVel && isGrounded && enableForce )
            {
                rb.AddForce(new Vector3(-speed , 2.0f, 0.0f));
            }
            if ( rb.velocity.x >= -maxVel && !isGrounded && enableForce)
            {
                rb.AddForce(new Vector3(-speed * 0.4f, 2.0f, 0.0f));
            }       
        }
        if (Input.GetKey(KeyCode.S))
        {
            Debug.Log("S was pressed");
        }
    }

    private void HandleAnimations()
    {
        // Jumping and orientation
        if (!isGrounded) { GetComponent<SpriteRenderer>().sprite = anims[3]; } 
        else if (isGrounded && Mathf.Abs(rb.velocity.x) == 0 )
        { 
            GetComponent<SpriteRenderer>().sprite = anims[0]; 
        }
        else if (isGrounded && Mathf.Abs(rb.velocity.x) > 0 )
        { 
            GetComponent<SpriteRenderer>().sprite = anims[1 +  ((int) (_time * 5) ) % 2 ]; 
        }

        if ( rb.velocity.x <= 0 ) {  transform.eulerAngles = new Vector3(0.0f, -180.0f, 0.0f);  }
        else { transform.eulerAngles = new Vector3(0.0f, 0.0f, 0.0f); }




    }


}
