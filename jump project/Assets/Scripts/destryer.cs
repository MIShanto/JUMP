using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class destryer : MonoBehaviour {

    public GameObject player;
    public GameObject platform;
    private GameObject myplat;
    public GameObject springplat;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    public void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.name.StartsWith("Platform"))
        {
            if (Random.Range(1, 7) > 1)
            {
                Destroy(collision.gameObject);
                Instantiate(springplat, new Vector2(Random.Range(-5.5f, 5.5f), player.transform.position.y + (9 + Random.Range(0.5f, 1.0f))), Quaternion.identity);
            }
            else
                collision.gameObject.transform.position = new Vector2(Random.Range(-5.5f, 5.5f), player.transform.position.y + (9 + Random.Range(0.5f, 1.0f)));
        }
        if (collision.gameObject.name.StartsWith("speedplatform"))
        {
            if (Random.Range(1, 7) > 1)
            {
                collision.gameObject.transform.position = new Vector2(Random.Range(-5.5f, 5.5f), player.transform.position.y + (9 + Random.Range(0.5f, 1.0f)));

            }
            else
            {
                Destroy(collision.gameObject);
                Instantiate(platform, new Vector2(Random.Range(-5.5f, 5.5f), player.transform.position.y + (9 + Random.Range(0.5f, 1.0f))), Quaternion.identity);

            }
        }
    }
}
