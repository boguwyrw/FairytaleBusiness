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
    }

    private void Update()
    {
        sumOfDicesPips = boardGameController.GetDicesPips();
        movePlayerNumber = boardGameController.GetPlayerNumber();
        isPlayerMoving = boardGameController.GetPlayerCanMove();
        if (isPlayerMoving)
        {
            playersList[movePlayerNumber].GetComponent<NavMeshAgent>().SetDestination(new Vector3(playersList[movePlayerNumber].position.x, playersList[movePlayerNumber].position.y, sumOfDicesPips));
        }
        
        /*
        foreach (Transform player in playersList)
        {
            Debug.Log(player.position.x.ToString() + " , " + player.position.z.ToString());
        }
        */
    }
}
