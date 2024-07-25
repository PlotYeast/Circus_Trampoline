using System.Collections;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using UnityEngine;

public class TrickPatternCreator : MonoBehaviour
{
    //List<string> patterns = new List<string>();
    int difficultyScale = 2;
    int numOfCorrectInputs = 0;
    string pattern = "";
    string playerPattern = "";
    

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    public void CreateNewInputs()
    {
        for (int i = 0; i < difficultyScale; i++)
        {
            switch (Random.Range(0, 4))
            {
                case 0:
                    // patterns.Add("upkey");
                    pattern += "up";
                    break;
                case 1:
                    // patterns.Add("downkey");
                    pattern += "down";
                    break;
                case 2:
                    //  patterns.Add("leftkey");
                    pattern += "left";
                    break;
                case 3:
                    pattern += "right";
                   // patterns.Add("rightkey");
                    break;
            }
                
            
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
