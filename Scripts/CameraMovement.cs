using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    public Transform player;

    void LateUpdate(){
        
        try{
            float playerXposition = player.position.x;
            float playerZposition = player.position.z;
        
            if (playerXposition < 6.5f && playerXposition > -6.5f && playerZposition>-6.5f && playerZposition<6.5f){
                transform.position = new Vector3((player.position.x), 3.029042f , (player.position.z-4));
            }
        }
        catch{
            Debug.Log("Noob Player");
        }
         
    }
}
