using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class toTheInit : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    public void Button(){
        GameSetting.selec_p1 = -1;
        GameSetting.selec_p2 = -1;
        Invoke("toTheStart",.3f);
    }
    private void toTheStart(){
        SceneManager.LoadScene("InitialScene");
    }
    
    void Update()
    {
        
    }
}
