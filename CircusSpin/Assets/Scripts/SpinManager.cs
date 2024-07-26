using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.SocialPlatforms.Impl;


public class SpinManager : MonoBehaviour
{
    bool inDeathSpace;
    public float spinTime;
    [SerializeField] AudioSource whoosh;
    [SerializeField] Text scoreText;
    float score = 0f;
    PlayerBounce playerBounce;
    Rigidbody2D rB;
    float highestDistance = 0f;
    List<string> playerInputs;
    public Animator anim;

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
        playerInputs = new List<string>();
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.y > highestDistance)
        {
            highestDistance = transform.position.y;
        }

        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            AddInput("up");
            anim.SetFloat("TrickDirection", 1);
            anim.SetTrigger("IsTricking");
        }
        else if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            AddInput("left");
            anim.SetFloat("TrickDirection", 0);
            anim.SetTrigger("IsTricking");
        }
        else if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            AddInput("down");
            anim.SetFloat("TrickDirection", 0.6666667f);
            anim.SetTrigger("IsTricking");
        }
        else if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            AddInput("right");
            anim.SetFloat("TrickDirection", 0.33333333f);
            anim.SetTrigger("IsTricking");
        }

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
    }
    void AddInput(string input)
    {
        if (inDeathSpace)
        {
            loseGame();
        }
        else 
        {
            playerInputs.Add(input);
            rB.gravityScale = 1f;
            //whoosh may have to be adjusted, but it's a temporary sound, so that was going to happen anyways
            whoosh.Play();
        }

    }
    public List<string> GetPlayerInputs() 
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
    public void AddScore(int inputSequences)
    {
        score += (inputSequences * (inputSequences + 1) * 50);
        scoreText.text = "Current Score: " + score;
    }
}
