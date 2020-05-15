using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuyFieldController : MonoBehaviour
{

    private List<bool> canBuyOrCanNotBuyList = new List<bool>();
    private int currentPlayerLocation;
    private PlayersController playersController;
    private bool fieldForBuyOrNotForBuy;

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
        fieldForBuyOrNotForBuy = false;
    }

    private void Update()
    {
        currentPlayerLocation = playersController.GetPlayerLocation();
    }

    private void MarkingFieldsSystem()
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
    }

    public void MarkField()
    {
        listOfFieldsColors[currentPlayerLocation].material.color = playersController.GetPlayersColors();
        canBuyOrCanNotBuyList.Clear();
        MarkingFieldsSystem();
    }

    public bool GetCanBuyOrCanNotBuy()
    {
        fieldForBuyOrNotForBuy = canBuyOrCanNotBuyList[currentPlayerLocation];
        return fieldForBuyOrNotForBuy;
    }

}
