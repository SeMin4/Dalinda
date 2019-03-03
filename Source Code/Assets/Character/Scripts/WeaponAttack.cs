using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class WeaponAttack : MonoBehaviour
{
    private CharacterBehavior player;

    void Start()
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

    void OnTriggerEnter2D(Collider2D other){
        if(other.tag == "Enemy" && player.is_attacking) {
            
            AnimalObject enemy = other.GetComponent<AnimalObject>();
            enemy._hp--;
            Vector3 hit_pos = new Vector3(other.transform.position.x+50, other.transform.position.y, other.transform.position.z);
            other.transform.position = Vector3.Lerp(other.transform.position,  hit_pos, Time.deltaTime);
            //(System).Random rand = new (System).Random();
            int number = Random.Range(0,3);

            if(enemy._hp <= 0)
            {
                if(number == 0 || number == 1){
                    GameObject GiftBox;
                    Vector3 pos_animal = other.transform.position;
                    GiftBox = Instantiate (Resources.Load ("Prefabs/gift_box"), pos_animal, Quaternion.identity) as GameObject;
                    GiftBox.name = "GiftBox"; // name을 변경
                    GiftBox.transform.parent = GameObject.Find(other.transform.root.name).transform;
                }
                Destroy(other.gameObject);
            }
                
            
            player.is_attacking = false;
            Debug.Log("E "+enemy._hp);
        }
    }

    void OnCollisionStay2D(Collision2D other){
        
    }

    void OnCollisionExit2D(Collision2D other){
        
    }

    // Update is called once per frame
    void Update()
    {
    }
}
