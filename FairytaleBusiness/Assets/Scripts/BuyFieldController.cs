using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuyFieldController : MonoBehaviour
{

    private List<bool> canBuyOrCanNotBuyList = new List<bool>();
    private int currentPlayerLocation;
    private PlayersController playersController;
    private bool fieldForBuyOrNotForBuy;
    private int fieldPositionX;
    private int fieldPositionZ;

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
        fieldPositionX = 0;
        fieldPositionZ = 0;
    }

    private void Update()
    {
        currentPlayerLocation = playersController.GetPlayerLocation();
        Debug.Log("Field X: " + listOfFieldsColors[currentPlayerLocation].gameObject.transform.position.x.ToString());
        Debug.Log("Field Z: " + listOfFieldsColors[currentPlayerLocation].gameObject.transform.position.z.ToString());
    }

    public void MarkField()
    {
        listOfFieldsColors[currentPlayerLocation].material.color = playersController.GetPlayersColors();
        canBuyOrCanNotBuyList[currentPlayerLocation] = false;
    }

    public bool GetCanBuyOrCanNotBuy()
    {
        fieldForBuyOrNotForBuy = canBuyOrCanNotBuyList[currentPlayerLocation];
        return fieldForBuyOrNotForBuy;
    }

    public Color32 GetFieldsColors()
    {
        return listOfFieldsColors[currentPlayerLocation].material.color;
    }
    
    public int GetFieldPositionX()
    {
        fieldPositionX = (int)listOfFieldsColors[currentPlayerLocation].gameObject.transform.position.x;
        return fieldPositionX;
    }

    public int GetFieldPositionZ()
    {
        fieldPositionZ = (int)listOfFieldsColors[currentPlayerLocation].gameObject.transform.position.z;
        return fieldPositionZ;
    }

}
