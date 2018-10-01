using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UIControlScript : MonoBehaviour {

    public Text win;
    public Text lose;

    private bool won;
    private bool end;

    public GameObject retry;
    public GameObject back;
    public GameObject left, right, centre; 

	// Use this for initialization
	void Start () {
        won = GameObject.Find("Cube").GetComponent<MainCubeControl>().getsetGameWin;
        end = GameObject.Find("Cube").GetComponent<MainCubeControl>().getsetGameState;
        win.enabled = false;
        lose.enabled = false;
        //Deactivates both retry and quit buttons until needed
        retry.SetActive(false);
        back.SetActive(false); 
	}
	
    public void reloadGame()
    {
        SceneManager.LoadScene("MainGameScene");
    }

    public void returnToTitle()
    {
        SceneManager.LoadScene("Title Screen");
    }

	// Update is called once per frame
	void Update () {
        //Keep on updating the status of both the game state and also winning or losing
        won = GameObject.Find("Cube").GetComponent<MainCubeControl>().getsetGameWin;
        end = GameObject.Find("Cube").GetComponent<MainCubeControl>().getsetGameState;
        if(!won && end) //if the game is over AND you have lost
        {
            lose.enabled = true;

            //Deactivate the movement buttons
            left.SetActive(false);
            right.SetActive(false);
            centre.SetActive(false);
            //Activate the retry and quit buttons
            retry.SetActive(true);
            back.SetActive(true);

        } else if(won && end) //if the game is over AND you won
        {
            win.enabled = true;

            //Deactivate the movement buttons
            left.SetActive(false);
            right.SetActive(false);
            centre.SetActive(false);
            //Activate the retry and quit buttons
            retry.SetActive(true);
            back.SetActive(true);

        }
    }
}
