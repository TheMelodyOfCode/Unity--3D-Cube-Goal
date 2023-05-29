using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public Rigidbody rb;
    public float speed = 0.01f;
    public float jumpForce = 7f;
    public bool isGrounded = true;


    Vector3 startPos;
    // Start is called before the first frame update
    void Start()
    {
        startPos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        rb.MovePosition( rb.position + (new Vector3(x, 0, z) * speed * Time.deltaTime) );

        if(transform.position.y < -15) 
        {             
            transform.position = startPos;
        }

        if (Input.GetKeyDown(KeyCode.Space) && isGrounded == true )
        {
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            isGrounded = false;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
       Debug.Log("Goal - Success" + collision.transform.name);

        isGrounded = true;

        if (collision.transform.tag == "Goal")
        {
            Destroy(collision.gameObject);

            GameManager manger = FindObjectOfType<GameManager>();
            manger.LoadNextLevel();
        }
    }


}
