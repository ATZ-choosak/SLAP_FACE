using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class TurnBaseUIHandler : MonoBehaviour
{
    public static TurnBaseUIHandler Instance;

    [SerializeField] private float gameTimer;
    [SerializeField] private float beforeStartTheGameTimer;
    [SerializeField] private TextMeshProUGUI gameTimerTxt;
    [SerializeField] private TextMeshProUGUI timeBeforeStart;
    [SerializeField] private Image playerTurnTimerLoad;

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

    public HealthBar enemyHp;
    public HealthBar playerHp;

    public bool IsStart = false , actionToEnemy = false;

    float maxPlayerTurnTimer;

    private void Start()
    {
        maxPlayerTurnTimer = playerTurnTimer;
    }

    private void Awake()
    {
        Instance = this;
    }


    public void startTurnBase()
    {
        IsStart = true;
    }

    void Update()
    {
        if (IsStart)
        {
            TurnSystem();
        }
        else
        {
            gameTimerTxt.gameObject.SetActive(false);
            enemyHp.gameObject.SetActive(false);
            playerHp.gameObject.SetActive(false);
        }
    }


    void TurnSystem()
    {
        //2 Seconds Before Start The Game
        if (beforeStartTheGameTimer > 0.01f)
        {
            timeBeforeStart.text = ((int)(beforeStartTheGameTimer)).ToString();
            beforeStartTheGameTimer -= Time.deltaTime;
        }

        //Start The Game
        else if (!isGameEnd)
        {
            timeBeforeStart.text = "";

            gameTimerTxt.gameObject.SetActive(true);
            enemyHp.gameObject.SetActive(true);
            playerHp.gameObject.SetActive(true);

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
                actionToEnemy = false;
                playerTurnTimerLoad.enabled = false;
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

                    playerHp.TakeDamage(Random.Range(8 , 10));

                    enemyTurnTimer = 5f;
                }
            }

            //Player Turn
            else if (!isEnemyTurn)
            {
                //Player Turn CountDown Timer
                playerTurnTimerLoad.enabled = true;
                playerTurnTimerLoad.fillAmount = playerTurnTimer / maxPlayerTurnTimer;
                playerTurnTimer -= Time.deltaTime;

                //When Player Turn Timer End Or Does An Action
                if (playerTurnTimer < 0.01f || actionToEnemy)
                {
                    //End The Enemy Turn
                    //Next Turn is Player Turn
                    isEnemyTurn = true;

                    //Announce Enemy Turn
                    announceTxtTimer = 1.5f;
                    isAnnounce = false;

                    playerTurnTimerTxt.enabled = false;
                    playerTurnTimerNumber.enabled = false;

                    playerTurnTimer = 30f;
                }
            }
        }
        //If Game End
        else if (isGameEnd)
        {
            gameEndTxt.enabled = true;
        }
    }

    public void takeDamageToEnemy(int damage)
    {
        if (!isEnemyTurn && IsStart)
        {
            actionToEnemy = true;
            enemyHp.TakeDamage(damage);
        }
        
    }

    private bool Action()
    {
        if (Input.GetKeyDown(KeyCode.S))
        {
            Debug.Log("S preesed!");
            
            return true;
        }
        else
            return false;
    }
}
