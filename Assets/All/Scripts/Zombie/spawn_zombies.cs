using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawn_zombies : MonoBehaviour
{

    public GameObject Zombie;
    public int max_num_zombies = 10;
    int current_zombies;
    public GameObject[] zombies;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        zombies = GameObject.FindGameObjectsWithTag("Zombie");
       
        current_zombies = zombies.Length;
        if (current_zombies < max_num_zombies) { 
        Instantiate(Zombie, new Vector3(707, 21, 512), Quaternion.identity);
            current_zombies = current_zombies + 1;
        }
    }
}
