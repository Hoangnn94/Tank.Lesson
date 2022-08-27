using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using LTAUnityBase.Base.DesignPattern;


public class GameManager : MonoBehaviour
{
    

    public EnemyController tankEnemy;
    public int scorePlayer;
    public Text scoreTxt;
    public GameObject Gate;
    public int levelPlayer;
    public Text levelTxt;

    private void Awake()
    {
        // khoi tao observer 
        Observer.Instance.AddObserver(TOPICNAME.ENEMYDESTROY, addScore);
        Observer.Instance.AddObserver(TOPICNAME.ENEMYDESTROY, addLevel);
    }

    private void Update()
    {
        scoreTxt.text = "score : " + scorePlayer.ToString();
        levelTxt.text = "level : " + levelPlayer.ToString();

    }

    public void addScore(object data)
    {
        // co cong diem 
        scorePlayer += 10;
        Instantiate(tankEnemy, Gate.transform.position, Gate.transform.rotation);
    }

    public void addLevel(object data)
    {
        levelPlayer += 50;
    }

    public void Respawn ()
     {
      Debug.Log("da chay qua day");
     }

}
public class Gamer : SingletonMonoBehaviour<GameManager>
{
    
}