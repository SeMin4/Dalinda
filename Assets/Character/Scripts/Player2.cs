using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player2 : CharacterBehavior{

    void Start(){
        GameObject p2 = null;
        GameObject[] rootObjects = UnityEngine.SceneManagement.SceneManager.GetActiveScene().GetRootGameObjects();
        foreach (GameObject i in rootObjects){
            if(i.name == "P1"){
                p2 = i;
                break;
            }
        }

        other_player = p2.transform.Find("Player1").GetComponent<CharacterBehavior>();

        int type = GameSetting.selec_p2;
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
        StartCoroutine(CheckDie());
    }

    void Update(){
        UserInput();
    }
    IEnumerator CheckDie() {
        while (true) {
            if(_hp <= 0){
                _hp = 3;
                dead = true;
                _animator.Play("Die");
                Debug.Log("P2 Die");
                yield return StartCoroutine(Revive());
            }
            yield return null;
        }
    }
    private bool one = true;
    
    void OnCollisionEnter2D(Collision2D other){
        if(other.gameObject.tag == "Enemy" && one) {
            _hp--;
            StartCoroutine(BeatTimer());
            Debug.Log("P2 "+_hp);
        }
    }
    protected IEnumerator BeatTimer(){
        one = false;
        yield return new WaitForSeconds(3f);
        one = true;
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
        if(Input.GetKeyDown(KeyCode.DownArrow)){
            is_sitting = true;
            _animator.Play("Sit");
        }else if(Input.GetKeyUp(KeyCode.DownArrow)){
            _animator.Play("Idle");
            is_sitting = false;
        }
        
        // move control
        if(!is_direction_reverse){
            if(Input.GetKey(KeyCode.LeftArrow)){
                if(is_ground)
                    _animator.Play("Run");
                update_left = true;
            }else if(Input.GetKey(KeyCode.RightArrow)){
                if(is_ground)
                    _animator.Play("Run");
                update_right = true;
            }
        }else{
            if(Input.GetKey(KeyCode.UpArrow)){
                if(is_ground)
                    _animator.Play("Run");
                update_left = true;
            }else if(Input.GetKey(KeyCode.DownArrow)){
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
        if(Input.GetKeyDown(KeyCode.L)){
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
        if (Input.GetKey(KeyCode.Semicolon)){
            _animator.Play("Attack");
            is_attacking = true;
            StartCoroutine(AttackTimer());
        }

        // Skill 1
        if (Input.GetKey(KeyCode.Quote)){
            if(is_skill)
                return;
            is_skill = true;
            _animator.Play("Attack");
            _skill.Skill1(true);
            StartCoroutine(SkillTimer());
        }

        // Skill 2
        // if (Input.GetKey(KeyCode.DoubleQuote)){
        //     _animator.Play("Attack");
        //     _skill.Skill2();
        // }
    }
    
}