using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dice : MonoBehaviour
{
    Rigidbody rb;

    bool hasLanded;
    bool thrown;

    Vector3 initPosition;

    public DiceSides[] diceSides;
    public int dicevalue;

    public List<Player> playerList = new List<Player>();
    public int currentPlayer;
    public Player player;

    // Start is called before the first frame update
    void Start()
    {
        initPosition = transform.position;
        rb = GetComponent<Rigidbody>();
        rb.useGravity = false;
    }

    // Update is called once per frame
    public void RollDice(int PlayerNum)
    {
        Reset();
        currentPlayer = PlayerNum;
        if(!thrown & !hasLanded)
        {
            thrown = true;
            rb.useGravity=true;
            rb.AddTorque(Random.Range(0, 500), Random.Range(0, 500), Random.Range(0, 500));
        }
        else if(thrown && hasLanded)
        {
            //reset dice
            Reset();
        }
    }

    private void Reset()
    {
        transform.position= initPosition;
        rb.isKinematic = false;
        thrown = false;
        hasLanded = false;
        rb.useGravity = false;
        dicevalue = 0;
    }

    private void Update()
    {
        if(rb.IsSleeping() && ! hasLanded && thrown)
        {
            hasLanded = true;
            rb.useGravity = false;
            rb.isKinematic = true;


            //side value check
            SideValueCheck();
        }
        else if(rb.IsSleeping() &&hasLanded && dicevalue==0)
        {
            //roll again
            RollAgain();
        }
    }

    void RollAgain()
    {
        Reset();
        thrown = true;
        rb.useGravity = true;
        rb.AddTorque(Random.Range(0, 500), Random.Range(0, 500), Random.Range(0, 500));
    }

    void SideValueCheck()
    {
        foreach(DiceSides side in diceSides)
        {
            if (side.OnGround())
            {
                dicevalue = side.sideValue;
                //return value
                playerList[currentPlayer-1].RollDice(dicevalue);
            }
        }
    }
}
