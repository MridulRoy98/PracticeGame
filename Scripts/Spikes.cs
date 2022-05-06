using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spikes : MonoBehaviour
{
    // Start is called before the first frame update
    //Will add component only when the game starts
    void Start()
    {
        //Adding Collider to Spikes so player can interact with it
        gameObject.AddComponent<BoxCollider>();    
    }

    // Update is called once per frame
    
}
