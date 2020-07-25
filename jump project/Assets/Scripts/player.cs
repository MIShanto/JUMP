using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class player : MonoBehaviour {
    public float speed = 10f;
    Rigidbody2D rb;
    public float move = 0f;
    //public float xx = 0f;
	// Use this for initialization
	void Start () {
        rb = GetComponent < Rigidbody2D>();
	}

    private void Update()
    {
        if (move < 0)
            this.GetComponent<SpriteRenderer>().flipX=true;
        else
            this.GetComponent<SpriteRenderer>().flipX=false;
    }
    // Update is called once per frame
    void FixedUpdate()
    {
        move = Input.GetAxis("Horizontal") * Time.deltaTime * 10f;
        //rb.velocity = new Vector2(move, rb.velocity.y);
        transform.Translate(move, 0,0);
    }
    
}
