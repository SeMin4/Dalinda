using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerSelect : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    void Update()
    {
        if(GameSetting.selec_p1 != -1 && GameSetting.selec_p2 != -1){
            ChangeScene();
        }
    }

    void ChangeScene(){
        Debug.Log("Changing to Scene2");
        SceneManager.LoadScene("PlayScene");
    }
}
