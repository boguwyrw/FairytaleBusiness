﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuyFieldController : MonoBehaviour
{

    private List<bool> canBuyOrCanNotBuyList = new List<bool>();
    private int currentPlayerLocation;
    private PlayersController playersController;

    public List<Renderer> listOfFieldsColors = new List<Renderer>();

    private void Start()
    {
        for (int i = 0; i < listOfFieldsColors.Count; i++)
        {
            if (listOfFieldsColors[i].material.color == new Color32(220, 220, 220, 255))
            {
                canBuyOrCanNotBuyList.Add(true);
            }
            else
            {
                canBuyOrCanNotBuyList.Add(false);
            }
        }

        currentPlayerLocation = 0;
        playersController = FindObjectOfType<PlayersController>();
    }

    private void Update()
    {
        currentPlayerLocation = playersController.GetPlayerLocation();
        Debug.Log(currentPlayerLocation.ToString());
        Debug.Log(canBuyOrCanNotBuyList[currentPlayerLocation].ToString());
    }

    public bool GetCanBuyOrCanNotBuy()
    {
        return canBuyOrCanNotBuyList[currentPlayerLocation];
    }

}