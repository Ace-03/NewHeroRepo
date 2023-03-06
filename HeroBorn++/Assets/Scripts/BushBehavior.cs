using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BushBehavior : MonoBehaviour
{
    public PlayerBehaviour player;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player").GetComponent<PlayerBehaviour>();
    }

    private void OnTriggerStay(Collider other)
    {
        if(other.name == "Player")
        {
            player.moveMultiplier = 0.5f;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.name == "Player")
        {
            player.moveMultiplier = 1f;
        }
    }
}
