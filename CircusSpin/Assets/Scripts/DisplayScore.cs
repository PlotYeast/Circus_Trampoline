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
        scoreText.text = "This round's highest jump: " + PlayerPrefs.GetFloat("GameDistance", 0f).ToString("0.#") + " meters!";
        HighestDistance.text = "All-time highest jump: " + PlayerPrefs.GetFloat("HighestDistance", 100.1f).ToString("0.#") + " meters!";
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
