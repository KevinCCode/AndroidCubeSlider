using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class SceneControlScript : MonoBehaviour {
 
	public void loadGame()
    {
        SceneManager.LoadScene("MainGameScene");
    }

    public void exitGame()
    {
        Application.Quit();
    }

    public void instructionOne()
    {
        SceneManager.LoadScene("Instruction 1");
    }

    public void instructionTwo()
    {
        SceneManager.LoadScene("Instruction 2");
    }

    public void instructionThree()
    {
        SceneManager.LoadScene("Instruction 3");
    }

    public void titleScreen()
    {
        SceneManager.LoadScene("Title Screen");
    }

}
