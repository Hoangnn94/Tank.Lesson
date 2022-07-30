using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
 

    void Update()
    {
        var CarmeraPos = PlayerController.instance.transform;
        Vector3 newPos = new Vector3(CarmeraPos.position.x, CarmeraPos.position.y, -10f);
        transform.position = Vector3.Lerp(transform.position, newPos, 3.3f);

    }
}
