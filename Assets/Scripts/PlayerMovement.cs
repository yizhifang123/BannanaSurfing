using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] GameObject player;
    public Rigidbody rb;
    public float Speed;
    public bool Grounded;
    public float jumpForce;
    public Obstacle obstacle;
    
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        MoveForward();
        Dodge();
        Jump();
    }

    void MoveForward()
    {
        transform.position += transform.forward * Time.deltaTime * Speed;
    }

    void Dodge()
    {
        if(Input.GetKeyDown(KeyCode.D) & player.transform.position.x < 2 & obstacle.move == true)
        {
            rb.AddForce(transform.right * 250);
        }

        if (Input.GetKeyDown(KeyCode.A) & player.transform.position.x > -2 & obstacle.move == true)
        {
            rb.AddForce(transform.right * -250);
        }

    }

    void Jump()
    {
        if (Input.GetButtonDown("Jump") & Grounded == true & obstacle.move == true)
        {
            rb.AddForce(new Vector3(0, jumpForce, 0), ForceMode.Impulse);
            Grounded = false;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            Grounded = true;
        }
    }
}
