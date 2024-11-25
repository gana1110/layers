using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class canvas : MonoBehaviour
{
    int compteur = 0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        compteur++;
        if (compteur == 300){
            GetComponent<Canvas>().enabled = false;
        }
    }
}
