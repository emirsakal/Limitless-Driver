using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour
{
    bool alive = true;

    public float speed = 7;
    public Rigidbody rb;
    
    float horizontalInput;
    float verticalInput;
    public bool playerIsOnTheGround = true;
    private void Start ()
    {
        rb = GetComponent<Rigidbody>();
    }
    private void FixedUpdate  ()
    {
        if (!alive) return;
        
        Vector3 horizontalMove = transform.right * speed * horizontalInput * Time.fixedDeltaTime * 2;
        Vector3 forwardMove = transform.forward * speed * Time.fixedDeltaTime;
        rb.MovePosition(rb.position + forwardMove + horizontalMove);
    }
    void Update()
    {
        horizontalInput = Input.GetAxis("Horizontal");

        if (transform.position.y < -1) 
        {
            Die();
        }

        if (Input.GetButtonDown("Jump") && playerIsOnTheGround)
        {
            rb.AddForce(new Vector3(0,7,0), ForceMode.Impulse);
            playerIsOnTheGround = false;
        }
    }

    private void OnCollisionEnter (Collision collision)
    {
        if(collision.gameObject.tag == "Ground")
        {
            playerIsOnTheGround = true;
        }
    }

    public void Die ()
    {
        alive = false;

        Invoke("Restart", 1);
    } 
    
    void Restart ()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
