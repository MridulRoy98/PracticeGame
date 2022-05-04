using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SphereSpawn : MonoBehaviour
{
    public GameObject Sphere;
    void Start()
    {
        Instantiate(Sphere, transform.position, Quaternion.identity);
    }

    // Update is called once per frame
    
}
