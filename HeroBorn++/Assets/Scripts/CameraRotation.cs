using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraRotation : MonoBehaviour
{
    private float vInput;
    public float rotateSpeed = 1;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        vInput = Input.GetAxis("Vertical") * rotateSpeed;
        this.transform.Rotate(Vector3.right * vInput * Time.fixedDeltaTime);
    }
}
