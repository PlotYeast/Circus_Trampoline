using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DisplayScore : MonoBehaviour
{
    [SerializeField] Text scoreText;
    [SerializeField] Text HighestDistance;
    // Start is called before the first frame update
    void Start()
    {
        scoreText.text = "This round's score: " + PlayerPrefs.GetFloat("GameDistance", 0f).ToString("0.#");
        HighestDistance.text = "All-time highest score: " + PlayerPrefs.GetFloat("HighestDistance", 100.1f).ToString("0.#");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
