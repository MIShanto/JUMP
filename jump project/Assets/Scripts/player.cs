using UnityEngine;
[RequireComponent(typeof(Rigidbody2D))]
public class player : MonoBehaviour
{
    public float moveSpeed = 10f;
    float move;

    Rigidbody2D rb;
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.gravityScale = 0f;
    }
    void FixedUpdate()
    {
        move = Input.GetAxis("Horizontal") * Time.deltaTime * moveSpeed;
        //rb.velocity = new Vector2(move, rb.velocity.y);
        transform.Translate(move, 0, 0);
    }

    public void GameStarted()
    {
        rb.gravityScale = 2f;
    }

}