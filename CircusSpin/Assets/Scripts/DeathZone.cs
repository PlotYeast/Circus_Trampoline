using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathZone : MonoBehaviour
{
    [SerializeField] SpinManager BallSpinClass;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        BallSpinClass.enterDeathSpace();
    }

    public void OnTriggerExit2D(Collider2D other)
    {
        BallSpinClass.exitDeathSpace();
    }

    public void PretendThisIstheend(float totalScore)
    {
        PlayerPrefs.SetFloat("GameDistance", totalScore);
        if (totalScore > PlayerPrefs.GetFloat("HighestDistance", 0.0f))
            {
            PlayerPrefs.SetFloat("HighestDistance", totalScore);
            }
        
    }
}
