using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundSensor : MonoBehaviour{

    private CharacterBehavior player;
    
    void Awake (){
        if(this.transform.root.name == "P1")
            player = this.transform.root.Find("Player1").GetComponent<CharacterBehavior>();
        else if(this.transform.root.name == "P2")
            player = this.transform.root.Find("Player2").GetComponent<CharacterBehavior>();
    }

    void Start(){
        
    }
    
    void Update(){
        
    }

    void OnTriggerEnter2D(Collider2D other){
        if(other.tag == "Ground") {
            player.is_ground = true;
            player.jump_count = 0;
            // Debug.Log("ground");
        }
        if(other.tag == "Block")
            player.jump_count = 0;
    }
    
    void OnTriggerStay2D(Collider2D other)
    {
        if (other.tag == "Ground")
        {
            player.is_ground = true;
            player.jump_count = 0;
            // Debug.Log("ground");
        }
        if (other.tag == "Block")
            player.jump_count = 0;
    }

    void OnTriggerExit2D(Collider2D other){
        if(other.tag == "Ground") {
            player.is_ground = false;
            // Debug.Log("not ground");
        }
    }
}