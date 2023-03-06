using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flammable : MonoBehaviour
{
    private double timeOnFire;
    private bool onFire = false;
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
            Instantiate(FirePS, this.transform.position,this.transform.rotation);
        }
    }

    private void OnCollisionStay(Collision collision)
    {
        if (collision.gameObject.name == "fire")
        {
            Debug.Log("AAAAA");
            timeOnFire += Time.deltaTime;
        }
    }
}
