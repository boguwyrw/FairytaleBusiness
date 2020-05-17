using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

public class PlayersController : MonoBehaviour
{

    private List<Transform> playersList = new List<Transform>();
    private BoardGameController boardGameController;
    private int movePlayerNumber;
    private bool isPlayerMoving;
    private List<Color32> playersColorsList = new List<Color32>();
    private Color32 playerColor;
    private bool letsStartGame;
    // Players location
    private int player_1_Location;
    private int player_2_Location;
    private int player_3_Location;
    private int player_4_Location;
    private int playerLocation;
    // buying Fields
    private bool canBuyField;
    private BuyFieldController buyFieldController;
    private List<int> playersMoneyList = new List<int>();
    private int fieldPrice;
    private BoardGameFieldsPrices boardGameFieldsPrices;
    // fee for park on another player's field
    private Color32 currentFieldColor;
    //private bool playerMustPay;
    private bool playerPaid;

    public List<Transform> boardGameWaypointsPath = new List<Transform>();
    public Text player_1_Text;
    public Text player_2_Text;
    public Text player_3_Text;
    public Text player_4_Text;
    public Image player_1_Image;
    public Image player_2_Image;
    public Image player_3_Image;
    public Image player_4_Image;

    private void Start()
    {
        for (int i = 0; i < gameObject.transform.childCount; i++)
        {
            playersList.Add(gameObject.transform.GetChild(i));
            playersColorsList.Add(gameObject.transform.GetChild(i).GetComponent<Renderer>().material.color);
        }

        boardGameController = FindObjectOfType<BoardGameController>();
        movePlayerNumber = 0;
        isPlayerMoving = false;
        // Values of Players location
        player_1_Location = 0;
        player_2_Location = 0;
        player_3_Location = 0;
        player_4_Location = 0;
        playerLocation = 0;
        playerColor = new Color32(0, 0, 0, 255);
        letsStartGame = false;

        canBuyField = false;
        buyFieldController = FindObjectOfType<BuyFieldController>();

        for (int i = 0; i < playersList.Count; i++)
        {
            playersMoneyList.Add(1500);
        }

        fieldPrice = 0;
        boardGameFieldsPrices = FindObjectOfType<BoardGameFieldsPrices>();
        // fee for park on another player's field
        playerPaid = false;

        player_1_Text.transform.position = new Vector3(0.06f * Screen.width, 0.2f * Screen.height, 0);
        player_2_Text.transform.position = new Vector3(0.14f * Screen.width, 0.2f * Screen.height, 0);
        player_3_Text.transform.position = new Vector3(0.06f * Screen.width, 0.1f * Screen.height, 0);
        player_4_Text.transform.position = new Vector3(0.14f * Screen.width, 0.1f * Screen.height, 0);
        player_1_Image.gameObject.SetActive(false);
        player_2_Image.gameObject.SetActive(false);
        player_3_Image.gameObject.SetActive(false);
        player_4_Image.gameObject.SetActive(false);
    }

    private void Update()
    {
        movePlayerNumber = boardGameController.GetPlayerNumber();
        isPlayerMoving = boardGameController.GetPlayerCanMove();
        player_1_Location = boardGameController.GetPlayerOneLocation();
        player_2_Location = boardGameController.GetPlayerTwoLocation();
        player_3_Location = boardGameController.GetPlayerThreeLocation();
        player_4_Location = boardGameController.GetPlayerFourLocation();

        CurrentPlayersLocation();

        letsStartGame = boardGameController.GetStartGame();

        canBuyField = buyFieldController.GetCanBuyOrCanNotBuy();
        fieldPrice = boardGameFieldsPrices.GetFieldsPrices();

        // fee for park on another player's field
        PlayerMustPayAction();

        player_1_Text.text = playersMoneyList[0].ToString();
        player_2_Text.text = playersMoneyList[1].ToString();
        player_3_Text.text = playersMoneyList[2].ToString();
        player_4_Text.text = playersMoneyList[3].ToString();
        /*
        foreach (Transform player in playersList)
        {
            Debug.Log(player.position.x.ToString() + " , " + player.position.z.ToString());
        }
        */
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playersMoneyList[movePlayerNumber] = playersMoneyList[movePlayerNumber] + 200;
        }
    }

    private void CurrentPlayersLocation()
    {
        switch (movePlayerNumber)
        {
            case 0:
                if (letsStartGame)
                {
                    player_1_Image.gameObject.SetActive(true);
                }
                player_4_Image.gameObject.SetActive(false);
                if (isPlayerMoving)
                {
                    playersList[0].GetComponent<NavMeshAgent>().SetDestination(boardGameWaypointsPath[player_1_Location].transform.position);
                }
                break;
            case 1:
                player_2_Image.gameObject.SetActive(true);
                player_1_Image.gameObject.SetActive(false);
                if (isPlayerMoving)
                {
                    playersList[1].GetComponent<NavMeshAgent>().SetDestination(boardGameWaypointsPath[player_2_Location].transform.position);
                }
                break;
            case 2:
                player_3_Image.gameObject.SetActive(true);
                player_2_Image.gameObject.SetActive(false);
                if (isPlayerMoving)
                {
                    playersList[2].GetComponent<NavMeshAgent>().SetDestination(boardGameWaypointsPath[player_3_Location].transform.position);
                }
                break;
            case 3:
                player_4_Image.gameObject.SetActive(true);
                player_3_Image.gameObject.SetActive(false);
                if (isPlayerMoving)
                {
                    playersList[3].GetComponent<NavMeshAgent>().SetDestination(boardGameWaypointsPath[player_4_Location].transform.position);
                }
                break;
        }
    }

    // fee for park on another player's field
    private void PlayerMustPayAction()
    {
        if (!playerPaid)
        {
            // fee for park on another player's field
            //Debug.Log("X: " + Math.Round(playersList[movePlayerNumber].position.x).ToString());
            //Debug.Log("Z: " + Math.Round(playersList[movePlayerNumber].position.z).ToString());
            Color32 redField = new Color32(255, 0, 0, 255);
            Color32 greenField = new Color32(0, 255, 0, 255);
            Color32 blueField = new Color32(0, 0, 255, 255);
            Color32 yellowField = new Color32(255, 255, 0, 255);
            currentFieldColor = buyFieldController.GetFieldsColors();
            Color32 currentPlayerColor = playersList[movePlayerNumber].GetComponent<Renderer>().material.color;

            bool equalPositions = (buyFieldController.GetFieldPositionX() == Math.Round(playersList[movePlayerNumber].position.x)) && (buyFieldController.GetFieldPositionZ() == Math.Round(playersList[movePlayerNumber].position.z));
            if (currentFieldColor.Equals(redField) || currentFieldColor.Equals(greenField) || currentFieldColor.Equals(blueField) || currentFieldColor.Equals(yellowField))
            {
                if (!currentPlayerColor.Equals(currentFieldColor) && equalPositions)
                {
                    playersMoneyList[movePlayerNumber] = playersMoneyList[movePlayerNumber] - 16;
                    playerPaid = true;
                }
            }
        }
    }

    public void PlayerBuyField()
    {
        if (canBuyField)
        {
            playersMoneyList[movePlayerNumber] = playersMoneyList[movePlayerNumber] + fieldPrice;
        }
    }

    public void PlayerStopPay()
    {
        playerPaid = false;
    }

    public int GetPlayerLocation()
    {
        if (movePlayerNumber == 0)
        {
            playerLocation = player_1_Location;
        }
        if (movePlayerNumber == 1)
        {
            playerLocation = player_2_Location;
        }
        if (movePlayerNumber == 2)
        {
            playerLocation = player_3_Location;
        }
        if (movePlayerNumber == 3)
        {
            playerLocation = player_4_Location;
        }
        return playerLocation;
    }

    public Color32 GetPlayersColors()
    {
        playerColor = playersColorsList[movePlayerNumber];
        return playerColor;
    }

}
