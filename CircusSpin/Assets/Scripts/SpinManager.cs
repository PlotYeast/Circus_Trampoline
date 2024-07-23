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
        if (inDeathSpace)
        {
            //im thinking something around the lines of locking all player interaction
            //and forcing a cutscene of the player going oof
            //but it also can just cut to a screen of a dead af little guy as the "game over".
            // it would be easier to code but more jarring 
            
        }
        else
        {
            Debug.Log("counting");
            if (Input.GetKey(KeyCode.E))
            {
                spinTime += Time.deltaTime;
                Debug.Log("getkey" + spinTime);
                GetComponent<SpriteRenderer>().color = Color.yellow;
            }

            if (Input.GetKeyUp(KeyCode.E))
            {
                 //the spinTime will be sent to another script thatll determine how much force to add/subtract to the ball when it bounces again
                 //but the prototype wouldnt have this for now

                 //and once the key is released, the spinTime is reset to zero
                 spinTime = 0;
                GetComponent<SpriteRenderer>().color = Color.white;
                 Debug.Log("keylifted");
               
            }
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
