using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterBehavior : MonoBehaviour
{
    private CapsuleCollider2D _capsulle_collider;
    private Rigidbody2D _rigidbody;
    private Animator _animator;
    
    // status
    public int jump_count = 0;
    
    private bool is_sitting = false;
    public bool is_ground = true;

    // for FixedUpdate
    private bool update_jump = false;
    private bool update_down_jump = false;
    private bool update_left = false;
    private bool update_right = false;

    // for skill effect
    public bool is_direction_reverse = false;
    
    [Header("[Setting]")]
    public float move_power = 5f;
    public float jump_power = 10f;
    public int jump = 2;


    // [Override Functions]

    void Awake(){
        
    }

    void Start(){
        _animator = this.transform.Find("model").GetComponent<Animator>();
        _capsulle_collider = this.transform.GetComponent<CapsuleCollider2D>();
        _rigidbody = this.transform.GetComponent<Rigidbody2D>();
    }
    
    void Update(){
        UserInput();
    }

    // Physics engine Updates
    // Refer: https://docs.unity3d.com/ScriptReference/MonoBehaviour.FixedUpdate.html
    void FixedUpdate(){
        Move();
        Jump();
        DownJump();
    }

    // void OnCollisionEnter2D(Collision2D other){
    //     if(other.gameObject.tag == "Ground") {
    //         is_ground = true;
    //         jump_count = 0;
    //         Debug.Log("ground");
    //     }
    // }

    // void OnCollisionExit2D(Collision2D other){
    //     if(other.gameObject.tag == "Ground") {
    //         is_ground = false;
    //         Debug.Log("not ground");
    //     }
    // }

    // void OnTriggerEnter2D(Collider2D other){
    //     //if (other.CompareTag("Ground")){}
    // }

    // void OnTriggerExit2D(Collider2D other){
    //     //if (other.CompareTag("Ground")){}
    // }

    // [Custom Functions]
    
    
    // UserInput: Animation Control by user input
    void UserInput(){
        AnimatorStateInfo anim_info = _animator.GetCurrentAnimatorStateInfo(0);

        // TODO remove Die
        if (Input.GetKey(KeyCode.Alpha1)){
            _animator.Play("Die");
        }

        // die, do nothing
        if(anim_info.IsName("Die"))
            return;

        // attack, do noting
        if (anim_info.IsName("Attack"))
            return;
            
        // sit control
        if(Input.GetKeyDown(KeyCode.DownArrow)){
            is_sitting = true;
            _animator.Play("Sit");
        }else if(Input.GetKeyUp(KeyCode.DownArrow)){
            _animator.Play("Idle");
            is_sitting = false;
        }
        
        // move control
        if(Input.GetKey(KeyCode.LeftArrow)){
            if(is_ground)
                _animator.Play("Run");
            update_left = true;
        }else if(Input.GetKey(KeyCode.RightArrow)){
            if(is_ground)
                _animator.Play("Run");
            update_right = true;
        }

        // idle contorl
        if(update_left == false && update_right == false)
            if(is_ground && !is_sitting)
                _animator.Play("Idle");
            
        // jump control
        if(Input.GetKeyDown(KeyCode.Space)){
            if(jump_count < jump){   // 0, 1
                _animator.Play("Jump");
                jump_count++;

                if(is_sitting && !is_ground)
                    update_down_jump = true;
                else
                    update_jump = true;
            }
        }

        // attack control
        if (Input.GetKey(KeyCode.Mouse0))
            _animator.Play("Attack");
    }


    // [Character control]
    // controlled in FixedUpdate because character has Rigidbody

    void Move(){
        Vector3 moveVelocity = Vector3.zero;
        
        if(update_left){
            if(is_direction_reverse){
                moveVelocity = Vector3.right;
                transform.rotation = Quaternion.Euler(new Vector3(transform.rotation.x, 180, transform.rotation.z));
            }else{
                moveVelocity = Vector3.left;
                transform.rotation = Quaternion.Euler(new Vector3(transform.rotation.x, 0, transform.rotation.z));
            }
            
        }else if(update_right){
            if(is_direction_reverse){
                moveVelocity = Vector3.left;
                transform.rotation = Quaternion.Euler(new Vector3(transform.rotation.x, 0, transform.rotation.z));
            }else{
                moveVelocity = Vector3.right;
                transform.rotation = Quaternion.Euler(new Vector3(transform.rotation.x, 180, transform.rotation.z));
            }
        }
        transform.position += moveVelocity * move_power * Time.deltaTime;
        
        update_left = false;
        update_right = false;
    }

    void Jump(){
        if(!update_jump)
            return;

        // Prevent Velocity amplification
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


    IEnumerator GroundCapsulleColliderTimmerFuc()
    {
        yield return new WaitForSeconds(0.07f);
        _capsulle_collider.enabled = true;
    }
}
