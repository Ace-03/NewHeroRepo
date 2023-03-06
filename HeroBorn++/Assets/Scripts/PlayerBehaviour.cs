using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBehaviour : MonoBehaviour
{
    public float moveSpeed = 10f;
    public float moveMultiplier = 1;
    public float rotateSpeed = 75f;
    public float jumpVelociy = 5f;
    public float distanceToGround = 0.1f;
    public LayerMask groundLayer;
    public GameObject bullet;
    public GameObject fourth_shot;
    public float bulletSpeed = 75f;
    public double shot;
    public float jumpMod = 1f;
    public GameObject tracer_guns;
    public GameObject four_gun;
    public GameObject base_gun;
    public GameObject jump_pad;
    public GameObject jump_pad_sml;
    public GameObject firegun;
    public GameObject fire;
    public GameObject camera;
    //public GameBehavior gameManager;

    private float vInput;
    private float hInput;
    private Rigidbody _rb;
    private CapsuleCollider _col;
    private double bulletDelay = 0.1;
    private double timeShot = 0.0;
    private int bulletCounter = 0;
    private GameBehavior _gameManager;
    private float sInput;
    private int gunSelect = 1;
    

    // Start is called before the first frame update
    void Start()
    {
        _rb = GetComponent<Rigidbody>();
        _col = GetComponent<CapsuleCollider>();
        _gameManager = GameObject.Find("GameManager").GetComponent<GameBehavior>();
        camera = GameObject.Find("Main Camera");
    }
    // Update is called once per frame
    void Update()
    {
        
        hInput = Input.GetAxis("Horizontal") * rotateSpeed;
        /*
        this.transform.Translate(Vector3.forward * vInput * Time.deltaTime);
        this.transform.Rotate(Vector3.up * hInput * Time.deltaTime);
        */

        gunSelect += (int)Mathf.Round(Input.mouseScrollDelta.y);
        
        if (gunSelect > _gameManager.numPickups)
            gunSelect = 0;
        else if (gunSelect < 0)
            gunSelect = _gameManager.numPickups;
        


        if (gunSelect == _gameManager.tracerID)
            tracer_guns.SetActive(true);
        else
            tracer_guns.SetActive(false);
        
        if (gunSelect == _gameManager.fourID)
            four_gun.SetActive(true);
        else
            four_gun.SetActive(false);

        if (gunSelect == _gameManager.JumpPadID)
            jump_pad.SetActive(true);
        else
            jump_pad.SetActive(false);

        if (gunSelect == _gameManager.FiregunID)
            firegun.SetActive(true);
        else
            firegun.SetActive(false);
          
        if (gunSelect == 0)
            base_gun.SetActive(true);
        else
            base_gun.SetActive(false);




        if (Input.GetKey(KeyCode.A))
            sInput = -1f * moveSpeed;
        else if (Input.GetKey(KeyCode.D))
            sInput = 1f * moveSpeed;
        else
            sInput = 0;

        if (Input.GetKey(KeyCode.W))
            vInput = 1f * moveSpeed;
        else if (Input.GetKey(KeyCode.S))
            vInput = -1f * moveSpeed;
        else
            vInput = 0;

        Vector3 rotation = Vector3.up * hInput;
        Quaternion angleRot = Quaternion.Euler(rotation * Time.fixedDeltaTime);
        _rb.MoveRotation(_rb.rotation * angleRot);  

        if (IsGrounded() && Input.GetKeyDown(KeyCode.Space))
        {
            _rb.AddForce(Vector3.up * jumpVelociy * jumpMod, ForceMode.Impulse);
        }

        if (Input.GetMouseButtonDown(0) && gunSelect == _gameManager.JumpPadID)
        { 
            GameObject newJumpPad = Instantiate((jump_pad_sml), camera.transform.position + camera.transform.rotation * new Vector3(1, 0, 2), this.transform.rotation) as GameObject;
            Rigidbody JumpPadRB = newJumpPad.GetComponent<Rigidbody>();
            JumpPadRB.velocity = camera .transform.forward * (moveSpeed + .5f) - camera.transform.right * 2f;
        }

        if (Input.GetMouseButton(0) && gunSelect == _gameManager.FiregunID)
            fire.SetActive(true);
        else
            fire.SetActive(false);


        if ((Input.GetMouseButtonDown(0) && gunSelect == 0) || (Input.GetMouseButton(0) && gunSelect == _gameManager.tracerID && Time.timeAsDouble > timeShot + bulletDelay) || (Input.GetMouseButtonDown(0) && gunSelect == _gameManager.fourID))
        {
            if (bulletCounter >= 3 && gunSelect == _gameManager.fourID)
            {
                GameObject newBullet3 = Instantiate(fourth_shot, camera.transform.position + camera.transform.rotation * new Vector3(1, -0.15f, 1), this.transform.rotation) as GameObject;
                Rigidbody bulletRB3 = newBullet3.GetComponent<Rigidbody>();
                bulletRB3.velocity = camera.transform.forward * bulletSpeed * 4f - camera.transform.right * 2f;
                Debug.Log("FOUR!");
                bulletCounter = 0;

            }
            else
            {
                //Base Gun Firing
                GameObject newBullet = Instantiate(bullet, camera.transform.position + camera.transform.rotation * new Vector3(1, -0.15f, 1), this.transform.rotation) as GameObject;
                Rigidbody bulletRB = newBullet.GetComponent<Rigidbody>();
                bulletRB.velocity = camera.transform.forward * bulletSpeed - camera.transform.right * 2f;
                timeShot = Time.timeAsDouble;
                bulletCounter++;
                if (gunSelect == _gameManager.tracerID)
                {
                    GameObject newBullet2 = Instantiate(bullet, camera.transform.position + camera.transform.rotation * new Vector3(-1, -0.15f, 1), camera.transform.rotation) as GameObject;
                    Rigidbody bulletRB2 = newBullet2.GetComponent<Rigidbody>();
                    bulletRB2.velocity = camera.transform.forward * bulletSpeed + camera.transform.right * 2f;
                }

            }
        }
    }

    void FixedUpdate()
    {
              
        _rb.MovePosition(this.transform.position + this.transform.forward * vInput * moveMultiplier * Time.fixedDeltaTime + (this.transform.right * sInput * Time.fixedDeltaTime));

    }

    private bool IsGrounded()
    {
        Vector3 capsuleBottom = new Vector3(_col.bounds.center.x, _col.bounds.min.y, _col.bounds.center.z);
        bool grounded = Physics.CheckCapsule(_col.bounds.center, capsuleBottom, distanceToGround, groundLayer, QueryTriggerInteraction.Ignore);
        return grounded;
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name == "Enemy" || collision.gameObject.name == "Enemy_1" || collision.gameObject.name == "Enemy_2" || collision.gameObject.name == "Enemy_3" || collision.gameObject.name == "Enemy_4")
        {
            _gameManager.HP -= 1;
        }
    }
}
