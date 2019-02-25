using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class CameraController : MonoBehaviour
{

    public Transform edge;

    public GameObject Target;
    public float PosY = 10;
    private bool camera_move;
    
    // skill for camera flip
    public bool camera_flip;

    void Start()
    {
        edge = this.transform.Find("LeftEdge");
        camera_flip = false;
        camera_move = true;
    }

    void Update()
    {
        float x_position = Target.transform.position.x;
        float prev_x_poisition = edge.position.x;

        if (prev_x_poisition - x_position < -4.53)
            camera_move = true;
        else
            camera_move = false;

         //Debug.Log(prev_x_poisition - x_position);

        if (!camera_move)
        {
            Vector3 Targetpos = new Vector3(this.transform.position.x, Target.transform.position.y + PosY, camera_flip ? 100 : -100);
            transform.position = Vector3.Lerp(transform.position, Targetpos, Time.deltaTime * 4);
        }
        else
        {
            Vector3 Targetpos = new Vector3(Target.transform.position.x + 8, Target.transform.position.y + PosY, camera_flip ? 100 : -100);
            transform.position = Vector3.Lerp(transform.position, Targetpos, Time.deltaTime * 4);
        }

        if (camera_flip)
        {
            float speed = 5;
            transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.Euler(0, 180, 180), speed * Time.deltaTime);
        }
    }
}