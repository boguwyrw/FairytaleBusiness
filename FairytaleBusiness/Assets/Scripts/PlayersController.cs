using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PlayersController : MonoBehaviour
{

    private List<Transform> playersList = new List<Transform>();
    private int sumOfDicesPips;
    private BoardGameController boardGameController;
    private int movePlayerNumber;
    private bool isPlayerMoving;
    private bool movePlayer;
    // Players location
    private int player_1_Location;
    private int player_2_Location;
    private int player_3_Location;
    private int player_4_Location;

    public List<Transform> boardGameWaypointsPath = new List<Transform>();

    private void Start()
    {
        for (int i = 0; i < gameObject.transform.childCount; i++)
        {
            playersList.Add(gameObject.transform.GetChild(i));
        }

        sumOfDicesPips = 0;
        boardGameController = FindObjectOfType<BoardGameController>();
        movePlayerNumber = 0;
        isPlayerMoving = false;
        movePlayer = false;
        // Values of Players location
        player_1_Location = 0;
        player_2_Location = 0;
        player_3_Location = 0;
        player_4_Location = 0;
    }

    private void Update()
    {
        sumOfDicesPips = boardGameController.GetDicesPips();
        movePlayerNumber = boardGameController.GetPlayerNumber();
        isPlayerMoving = boardGameController.GetPlayerCanMove();
        
        CurrentPlayersLocation();

        /*
        foreach (Transform player in playersList)
        {
            Debug.Log(player.position.x.ToString() + " , " + player.position.z.ToString());
        }
        */
    }

    private void PlayerIsMoving()
    {
        if (isPlayerMoving)
        {
            playersList[movePlayerNumber].GetComponent<NavMeshAgent>().SetDestination(boardGameWaypointsPath[sumOfDicesPips].transform.position);
        }
    }

    private void CurrentPlayersLocation()
    {
        switch (movePlayerNumber)
        {
            case 0:
                Debug.Log("Player_1");
                Debug.Log(player_1_Location.ToString());
                if (isPlayerMoving)
                {
                    player_1_Location = player_1_Location + sumOfDicesPips;
                    if (player_1_Location > 39)
                    {
                        player_1_Location = player_1_Location - boardGameWaypointsPath.Count;
                    }
                    playersList[0].GetComponent<NavMeshAgent>().SetDestination(boardGameWaypointsPath[player_1_Location].transform.position);
                }
                
                //PlayerIsMoving();
                break;
            case 1:
                Debug.Log("Player_2");
                PlayerIsMoving();
                break;
            case 2:
                Debug.Log("Player_3");
                PlayerIsMoving();
                break;
            case 3:
                Debug.Log("Player_4");
                PlayerIsMoving();
                break;
        }
    }

}
