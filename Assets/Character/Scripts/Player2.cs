using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player2 : CharacterBehavior{
    private Skill _skill;

    void Awake(){
        GameObject p1 = null;
        GameObject[] rootObjects = UnityEngine.SceneManagement.SceneManager.GetActiveScene().GetRootGameObjects();
        foreach (GameObject i in rootObjects){
            if(i.name == "P1"){
                p1 = i;
                break;
            }
        }

        other_player = p1.transform.Find("Player1").GetComponent<CharacterBehavior>();
        // TODO
        _skill = new Egypt(this, other_player);
    }

    void Update(){
        UserInput();
    }

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
        if(Input.GetKeyDown(KeyCode.G)){
            is_sitting = true;
            _animator.Play("Sit");
        }else if(Input.GetKeyUp(KeyCode.G)){
            _animator.Play("Idle");
            is_sitting = false;
        }
        
        // move control
        if(Input.GetKey(KeyCode.F)){
            if(is_ground)
                _animator.Play("Run");
            update_left = true;
        }else if(Input.GetKey(KeyCode.H)){
            if(is_ground)
                _animator.Play("Run");
            update_right = true;
        }

        // idle contorl
        if(update_left == false && update_right == false)
            if(is_ground && !is_sitting)
                _animator.Play("Idle");
            
        // jump control
        if(Input.GetKeyDown(KeyCode.T)){
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
        if (Input.GetKey(KeyCode.Q))
            _animator.Play("Attack");

        // Skill 1
        if (Input.GetKey(KeyCode.W)){
            _animator.Play("Attack");
            _skill.Skill1();
        }

        // Skill 2
        if (Input.GetKey(KeyCode.E)){
            _animator.Play("Attack");
            _skill.Skill2();
        }
    }
}