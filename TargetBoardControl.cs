using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetBoardControl : MonoBehaviour {
    public Material [] targetboard_Mat; //List of material colours for the target boards (RGB)
    public Material currentMat; //Reference to the current material shown by the object
    Renderer render;

    [SerializeField]
    private int gameTime = 0; //Records the time ever since the start of the game

    //Initialising all the target boards
	void Awake () {

        render = GetComponent<Renderer>();
        render.enabled = true;

        //Upon awaking, check the object's name and if it is in the front row, then fix its colours
        if(this.gameObject.name == "L1 Target Board 1")
        {
            render.sharedMaterial = targetboard_Mat[0]; //Make the middle object red
        } else if(this.gameObject.name == "L1 Target Board 2")
        {
            render.sharedMaterial = targetboard_Mat[2]; //Make the rightmost object blue
        } else if(this.gameObject.name == "L1 Target Board 3")
        {
            render.sharedMaterial = targetboard_Mat[1]; //Make the leftmost object green
        } else if(this.gameObject.name == "L2 Target Board 1")
        {
            render.sharedMaterial = targetboard_Mat[1]; //Starts off as green
        }
        else if(this.gameObject.name == "L2 Target Board 2")
        {
            render.sharedMaterial = targetboard_Mat[2]; //Starts off as blue
        }
        else if(this.gameObject.name == "L2 Target Board 3")
        {
            render.sharedMaterial = targetboard_Mat[0]; //Starts off as red
        } else if(this.gameObject.name == "L3 Target Board 1")
        {
            render.sharedMaterial = targetboard_Mat[1]; //Starts off as green
        } else if(this.gameObject.name == "L3 Target Board 2")
        {
            render.sharedMaterial = targetboard_Mat[0]; //Starts off as red
        } else if(this.gameObject.name == "L3 Target Board 3")
        {
            render.sharedMaterial = targetboard_Mat[2]; //Starts off as blue
        } else if(this.gameObject.name == "L4 Target Board 1")
        {
            render.sharedMaterial = targetboard_Mat[0]; //Starts off as red
        } else if(this.gameObject.name == "L4 Target Board 2")
        {
            render.sharedMaterial = targetboard_Mat[1]; //Starts off as green
        } else if(this.gameObject.name == "L4 Target Board 3")
        {
            render.sharedMaterial = targetboard_Mat[2]; //Starts off as blue
        } 
        currentMat = render.sharedMaterial;
    }

    // Update is called once per frame
    void Update () {
        gameTime = gameTime + 1;
        //Level 2 Target Board Code
        // Concept: Red-Green-Blue -> 150 frames -> Blue-Red-Green -> 150 frames -> Green-Blue-Red
        if (this.gameObject.name == "L2 Target Board 1") //MIDDLE BOARD (Order: Green, Red, Blue)
        {

            if(gameTime % 150 == 0) //this ticks true every 150 frames
            {
                //Cycles the object every 150 frames
                if (render.sharedMaterial == targetboard_Mat[1]) //If the object is green, it becomes red
                {
                    render.sharedMaterial = targetboard_Mat[0];
                } else if(render.sharedMaterial == targetboard_Mat[0]) //If the object is red, it becomes blue
                {
                    render.sharedMaterial = targetboard_Mat[2];
                } else if(render.sharedMaterial == targetboard_Mat[2]) //If the object is blue, it becomes green
                {
                    render.sharedMaterial = targetboard_Mat[1];
                }
                currentMat = render.sharedMaterial;
            }
        }

        if (this.gameObject.name == "L2 Target Board 2") //RIGHT BOARD (Order: Blue, Green, Red)
        {

            if (gameTime % 150 == 0) //this ticks true every 150 frames
            {
                //Cycles the object every 150 frames
                if (render.sharedMaterial == targetboard_Mat[2]) //If the object is green, it becomes red
                {
                    render.sharedMaterial = targetboard_Mat[1];
                }
                else if (render.sharedMaterial == targetboard_Mat[1]) //If the object is red, it becomes blue
                {
                    render.sharedMaterial = targetboard_Mat[0];
                }
                else if (render.sharedMaterial == targetboard_Mat[0]) //If the object is blue, it becomes green
                {
                    render.sharedMaterial = targetboard_Mat[2];
                }
                currentMat = render.sharedMaterial;

            }
        }

        if (this.gameObject.name == "L2 Target Board 3") //LEFT BOARD (Order: Red, Blue, Green)
        {

            if (gameTime % 150 == 0) //this ticks true every 100 frames
            {
                //Cycles the object every 150 frames
                if (render.sharedMaterial == targetboard_Mat[0]) //If the object is green, it becomes red
                {
                    render.sharedMaterial = targetboard_Mat[2];
                }
                else if (render.sharedMaterial == targetboard_Mat[2]) //If the object is red, it becomes blue
                {
                    render.sharedMaterial = targetboard_Mat[1];
                }
                else if (render.sharedMaterial == targetboard_Mat[1]) //If the object is blue, it becomes green
                {
                    render.sharedMaterial = targetboard_Mat[0];
                }
                currentMat = render.sharedMaterial;

            }
        }

       //Level 3 Target Board Code
       //Concept: Green,Red,Blue -> 100 frames -> Red,Blue,Green -> 100 frames -> Blue,Green,Red
       if(this.gameObject.name == "L3 Target Board 1") //CENTRE 
        {
            //Every 100 frames cycle through a colour
            if(gameTime % 100 == 0)
            {
                if(render.sharedMaterial == targetboard_Mat[1]) //If green, then turn red
                {
                    render.sharedMaterial = targetboard_Mat[0]; 
                } else if(render.sharedMaterial == targetboard_Mat[0]) //If red then turn blue
                {
                    render.sharedMaterial = targetboard_Mat[2]; 
                } else if(render.sharedMaterial == targetboard_Mat[2]) //If blue then turn green
                {
                    render.sharedMaterial = targetboard_Mat[1];
                }
                currentMat = render.sharedMaterial;

            }

        }

        if (this.gameObject.name == "L3 Target Board 2") //RIGHT 
        {
            //Every 100 frames cycle through a colour
            if (gameTime % 100 == 0)
            {
                if (render.sharedMaterial == targetboard_Mat[2]) //If blue, then turn green
                {
                    render.sharedMaterial = targetboard_Mat[1];
                }
                else if (render.sharedMaterial == targetboard_Mat[1]) //If green then turn red
                {
                    render.sharedMaterial = targetboard_Mat[0];
                }
                else if (render.sharedMaterial == targetboard_Mat[0]) //If red then turn blue
                {
                    render.sharedMaterial = targetboard_Mat[2];
                }
                currentMat = render.sharedMaterial;

            }

        }

        if (this.gameObject.name == "L3 Target Board 3") //LEFT 
        {
            //Every 100 frames cycle through a colour
            if (gameTime % 100 == 0)
            {
                if (render.sharedMaterial == targetboard_Mat[1]) //If green, then turn red
                {
                    render.sharedMaterial = targetboard_Mat[0];
                }
                else if (render.sharedMaterial == targetboard_Mat[0]) //If red then turn blue
                {
                    render.sharedMaterial = targetboard_Mat[2];
                }
                else if (render.sharedMaterial == targetboard_Mat[2]) //If blue then turn green
                {
                    render.sharedMaterial = targetboard_Mat[1];
                }
                currentMat = render.sharedMaterial;

            }

        }

        //Level 4 Target Board Code
        //Concept: Red,Green,Blue -> 50 frames -> Green,Blue,Red -> 50 frames -> Blue,Red,Green
        if (this.gameObject.name == "L4 Target Board 1") //MIDDLE 
        {
            //Every 100 frames cycle through a colour
            if (gameTime % 50 == 0)
            {
                if (render.sharedMaterial == targetboard_Mat[0]) //If green, then turn red
                {
                    render.sharedMaterial = targetboard_Mat[1];
                }
                else if (render.sharedMaterial == targetboard_Mat[1]) //If red then turn blue
                {
                    render.sharedMaterial = targetboard_Mat[2];
                }
                else if (render.sharedMaterial == targetboard_Mat[2]) //If blue then turn green
                {
                    render.sharedMaterial = targetboard_Mat[0];
                }
                currentMat = render.sharedMaterial;

            }

        }

        if (this.gameObject.name == "L4 Target Board 2") //RIGHT 
        {
            //Every 100 frames cycle through a colour
            if (gameTime % 50 == 0)
            {
                if (render.sharedMaterial == targetboard_Mat[1]) //If green, then turn red
                {
                    render.sharedMaterial = targetboard_Mat[2];
                }
                else if (render.sharedMaterial == targetboard_Mat[2]) //If red then turn blue
                {
                    render.sharedMaterial = targetboard_Mat[0];
                }
                else if (render.sharedMaterial == targetboard_Mat[0]) //If blue then turn green
                {
                    render.sharedMaterial = targetboard_Mat[1];
                }
                currentMat = render.sharedMaterial;

            }

        }

        if (this.gameObject.name == "L4 Target Board 3") //LEFT 
        {
            //Every 100 frames cycle through a colour
            if (gameTime % 50 == 0)
            {
                if (render.sharedMaterial == targetboard_Mat[2]) //If green, then turn red
                {
                    render.sharedMaterial = targetboard_Mat[0];
                }
                else if (render.sharedMaterial == targetboard_Mat[0]) //If red then turn blue
                {
                    render.sharedMaterial = targetboard_Mat[1];
                }
                else if (render.sharedMaterial == targetboard_Mat[1]) //If blue then turn green
                {
                    render.sharedMaterial = targetboard_Mat[2];
                }
                currentMat = render.sharedMaterial;

            }

        }


    }
}
