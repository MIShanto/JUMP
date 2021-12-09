using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnOnCamFollow : MonoBehaviour
{

    [SerializeField] CameraFollow camFollow;

    private void Start()
    {
        camFollow.enabled=false;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
        {
            camFollow.enabled = true;

        }
    }
}
