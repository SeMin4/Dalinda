using System;
using System.Collections;
using UnityEngine;
public class European :  Skill
{
    private CharacterBehavior me;
    private CharacterBehavior other_player;

    public European(CharacterBehavior me, CharacterBehavior other)
    {
        this.me = me;
        this.other_player = other;
    }
    // DirectionReverser
    public void Skill1()
    {
        other_player.skill_jump = true;
    }
 
    public void Skill2()
    {

    }


}
