using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBounce : MonoBehaviour
{
    float airTime = 0;
    float spinTime;
    [SerializeField] float jumpForce;
    [SerializeField] float timeMultiplier = 1.5f;
    Rigidbody2D rB;
    // Start is called before the first frame update
    void Start()
    {
        rB = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        airTime += Time.deltaTime;
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        float timeSpun = spinTime / airTime * timeMultiplier;
        rB.velocity = new Vector2(0, timeSpun*jumpForce);
        if (spinTime == 0) 
        {
            //Loss Code
        }
        airTime = 0;
        spinTime = 0;
    }
    public void AddSpinTime(float extraTime) 
    {
        spinTime += extraTime;
    }
}
