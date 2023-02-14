using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletBahvior : MonoBehaviour
{

    public float onscreenDelay = 1f;
    // Start is called before the first frame update
    void Start()
    {
        Destroy(this.gameObject, onscreenDelay);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
