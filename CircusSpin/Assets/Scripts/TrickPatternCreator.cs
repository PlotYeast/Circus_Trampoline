using System.Collections;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using UnityEngine;
using UnityEngine.UI;
using System;

public class TrickPatternCreator : MonoBehaviour
{
    [SerializeField] Text comboText;
    List<string> patterns = new List<string>();

    List<GameObject> arrowObjects = new List<GameObject>();
    int comboNumber;
    int difficultyScale = 2;
    int currentInput = 0;
    public int numOfCorrectInputs = 0;
    int numOfBounce = 0;
    string pattern = "";
    string playerPattern = "";

    public Sprite upArrow;
    public Sprite downArrow;
    public Sprite leftArrow;
    public Sprite rightArrow;

    public GameObject ArrowDefault;
    public AudioSource succesScore;
    public AudioSource comboSuccess;
    public AudioSource wrongInput;

    // Start is called before the first frame update
    void Start()
    {
        comboText.text = "0x Combo";
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

        if (numOfCorrectInputs > 0)
        {
            succesScore.Play();
        }

        numOfCorrectInputs = Regex.Matches(playerPattern, pattern).Count;
        pattern = "";
        playerPattern = "";
        ResetArrows();
        numOfBounce += 1;
        currentInput = 0;
        patterns.Clear();
        difficultyScale = Math.Clamp((numOfBounce / 4), 2, 9);
        comboNumber = 0;
        comboText.text = $"{comboNumber}x Combo";
        return numOfCorrectInputs;
    }
    public void GetInput(string playerInput) 
    {
        if (playerInput == patterns[currentInput])
        {
            arrowObjects[currentInput].GetComponent<SpriteRenderer>().color = Color.green;
            currentInput++;
            if (currentInput >= difficultyScale)
            {
                currentInput = 0;
                ResetArrows();
                comboNumber++;
                comboText.text = $"{comboNumber}x Combo";
                comboSuccess.Play();
            }
        }
        else 
        {
            wrongInput.Play();
            currentInput = 0;
            ResetArrows();
        }
    }
    void ResetArrows() 
    {
        foreach (GameObject Arrow in arrowObjects) 
        {
            Arrow.GetComponent<SpriteRenderer>().color = Color.white;
        }
    }
}
