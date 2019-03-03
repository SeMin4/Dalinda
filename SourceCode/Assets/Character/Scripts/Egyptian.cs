public class Egyptian : Skill
{
    private CharacterBehavior me;
    private CharacterBehavior other_player;

    public Egyptian(CharacterBehavior me, CharacterBehavior other){
        skill_time = 10f;
        this.me = me;
        this.other_player = other;
    }
    // DirectionReverser
    public override void Skill1(bool t){
        if(t)
            other_player.is_direction_reverse = true;
        else
            other_player.is_direction_reverse = false;
    }
    // public void Skill2(){
        
    // }

    
}
