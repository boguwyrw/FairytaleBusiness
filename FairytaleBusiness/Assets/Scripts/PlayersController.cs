using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PlayersController : MonoBehaviour
{

    private List<Transform> playersList = new List<Transform>();
    private BoardGameController boardGameController;
    private int movePlayerNumber;
    private bool isPlayerMoving;
    // Players location
    private int player_1_Location;
    private int player_2_Location;
    private int player_3_Location;
    private int player_4_Location;
    private int playerLocation;

    public List<Transform> boardGameWaypointsPath = new List<Transform>();

    private void Start()
    {
        for (int i = 0; i < gameObject.transform.childCount; i++)
        {
            playersList.Add(gameObject.transform.GetChild(i));
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

}
