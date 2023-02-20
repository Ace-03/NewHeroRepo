using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jump_Boost : MonoBehaviour
{
    public PlayerBehaviour _player;
    public GameBehavior _gameManager;
    // Start is called before the first frame update
    void Start()
    {
        _player = GameObject.Find("Player").GetComponent<PlayerBehaviour>();
        _gameManager = GameObject.Find("GameManager").GetComponent<GameBehavior>();
        _gameManager.jump_pad_count += 1;
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.name == "Player")
            other.gameObject.GetComponent<Rigidbody>().AddForce(Vector3.up * 15f, ForceMode.Impulse);
    }
}