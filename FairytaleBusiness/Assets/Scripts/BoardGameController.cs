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
    private int playerOneLocation;
    private int playerTwoLocation;
    private int playerThreeLocation;
    private int playerFourLocation;

    public Text diceOneText;
    public Text diceTwoText;
    public Button startButton;
    public Button rollDicesButton;
    public Button buyFieldButton;
    public Button endOfTurnButton;

    private void Start()
    {
        dicesPips = 0;
        playerNumber = 0;
        startGame = false;
        playerCanMove = false;
        playerOneLocation = 0;
        playerTwoLocation = 0;
        playerThreeLocation = 0;
        playerFourLocation = 0;

        diceOneText.transform.position = new Vector3(0.1f * Screen.width, 0.9f * Screen.height, 0);
        diceTwoText.transform.position = new Vector3(0.1f * Screen.width, 0.85f * Screen.height, 0);
        startButton.transform.position = new Vector3(0.5f * Screen.width, 0.5f * Screen.height, 0);
        rollDicesButton.transform.position = new Vector3(0.1f * Screen.width, 0.75f * Screen.height, 0);
        buyFieldButton.transform.position = new Vector3(0.1f * Screen.width, 0.5f * Screen.height, 0);
        endOfTurnButton.transform.position = new Vector3(0.1f * Screen.width, 0.1f * Screen.height, 0);

        DeactivateRollDicesButton();
        DeactivateBuyFieldButton();
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

    private void DeactivateBuyFieldButton()
    {
        buyFieldButton.interactable = false;
    }

    private void ActivateBuyFieldButton()
    {
        buyFieldButton.interactable = true;
    }

    private void DeactivateEndOfTurnButton()
    {
        endOfTurnButton.interactable = false;
    }

    private void ActivateEndOfTurnButton()
    {
        endOfTurnButton.interactable = true;
    }

    private void PlayersCurrentLocation()
    {
        if (playerNumber == 0)
        {
            playerOneLocation = playerOneLocation + dicesPips;
            if (playerOneLocation > 39)
            {
                playerOneLocation = playerOneLocation - 40;
            }
        }

        if (playerNumber == 1)
        {
            playerTwoLocation = playerTwoLocation + dicesPips;
            if (playerTwoLocation > 39)
            {
                playerTwoLocation = playerTwoLocation - 40;
            }
        }

        if (playerNumber == 2)
        {
            playerThreeLocation = playerThreeLocation + dicesPips;
            if (playerThreeLocation > 39)
            {
                playerThreeLocation = playerThreeLocation - 40;
            }
        }

        if (playerNumber == 3)
        {
            playerFourLocation = playerFourLocation + dicesPips;
            if (playerFourLocation > 39)
            {
                playerFourLocation = playerFourLocation - 40;
            }
        }
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
            PlayersCurrentLocation();
            playerCanMove = true;
            if (pipsFromDiceOne == pipsFromDiceTwo)
            {
                ActivateRollDicesButton();
                ActivateBuyFieldButton();
                DeactivateEndOfTurnButton();
            }
            else
            {
                DeactivateRollDicesButton();
                ActivateBuyFieldButton();
                ActivateEndOfTurnButton();
            }
        }
    }

    public void BuyField()
    { 
        
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
            DeactivateBuyFieldButton();
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

    public int GetPlayerOneLocation()
    {
        return playerOneLocation;
    }

    public int GetPlayerTwoLocation()
    {
        return playerTwoLocation;
    }

    public int GetPlayerThreeLocation()
    {
        return playerThreeLocation;
    }

    public int GetPlayerFourLocation()
    {
        return playerFourLocation;
    }

}
