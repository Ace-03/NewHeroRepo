using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBehaviour : MonoBehaviour
{
    public float moveSpeed = 10f;
    public float rotateSpeed = 75f;
    public float jumpVelociy = 5f;
    public float distanceToGround = 0.1f;
    public LayerMask groundLayer;
    public GameObject bullet;
    public GameObject fourth_shot;
    public float bulletSpeed = 50f;
    public double shot;
    //public GameBehavior gameManager;

    private float vInput;
    private float hInput;
    private Rigidbody _rb;
    private CapsuleCollider _col;
    private double bulletDelay = 0.1;
    private double timeShot = 0.0;
    private int bulletCounter = 0;
    private GameBehavior _gameManager;

    // Start is called before the first frame update
    void Start()
    {
        _rb = GetComponent<Rigidbody>();
        _col = GetComponent<CapsuleCollider>();
        _gameManager = GameObject.Find("GameManager").GetComponent<GameBehavior>();

    }



    // Update is called once per frame
    void Update()
    {

        vInput = Input.GetAxis("Vertical") * moveSpeed;
        hInput = Input.GetAxis("Horizontal") * rotateSpeed;
        /*
        this.transform.Translate(Vector3.forward * vInput * Time.deltaTime);
        this.transform.Rotate(Vector3.up * hInput * Time.deltaTime);
        */

        

        if (IsGrounded() && Input.GetKeyDown(KeyCode.Space))
        {
            _rb.AddForce(Vector3.up * jumpVelociy, ForceMode.Impulse);
        }


        if ((Input.GetMouseButtonDown(0) && _gameManager.Tracer_Pickup == false) || (Input.GetMouseButton(0) && _gameManager.Tracer_Pickup == true && Time.timeAsDouble > timeShot + bulletDelay))
        {
            
            if (bulletCounter >= 3 && _gameManager.Four_Pickup)
            {
                GameObject newBullet3 = Instantiate(fourth_shot, this.transform.position + this.transform.rotation * new Vector3(1, 0, 1), this.transform.rotation) as GameObject;
                Rigidbody bulletRB3 = newBullet3.GetComponent<Rigidbody>();
                bulletRB3.velocity = this.transform.forward * bulletSpeed * 4f;
                bulletCounter = 0;
                if (_gameManager.Tracer_Pickup) 
                {
                    GameObject newBullet4 = Instantiate(fourth_shot, this.transform.position + this.transform.rotation * new Vector3(-1, 0, 1), this.transform.rotation) as GameObject;
                    Rigidbody bulletRB4 = newBullet4.GetComponent<Rigidbody>();
                    bulletRB4.velocity = this.transform.forward * bulletSpeed * 4f;
                }
                timeShot = Time.timeAsDouble;
            }
            else
            {
                bulletCounter++;
                if (_gameManager.Tracer_Pickup)
                {
                    GameObject newBullet2 = Instantiate(bullet, this.transform.position + this.transform.rotation * new Vector3(-1, 0, 1), this.transform.rotation) as GameObject;
                    Rigidbody bulletRB2 = newBullet2.GetComponent<Rigidbody>();
                    bulletRB2.velocity = this.transform.forward * bulletSpeed;
                }
                GameObject newBullet = Instantiate(bullet, this.transform.position + this.transform.rotation * new Vector3(1, 0, 1), this.transform.rotation) as GameObject;
                Rigidbody bulletRB = newBullet.GetComponent<Rigidbody>();
                bulletRB.velocity = this.transform.forward * bulletSpeed;
                timeShot = Time.timeAsDouble;
            }
        }
       
    }

    void FixedUpdate()
    {

           

        Vector3 rotation = Vector3.up * hInput;
        Quaternion angleRot = Quaternion.Euler(rotation * Time.fixedDeltaTime);

        _rb.MovePosition(this.transform.position + this.transform.forward * vInput * Time.fixedDeltaTime);
        _rb.MoveRotation(_rb.rotation * angleRot);

        
    }

    private bool IsGrounded()
    {

        Vector3 capsuleBottom = new Vector3(_col.bounds.center.x, _col.bounds.min.y, _col.bounds.center.z);

        bool grounded = Physics.CheckCapsule(_col.bounds.center, capsuleBottom, distanceToGround, groundLayer, QueryTriggerInteraction.Ignore);

        return grounded;
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name == "Enemy")
        {

            _gameManager.HP -= 1;

        }
    }
}
