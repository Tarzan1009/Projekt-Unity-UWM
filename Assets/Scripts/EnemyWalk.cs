using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyWalk : MonoBehaviour
{
    public float damage;
    public float force;

    private GameObject player;
    private GameObject destination;
    private NavMeshAgent agent;

    void OnCollisionEnter(Collision other)
    {
        if(other.gameObject.tag == "Player")
        {
            player.GetComponent<Health>().Damage(damage);

            Vector3 otherDirection = (player.transform.position - transform.position).normalized;
            Vector3 forceDirection = (otherDirection + Vector3.up * 0.5f).normalized;
            player.GetComponent<Rigidbody>().AddForce(forceDirection * force * 50);
            Debug.Log(other.gameObject.GetComponent<Rigidbody>());
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        System.Random rand = new System.Random();
        int playerOrNav = rand.Next(1, 3);
        if(playerOrNav == 1)
        {
            destination = GameObject.Find("Player");
        }
        else
        {
            destination = GameObject.Find("NavPoint");
        }
        player = GameObject.Find("Player");
        agent = GetComponent<NavMeshAgent>();

        agent.SetDestination(destination.transform.position);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
