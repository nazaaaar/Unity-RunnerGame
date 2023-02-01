using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Platform : MonoBehaviour
{
    protected const float leftLimit = -12.5f, rightLimit = 12.5f;

    protected float speed;

    public float Speed { get => speed;  set => speed = value; }

    protected abstract void CheckCond();

    void Update()
    {
        CheckCond();
        transform.Translate(speed * Time.deltaTime, 0, 0);
    }

    void OnCollisionEnter(Collision collision)
    {
        
        collision.transform.parent = this.transform;
    }

    void OnCollisionExit(Collision collision)
    {
        collision.transform.parent = null;
    }
}
