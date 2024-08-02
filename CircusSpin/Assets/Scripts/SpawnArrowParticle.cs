using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnArrowParticle : MonoBehaviour
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

    public void SpawnParticle(Vector3 position, GameObject parent)
    {
        if (particalSystem != null)
        {
            GameObject newObject = Instantiate(particalSystem, position, Quaternion.identity);
            newObject.transform.SetParent(parent.transform);
        }
    }


}
