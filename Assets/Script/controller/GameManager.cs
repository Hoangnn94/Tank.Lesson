using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using LTAUnitybase.Base.DesignPattern;


public class GameManager : MonoBehaviour
{
    public EnemyController tankEnemy;
    public int scorePlayer;
    public GameObject gate;
    public Text scoreTxt;
    public int levelPlayer;

    public void Awake()
    {
        Observer.Instance.AddObsever(TOPICNAME.ENEMYDESTROY, addScore);

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
}
