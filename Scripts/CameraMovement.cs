using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    //Variable to store position of the player.
    public Transform player;

    //Using late update because I want to move the camera after the player.
    void LateUpdate(){
        
        try{
            //Taking x coordinate and Z coordinate of player.
            float playerXposition = player.position.x;
            float playerZposition = player.position.z;
            
            //This condition will only allow the camera to follow the player until
            //a certain coordinate is met.
            //I also set a static value for the camera's y position as 
            //I did not want it to follow the ball when it's jumping
            if (playerXposition < 6.5f && playerXposition > -6.5f && playerZposition>-6.5f && playerZposition<6.5f){
                transform.position = new Vector3((player.position.x), 3.029042f , (player.position.z-4));
            }
        }
        catch{
            Debug.Log("Noob Player");
        }
         
    }
}
