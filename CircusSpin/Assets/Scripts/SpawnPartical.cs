using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPartical : MonoBehaviour
{
    [SerializeField] GameObject particalSystem;
    [SerializeField] TrickPatternCreator bouncecounterkeeper;
    ParticleSystem part = null;


    // Start is called before the first frame update
    void Start()
    {
        part = particalSystem.GetComponent<ParticleSystem>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (particalSystem != null && bouncecounterkeeper.numOfCorrectInputs > 0)
        {
            Instantiate(particalSystem, new Vector3(0,-2.77f,0), Quaternion.Euler(-90,0,0));
        }
    }


}
