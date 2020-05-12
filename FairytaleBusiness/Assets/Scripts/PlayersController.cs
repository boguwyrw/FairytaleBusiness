﻿using System.Collections;
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
                Debug.Log("Player_1");
                if (isPlayerMoving)
                {
                    playersList[0].GetComponent<NavMeshAgent>().SetDestination(boardGameWaypointsPath[player_1_Location].transform.position);
                }
                break;
            case 1:
                Debug.Log("Player_2");
                if (isPlayerMoving)
                {
                    playersList[1].GetComponent<NavMeshAgent>().SetDestination(boardGameWaypointsPath[player_2_Location].transform.position);
                }
                break;
            case 2:
                Debug.Log("Player_3");
                if (isPlayerMoving)
                {
                    playersList[2].GetComponent<NavMeshAgent>().SetDestination(boardGameWaypointsPath[player_3_Location].transform.position);
                }
                break;
            case 3:
                Debug.Log("Player_4");
                if (isPlayerMoving)
                {
                    playersList[3].GetComponent<NavMeshAgent>().SetDestination(boardGameWaypointsPath[player_4_Location].transform.position);
                }
                break;
        }
    }

}
