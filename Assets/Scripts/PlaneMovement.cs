using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaneMovement : MonoBehaviour
{
    public float speed = 1;
    public int type = 1;
    private readonly float bound = 14;
    void Start()
    {
        //speed /= 60;
    }

    // Update is called once per frame
    void Update()
    {
        if (type == 1)
        {
            if (transform.position.x < -bound) {  transform.DetachChildren(); transform.position = new Vector3(bound, 0, transform.position.z); }
            else if (transform.position.x > bound){  transform.DetachChildren(); transform.position = new Vector3(-bound, 0, transform.position.z); }
        }
        else if (type == 2)
        {
            if (transform.position.x <= -bound) speed = Mathf.Abs(speed);
            else if (transform.position.x >= bound) speed = -Mathf.Abs(speed);
        }
        transform.Translate(speed * Time.deltaTime, 0, 0);
    }

    void OnCollisionEnter(Collision collision)
    {
        collision.transform.parent.parent = this.transform;
    }

    void OnCollisionExit(Collision collision)
    {
        collision.transform.parent.parent = null;
    }
}
