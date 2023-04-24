using System.Collections;
using System.Collections.Generic;
using UnityEngine;





public class PlayerMovement : MonoBehaviour
{

    public Rigidbody rb;

    public float forwardForce = 2000f;
    public float sidewaysForce = 500f;
    public float jumpForce = 120f;

    private float width;
    private float height;

    private void Awake()
    {
        width = (float)Screen.width / 2.0f;
        height = (float)Screen.height / 2.0f;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        rb.AddForce(0, 0, forwardForce * Time.deltaTime);

        if(Input.GetKey("d"))
        {
            rb.AddForce(sidewaysForce * Time.deltaTime , 0 , 0, ForceMode.VelocityChange);
        }

        if (Input.GetKey("a"))
        {
            rb.AddForce(-sidewaysForce * Time.deltaTime, 0, 0, ForceMode.VelocityChange);
        }

        if (Input.GetKey("w"))
        {
            rb.AddForce(0,jumpForce * Time.deltaTime, 0, ForceMode.VelocityChange);
        }

        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);
            Vector2 pos = touch.position;
            pos.x = (pos.x - width) / width;
            pos.y = (pos.y - height) / height;

            if (pos.x > 0)
            {
                rb.AddForce(+sidewaysForce * Time.deltaTime, 0, 0, ForceMode.VelocityChange);

            }


            if (pos.x < 0)
            {
                rb.AddForce(-sidewaysForce * Time.deltaTime, 0, 0, ForceMode.VelocityChange);
            }
        }


        if (rb.position.y<-0.2f)
        {
            FindObjectOfType<GameManager>().EndGame();
        }
    }
}
