using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class score : MonoBehaviour
{
    public Text scr;
    public Text txt;
    public Text bgtxt;
    private Rigidbody2D rb;
    public float topscore = -5f;
    private float move;
    private float speed;
	// Use this for initialization
	private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    private void Update()
    {
       
        if (rb.velocity.y > 0 && transform.position.y > topscore)
        {
            //Debug.Log(topscore);
            topscore = transform.position.y;
        }
        scr.text = "score: " + Mathf.Round(5+topscore).ToString();
        if (Mathf.Abs(topscore - rb.transform.position.y) > 20)
        {
            txt.text = "Game Over..";
            bgtxt.text = "Game Over..";
            Invoke("end", 3f);
        }
    }
    void FixedUpdate () {
        move = Input.GetAxis("Horizontal") * Time.deltaTime * 10f;
        //rb.velocity = new Vector2(move, rb.velocity.y);
        transform.Translate(move, 0, 0);
    }
    void end()
    {
        SceneManager.LoadScene(0);
    }
}
