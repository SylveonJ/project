using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RollDice : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    int dicevalue;
    public void Roll()
    {
        dicevalue = Random.Range(1, 7);

        Debug.Log(dicevalue);
    }
}
