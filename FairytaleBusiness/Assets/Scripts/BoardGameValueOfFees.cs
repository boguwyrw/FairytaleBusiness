using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoardGameValueOfFees : MonoBehaviour
{

    // field 5 - 25 / 1 pole (50 / 2 pola) (100 / 3 pola) (200 / 4 pola)
    // field 12 - 4 x liczba oczek (jesli dwie karty 10 x liczba oczek)
    // field 28 - 4 x liczba oczek (jesli dwie karty 10 x liczba oczek)

    private Dictionary<int, int> fieldsValueOfFeesList = new Dictionary<int, int>();
    private int fieldValueOfFee;
    private int currentPlayerLocation;
    private PlayersController playersController;
    private int numberOfPips;
    private BoardGameController boardGameController;

    private void Start()
    {
        fieldsValueOfFeesList.Add(0, 0);
        fieldsValueOfFeesList.Add(1, -2);
        fieldsValueOfFeesList.Add(2, 0);
        fieldsValueOfFeesList.Add(3, -4);
        fieldsValueOfFeesList.Add(4, -200);
        fieldsValueOfFeesList.Add(5, -25);
        fieldsValueOfFeesList.Add(6, -6);
        fieldsValueOfFeesList.Add(7, 0);
        fieldsValueOfFeesList.Add(8, -6);
        fieldsValueOfFeesList.Add(9, -8);
        fieldsValueOfFeesList.Add(10, 0);
        fieldsValueOfFeesList.Add(11, -10);
        fieldsValueOfFeesList.Add(12, -4 * numberOfPips);
        fieldsValueOfFeesList.Add(13, -10);
        fieldsValueOfFeesList.Add(14, -12);
        fieldsValueOfFeesList.Add(15, -25);
        fieldsValueOfFeesList.Add(16, -14);
        fieldsValueOfFeesList.Add(17, 0);
        fieldsValueOfFeesList.Add(18, -14);
        fieldsValueOfFeesList.Add(19, -16);
        fieldsValueOfFeesList.Add(20, 0);
        fieldsValueOfFeesList.Add(21, -18);
        fieldsValueOfFeesList.Add(22, 0);
        fieldsValueOfFeesList.Add(23, -18);
        fieldsValueOfFeesList.Add(24, -20);
        fieldsValueOfFeesList.Add(25, -25);
        fieldsValueOfFeesList.Add(26, -22);
        fieldsValueOfFeesList.Add(27, -22);
        fieldsValueOfFeesList.Add(28, -4 * numberOfPips);
        fieldsValueOfFeesList.Add(29, -24);
        fieldsValueOfFeesList.Add(30, 0);
        fieldsValueOfFeesList.Add(31, -26);
        fieldsValueOfFeesList.Add(32, -26);
        fieldsValueOfFeesList.Add(33, 0);
        fieldsValueOfFeesList.Add(34, -28);
        fieldsValueOfFeesList.Add(35, -25);
        fieldsValueOfFeesList.Add(36, 0);
        fieldsValueOfFeesList.Add(37, -35);
        fieldsValueOfFeesList.Add(38, -100);
        fieldsValueOfFeesList.Add(39, -50);

        fieldValueOfFee = 0;
        currentPlayerLocation = 0;
        playersController = FindObjectOfType<PlayersController>();
        numberOfPips = 0;
        boardGameController = FindObjectOfType<BoardGameController>();
    }

    private void Update()
    {
        currentPlayerLocation = playersController.GetPlayerLocation();
        numberOfPips = boardGameController.GetDicesPips();
    }

    public int GetFieldsValueOfFees()
    {
        foreach (KeyValuePair<int, int> fieldsValueOfFees in fieldsValueOfFeesList)
        {
            if (fieldsValueOfFees.Key == currentPlayerLocation)
            {
                fieldValueOfFee = fieldsValueOfFees.Value;
            }
        }
        return fieldValueOfFee;
    }

}
