public class Egyptian : Skill
{
    private CharacterBehavior me;
    private CharacterBehavior other_player;

    public Egyptian(CharacterBehavior me, CharacterBehavior other){
        this.me = me;
        this.other_player = other;
    }
    // DirectionReverser
    public void Skill1(){
        other_player.is_direction_reverse = true;
    }
    public void Skill2(){
        
    }

    
}
