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
    Rigidbody2D rB;
    float highestDistance = 0f;
    List<KeyCode> playerInputs;

    //this is some set up variables for changing the force of the bounce.
    //Time gained will find
    float timeGained;

    // Start is called before the first frame update
    void Start()
    {
        inDeathSpace = false;
        spinTime = 0;
        playerBounce = GetComponent<PlayerBounce>();
        rB = GetComponent<Rigidbody2D>();
        rB.gravityScale = 0f;
        playerInputs = new List<KeyCode>();
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.y > highestDistance)
        {
            highestDistance = transform.position.y;
        }

        if (Input.GetKeyDown(KeyCode.UpArrow)) AddInput(KeyCode.UpArrow);
        else if (Input.GetKeyDown(KeyCode.LeftArrow)) AddInput(KeyCode.LeftArrow);
        else if(Input.GetKeyDown(KeyCode.DownArrow)) AddInput(KeyCode.DownArrow);
        else if(Input.GetKeyDown(KeyCode.RightArrow)) AddInput(KeyCode.RightArrow);

            if (inDeathSpace && Input.GetKey(KeyCode.E))
            {
                //im thinking something around the lines of locking all player interaction
                //and forcing a cutscene of the player going oof
                //but it also can just cut to a screen of a dead af little guy as the "game over".
                // it would be easier to code but more jarring 
                loseGame();
            }
            else
            {
                if (Input.GetKeyDown(KeyCode.E))
                {
                    whoosh.Play();
                    rB.gravityScale = 1f;
                }

                if (Input.GetKey(KeyCode.E))
                {
                    spinTime += Time.deltaTime;
                    totalScore += spinTime;
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

                }
            }

        scoreText.text = "Highest jump reached \r\n" + (highestDistance).ToString("0.#") + " meters.";
    }
    void AddInput(KeyCode input)
    {
        if (inDeathSpace)
        {
            loseGame();
        }
        else 
        {
            playerInputs.Add(input);
            //whoosh may have to be adjusted, but it's a temporary sound, so that was going to happen anyways
            whoosh.Play();
        }

    }
    public List<KeyCode> GetPlayerInputs() 
    {
        return playerInputs;
    }
    public void ClearInputs() 
    {
        playerInputs.Clear();
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
        SceneManager.LoadScene("EndScene");
        PlayerPrefs.SetFloat("GameDistance", highestDistance);
        if (highestDistance > PlayerPrefs.GetFloat("HighestDistance", 0.0f))
        {
            PlayerPrefs.SetFloat("HighestDistance", highestDistance);
        }
    }
}
