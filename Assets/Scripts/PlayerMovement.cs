using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public Rigidbody rb;
    public float speed = 0.01f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        rb.MovePosition( rb.position + (new Vector3(x, 0, z) * speed) );
    }

    private void OnCollisionEnter(Collision collision)
    {
       Debug.Log("Goal - Success" + collision.transform.name);
        if (collision.transform.tag == "Goal")
        {
            Destroy(collision.gameObject);

            GameManager manger = FindObjectOfType<GameManager>();
            manger.LoadNextLevel();
        }
    }


}
