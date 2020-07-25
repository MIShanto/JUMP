using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bounce : MonoBehaviour
{

    public float vel=150f;
   
    void OnCollisionEnter2D(Collision2D collision)
    {

        if (collision.relativeVelocity.y <= 0f)
        {
            Rigidbody2D rb = collision.collider.GetComponent<Rigidbody2D>();
            if (rb != null)
            {
                // Vector2 velocity = rb.velocity;
                // velocity.y = vel;
                // rb.velocity = velocity;
                //Debug.Log(collision.gameObject.name);
                rb.AddForce(Vector3.up * vel);
            }
        }

    }
}
