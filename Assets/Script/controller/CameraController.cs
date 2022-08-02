using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using LTAUnityBase.Base.DesignPattern;
public class CameraController : MonoBehaviour
{
 

    void Update()
    {
        var CarmeraPos = Player.Instance.transform;
        Vector3 newPos = new Vector3(CarmeraPos.position.x, CarmeraPos.position.y, -10f);
        transform.position = Vector3.Lerp(transform.position, newPos, 0.3f);

    }
}

