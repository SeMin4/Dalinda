using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player1 : CharacterBehavior{
    

    void Start(){
        GameObject p1 = null;
        GameObject[] rootObjects = UnityEngine.SceneManagement.SceneManager.GetActiveScene().GetRootGameObjects();
        foreach (GameObject i in rootObjects){
            if(i.name == "P2"){
                p1 = i;
                break;
            }
        }
        

        other_player = p1.transform.Find("Player2").GetComponent<CharacterBehavior>();
    
        int type = GameSetting.selec_p1;
        switch(type)
        {
            case 0 : _skill = new European(this,other_player);
            break;
            case 1 : _skill = new Korean(this,other_player);
            break;
            case 2 : _skill = new Egyptian(this,other_player);
            break;
            case 3 : _skill = new American(this,other_player);
            break;
            case 4 : _skill = new NorthAmerican(this,other_player);
            break;
            default:
            break;           
        }
    }

    void Update(){
        UserInput();
    }

    private bool one = true;
    void OnCollisionEnter2D(Collision2D other){
        if(other.gameObject.tag == "Enemy" && one) {
            _hp--;
            StartCoroutine(BeatTimer());
            Debug.Log("P1 "+_hp);

            if(_hp <= 0){
                _animator.Play("Die");
                Debug.Log("P1 Die");
            }
        }
    }
    protected IEnumerator BeatTimer(){
        one = false;
        yield return new WaitForSeconds(3f);
        one = true;
    }

    void OnCollisionStay2D(Collision2D other){
        // bool one = true;
        // Debug.Log("Enter");
        // if(other.gameObject.tag == "Enemy" && one) {
        //     one = false;
        //     if(_hp <= 0) {
        //         Debug.Log("Die");
        //     }else {
        //         _hp--;
        //     }
        //     Debug.Log(_hp);
        // }
    }

    void UserInput(){
        AnimatorStateInfo anim_info = _animator.GetCurrentAnimatorStateInfo(0);

        // die, do nothing
        if(anim_info.IsName("Die"))
            return;

        // attack, do noting
        if (anim_info.IsName("Attack"))
            return;
            
        // sit control
        if(Input.GetKeyDown(KeyCode.G)){
            is_sitting = true;
            _animator.Play("Sit");
        }else if(Input.GetKeyUp(KeyCode.G)){
            _animator.Play("Idle");
            is_sitting = false;
        }
        
        // move control
        if(!is_direction_reverse){
            if(Input.GetKey(KeyCode.F)){
                if(is_ground)
                    _animator.Play("Run");
                update_left = true;
            }else if(Input.GetKey(KeyCode.H)){
                if(is_ground)
                    _animator.Play("Run");
                update_right = true;
            }
        }else{
            if(Input.GetKey(KeyCode.T)){
                if(is_ground)
                    _animator.Play("Run");
                update_left = true;
            }else if(Input.GetKey(KeyCode.G)){
                if(is_ground)
                    _animator.Play("Run");
                update_right = true;
            }
        }

        // idle contorl
        if(update_left == false && update_right == false)
            if(is_ground && !is_sitting)
                _animator.Play("Idle");
            
        // jump control
        if(Input.GetKeyDown(KeyCode.Q)){
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
        if (Input.GetKey(KeyCode.W)){
            _animator.Play("Attack");
            is_attacking = true;
            StartCoroutine(AttackTimer());
        }

        // Skill 1
        if (Input.GetKey(KeyCode.E)){
            _animator.Play("Attack");
            _skill.Skill1(true);
            StartCoroutine(SkillTimer());
        }

        // Skill 2
        // if (Input.GetKey(KeyCode.E)){
        //     _animator.Play("Attack");
        //     _skill.Skill2();
        // }
    }
    
    
}