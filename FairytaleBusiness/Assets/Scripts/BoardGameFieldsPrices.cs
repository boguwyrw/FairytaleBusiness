using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoardGameFieldsPrices : MonoBehaviour
{

    private Dictionary<int, int> fieldsPricesList = new Dictionary<int, int>();
    private int fieldPrice;
    private int currentPlayerLocation;
    private PlayersController playersController;

    void Start()
    {
        fieldsPricesList.Add(0, 200);
        fieldsPricesList.Add(1, -60);
        fieldsPricesList.Add(2, 0);
        fieldsPricesList.Add(3, -60);
        fieldsPricesList.Add(4, -200);
        fieldsPricesList.Add(5, -200);
        fieldsPricesList.Add(6, -100);
        fieldsPricesList.Add(7, 0);
        fieldsPricesList.Add(8, -100);
        fieldsPricesList.Add(9, -120);
        fieldsPricesList.Add(10, 0);
        fieldsPricesList.Add(11, -140);
        fieldsPricesList.Add(12, -150);
        fieldsPricesList.Add(13, -140);
        fieldsPricesList.Add(14, -160);
        fieldsPricesList.Add(15, -200);
        fieldsPricesList.Add(16, -180);
        fieldsPricesList.Add(17, 0);
        fieldsPricesList.Add(18, -180);
        fieldsPricesList.Add(19, -200);
        fieldsPricesList.Add(20, 0);
        fieldsPricesList.Add(21, -220);
        fieldsPricesList.Add(22, 0);
        fieldsPricesList.Add(23, -220);
        fieldsPricesList.Add(24, -240);
        fieldsPricesList.Add(25, -200);
        fieldsPricesList.Add(26, -260);
        fieldsPricesList.Add(27, -260);
        fieldsPricesList.Add(28, -150);
        fieldsPricesList.Add(29, -280);
        fieldsPricesList.Add(30, 0);
        fieldsPricesList.Add(31, -300);
        fieldsPricesList.Add(32, -300);
        fieldsPricesList.Add(33, 0);
        fieldsPricesList.Add(34, -320);
        fieldsPricesList.Add(35, -200);
        fieldsPricesList.Add(36, 0);
        fieldsPricesList.Add(37, -350);
        fieldsPricesList.Add(38, -100);
        fieldsPricesList.Add(39, -400);

        fieldPrice = 0;
        currentPlayerLocation = 0;
        playersController = FindObjectOfType<PlayersController>();
    }

    void Update()
    {
        currentPlayerLocation = playersController.GetPlayerLocation();
    }

    public int GetFieldsPrices()
    {
        foreach (KeyValuePair<int, int> fieldsPrices in fieldsPricesList)
        {
            if (fieldsPrices.Key == currentPlayerLocation)
            {
                fieldPrice = fieldsPrices.Value;
            }
        }
        return fieldPrice;
    }

}
