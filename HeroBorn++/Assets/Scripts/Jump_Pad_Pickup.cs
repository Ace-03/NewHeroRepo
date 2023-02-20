using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jump_Pad_Pickup: MonoBehaviour
{
    public GameBehavior gameManager;

    void Start()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameBehavior>();
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name == "Player")
        {
            Destroy(this.transform.parent.gameObject);
            Debug.Log("Item collected!");
            gameManager.Items += 1;
            gameManager.numPickups++;
            gameManager.Jump_Pad_Pickup = true;
        }
    }
}
