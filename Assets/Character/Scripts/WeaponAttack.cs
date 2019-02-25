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
            Destroy(other.gameObject);
            Debug.Log("DELETE ENEMY");
        }
    }

    void OnCollisionStay2D(Collision2D other){
        if(other.gameObject.tag == "Enemy" && player.is_attacking) {
            Destroy(other.gameObject);
        }
    }

    void OnCollisionExit2D(Collision2D other){
        if(other.gameObject.tag == "Enemy") {
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
