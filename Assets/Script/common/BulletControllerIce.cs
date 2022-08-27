using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletControllerIce : BulletController, IceSkill
{
    public void EffIceBounding(GameObject oppoment)
    {
        var affected = oppoment.GetComponent<MoveController>();
        if (affected is null)
        {
            return;
        }
        affected.speed = 0;
    }

    public float Ice(int dameff)
    {
        Instantiate(prebIce, this.gameObject.transform.position, this.gameObject.transform.rotation);
        return dameff;
    }

    public GameObject prebIce;

    protected override void BulletEx()
    {
        if (time ==30)
        {
            Instantiate(prebIce, this.gameObject.transform.position, this.gameObject.transform.rotation);
        }
        base.BulletEx();
    }

   protected override void OnTriggerEnter2D(Collider2D collsion)
    {
        if (collsion.gameObject.tag == "Enemy")
        {
            damage += Ice(25);
            EffIceBounding(collsion.gameObject);
        }
    }
}
