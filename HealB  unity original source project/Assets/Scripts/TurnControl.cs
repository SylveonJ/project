using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class TurnControl : MonoBehaviour
{

    public int turn = 1;
    public int y = 1;

    public GameObject P1UI;
    public GameObject P2UI;
    public GameObject P3UI;
    public GameObject P4UI;
    // Start is called before the first frame update
    void Start()
    {
        //  DontDestroyOnLoad(this.gameObject);

        GameObject player1 = GameObject.Find("Player1");
        GameObject player2 = GameObject.Find("Player2");
        GameObject player3 = GameObject.Find("Player3");
        GameObject player4 = GameObject.Find("Player4");

        //GameObject P1UI = GameObject.Find("P1UI");
        //GameObject P2UI = GameObject.Find("P2UI");


        if (turn == 1)
        {
            player1.GetComponent<Player>().enabled = true;
            P1UI.SetActive(true);
            //playerCamera.GetComponent<Camera>().enabled = true;
        }
        if (turn == 2)
        {
            player1.GetComponent<Player>().enabled = false;
            player2.GetComponent<Player>().enabled = true;

            P1UI.SetActive(false);
            P2UI.SetActive(true);
            //playerCamera.GetComponent<Camera>().enabled = false;
            //player2Camera.GetComponent<Camera>().enabled = true;
        }
        //if (turn == 3)
        //{
        //    player2.GetComponent<Player>().enabled = false;
        //    P2UI.SetActive(false);
        //    y = 1;
        //}
        if (turn == 3)
        {
            player2.GetComponent<Player>().enabled = false;
            player3.GetComponent<Player>().enabled = true;

            P2UI.SetActive(false);
            P3UI.SetActive(true);
        }
        if (turn == 4)
        {
            player3.GetComponent<Player>().enabled = false;
            player4.GetComponent<Player>().enabled = true;

            P3UI.SetActive(false);
        }
        if (turn == 5)
        {
            player4.GetComponent<Player>().enabled = false;
            y = 1;
        }

    }
    // Update is called once per frame
    void Update()
    {
        if (turn != y)
        {
            turn = y;
            Start();
        }
    }
}
