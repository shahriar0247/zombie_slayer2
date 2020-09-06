using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using UnityEngine;
using UnityEngine.AI;

public class Zombie_Controller : MonoBehaviour
{

    public float lookRadius = 10f;
    public float health;
    public float attack_power;

    NavMeshAgent agent;
    Animator animator;

    bool attacking;
    GameObject closestplayer;

    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        animator = GetComponentInChildren<Animator>();
        animator.SetInteger("state", 0);
        attacking = false;
       
    }





    void Update()
    {

        GameObject[] players = search_for_players();
        GameObject player = find_closest_player(players);
        closestplayer = player;
   

        float distance = Vector3.Distance(player.transform.position, transform.position);

        if (distance <= lookRadius && distance > 2f)
        {
            face_target(player);
            attacking = false;
            animator.SetInteger("state", 1);
            if (!animator.GetCurrentAnimatorStateInfo(0).IsName("attack"))
            {
                agent.SetDestination(player.transform.position);
            }
               
           
        }
        else if (distance > lookRadius) {
            agent.SetDestination(this.transform.position);
            animator.SetInteger("state", 0);
        }

        else if (distance <= 2f)
        {

            face_target(player);

            attacking = true;
          
               animator.SetInteger("state", 3);


           


        }
    }

    GameObject[] search_for_players()
    {
        GameObject[] players = null;

        players = GameObject.FindGameObjectsWithTag("Player");

        return players;
    }

    GameObject find_closest_player(GameObject[] players)
    {
        GameObject closest_player = players[0];
        float closest_player_distance = Vector3.Distance(this.transform.position, players[0].transform.position);
       

        foreach (GameObject player in players)
        {
            if (Vector3.Distance(this.transform.position, player.transform.position) < closest_player_distance) {
                closest_player_distance = Vector3.Distance(this.transform.position, player.transform.position);
                closest_player = player;
            }
           
        }


        return closest_player;
    }

    void face_target(GameObject player)
    {
        Vector3 direction = (player.transform.position -  transform.position).normalized;
        Quaternion lookRotation = Quaternion.LookRotation(new Vector3(direction.x, 0, direction.z));
        transform.rotation = Quaternion.Slerp(transform.rotation,lookRotation, Time.deltaTime * 5);
    }

    void Attack()
    {

       
        if (attacking == true) {
        
            closestplayer.GetComponent<Player_health>().take_damage(attack_power);
            

        }


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
