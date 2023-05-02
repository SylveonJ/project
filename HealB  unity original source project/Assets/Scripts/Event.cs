using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Event : MonoBehaviour
{
    //public Player player;
    public List<Player> playerList = new List<Player>();

    int choice;
    string Message;

    public GameObject EventUI;
    public Text UI_message;

    public void CheckEvent(int playerNum)
    {
        choice = Random.Range(1, 4);
        if (playerList[playerNum - 1].isCpu)
        {
            if (choice == 1)
            {
                playerList[playerNum - 1].extra_steps = 1;
            }
            else if (choice == 2)
            {
                playerList[playerNum - 1].extra_steps = -2;
            }
            else if (choice == 3)
            {
                playerList[playerNum - 1].HealthLevel-= 2;
            }
        }
        else
        {
            if (choice == 1)
            {
                playerList[playerNum - 1].extra_steps = 1;
                Message = "You get a bike.\n You can move one more step for next turn.";
            }
            else if (choice == 2)
            {
                playerList[playerNum - 1].extra_steps = -1;
                playerList[playerNum - 1].HealthLevel -= 1;
                Message = "You break your leg.\nYour next movement decrease.";
            }
            else if (choice == 3)
            {
                playerList[playerNum - 1].HealthLevel -= 4;
                Message = "You've found a great novel.\n You stay up all night to finish it.";
            }


            EventUI.SetActive(true);
            UI_message.text = Message;
        }

    }


    public void closeButton()
    {
        EventUI.SetActive(false);
    }

}
