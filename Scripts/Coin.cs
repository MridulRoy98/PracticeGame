using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    private Vector3 initialPosition;
    void Start()
    {
        //Adding Collider and rigidbody to coins.
        //Added Rigidbody to allow player to clip through.
        //Disabled Gravity to allow coin to float.
        initialPosition = transform.position;
        gameObject.AddComponent<BoxCollider>();
        gameObject.AddComponent<Rigidbody>();
        GetComponent<Rigidbody>().useGravity = false;
    }
    void Update(){
        
        //Constant Rotation animation.
        transform.Rotate(0, 0, 50f * Time.deltaTime);

        //Constant Floating animation (up and down).
        GetComponent<Rigidbody>().velocity = new Vector3(0, Mathf.Sin(Time.time * 2) * 0.5f, 0);
    }
    void OnCollisionEnter(Collision collisionInfo){

        //Checking for collision with player and Moving Coin out of camera.
        if(collisionInfo.gameObject.name == "Sphere"){
            transform.position = new Vector3(transform.position.x, transform.position.y+10, transform.position.z);
        } 
    }
}
