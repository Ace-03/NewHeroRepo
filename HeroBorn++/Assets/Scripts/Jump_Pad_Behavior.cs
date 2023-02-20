using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jump_Pad_Behavior : MonoBehaviour
{

    public GameObject JumpPad;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    void OnCollisionEnter(Collision collision)
    {
        Destroy(this.gameObject);
        if (collision.gameObject.CompareTag("ground"))
            Instantiate((JumpPad), this.transform.position, this.transform.rotation);
    }
    // Update is called once per frame
    void Update()
    {

    }
}

