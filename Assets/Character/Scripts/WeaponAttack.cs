using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponAttack : MonoBehaviour
{
    private CharacterBehavior player;

    void Awake()
    {
        string me = this.transform.root.gameObject.name;
        
        GameObject[] rootObjects = UnityEngine.SceneManagement.SceneManager.GetActiveScene().GetRootGameObjects();
        foreach (GameObject i in rootObjects){
            if(i.name == "P1" && me == "P1"){
                player = i.transform.Find("Player1").GetComponent<CharacterBehavior>();
                break;
            }
            else if(i.name == "P2" && me == "P2"){
                player = i.transform.Find("Player2").GetComponent<CharacterBehavior>();
                break;
            }
        }
    }

    void OnCollisionEnter2D(Collision2D other){
        if(other.gameObject.tag == "Enemy" && player.is_attacking) {
            
            AnimalObject enemy = other.gameObject.GetComponent<AnimalObject>();
            if(enemy._hp <= 0)
                Destroy(other.gameObject);
            else
                enemy._hp--;
            player.is_attacking = false;
            
            Debug.Log("E "+enemy._hp);
        }
    }

    void OnCollisionStay2D(Collision2D other){
        
    }

    void OnCollisionExit2D(Collision2D other){
        
    }

    void Start(){
        
    }
    // Update is called once per frame
    void Update()
    {
    }
}
