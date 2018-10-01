using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class titleRotatingCube : MonoBehaviour {

    Vector3 rotation;

    //Set the game object and text object
    public GameObject rotatingObject;
    public Text changingText;

    [SerializeField]
    private int gameTime = 0;

    public Material[] titleCubeMat;
    public Material currentMat; 
    Renderer render; 

	// Use this for initialization
	void Start () {
        render = rotatingObject.GetComponent<Renderer>();
        render.enabled = true;
        render.sharedMaterial = titleCubeMat[0]; //starts off as red;
        currentMat = render.sharedMaterial;

        changingText.color = Color.red; //starts off as red

        rotation.x = 0;
        rotation.y = 25;
        rotation.z = 0;
	}
	
	// Update is called once per frame
	void Update () {
        gameTime = gameTime + 1;
        if(gameTime % 200 == 0)
        {
            if(render.sharedMaterial == titleCubeMat[0])
            {
                render.sharedMaterial = titleCubeMat[1];
            } else if(render.sharedMaterial == titleCubeMat[1])
            {
                render.sharedMaterial = titleCubeMat[2];
            } else if(render.sharedMaterial == titleCubeMat[2])
            {
                render.sharedMaterial = titleCubeMat[0];
            }
            currentMat = render.sharedMaterial;

            if(changingText.color == Color.red)
            {
                changingText.color = Color.green;
            } else if(changingText.color == Color.green)
            {
                changingText.color = Color.blue;
            } else if(changingText.color == Color.blue)
            {
                changingText.color = Color.red;
            }
        }

       rotatingObject.transform.Rotate(rotation * Time.deltaTime);
	}
}
