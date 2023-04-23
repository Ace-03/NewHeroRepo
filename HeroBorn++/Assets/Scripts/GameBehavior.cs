using UnityEngine;
using UnityEngine.SceneManagement;

public class GameBehavior : MonoBehaviour
{
    public bool showWinScreen = false;
    public bool showLossScreen = false;

    private int _itemsCollected = 0;
    private int _playerHP = 10;


    private int jump_pad_num = 0;
    public int jump_pad_count
    {
        get { return jump_pad_num; }
        set 
        { 
            jump_pad_num = value;
            if (jump_pad_num > 3)
            {
                int i = 0;
                for (i = 1; i <= jump_pad_num - 3; ++i) 
                {
                    Destroy(GameObject.Find("jump_pad(Clone)"));
                
                }
            }
        }
    }

    private bool firegun = false;
    public bool Firegun_Pickup
    {
        get { return firegun; }
        set 
        {
            firegun = value;
            FiregunPower = numPickups;
        }
    }

    private bool jump_pad = false;
    public bool Jump_Pad_Pickup 
    { 
        get { return jump_pad; }
        set
        {
            jump_pad = value;
            JumpPadPower = numPickups;
        }
    }

    private bool tracer = false;
    public bool Tracer_Pickup
    {
        get { return tracer; }
        set 
        {   
            tracer = value;
            tracerPower = numPickups;        
        }
    }

    private bool four = false;
    public bool Four_Pickup
    {
        get { return four; }
        set 
        { 
            four = value;
            fourPower = numPickups;
        }
    }

    private int numPowerups = 0;
    public int numPickups
    {
        get {return numPowerups; }
        set { numPowerups = value; }
        
    }

    private int FiregunPower = -1;
    public int FiregunID 
    {
        get { return FiregunPower; }
    }

    private int JumpPadPower = -1;
    public int JumpPadID 
    { 
        get { return JumpPadPower; }
    }

    private int tracerPower = -1;
    public int tracerID
    {
        get { return tracerPower; }
    }

    private int fourPower = -1;
    public int fourID
    { 
        get { return fourPower; }
    }

    public string labelText = "Collect all 4 items and win your freedom";
    public int maxItems = 4;

    public int Items
    { 
    
        get { return _itemsCollected; }
        set { _itemsCollected = value;
                Debug.LogFormat("Items: {0}", _itemsCollected);

                    if (_itemsCollected >= maxItems)
                    { 
                        labelText = "You've found all the items!";
                        showWinScreen = true;
                        Time.timeScale = 0f;
                    } 
                    else 
                    {
                        labelText = "Item found, only " + (maxItems - _itemsCollected) + " more to go!";
                    }
        }

    }

    public int HP
    {

        get { return _playerHP; }
        set
        {
            _playerHP = value;
            Debug.LogFormat("Lives: {0}", _playerHP);


            if (_playerHP <= 0)
            {
                labelText = "You want another life with that?";
                showLossScreen = true;
                Time.timeScale = 0;
            }
            else
            {
                labelText = "Ouch... that's got to hurt";
            }
        }

    }

    void restartGame()
    {
        SceneManager.LoadScene(0);
        Time.timeScale = 1.0f;

    }
    void OnGUI()
    {

        GUI.Box(new Rect(20, 20, 150, 25), "Player Health: " + _playerHP);
        GUI.Box(new Rect(20, 50, 150, 25), "Items Collected: " + _itemsCollected);
        GUI.Label(new Rect(Screen.width / 2 - 100, Screen.height - 50, 300, 50), labelText);


        if (showWinScreen)
        {
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
            /*
            if (GUI.Button(new Rect(Screen.width / 2 - 100, Screen.height / 2 - 50, 200, 100), "YOU WON!"))
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
            }
            */
        }

        if (showLossScreen)
        {
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 2);
            /*
            if (GUI.Button(new Rect(Screen.width / 2 - 100, Screen.height / 2 - 50, 200, 100), "YOU LOSE..."))
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 2);
            }
            */
        }


    }

    // Start is called before the first frame update
    void Start()
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

