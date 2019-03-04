using System;
using System.Collections;
using UnityEngine;
public class European :  Skill
{
    private CharacterBehavior me;
    private CharacterBehavior other_player;

    public European(CharacterBehavior me, CharacterBehavior other)
    {
        skill_time = 10f;
        this.me = me;
        this.other_player = other;
    }
    // infinite jump
    public override void Skill1(bool t)
    {
        if(t == true)
            other_player.skill_jump = true;
        else
            other_player.skill_jump = false;
    }
 
    // public override void Skill2(bool t)
    // {

    // }
    


}
