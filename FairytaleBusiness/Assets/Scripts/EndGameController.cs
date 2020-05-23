using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EndGameController : MonoBehaviour
{

    public Button quitButton;

    private void Start()
    {
        quitButton.gameObject.SetActive(false);
    }

    private void Update()
    {
        if (Input.GetKey(KeyCode.Escape))
        {
            quitButton.gameObject.SetActive(true);
            Time.timeScale = 0;
        }
    }

    public void QuitGameButton()
    {
        Application.Quit();
    }

}
