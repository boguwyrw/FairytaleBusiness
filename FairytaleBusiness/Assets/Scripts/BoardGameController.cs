using System.Collections;
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
    private bool playerCanMove;

    public Text diceOneText;
    public Text diceTwoText;
    public Button rollDicesButton;
    public Button startButton;
    public Button endOfTurnButton;

    private void Start()
    {
        dicesPips = 0;
        playerNumber = 0;
        startGame = false;
        playerCanMove = false;

        diceOneText.transform.position = new Vector3(0.1f * Screen.width, 0.9f * Screen.height, 0);
        diceTwoText.transform.position = new Vector3(0.1f * Screen.width, 0.85f * Screen.height, 0);
        rollDicesButton.transform.position = new Vector3(0.1f * Screen.width, 0.75f * Screen.height, 0);
        startButton.transform.position = new Vector3(0.5f * Screen.width, 0.5f * Screen.height, 0);
        endOfTurnButton.transform.position = new Vector3(0.1f * Screen.width, 0.1f * Screen.height, 0);

        DeactivateRollDicesButton();
        DeactivateEndOfTurnButton();
    }

    private void Update()
    {
        if (startGame)
        {
            startButton.gameObject.SetActive(false);
        }

        diceOneText.text = "Dice 1: " + pipsFromDiceOne.ToString();
        diceTwoText.text = "Dice 2: " + pipsFromDiceTwo.ToString();
    }

    private void DeactivateRollDicesButton()
    {
        rollDicesButton.interactable = false;
    }

    private void ActivateRollDicesButton()
    {
        rollDicesButton.interactable = true;
    }

    private void DeactivateEndOfTurnButton()
    {
        endOfTurnButton.interactable = false;
    }

    private void ActivateEndOfTurnButton()
    {
        endOfTurnButton.interactable = true;
    }

    public void StartGame()
    {
        startGame = true;
        ActivateRollDicesButton();
    }

    public void RollDices()
    {
        if (startGame)
        {
            pipsFromDiceOne = Random.Range(1, 7);
            pipsFromDiceTwo = Random.Range(1, 7);
            dicesPips = pipsFromDiceOne + pipsFromDiceTwo;
            playerCanMove = true;
            DeactivateRollDicesButton();
            ActivateEndOfTurnButton();
        }
    }

    public void EndOfTurn()
    {
        if (startGame)
        {
            playerNumber += 1;
            if (playerNumber > 3)
            {
                playerNumber = 0;
            }
            playerCanMove = false;
            DeactivateEndOfTurnButton();
            ActivateRollDicesButton();
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

    public bool GetPlayerCanMove()
    {
        return playerCanMove;
    }

}
