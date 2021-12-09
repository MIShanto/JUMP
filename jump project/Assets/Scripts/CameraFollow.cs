using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField] Transform target;

    [SerializeField] float smoothSpeed;
    [SerializeField] float upOffset;
    [SerializeField] float downOffset;
    [SerializeField] Vector3 offset;

    private void FixedUpdate()
    {
        if (target.transform.position.y >= transform.position.y + upOffset || target.transform.position.y <= transform.position.y - downOffset)
        {
            Vector3 desiredPosition = new Vector3(transform.position.x, target.position.y + offset.y, transform.position.z);
            //desiredPosition.x = 0;
            Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed * Time.deltaTime);
            //smoothedPosition.x = 0;
            //if(target.transform.position.y >= transform.position.y + offset.y)
            transform.position = smoothedPosition;

            //transform.LookAt(target);
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawLine(new Vector2(transform.position.x, transform.position.y + upOffset), new Vector2(transform.position.x + 20, transform.position.y + upOffset));
        Gizmos.DrawLine(new Vector2(transform.position.x, transform.position.y - downOffset), new Vector2(transform.position.x - 20, transform.position.y - downOffset));
    }

}
