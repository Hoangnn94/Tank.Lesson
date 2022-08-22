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
    public GameObject gun1;
    public Transform transhoot1;
    public GameObject gun2;
    public Transform transhoot2;
    private bool _itemGunUp = false;

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
        levelTxt.text = "Level Player: " + level.ToString();
        gun1.SetActive(_itemGunUp);
        gun2.SetActive(_itemGunUp);
        slider_hp.value = hp;
        if (hp <= 0)

        {
            //Destroy(this.gameObject);
        }
     
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");
        Vector3 direction = new Vector3(horizontal, vertical);
        move(direction);

       
        var position = Input.mousePosition;
        Vector3 gunDirectionmoba = new Vector3(
            position.x - Screen.width / 2,
            position.y - Screen.height / 2);
        rotateGun(gunDirectionmoba);

        if (Input.GetMouseButtonDown(0))
        {
            Shoot();
        }
    }

    protected override void Shoot()
    {
     if (_itemGunUp)
        {
            CreateBullet(transhoot1);
            Debug.Log("co ban dan khong o sung 2");
            CreateBullet(transhoot2);
            Debug.Log("co ban dan khong o sung 1");
        }
     base.Shoot();
        Debug.Log("có bắn ở súng chính");
    }


    private void LevelUp(object data)
    {
        float levelEnemy = (float)data;
        level += levelEnemy;
        levelTxt.text = "Level player: " + level.ToString();
    }
    
    protected override void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "ItemGunUp")
        {
            _itemGunUp = true;
            Destroy(collision.gameObject);
             
        }
        base.OnTriggerEnter2D(collision);
    }
}

public class Player : SingletonMonoBehaviour<PlayerController>
{
    
}
