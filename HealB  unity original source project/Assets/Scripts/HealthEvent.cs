using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthEvent : MonoBehaviour
{
    //public Player player;
    public List<Player> playerList = new List<Player>();

    int choice;
    string Message;
    int change;
    public int PlayerTurn;

    public GameObject HealthUI;
    public Text UI_message;

    public Item Apple;
    Item currentItem;


    public List<Item> ItemList1;
    public List<Item> ItemList2;

    //do the health event avtion
    public void CheckHealthEvent(int playerNum)
    {
        PlayerTurn = playerNum;
        choice = Random.Range(1, 7);
        if (playerList[playerNum - 1].isCpu)
        {
            if (choice == 1 || choice == 2 || choice == 3)
            {
                playerList[playerNum-1].HealthLevel += 1;
            }
            else if (choice == 4 || choice == 5)
            {
                playerList[playerNum - 1].HealthLevel += 0;
            }
            else if (choice == 6)
            {
                playerList[playerNum - 1].HealthLevel += 2;
            }
            //else if (choice == 8)
            //{
            //    playerList[playerNum - 1].HealthLevel -= 1;
            //}
            //else if (choice == 9 || choice == 10)
            //{
            //    playerList[playerNum - 1].HealthLevel += 2;
            //}
        }
        else
        {
            if (choice == 1 || choice == 2 || choice == 3)
            {
                //playerList[playerNum-1].HealthLevel += 1;
                Message = "You've found an apple tree. There are lots of apples on the apple tree. Do you want to pick an apple and take it with you?";
                playerList[playerNum - 1].HealthChange = -1;
                currentItem = playerList[playerNum - 1].ItemList[0];
            }
            else if (choice == 4 || choice == 5)
            {
                //playerList[playerNum - 1].HealthLevel += 0;
                Message = "You get one beef";
                playerList[playerNum - 1].HealthChange = -1;
                currentItem = playerList[playerNum - 1].ItemList[1];
            }
            else if (choice == 6)
            {
                //playerList[playerNum - 1].HealthLevel += 2;
                Message = "You've caught a fish";
                playerList[playerNum - 1].HealthChange = -1;
                currentItem = playerList[playerNum - 1].ItemList[2];
            }
            //else if (choice == 8)
            //{
            //    Message = "Your parents want to give you a pair of sports shoes as gift. Do you want it?";
            //    currentItem = playerList[playerNum - 1].ItemList[3];
            //}
            //else if (choice == 9 || choice == 10)
            //{
            //    Message = "Your parents want to give you a pair of sports shoes as gift. Do you want it?";
            //    currentItem = playerList[playerNum - 1].ItemList[4];
            //}

            //make UI active
            HealthUI.SetActive(true);
            UI_message.text = Message;
        }
        

    }

    //do the bad event avtion
    public void CheckBadEvent(int playerNum)
    {
        PlayerTurn = playerNum;
        choice = Random.Range(1, 7);
        if (playerList[playerNum - 1].isCpu)
        {
            if (choice == 1 || choice == 2 || choice == 3)
            {
                playerList[playerNum - 1].HealthLevel -= 1;
            }
            else if (choice == 4 || choice == 5)
            {
                playerList[playerNum - 1].HealthLevel += 0;
            }
            else if (choice == 6)
            {
                playerList[playerNum - 1].HealthLevel -= 2;
            }

        }
        else
        {
            if (choice == 1 || choice == 2 || choice == 3)
            {
                //playerList[playerNum - 1].HealthLevel -= 1;
                Message = "You've found a bottle of cola";
                playerList[playerNum - 1].HealthChange = -1;
                currentItem = playerList[playerNum - 1].ItemList[3];
            }
            else if (choice == 4 || choice == 5)
            {
                //playerList[playerNum - 1].HealthLevel += 0;
                Message = "You've found a packet of crisps";
                playerList[playerNum - 1].HealthChange = -1;
                currentItem = playerList[playerNum - 1].ItemList[4];
            }
            else if (choice == 6)
            {
                //playerList[playerNum - 1].HealthLevel -= 2;
                Message = "Your friend share you a cup of bubble tea";
                playerList[playerNum - 1].HealthChange = -2;
                currentItem = playerList[playerNum - 1].ItemList[5];
            }
            //make UI active
            HealthUI.SetActive(true);
            UI_message.text = Message;
        }
    }


    //Close UI
    public void closeButton()
    {
        HealthUI.SetActive(false);
    }
    public void AcceptButton()
    {
        PlayerTurn = GameObject.Find("TurnControl").GetComponent<TurnControl>().y;
        //playerList[PlayerTurn -1].IncreaseHealth();
        playerList[PlayerTurn - 1].IncreaseItem(currentItem);
        HealthUI.SetActive(false);
    }
}
