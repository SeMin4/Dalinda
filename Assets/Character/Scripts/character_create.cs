using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class character_create : MonoBehaviour
{
    public static GameObject Player1;
    public static GameObject Player2;
    void Awake(){
        GameSetting.Characters char_p1 = (GameSetting.Characters)GameSetting.selec_p1;
        GameSetting.Characters char_p2 = (GameSetting.Characters)GameSetting.selec_p2;
        Vector3 pos_p1 = GameObject.Find("P1/ReviveY").transform.position;
        Vector3 pos_p2 = GameObject.Find("P2/ReviveY").transform.position;

        Player1 = Instantiate (Resources.Load ("Prefabs/"+char_p1.ToString()), pos_p1, Quaternion.identity) as GameObject;
        Player2 = Instantiate (Resources.Load ("Prefabs/"+char_p2.ToString()), pos_p2, Quaternion.identity) as GameObject;

        Player1.name = "Player1"; // name을 변경
        Player1.transform.parent = GameObject.Find("P1").transform;
        Player1.AddComponent<Player1>();
        Player2.name = "Player2"; // name을 변경
        Player2.transform.parent = GameObject.Find("P2").transform;
        Player2.AddComponent<Player2>();
    }
    
    
    // Start is called before the first frame update
//    void Start()
  //  {
        
   // }

    // Update is called once per frame
    void Update()
    {
        
    }
}
