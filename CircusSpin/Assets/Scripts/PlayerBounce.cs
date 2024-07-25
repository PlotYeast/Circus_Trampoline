using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBounce : MonoBehaviour
{
    float airTime = 0;
    float spinTime;
    int score = 0;
    [SerializeField] float jumpForce;
    [SerializeField] float timeMultiplier = 1.5f;
    [SerializeField] AudioSource Bounce1;
    [SerializeField] AudioSource Bounce2;
    [SerializeField] AudioSource Bounce3;
    SpinManager spinner;
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
        airTime += Time.deltaTime;
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        int bounceSound = Random.Range(1, 4);
        Debug.LogWarning(bounceSound);

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
        foreach (KeyCode input in spinner.GetPlayerInputs()) 
        {
            print(input.ToString());
        }
        spinner.ClearInputs();
        float timeSpun = spinTime / airTime * timeMultiplier;
        rB.velocity = new Vector2(0, timeSpun*jumpForce);
        if (spinTime == 0) 
        {
            spinner.loseGame();
        }
        airTime = 0;
        spinTime = 0;
    }
    public void AddSpinTime(float extraTime) 
    {
        spinTime += extraTime;
    }
    public void AddScore(int inputSequences) 
    {
        score += (inputSequences * (inputSequences + 1) * 50);
    }
}
