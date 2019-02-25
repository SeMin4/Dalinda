public class Korean : Skill
{
    private CharacterBehavior me;
    private CharacterBehavior other_player;

    public Korean(CharacterBehavior me, CharacterBehavior other)
    {
        this.me = me;
        this.other_player = other;
    }
    // DirectionReverser
    public void Skill1()
    {
        me.move_power = 10f;
    }
    public void Skill2()
    {

    }
    

}
