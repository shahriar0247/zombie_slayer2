using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using UnityEngine;
using UnityEngine.AI;

public class Zombie_Controller : MonoBehaviour
{

    public float lookRadius = 10f;
    public float health;

    NavMeshAgent agent;
    public GameObject player;

    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
      

    }

    // Update is called once per frame
    void Update()
    {
        float distance = Vector3.Distance(player.transform.position, transform.position);
        
        if (distance <= lookRadius && distance > 2f)
        {
            face_target();
            agent.SetDestination(player.transform.position);
            
        }

        else if(distance <= 2f)
        {
            attack();
        }
    }

    void face_target()
    {
        Vector3 direction = (player.transform.position -  transform.position).normalized;
        Quaternion lookRotation = Quaternion.LookRotation(new Vector3(direction.x, 0, direction.z));
        transform.rotation = Quaternion.Slerp(transform.rotation,lookRotation, Time.deltaTime * 5);
    }

    void attack()
    {
        player.GetComponent<Player_health>().take_damage(10f);
        


    }

    public void take_damage(float amount)
    {
        health = health - amount;
        if (health <= 0)
        {
            die();
        }
      
    }
    public void die()
    {
        Destroy(this.gameObject);
    }

    

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, lookRadius);
    }
}
