using System.Collections;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using UnityEngine;
using UnityEngine.UI;

public class TrickPatternCreator : MonoBehaviour
{
    List<string> patterns = new List<string>();

    int difficultyScale = 2;
    int numOfCorrectInputs = 0;
    
    string pattern = "";
    string playerPattern = "";

    public GameObject upArrow;
    public GameObject downArrow;
    public GameObject leftArrow;
    public GameObject rightArrow;

    [SerializeField] Camera mainCamera = null;

    // Start is called before the first frame update
    void Start()
    {
        CreateNewInputs();
        DisplayInputs();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    private void CreateNewInputs()
    {
        for (int i = 0; i < difficultyScale; i++)
        {
            switch (Random.Range(0, 4))
            {
                case 0:
                    patterns.Add("up");
                    pattern += "up";
                    break;
                case 1:
                    patterns.Add("down");
                    pattern += "down";
                    break;
                case 2:
                    patterns.Add("left");
                    pattern += "left";
                    break;
                case 3:
                    pattern += "right";
                    patterns.Add("right");
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

        return numOfCorrectInputs;
    }
}
