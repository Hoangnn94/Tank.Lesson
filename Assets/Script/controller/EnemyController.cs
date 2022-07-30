using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : TankController
{
    
   private void Update()
    {
        var Player = PlayerController.instance.gameObject.transform;
        Vector3 direction = Player.position;
        var gunDirection = direction - transform.position;

        move(gunDirection);
        rotateGun(gunDirection);
        if (Random.Range(0, 100) % 50 == 0)
        {
            Shoot();

        }

    }
 
}