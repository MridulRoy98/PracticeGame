using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{   
    void Start()
    {
        gameObject.AddComponent<BoxCollider>();
        gameObject.AddComponent<Rigidbody>();
        GetComponent<Rigidbody>().useGravity = false;
        
        
    }
    void Update()
    {
        transform.Rotate(0, 0, 50f * Time.deltaTime);
        // Vector3 currentPosition = transform.position;
        // while (currentPosition.y != 1.5f){
        //     currentPosition.y -= 0.01f;
        //     transform.position = currentPosition;
        // }if(transform.position.y == 1.5f){
        //     while(transform.position.y!=2.5f){
        //         currentPosition.y += 0.01f;
        //         transform.position = currentPosition;
        //     }
        // }
        
            
            
    }
    void OnCollisionEnter(Collision collisionInfo)
    {
        if(collisionInfo.gameObject.name == "Sphere"){
            Destroy(gameObject);
        }
        
    }
}
