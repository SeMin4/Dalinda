using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class gameStartButton : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    public void Button(){
        Invoke("startgame",.3f);
    }
    private void startgame(){
        SceneManager.LoadScene("SampleScene");
    }
    
    void Update()
    {
        
    }
}
