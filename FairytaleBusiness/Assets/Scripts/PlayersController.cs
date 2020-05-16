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

    public List<Transform> boardGameWaypointsPath = new List<Transform>();
    public Text player_1_Text;
    public Text player_2_Text;
    public Text player_3_Text;
    public Text player_4_Text;

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
        canBuyField = false;
        buyFieldController = FindObjectOfType<BuyFieldController>();

        for (int i = 0; i < playersList.Count; i++)
        {
            playersMoneyList.Add(1500);
        }

        fieldPrice = 0;
        boardGameFieldsPrices = FindObjectOfType<BoardGameFieldsPrices>();

        player_1_Text.transform.position = new Vector3(0.9f * Screen.width, 0.9f * Screen.height, 0);
        player_2_Text.transform.position = new Vector3(0.9f * Screen.width, 0.8f * Screen.height, 0);
        player_3_Text.transform.position = new Vector3(0.9f * Screen.width, 0.7f * Screen.height, 0);
        player_4_Text.transform.position = new Vector3(0.9f * Screen.width, 0.6f * Screen.height, 0);
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

        canBuyField = buyFieldController.GetCanBuyOrCanNotBuy();
        fieldPrice = boardGameFieldsPrices.GetFieldsPrices();

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
    
    private void CurrentPlayersLocation()
    {
        switch (movePlayerNumber)
        {
            case 0:
                if (isPlayerMoving)
                {
                    playersList[0].GetComponent<NavMeshAgent>().SetDestination(boardGameWaypointsPath[player_1_Location].transform.position);
                }
                //playerLocation = player_1_Location;
                break;
            case 1:
                if (isPlayerMoving)
                {
                    playersList[1].GetComponent<NavMeshAgent>().SetDestination(boardGameWaypointsPath[player_2_Location].transform.position);
                }
                //playerLocation = player_2_Location;
                break;
            case 2:
                if (isPlayerMoving)
                {
                    playersList[2].GetComponent<NavMeshAgent>().SetDestination(boardGameWaypointsPath[player_3_Location].transform.position);
                }
                //playerLocation = player_3_Location;
                break;
            case 3:
                if (isPlayerMoving)
                {
                    playersList[3].GetComponent<NavMeshAgent>().SetDestination(boardGameWaypointsPath[player_4_Location].transform.position);
                }
                //playerLocation = player_4_Location;
                break;
        }
    }

    public void PlayerBuyField()
    {
        if (canBuyField)
        {
            playersMoneyList[movePlayerNumber] = playersMoneyList[movePlayerNumber] + fieldPrice;
        }
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
