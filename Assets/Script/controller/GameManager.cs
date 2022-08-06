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

    private void Awake()
    {
        Observer.Instance.AddObserver(TOPICNAME.ENEMYDESTROY, addScore);
    }

    private void Update()
    {
        scoreTxt.text = "score : " + scorePlayer.ToString();
        scoreTxt.text = "level : " + levelPlayer.ToString();

    }

    public void addScore(object data)
    {
        scorePlayer += 10;
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