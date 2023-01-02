using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flashlight : MonoBehaviour
{
    public GameObject Light;
    public bool LightOn;
    public bool Wait = true;

    // Start is called before the first frame update
    void Start()
    {
        LightOn = true;
        Wait = true;
    }

    // Update is called once per frame
    void Update()
    {
        //Input works
        //Turn ON
        if (Input.GetMouseButton(0) && LightOn == true && Wait)
        {      
            Light.SetActive(false);
            LightOn = false;
            Wait = false;
            StartCoroutine(FailSafe());
            Enemy.PlayerLightOn = false;
        }
        
        //Turn OFF
        if (Input.GetMouseButton(0) && LightOn == false && Wait)
        {
            Light.SetActive(true);
            LightOn = true;
            Wait = false;
            StartCoroutine(FailSafe());
            Enemy.PlayerLightOn = true;
        }

        

    }//Update

    IEnumerator FailSafe()
    {
        yield return new WaitForSeconds(1f);
        Wait = true;
    }


}//class
