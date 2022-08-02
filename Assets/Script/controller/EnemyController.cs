using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using LTAUnityBase.Base.DesignPattern;
public class EnemyController : TankController
{
    
   private void Update()
    {
        var player = Player.Instance.gameObject.transform;
        Vector3 direction = player.position;
        var gunDirection = direction - transform.position;

        move(gunDirection);
        rotateGun(gunDirection);
        if (Random.Range(0, 100) % 50 == 0)
        {
            Shoot();

        }
        if (hp <= 0)
        { Destroy.this.gameObject;
            Observer.Instance.Notify(TOPICNAME.ENEMYDESTROY, level);
        }
    }
 
}