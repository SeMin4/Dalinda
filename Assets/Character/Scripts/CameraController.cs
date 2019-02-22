using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class CameraController : MonoBehaviour {

    public Transform edge;
    private CharacterBehavior player;

    public GameObject Target;
    public float PosY = 1;
    private bool camera_move = true;

    void Awake()
    {
        player = this.transform.root.Find("Player1").GetComponent<CharacterBehavior>();
    }
    void Start()
    {
        edge = this.transform.Find("LeftEdge");
    }

    void Update()
    {
        float x_position = Target.transform.position.x;
        float prev_x_poisition = edge.position.x;

        if(prev_x_poisition - x_position < -2.4)
            camera_move = true;
        else
            camera_move = false;

        // Debug.Log(prev_x_poisition - x_position);
        
        if(!camera_move){
            if(player.is_ground){
                Vector3 Targetpos = new Vector3(this.transform.position.x, Target.transform.position.y + PosY, -100);
                transform.position = Vector3.Lerp(transform.position, Targetpos, Time.deltaTime * 4);
             }else{
                Vector3 Targetpos = new Vector3(this.transform.position.x, transform.position.y, -100);
                transform.position = Vector3.Lerp(transform.position, Targetpos, Time.deltaTime * 1);
             }
        }else {
            if(player.is_ground){
                Vector3 Targetpos = new Vector3(Target.transform.position.x+4, Target.transform.position.y + PosY, -100);
                transform.position = Vector3.Lerp(transform.position, Targetpos, Time.deltaTime * 4);
            }else{
                Vector3 Targetpos = new Vector3(this.transform.position.x+4, transform.position.y, -100);
                transform.position = Vector3.Lerp(transform.position, Targetpos, Time.deltaTime * 1);
             }
        }
    }



}
