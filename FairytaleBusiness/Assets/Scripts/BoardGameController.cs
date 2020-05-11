﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BoardGameController : MonoBehaviour
{

    private int pipsFromDiceOne;
    private int pipsFromDiceTwo;
    private int dicesPips;
    private int playerNumber;
    private bool startGame;

    public Button rollDicesButton;
    public Button startButton;

    private void Start()
    {
        dicesPips = 0;
        playerNumber = -1;
        startGame = false;

        rollDicesButton.transform.position = new Vector3(0.1f * Screen.width, 0.9f * Screen.height, 0);
        startButton.transform.position = new Vector3(0.5f * Screen.width, 0.5f * Screen.height, 0);
    }

    private void Update()
    {
        if (startGame)
        {
            startButton.gameObject.SetActive(false);
        }
    }

    public void StartGame()
    {
        startGame = true;
    }

    public void RollDices()
    {
        pipsFromDiceOne = Random.Range(1, 7);
        pipsFromDiceTwo = Random.Range(1, 7);
        dicesPips = pipsFromDiceOne + pipsFromDiceTwo;
        playerNumber += 1;
        if (playerNumber > 3)
        {
            playerNumber = 0;
        }
    }

    public int GetPlayerNumber()
    {
        return playerNumber;
    }

    public bool GetStartGame()
    {
        return startGame;
    }

    public int GetDicesPips()
    {
        return dicesPips;
    }

}
