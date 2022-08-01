using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flashlight : MonoBehaviour
{
    public GameObject Light;
    bool LightOn;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButton(1))
        {
            if(LightOn)
            {
          
                Light.SetActive(false);
                LightOn = false;
            }

            if(LightOn)
            {
              Light.SetActive(true);
                LightOn = true;
            }
        }

    }
}
