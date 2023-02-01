using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OneWayPlatform : Platform
{
    protected override void CheckCond()
    {
        if(transform.position.x > rightLimit)
        {
            transform.DetachChildren();
            transform.position = new Vector3(leftLimit, 0, transform.position.z);
            
        }
        else if (transform.position.x < leftLimit)
        {
            transform.DetachChildren();
            transform.position = new Vector3(rightLimit, 0, transform.position.z);
        }
    }
}
