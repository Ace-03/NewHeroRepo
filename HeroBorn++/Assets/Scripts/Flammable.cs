using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flammable : MonoBehaviour
{
    public double timeOnFire;
    public bool onFire = false;
    public GameObject FirePS;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (timeOnFire >= 3f && !onFire)
        {
            Debug.Log("burning");
            onFire = true;
            GameObject flame = Instantiate(FirePS, this.transform.position,this.transform.rotation) as GameObject;
            flame.transform.parent = this.transform;
        }
    }


}
