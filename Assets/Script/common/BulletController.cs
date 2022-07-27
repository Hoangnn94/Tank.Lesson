using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MoveController
{
    public float speed;
    private float time = 0;
    public GameObject smoke;
    public float timeLimit;

    void Update()
    {
        move(this.transform.up);
        BulletEx();
        

    }
    protected virtual void BulletEx()
    {
    if (time == timeLimit)
        {
        Destroy(this.gameObject);
        Instantiate(smoke, this.gameObject.transform.position, this.gameObject.transform.rotation);
        }
        time++;

     }
}
