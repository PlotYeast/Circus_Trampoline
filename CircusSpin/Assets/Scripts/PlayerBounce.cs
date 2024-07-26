using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBounce : MonoBehaviour
{
    int score = 0;
    [SerializeField] float jumpForce = 10.0f;
    [SerializeField] float jumpModifier = 0.5f;
    [SerializeField] float jumpForceMax = 10.0f;
    [SerializeField] AudioSource Bounce1;
    [SerializeField] AudioSource Bounce2;
    [SerializeField] AudioSource Bounce3;
    SpinManager spinner;
    [SerializeField] TrickPatternCreator patternCreator;
    Rigidbody2D rB;
    // Start is called before the first frame update
    void Start()
    {
        spinner = GetComponent<SpinManager>();
        rB = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        int bounceSound = Random.Range(1, 4);
        switch (bounceSound) 
        {
            case 1:
                Bounce1.Play();
                break;
            case 2:
                Bounce2.Play();
                break;
            case 3:
                Bounce3.Play();
                break;
            default:
                break;
        }
        int inputSequences = patternCreator.CompareInputs(spinner.GetPlayerInputs());
        print(inputSequences);
        spinner.AddScore(inputSequences);
        if (inputSequences == 0) { jumpForce -= jumpModifier; }
        else
        {
            jumpForce += jumpModifier;
            if (jumpForce > jumpForceMax) jumpForce = jumpForceMax;
        }
        foreach (string input in spinner.GetPlayerInputs()) 
        {
            print(input.ToString());
        }
        spinner.ClearInputs();
        
        rB.velocity = new Vector2(0, jumpForce);
        if (jumpForce <= 0) { spinner.loseGame();}
    }
    public void AddSpinTime(float spinTime) 
    {
        //I wanted to delete this function because we're no longer using spinTime
        //But that would break code in SpinManager, which someone else is working on.
        //So this is an empty function to prevent things from breaking.
    }
}
