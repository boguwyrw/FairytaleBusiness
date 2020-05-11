using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{

    private GameObject playersController;
    private BoardGameController boardGameController;
    private bool isGameStart;

    private void Start()
    {
        playersController = GameObject.Find("PlayersController");
        boardGameController = FindObjectOfType<BoardGameController>();
        isGameStart = false;
    }

    private void Update()
    {
        Transform playerTransform = playersController.transform.GetChild(boardGameController.GetPlayerNumber());
        isGameStart = boardGameController.GetStartGame();
        if (isGameStart)
        {
            transform.position = new Vector3(playerTransform.position.x, playerTransform.position.y + 20, playerTransform.position.z);
        }
    }
}
