using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using LTAUnityBase.Base.DesignPattern;

public class TankController : MoveController
{
   
    public Transform bodyTank;
    public Transform gun;
    public BulletController bullet;
    public Transform transhoot;
    public float hp;
    public float level;
    public float time;
   
    

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
    protected virtual void Shoot()
    {
        //Instantiate(bullet, transhoot.transform.position, transhoot.transform.rotation);
        CreateBullet(transhoot);
        


    }

    protected virtual void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag != this.gameObject.tag)
        {
            // getComponent de lay thuoc tinh cua Object minh xac dinh roi .

            var calculateHP = collision.GetComponent<BulletController>();
            if (calculateHP is null)
            {
                return;
            }
            hp = calculateHP.CalculateHp(hp);

        }
       

    }

    public BulletController CreateBullet(Transform tranShoot)
    {  // tao ra vat mau la bullet voi kieu du lieu la bulletController 
        BulletController bulletclone = PoolingObject.createPooling<BulletController>(bullet);

        if (bulletclone == null)
        {
            Debug.Log("co di qua day");
            return Instantiate(bullet, transhoot.position, tranShoot.rotation);
            

        }

        bulletclone.time = 0;
        bulletclone.transform.position = tranShoot.position;
        bulletclone.transform.rotation = tranShoot.rotation;
        //
        bulletclone.damage += level;
        // tag cua vien dan bang = tank(Player) 

        bulletclone.tag = this.tag;
        return bulletclone;


    }


}

