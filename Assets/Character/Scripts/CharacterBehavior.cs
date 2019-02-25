﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class CharacterBehavior : MonoBehaviour
{
    private CapsuleCollider2D _capsulle_collider;
    private Rigidbody2D _rigidbody;

    public Animator _animator;
    protected CharacterBehavior other_player;

    public Skill _skill;
    public bool is_skill;

   
    // status
    public int jump_count = 0;
    protected bool is_sitting = false;
    public bool is_ground;
    public bool is_attacking;

    // for FixedUpdate
    public bool update_jump = false;
    protected bool update_down_jump = false;
    protected bool update_left = false;
    protected bool update_right = false;

    // for skill effect
    public bool is_direction_reverse = false;

    //tilemap & background for color black(skill effect)
    public Tilemap _tilemap;
    public SpriteRenderer[] _background;

    //skill effect camera reverse
    public Transform camera_transform;
    public CameraController camera_controller;
    //skill infinite jump
    public bool skill_jump = false;

    [Header("[Setting]")]
    public float move_power = 5f;
    public float jump_power = 10f;
    public int jump = 2;


    // [Override Functions]
    void Start(){
        _animator = this.transform.Find("model").GetComponent<Animator>();
        _capsulle_collider = this.transform.GetComponent<CapsuleCollider2D>();
        _rigidbody = this.transform.GetComponent<Rigidbody2D>();
       
        //skill black screen
        _tilemap = this.transform.root.Find("map").Find("tile").Find("ground").GetComponent<Tilemap>();
        _background = new SpriteRenderer[3];
        _background[0] = this.transform.root.Find("map").Find("BG").Find("Background1").GetComponent<SpriteRenderer>();
        _background[1] = this.transform.root.Find("map").Find("BG").Find("Background2").GetComponent<SpriteRenderer>();
        _background[2] = this.transform.root.Find("map").Find("BG").Find("Background3").GetComponent<SpriteRenderer>();
        //skill camera reverse
        camera_transform = this.transform.root.Find("Camera").GetComponent<Transform>();
        camera_controller = this.transform.root.Find("Camera").GetComponent<CameraController>();
    }
    
    
    // Physics engine Updates
    // Refer: https://docs.unity3d.com/ScriptReference/MonoBehaviour.FixedUpdate.html
    void FixedUpdate(){
        Move();
        Jump();
        DownJump();
        InfiniteJump();
        
    }

    

    // void OnTriggerEnter2D(Collider2D other){
    //     if (other.CompareTag("Ground")){}
    // }

    // void OnTriggerExit2D(Collider2D other){
    //     //if (other.CompareTag("Ground")){}
    // }

    
    // [Character control]
    // controlled in FixedUpdate because character has Rigidbody
    void Move(){
        Vector3 moveVelocity = Vector3.zero;
        
        if(update_left){
            moveVelocity = Vector3.left;
            transform.rotation = Quaternion.Euler(new Vector3(transform.rotation.x, 0, transform.rotation.z));
        }else if(update_right){
            moveVelocity = Vector3.right;
            transform.rotation = Quaternion.Euler(new Vector3(transform.rotation.x, 180, transform.rotation.z));
        }
        transform.position += moveVelocity * move_power * Time.deltaTime;
        
        update_left = false;
        update_right = false;
    }

    void Jump(){
        if(!update_jump)
            return;

        _rigidbody.velocity = Vector2.zero;

        Vector2 jumpVelocity = new Vector2(0, jump_power);
        _rigidbody.AddForce(jumpVelocity, ForceMode2D.Impulse);

        update_jump = false;
    }

    void DownJump(){
        if(!update_down_jump)
            return;

        _rigidbody.velocity = Vector2.zero;
        _capsulle_collider.enabled = false;
        
        Vector2 jumpVelocity = new Vector2(0, -jump_power);
        _rigidbody.AddForce(jumpVelocity, ForceMode2D.Impulse);
        
        StartCoroutine(GroundCapsulleColliderTimmerFuc());
        update_down_jump = false;
    }

    IEnumerator GroundCapsulleColliderTimmerFuc(){
        yield return new WaitForSeconds(0.066f);
        _capsulle_collider.enabled = true;
    }
    private int infinite_jump_count = 0;

    private void InfiniteJump(){
        if(!skill_jump)
            return;
        StartCoroutine(InfiniteJumpTimer());
        if(infinite_jump_count > 100){
            skill_jump = false;
            infinite_jump_count = 0;
        }
    }
    IEnumerator InfiniteJumpTimer(){
        if(is_ground)
        {
            update_jump = true;   
            infinite_jump_count++;
            jump_count = 1;
            // Debug.Log(infinite_jump_count);
            _animator.Play("Jump");     
        }
        yield return new WaitUntil(() => is_ground);
    }

    protected IEnumerator SkillTimer(){
        yield return new WaitForSeconds(_skill.getTime());
        _skill.Skill1(false);
    }

    protected IEnumerator AttackTimer(){
        yield return new WaitForSeconds(1f);
        is_attacking = false;
    }
}