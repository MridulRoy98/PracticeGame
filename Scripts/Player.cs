using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    private Rigidbody rb;
    public int speed = 10;
    private int points;
    
    void Start()
    {
        // Fetching rigidbody component of player.
        rb = GetComponent<Rigidbody>();
    }
    
    // Using fixed update because of physics simulation. 
    void FixedUpdate(){
       
        // Increasing local gravity of the Sphere(Player).
        rb.AddForce(Physics.gravity * rb.mass * 3.5f);

        Vector3 acc = Input.acceleration;
        rb.AddForce(acc.x * speed*5, 0, acc.y * speed*5);
        // Looking for input from the player.
        if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.Space))
        {


            float moveHorizontal = Input.GetAxis("Horizontal");
            float moveVertical = Input.GetAxis("Vertical");

            Vector3 movement = new Vector3(moveHorizontal, 0, moveVertical);
            rb.AddForce(movement * speed);
        }
        //void FixedUpdate()
        //{
        //    transform.Translate(Input.acceleration.x * speed * Time.deltaTime,
        //                        Input.acceleration.y * speed * Time.deltaTime, 0);
        //}

        // Adding friction to Sphere(Player)
        if (rb.velocity.magnitude !=0 ){
            
            // Will keep slowing down the player if the ball is moving.
            // Added force in the opposite direction of the player's movement.
            Vector3 dampeningDirection = rb.velocity.normalized * -7.0f;
            rb.AddForce(dampeningDirection * 0.5f);
        }
    }
    private void OnMouseDown()
    {
        rb.AddForce(Vector3.up * speed * 80);
    }
    void Jump(){

        // Applying force upwards to jump
        rb.AddForce(Vector3.up * speed * 80);
    }

    void OnCollisionStay(Collision collider)
    {
        if (collider.gameObject.name == "Ground" && Input.touchCount>0)
        {
            //OnMouseDown();
            Jump();
        }
    }
    void OnCollisionEnter(Collision collisionInfo){

        // This condition will check if the player falls off the platform or touches the spikes.
        // In that case this condition will restart the whole level.
        if (collisionInfo.gameObject.name == "Bottom_Detector" || collisionInfo.gameObject.name == "Spikes")
        {
            Debug.Log("You Died :(");
            ReInstantiate();
            //coin.RespawnCoin();
        }

        // Checking if the player collides with a coin.
        // If the player collides then they will be rewarded with one point which will increment if more collected
        if(collisionInfo.gameObject.name == "Coin"){
            points +=1;
            Debug.Log("Points: "+ points);
        }
    }
    void ReInstantiate(){

        // Reseting the whole scene when the player dies.
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

}
