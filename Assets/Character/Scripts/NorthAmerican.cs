using UnityEngine;
public class NorthAmerican : Skill
{
    private CharacterBehavior me;
    private CharacterBehavior other_player;

    public NorthAmerican(CharacterBehavior me, CharacterBehavior other)
    {
        this.me = me;
        this.other_player = other;
    }
    // DirectionReverser
    public void Skill1()
    {
            other_player.camera_controller.camera_flip = true;
    }
    public void Skill2()
    {

    }


}
