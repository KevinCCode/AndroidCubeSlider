using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetBoardList : MonoBehaviour {

    public List<GameObject> targetBoards = new List<GameObject>(); //List of all the targetboard objects

    //This new list was added since I realised that even though the objects dissappered they still exist within the game
    //Immediately switching positions at a wall area equates to hitting it
    public List<GameObject> alreadyHitBoards = new List<GameObject>(); //List of all objects already hit

    public List<GameObject> getsetList
    {
        get { return targetBoards; } //return the list of targetBoard gameObjects
    }

    public List<GameObject> getsetAlreadyHit
    {
        get { return alreadyHitBoards; } //return the list of already hit gameObjects
    }

}
