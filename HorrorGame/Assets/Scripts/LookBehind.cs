using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookBehind : MonoBehaviour
{
    public GameObject Fcam;
    public GameObject Bcam;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKey(KeyCode.R))
        {
            Fcam.SetActive (false);
            Bcam.SetActive (true);
        }
    
        else
        {
            Fcam.SetActive (true);
            Bcam.SetActive (false);
        }


    }//update
}//class
