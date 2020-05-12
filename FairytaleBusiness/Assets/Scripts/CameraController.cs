using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{

    private GameObject playersController;
    private BoardGameController boardGameController;
    private bool isGameStart;
    private int distanceValue;

    private void Start()
    {
        playersController = GameObject.Find("PlayersController");
        boardGameController = FindObjectOfType<BoardGameController>();
        isGameStart = false;
        distanceValue = 7;
    }

    private void Update()
    {
        Transform playerTransform = playersController.transform.GetChild(boardGameController.GetPlayerNumber());
        isGameStart = boardGameController.GetStartGame();
        if (isGameStart)
        {
            transform.position = new Vector3(playerTransform.position.x - distanceValue, playerTransform.position.y + distanceValue, playerTransform.position.z - distanceValue);
            transform.rotation = Quaternion.Euler(45, 45, 0);
        }
    }
}
