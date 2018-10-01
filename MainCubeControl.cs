using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainCubeControl : MonoBehaviour {

    public Material[] maincube_Mat;
    public Material thisMat; //used to reference cube's colour
    Renderer render;
    private float moveSpeed = 1f; //set speed of the cube moving forward
    public List<GameObject> objectList = new List<GameObject>(); //Create variable that references the list in target board control
    public List<GameObject> alreadyList = new List<GameObject>(); //Create variable that references the alreayd hit list

    private bool gameEnd = false; //This controls whether the game has ended or not
    private bool gameWon = false; //This controls whether the game has been won or not 
    private bool alreadyHit = false; //Used to determine if the object was already hit or not

    // Use this for initialization
    //Default colour of the cube starts off as GREEN
    void Start () {
        render = GetComponent<Renderer>();
        render.enabled = true;
        render.sharedMaterial = maincube_Mat[0]; //this is the green colour in the list
        thisMat = render.sharedMaterial;
        objectList = GameObject.Find("GameTopLevel").GetComponent<TargetBoardList>().getsetList;
        alreadyList = GameObject.Find("GameTopLevel").GetComponent<TargetBoardList>().getsetAlreadyHit;
    }

    //NOTE: LEFT IS NEGATIVE, RIGHT IS POSITIVE

    //The player cube moves to the right lane from their original position
    public void moveRight()
    {
        if(this.gameObject.transform.position.x == 0) //if centre, move + 2
        {
            this.gameObject.transform.Translate(2, 0, 0);
        } else if(this.gameObject.transform.position.x == -2) //if left, move + 4
        {
            this.gameObject.transform.Translate(4, 0, 0);
        }
    }

    //The player cube moves to the left lane from their original position
    public void moveLeft()
    {
        if (this.gameObject.transform.position.x == 0) //if centre, move - 2
        {
            this.gameObject.transform.Translate(-2, 0, 0);
        }
        else if (this.gameObject.transform.position.x == 2) //if right, move - 4
        {
            this.gameObject.transform.Translate(-4, 0, 0);
        }
    }

    //This allows the player cube to move left up to a set limit
    public void moveCentre()
    {
        if (this.gameObject.transform.position.x == -2) //if left, then move + 2
        {
            this.gameObject.transform.Translate(2, 0, 0);
        }
        else if (this.gameObject.transform.position.x == 2) //if right, then move - 2
        {
            this.gameObject.transform.Translate(-2, 0, 0);
        }
    }

    public void OnTriggerEnter(Collider other)
    {
        //Debug.Log("Contact");
        GameObject collidedObject = other.gameObject; //registers what object this cube hit
        if (collidedObject.GetComponent<TargetBoardControl>().currentMat == thisMat) //if the material matches this object's material
        {
            string dissappearTag = collidedObject.tag;
            //Check the tag of the object that was correctly collided and destroy all objects with the same tag
            foreach (GameObject board in objectList) //Cycle through whole list
            {
                if (board.tag == dissappearTag) //if the object's tag matches, change material to make it 'dissappear'
                {
                    board.GetComponent<Renderer>().enabled = false;
                    alreadyList.Add(board); //Add this object to the list
                    
                }
            }
        } else //if you hit the wrong object OR you hit something that's already been hit
        {
            //Debug.Log("Recognises Wrong Mat");
            //Debug.Log(other.gameObject.name);
            int searchSize = alreadyList.Count; //Get the size of the searchList
            //Searches through the entire list and checks if the hit object exists inside the list of already-hit objects
            for(int i = 0; i < searchSize; i++)
            {
                if(collidedObject.name == alreadyList[i].name)
                {
                    //Debug.Log("Correct Registration");
                    alreadyHit = true;
                }
            }

            if (!alreadyHit)
            {
                Debug.Log("Something Wrong!");
                render.sharedMaterial = maincube_Mat[1]; //make this object black
                moveSpeed = 0; //this object stops moving
                gameEnd = true; //change this flag to true
                //Debug.Log(gameEnd);
            }

            alreadyHit = false; //reset the alreadyHit variable to false
        }
    }

    // Update is called once per frame
    void Update () {
        transform.Translate(0, 0, moveSpeed * Time.deltaTime);

        if(transform.localPosition.z > 300) //Check the position of the cube, if it has passed the last wall, end the game
        {
            moveSpeed = 0;
            gameWon = true;
            gameEnd = true;
            //Debug.Log("Win");
        }
 
	}

    //Getter setter to access the new
    public bool getsetGameState
    {
        get { return gameEnd; } //returns the state of the gameEnd variable
    }

    //Getter setter to access the new
    public bool getsetGameWin
    {
        get { return gameWon; } //returns the state of the gameEnd variable
    }

}
