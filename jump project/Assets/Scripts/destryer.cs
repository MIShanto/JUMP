using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class destryer : MonoBehaviour {

    public GameObject player;
    public GameObject platform;
    private GameObject myplat;
    public GameObject springplat;

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.name.StartsWith("safe"))
        {
            if (Random.Range(1, 7) > 1)
            {
                Destroy(collision.gameObject);
                Instantiate(springplat, new Vector2(Random.Range(-1.7f, 1.7f), player.transform.position.y + (9 + Random.Range(0.5f, 2.2f))), Quaternion.identity);
            }
            else
                collision.gameObject.transform.position = new Vector2(Random.Range(-1.7f, 1.7f), player.transform.position.y + (9 + Random.Range(0.5f, 2.2f)));
        }
        if (collision.gameObject.name.StartsWith("speedplatform"))
        {
            if (Random.Range(1, 7) > 1)
            {
                collision.gameObject.transform.position = new Vector2(Random.Range(-1.7f, 1.7f), player.transform.position.y + (9 + Random.Range(0.5f, 2.2f)));

            }
            else
            {
                Destroy(collision.gameObject);
                Instantiate(platform, new Vector2(Random.Range(-1.7f, 1.7f), player.transform.position.y + (9 + Random.Range(0.5f, 2.2f))), Quaternion.identity);

            }
        }
    }
}
