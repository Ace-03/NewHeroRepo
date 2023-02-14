using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraBehaviour : MonoBehaviour
{

    public Vector3 camOffest = new Vector3(0f, 1.2f, -2.6f);
    private Transform target;

    // Start is called before the first frame update
    void Start()
    {
        target = GameObject.Find("Player").transform;
    }

    void LateUpdate()
    {

        this.transform.position = target.TransformPoint(camOffest);

        this.transform.LookAt(target);
    
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
