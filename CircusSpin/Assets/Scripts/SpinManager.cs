using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class SpinManager : MonoBehaviour
{

    bool inAirSpace;
    bool inDeathSpace;
    float spinTime;

    // Start is called before the first frame update
    void Start()
    {
        inAirSpace = false;
        inDeathSpace = false;
        spinTime = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (inDeathSpace && Input.GetKey(KeyCode.Space)) 
        {
            Destroy(gameObject);
        }
        while (inAirSpace && Input.GetKey(KeyCode.Space) && !inDeathSpace)
        {
            //spinTime is added to while the button is still pressed down
            spinTime += Time.deltaTime;
            Debug.Log(spinTime);
        }
    }

    public void enterAirSpace() 
    {
        inAirSpace = true; 
    }

    public void exitAirSpace()
    {
        inAirSpace = false;
    }

    public void enterDeathSpace()
    {

        inDeathSpace = true; 
    }

    public void exitDeathSpace()
    {
        inDeathSpace = false;
    }

}
