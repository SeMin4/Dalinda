using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDetect : MonoBehaviour{
    private AnimalObject animal;

    void Start(){
        animal = this.transform.root.GetComponent<AnimalObject>();
    }

    /*void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Player")){
            animal.Move(true);
            animal.LookAt(true);
            Debug.Log("MEET PLAYER");
        }
        if(other.CompareTag("Ground")){
            Debug.Log("MEET ground");
        }
    } */

}