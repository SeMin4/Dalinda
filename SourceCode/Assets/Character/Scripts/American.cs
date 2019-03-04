using UnityEngine;
public class American : Skill
{
    private CharacterBehavior me;
    private CharacterBehavior other_player;

    public American(CharacterBehavior me, CharacterBehavior other)
    {
        skill_time = 10f;
        this.me = me;
        this.other_player = other;
    }
    // DirectionReverser
    public override void Skill1(bool t)
    {
        if(t){
            other_player._tilemap.color = Color.black;
            other_player._background[0].color = Color.black;
            other_player._background[1].color = Color.black;
            other_player._background[2].color = Color.black;
        }else{
            other_player._tilemap.color = Color.white;
            other_player._background[0].color = Color.white;
            other_player._background[1].color = Color.white;
            other_player._background[2].color = Color.white;
        }
    }
    // public void Skill2()
    // {

    // }


}
