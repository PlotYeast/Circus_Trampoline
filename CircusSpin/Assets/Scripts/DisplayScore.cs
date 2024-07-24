using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DisplayScore : MonoBehaviour
{
    [SerializeField] Text scoreText;
    [SerializeField] Text Highscore;
    // Start is called before the first frame update
    void Start()
    {
        scoreText.text = "Final Score: " + PlayerPrefs.GetFloat("GameScore", 0f).ToString("0.###");
        Highscore.text = "Highscore: " + PlayerPrefs.GetFloat("Highscore", 100f).ToString("0.###");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
