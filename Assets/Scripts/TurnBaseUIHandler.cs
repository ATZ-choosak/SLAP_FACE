using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TurnBaseUIHandler : MonoBehaviour
{
    [SerializeField] private float gameTimer;
    [SerializeField] private float beforeStartTheGameTimer;
    [SerializeField] private TextMeshProUGUI gameTimerTxt;

    private bool isGameEnd = false;
    [SerializeField] private TextMeshProUGUI gameEndTxt;

    //Announce Variables
    [SerializeField] private float announceTxtTimer;
    private bool isAnnounce;

    //Enemy Turn Variables
    private bool isEnemyTurn = false;
    [SerializeField] private float enemyTurnTimer;
    [SerializeField] private TextMeshProUGUI enemyTurnAnnounceTxt;
    [SerializeField] private TextMeshProUGUI enemyTurnTimerTxt;
    [SerializeField] private TextMeshProUGUI enemyTurnTimerNumber;

    //Player Turn Variables
    [SerializeField] private float playerTurnTimer;
    [SerializeField] private TextMeshProUGUI playerTurnAnnounceTxt;
    [SerializeField] private TextMeshProUGUI playerTurnTimerTxt;
    [SerializeField] private TextMeshProUGUI playerTurnTimerNumber;

    private HealthBar enemyHp;
    private HealthBar playerHp;
    
    void Start()
    {
        enemyHp = GameObject.FindWithTag("Enemy").GetComponentInChildren<HealthBar>();
        playerHp = GameObject.FindWithTag("Player").GetComponentInChildren<HealthBar>();
    }

    void Update()
    {
        //2 Seconds Before Start The Game
        if (beforeStartTheGameTimer > 0.01f)
            beforeStartTheGameTimer -= Time.deltaTime;
        //Start The Game
        else if (!isGameEnd)
        {
            //Announce Whose Turn
            if (!isAnnounce)
            {
                announceTxtTimer -= Time.deltaTime;
                if (isEnemyTurn)
                {
                    playerTurnAnnounceTxt.enabled = false;
                    enemyTurnAnnounceTxt.enabled = true;
                    enemyTurnTimerNumber.enabled = true;
                    enemyTurnTimerTxt.enabled = true;
                }
                else if (!isEnemyTurn)
                {
                    enemyTurnAnnounceTxt.enabled = false;
                    playerTurnAnnounceTxt.enabled = true;
                    playerTurnTimerNumber.enabled = true;
                    playerTurnTimerTxt.enabled = true;
                }

                //After 1.5 Sec Announce Text Will Disappear
                if (announceTxtTimer <= 0)
                {
                    enemyTurnAnnounceTxt.enabled = false;
                    playerTurnAnnounceTxt.enabled = false;

                    isAnnounce = true;
                }
            }

            //Enemy Turn
            if (isEnemyTurn)
            {
                //Game Timer Will Count When Enemy's Turn
                if (gameTimer > 0.01f)
                {
                    gameTimer -= Time.deltaTime;
                    gameTimerTxt.text = gameTimer.ToString("0");

                    //Game End
                    if (gameTimer < 0f)
                        isGameEnd = true;

                }

                //Enemy Turn CountDown Timer
                enemyTurnTimer -= Time.deltaTime;
                enemyTurnTimerNumber.text = enemyTurnTimer.ToString("0");

                //When Enemy Turn Timer End
                if (enemyTurnTimer < 0.01f)
                {
                    //End The Enemy Turn
                    //Next Turn is Player Turn
                    isEnemyTurn = false;

                    //Announce Player Turn
                    announceTxtTimer = 1.5f;
                    isAnnounce = false;

                    enemyTurnTimerTxt.enabled = false;
                    enemyTurnTimerNumber.enabled = false;

                    playerHp.TakeDamage(8);

                    enemyTurnTimer = 5f;
                }
            }

            //Player Turn
            else if (!isEnemyTurn)
            {
                //Player Turn CountDown Timer
                playerTurnTimer -= Time.deltaTime;
                playerTurnTimerNumber.text = playerTurnTimer.ToString("0");

                //When Player Turn Timer End Or Does An Action
                if (playerTurnTimer < 0.01f || Action())
                {
                    //End The Enemy Turn
                    //Next Turn is Player Turn
                    isEnemyTurn = true;

                    //Announce Enemy Turn
                    announceTxtTimer = 1.5f;
                    isAnnounce = false;

                    playerTurnTimerTxt.enabled = false;
                    playerTurnTimerNumber.enabled = false;

                    playerTurnTimer = 20f;
                }
            }
        }
        //If Game End
        else if (isGameEnd)
        {
            gameEndTxt.enabled = true;
        }
    }

    private bool Action()
    {
        if (Input.GetKeyDown(KeyCode.S))
        {
            Debug.Log("S preesed!");
            enemyHp.TakeDamage(10);
            return true;
        }
        else
            return false;
    }
}
