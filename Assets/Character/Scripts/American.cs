using UnityEngine;
public class American : Skill
{
    private CharacterBehavior me;
    private CharacterBehavior other_player;

    public American(CharacterBehavior me, CharacterBehavior other)
    {
        this.me = me;
        this.other_player = other;
    }
    // DirectionReverser
    public void Skill1()
    {
        other_player._tilemap.color = Color.black;
        other_player._background[0].color = Color.black;
        other_player._background[1].color = Color.black;
        other_player._background[2].color = Color.black;
    }
    public void Skill2()
    {

    }


}
