public class Korean : Skill
{
    private CharacterBehavior me;
    private CharacterBehavior other_player;

    public Korean(CharacterBehavior me, CharacterBehavior other)
    {
        skill_time = 10f;
        this.me = me;
        this.other_player = other;
    }
    //  Speed up
    public override void Skill1(bool t)
    {
        if(t)
            me.move_power = 10f;
        else
            me.move_power = 5f;
    }
    // public override void Skill2(bool t)
    // {

    // }
    

}
