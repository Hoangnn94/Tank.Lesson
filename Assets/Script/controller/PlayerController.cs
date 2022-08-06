using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using LTAUnityBase.Base.DesignPattern;

// PlayerController kế thừa TankController
public class PlayerController : TankController
{
    public Text levelTxt;
    public Slider slider_hp;

    private void Awake()
    {
        // giá trị thanh slider chính là Hp của tank 
        slider_hp.maxValue = hp;
    }
    private void Start()
    {
        Observer.Instance.AddObserver(TOPICNAME.ENEMYDESTROY, LevelUp);
    }
    void Update()
    { 
        slider_hp.value = hp;
        if (hp <= 0)

        {
            //Destroy(this.gameObject);
        }
        // dùng A,D,W,S hay cá phím mũi tên để di chuyển tank
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");
        Vector3 direction = new Vector3(horizontal, vertical);
        move(direction);

        //hướng của súng bằng vị trí của chuột
        var position = Input.mousePosition;
        Vector3 gunDirectionmoba = new Vector3(
            position.x - Screen.width / 2,
            position.y - Screen.height / 2);
        rotateGun(gunDirectionmoba);

        //ấn 1 lần chuột là bắn 
        if (Input.GetMouseButtonDown(0))
        {
            Shoot(); 
        }

    }

    private void LevelUp(object data)
    {
        float levelEnemy = (float)data;
        level += levelEnemy;
        levelTxt.text = "Level player: " + level.ToString();
    }
    
}

public class Player : SingletonMonoBehaviour<PlayerController>
{
    
}
