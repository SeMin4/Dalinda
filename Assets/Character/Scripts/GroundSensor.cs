using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GroundSensor : MonoBehaviour{

    private CharacterBehavior player;
    
    void Start (){
        if(this.transform.root.name == "P1")
            player = this.transform.root.Find("Player1").GetComponent<CharacterBehavior>();
        else if(this.transform.root.name == "P2")
            player = this.transform.root.Find("Player2").GetComponent<CharacterBehavior>();
    }
    
    void OnTriggerEnter2D(Collider2D other){
        if(other.tag == "Trap" && !player.dead){
            player._hp = 0;
            Debug.Log(player._hp);
        }

        if(other.tag == "Finish")
            GameObject.Find("Canvas/FinishText").GetComponent<Text>().text = player.name + " win! !";
    }

    void OnTriggerStay2D(Collider2D other)
    {
        if (other.tag == "Ground")
        {
            player.is_ground = true;
            player.jump_count = 0;
        }
        if (other.tag == "Block")
            player.jump_count = 0;
    }

    void OnTriggerExit2D(Collider2D other){
        if(other.tag == "Ground") {
            player.is_ground = false;
        }
    }
}