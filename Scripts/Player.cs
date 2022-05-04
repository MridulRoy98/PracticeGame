using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public Vector3 sphereSpawn;
    private Rigidbody rb;
    public int speed = 10;
    private int points;
    
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }
    void FixedUpdate(){
       
        rb.AddForce(Physics.gravity * rb.mass * 3.5f);
        if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.D) ||Input.GetKey(KeyCode.Space)){
        
            float moveHorizontal = Input.GetAxis("Horizontal");
            float moveVertical = Input.GetAxis("Vertical");

            Vector3 movement = new Vector3(moveHorizontal, 0, moveVertical);
            rb.AddForce(movement * speed);
        }

        if(rb.velocity.magnitude !=0 ){
            Vector3 dampeningDirection = rb.velocity.normalized * -7.0f;
            rb.AddForce(dampeningDirection * 0.5f);
        }
    }
    void Jump(){
        rb.AddForce(Vector3.up * speed * 80);
    } 
    void OnCollisionStay(Collision collider){
        if(collider.gameObject.name == "Ground" && Input.GetKey(KeyCode.Space)){  
            Jump();
        }          
    }
    void OnCollisionEnter(Collision collisionInfo){
        if(collisionInfo.gameObject.name == "Ground"){
        }
        if(collisionInfo.gameObject.name == "Bottom_Detector"){
            Debug.Log("Recycled");
            // Destroy(gameObject);
            ReInstantiate();
        }
        if(collisionInfo .gameObject.name == "Coin"){
            points +=1;
            Debug.Log("Points: "+ points);
        }
    }
    void ReInstantiate(){
        rb.angularVelocity = Vector3.zero;
        rb.velocity = Vector3.zero;
        gameObject.transform.position = new Vector3(0, 12.55f, 0);
    }
    
}
