using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    public int Health;

    public int MaxHealth;

    public static int Batteries =0;

    public static bool attack;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(attack)
        {
            Health--;
            attack= false;
        }


    }//Update

    public static void Attacked()
    {
        attack = true;
    }

    public void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "battery") 
        {
            Batteries++;
            Destroy(other.gameObject);
        }
    }

}//class
