using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    public Route currentRoute;

    public static Player instance;

    int routePosition;

    public int steps;
    public int extra_steps;

    bool isMoving;

    public GameManager tiles;
    public HealthBar HealthBar;

    public int currentTilePos;
    public Tile currentTile;
    public string TileType;

    public int PlayerNum;

    public bool isCpu;

    public int HealthLevel=15;
    public int HealthChange=0;
    int maxHealthLevel = 30;
    public bool TurnAction = true;
    public bool DiceAction = false;
    public bool EndTurn = false;

    public GameObject winUI;
    public Text endMessage;
    public Text Health;

    public HealthEvent HealthEvent;
    public Text EventMessage;

    public GameObject MoveUI;
    public Text MoveMessage;

    public Event Event;

    public Dice dice;
    public GameObject RollButton;
    public GameObject EndButton;

    public GameObject BagUI;

    public BagList PlayerBag;
    public List<Item> ItemList;


    private void Awake()
    {
        instance = this;
    }
    private void Start()
    {
        TurnAction = true;
        if (BagUI != null)
        {
            BagUI.SetActive(false);
        }
    }
    private void Update()
    {
        if (isCpu)
        {
            if (!DiceAction)
            {
                DiceButton();
            }
            else if(!TurnAction)
            {
                EndTurnCPU();
            }
        }
        //Health.text = "Player " + PlayerNum + " Health: " + HealthLevel.ToString();
        Health.text = "P" + PlayerNum;
        HealthBar.UpdateHealthBar(HealthLevel, maxHealthLevel);
        if (HealthLevel > maxHealthLevel)
        {
            Win();
        }
        if (EndTurn)//check if the end turn is finish
        {
            tiles.currentPlayer = GameObject.Find("TurnControl").GetComponent<TurnControl>().y;
            GameObject.Find("TurnControl").GetComponent<TurnControl>().y++;
            EndTurn = false;
        }
    }

    IEnumerator Move()
    {
        if (isMoving)
        {
            yield break;
        }

        isMoving = true;

        while (steps > 0)
        {
            routePosition++;
            routePosition %= currentRoute.childNodeList.Count;

            Vector3 nextPos = currentRoute.childNodeList[routePosition].position;
            while (MoveToNextNode(nextPos))
            {
                yield return null;
            }

            yield return new WaitForSeconds(0.1f);

            steps--;
            //routePosition++;
            currentTilePos = routePosition;
        }

        isMoving = false;
        currentTilePos = routePosition;

        TileType = tiles.tileList[currentTilePos].type;
        checkTileAction(TileType);
        TurnAction = false;
        EndButton.SetActive(true);
    }

    bool MoveToNextNode(Vector3 goal)
    {
        return goal != (transform.position = Vector3.MoveTowards(transform.position, goal, 2f * Time.deltaTime));

    }

    public void checkTileAction(string type)
    {

        if (type == "Health")
        {
            Debug.Log("Good");
            HealthEvent.CheckHealthEvent(PlayerNum);
        }

        if (type == "BadThing")
        {
            Debug.Log("BadThing");
            HealthEvent.CheckBadEvent(PlayerNum);
        }

        if (type == "Event")
        {
            Debug.Log("Event");
            Event.CheckEvent(PlayerNum);
            return;
        }
    }

    public void EndTurnButton()
    {
        RollButton.SetActive(true);
        EndButton.SetActive(false);
        EndTurn = true;
        Debug.Log("End turn works");
    }

    public void DiceButton()
    {
        //Hide the button after click on it
        RollButton.SetActive(false);
        DiceAction = true;
        dice.RollDice(PlayerNum);

        //steps = dice.dicevalue;
        //steps = Random.Range(1, 7);
        //Debug.Log(steps);
        //DiceAction = true;
        //Debug.Log("Dice turn works");
        //StartCoroutine(Move());
    }
    public void RollDice(int _diceNumber)
    {
        int diceNumber = _diceNumber;
        //steps = dice.dicevalue;
        steps = diceNumber;
        steps += extra_steps;
        if (steps < 0)
        {
            steps = 0;
        }
        extra_steps = 0;
        Debug.Log(steps);
        DiceAction = true;
        Debug.Log("Dice turn works");
        if(steps == 0)
        {
            if (!isCpu)
            {
                MoveUI.SetActive(true);
            }
            TurnAction = false;
        }
        else
        {
            StartCoroutine(Move());
        }
    }

    public void TestButton()
    {
        TileType = tiles.tileList[currentTilePos].type;
        checkTileAction(TileType);
        Health.text = "Player 1 Health: " + HealthLevel.ToString();
    }

    public void Test2Button()
    {
        TileType = tiles.tileList[currentTilePos].type;
        checkTileAction(TileType);
        Health.text = "Player 2 Health:" + HealthLevel.ToString();
    }


    public void Win()
    {
        winUI.SetActive(true);
        if (PlayerNum == 1)
        {
            endMessage.text = "You win the game.";
        }
        else
        {
            endMessage.text = "<color=red>Player " + PlayerNum + " Win\nYou have lost the game</color>";
        }
    }

    public void QuitButton()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void BagButton()
    {
        BagUI.SetActive(true);
    }

    public void EndTurnCPU()
    {
        EndTurn = true;
        TurnAction = true;
        DiceAction = false;
    }
    public void UseButton() { 
    }

    public void IncreaseHealth()
    {
        HealthLevel += HealthChange;
        HealthChange = 0;
        Health.text = "Player " + PlayerNum + " Health: " + HealthLevel.ToString();
        Debug.Log("Action happen");
    }

    public void IncreaseItem(Item thisitem)
    {
        if (!PlayerBag.itemList.Contains(thisitem))
        {
            PlayerBag.itemList.Add(thisitem);
            //BagManager.CreateNewItem(thisitem);
        }
        else
        {
            thisitem.ItemHeld += 1;
        }
        BagManager.RefreshItem();
    }
    IEnumerator Wait(int time)
    {
        yield return new WaitForSeconds(time);
    }
}
