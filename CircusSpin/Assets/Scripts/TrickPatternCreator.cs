using System.Collections;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using UnityEngine;
using UnityEngine.UI;
using System;

public class TrickPatternCreator : MonoBehaviour
{
    List<string> patterns = new List<string>();

    List<GameObject> arrowObjects = new List<GameObject>();

    int difficultyScale = 2;
    int numOfCorrectInputs = 0;
    int numOfBounce = 0;
    
    string pattern = "";
    string playerPattern = "";

    public Sprite upArrow;
    public Sprite downArrow;
    public Sprite leftArrow;
    public Sprite rightArrow;

    public GameObject ArrowDefault;

    // Start is called before the first frame update
    void Start()
    {
        Vector3 position = Vector3.zero;
        float xposition = -2f;
        position.y = 1.5f;


        for (int i = 0; i<9; i++)
        {
            position.x = xposition;
            arrowObjects.Add(Instantiate(ArrowDefault, position, Quaternion.identity, transform));
            Debug.Log("created and added");
            xposition += 0.5f;
        }
            

        CreateNewInputs();
        //DisplayInputs();
    }

    
    public void CreateNewInputs()
    {
        for (int i = 0; i < difficultyScale; i++)
        {
            switch (UnityEngine.Random.Range(0, 4))
            {
                case 0:
                    patterns.Add("up");
                    pattern += "up";

                    arrowObjects[i].GetComponent<SpriteRenderer>().sprite = upArrow;

                    break;
                case 1:
                    patterns.Add("down");
                    pattern += "down";

                    arrowObjects[i].GetComponent<SpriteRenderer>().sprite = downArrow;

                    break;
                case 2:
                    patterns.Add("left");
                    pattern += "left";

                    arrowObjects[i].GetComponent<SpriteRenderer>().sprite = leftArrow;

                    break;

                case 3:
                    pattern += "right";
                    patterns.Add("right");

                    arrowObjects[i].GetComponent<SpriteRenderer>().sprite = rightArrow;

                    break;
            } 
        }
    }

    public void DisplayInputs()
    {
        Vector3 position = Vector3.zero;
        float xposition = -2f;
        position.y = 1.5f;
        

        foreach (string pattern in patterns)
        {
            position.x = xposition;
            switch (pattern)
            {
                case "up":
                    Instantiate(upArrow, position, Quaternion.identity, transform);
                    break;
                case "down":
                    Instantiate(downArrow, position, Quaternion.identity, transform);
                    break;
                case "left":
                    Instantiate(leftArrow, position, Quaternion.identity, transform);
                    break;
                case "right":
                    Instantiate(rightArrow, position, Quaternion.identity, transform);
                    break;
            }

            xposition += 0.5f;
        }
    }

    public int CompareInputs(List<string> playerInputs)
    {
        foreach (string playerInput in playerInputs)
        {
            playerPattern += playerInput;
        }
        

        numOfCorrectInputs = Regex.Matches(playerPattern, pattern).Count;

        pattern = "";
        playerPattern = "";

        numOfBounce += 1;

        difficultyScale = Math.Clamp((numOfBounce / 4), 2, 9);

        return numOfCorrectInputs;
    }
}
