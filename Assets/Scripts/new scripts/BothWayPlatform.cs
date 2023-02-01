using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BothWayPlatform : Platform
{

    protected override void CheckCond()
    {
        if (transform.position.x >= rightLimit || transform.position.x <= leftLimit)
        {
            speed *= -1;
        }

    }
}
