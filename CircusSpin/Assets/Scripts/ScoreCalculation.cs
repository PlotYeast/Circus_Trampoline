using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreCalculation : MonoBehaviour
{
    float airTime = 0f;
    float totalSpinTime = 0f;
    bool startTimer = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (startTimer)
        {
            StartTimer();
        }
    }

    public void AddSpinTime(float spinTime)
    {
        totalSpinTime += spinTime;
    }

    public void ResetSpinTime()
    {
        totalSpinTime = 0f;
    }

    private void Timer()
    {
        airTime += Time.deltaTime;
    }

    private void StartTimer() 
    {

    }
    private void EndTimer()
    {
        startTimer = false;
    }
}
