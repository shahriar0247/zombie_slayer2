using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Player_health : MonoBehaviour
{

    public float health;
    public Text healthText;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        healthText.text = Convert.ToInt32(health).ToString();
    }

    public void take_damage(float amount)
    {
        health = health - amount * Time.deltaTime;
        if (health <= 0)
        {
            die();
        }

    }

    public void die()
    {
        Destroy(this.gameObject);
    }
}
