using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : TankController
{
    public GameObject Player;

   private void Update()
    {
        Vector3 direction = Player.transform.position;
        var gunDirection = direction - transform.position;

        move(gunDirection);
        rotateGun(gunDirection);
        if (Random.Range(0, 100) % 50 == 0)
        {
            Shoot();
        }

    }
 
}