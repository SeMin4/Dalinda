using UnityEngine;
public class NorthAmerican : Skill
{
    private CharacterBehavior me;
    private CharacterBehavior other_player;

    public NorthAmerican(CharacterBehavior me, CharacterBehavior other)
    {
        skill_time = 10f;
        this.me = me;
        this.other_player = other;
    }
    // camera flip
    public override void Skill1(bool t)
    {
        if(t)
            other_player.camera_controller.camera_flip = true;
        else
            other_player.camera_controller.camera_flip = false;
    }

    // public void Skill2()
    // {

    // }


}
