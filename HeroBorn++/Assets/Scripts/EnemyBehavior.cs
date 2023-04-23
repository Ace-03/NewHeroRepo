using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyBehavior : MonoBehaviour
{

    public Transform patrolRoute;
    public List<Transform> locations;
    public Transform player;

    private int locationIndex = 0;
    private NavMeshAgent agent;
    private int _lives = 20;
    public int EnemyLives
    {
        get { return _lives; }
        set
        {
            _lives = value;
            if (_lives <= 0)
            {
                Destroy(this.gameObject);
                Debug.Log("Enemy down.");
            }
        }

    }
    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        player = GameObject.Find("Player").transform;
        InitializePatrolRoute();
        MoveToNextPatrolLocation();
    }

    // Update is called once per frame
    void Update()
    {
        if (agent.remainingDistance < 0.2f && !agent.pathPending)
        {
            MoveToNextPatrolLocation();
        }
    }


    void InitializePatrolRoute()
    {
        foreach (Transform child in patrolRoute)
        {
            locations.Add(child);
        }
    }

    void MoveToNextPatrolLocation()
    {
        if (locations.Count == 0)
            return;

        agent.destination = locations[locationIndex].position;

        locationIndex = (locationIndex + 1) % locations.Count;
    }

    void OnTriggerEnter(Collider other)
    {

        if (other.name == "Player")
        {
            agent.destination = player.position;
            Debug.Log("Player detected - attack!");
        }
    }

    void OnTriggerExit(Collider other)
    {

        if (other.name == "Player")
        {

            Debug.Log("Player out of range, resume patrol");

        }

    }
    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name == "Bullet(Clone)" || collision.gameObject.name == "fire")
        {
            EnemyLives -= 1;

            var audioSource = GetComponent<AudioSource>();
            audioSource.Play();
            Debug.Log("Critial hit!");
        }

        if (collision.gameObject.name == "fourth_shot(Clone)")
        {
            if (_lives >= 10) {
                EnemyLives -= (4 + ((20 - _lives )/2));
            } 
            else 
            {
                EnemyLives -= (4 + ((20 - 10 )/2));
            }

            var audioSource = GetComponent<AudioSource>();
            audioSource.Play();
            Debug.Log("Critial hit!");
        }
    }

}

