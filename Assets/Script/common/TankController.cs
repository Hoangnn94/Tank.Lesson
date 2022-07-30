using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankController : MoveController
{
   
    public Transform bodyTank;
    public Transform gun;
    public GameObject bullet;
    public Transform transhoot;

    protected override void move(Vector3 direction) 
    {
        if (direction != Vector3.zero)
        {
            bodyTank.up = direction;
        }
        base.move(direction);
    }

    protected void rotateGun(Vector3 direction)
    {
        gun.up = direction;
    }
    public void Shoot()
    {
        Instantiate(bullet, transhoot.transform.position, transhoot.transform.rotation);
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "trigger1")
        {
            Destroy(gameObject);
            GameManager.instance.addScore();
        }
        if (collision.gameObject.tag == "trigger2")
        {
            Debug.Log("dinh dan");
        }

    }

}
