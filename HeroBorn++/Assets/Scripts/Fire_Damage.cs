using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fire_Damage : MonoBehaviour
{
    private float timeDelay = .25f;
    private float startTime = 0f;
    public Flammable flammable;
    // Start is called before the first frame update
    void Start()
    {
       
    }

    void OnTriggerStay(Collider other)
    {
       if(other.gameObject.GetComponent<Flammable>() != null)
        {
            flammable = other.gameObject.GetComponent<Flammable>();
            flammable.timeOnFire += Time.deltaTime;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
