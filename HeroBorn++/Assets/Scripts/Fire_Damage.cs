using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fire_Damage : MonoBehaviour
{
    public EnemyBehavior _enemy;
    private float timeDelay = .25f;
    private float startTime = 0f;
    // Start is called before the first frame update
    void Start()
    {
        _enemy = GameObject.Find("Enemy").GetComponent<EnemyBehavior>();
    }

    void OnTriggerStay(Collider other)
    {

        _enemy = other.gameObject.GetComponent<EnemyBehavior>();
        if (Time.time >= timeDelay + startTime)
        {
            _enemy.EnemyLives -= 1;
            startTime = Time.time;
        }
       

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
