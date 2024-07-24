using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class SpinManager : MonoBehaviour
{
    bool inDeathSpace;
    public float spinTime;
    [SerializeField] AudioSource whoosh;
    [SerializeField] Text scoreText;
    float totalScore = 0f;
    PlayerBounce playerBounce;

    //this is some set up variables for changing the force of the bounce.
    //Time gained will find
    float timeGained;

    // Start is called before the first frame update
    void Start()
    {
        inDeathSpace = false;
        spinTime = 0;
        playerBounce = GetComponent<PlayerBounce>();
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
            if (Input.GetKey(KeyCode.E)) 
            {
                loseGame();
            }
        }
        else
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                whoosh.Play();
            }

            if (Input.GetKey(KeyCode.E))
            {
                spinTime += Time.deltaTime;
                Debug.Log("getkey" + spinTime);
                totalScore += spinTime;
                scoreText.text = "Score: " + (totalScore).ToString("0");
                GetComponent<SpriteRenderer>().color = Color.yellow;
            }

            if (Input.GetKeyUp(KeyCode.E))
            {
                //the spinTime will be sent to another script thatll determine how much force to add/subtract to the ball when it bounces again
                //but the prototype wouldnt have this for now
                playerBounce.AddSpinTime(spinTime);
                //and once the key is released, the spinTime is reset to zero
                spinTime = 0;
                GetComponent<SpriteRenderer>().color = Color.white;
                whoosh.Stop();
                Debug.Log("keylifted");
               
            }
        }
    }
    public void enterDeathSpace()
    {

        inDeathSpace = true; 
    }

    public void exitDeathSpace()
    {
        inDeathSpace = false;
    }
    public void loseGame() 
    {
        SceneManager.LoadScene("LoseScreen");
    }
}
