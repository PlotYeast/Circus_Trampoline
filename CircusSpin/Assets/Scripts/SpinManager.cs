using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class SpinManager : MonoBehaviour
{

    bool inAirSpace;
    bool inDeathSpace;
    float spinTime;

    //this is some set up variables for changing the force of the bounce.
    //Time gained will find
    float timeGained;

    // Start is called before the first frame update
    void Start()
    {
        inAirSpace = true;
        inDeathSpace = false;
        spinTime = 0;
    }

    // Update is called once per frame
    void Update()
    {      
        if (inAirSpace && Input.GetKeyDown(KeyCode.E))
        {
            startCounting();
        }
    }

    private void startCounting()
    {
        Debug.Log("counting");
        while (Input.GetKey(KeyCode.E))
        {
            //spinTime is added to while the button is still pressed down
            spinTime += Time.deltaTime;
            Debug.Log(spinTime);
        }
        /*else if (inDeathSpace)
        {
            Destroy(gameObject);
        }
        */
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
