using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioScript : MonoBehaviour
{
    AudioSource m_MyAudioSource;
    public AudioClip stage_1;
    public AudioClip stage_2;
    public AudioClip stage_3;
    bool m_play1 = false, m_play2 = false, m_play3 = false;
    float player1_camera_x_posion, player2_camera_x_posion;
    float winner_player_camera_x_posion;

    // Start is called before the first frame update
    void Start()
    {
        Destroy(GameObject.Find("Audio"));
        m_MyAudioSource = GetComponent<AudioSource>();
        m_play1 = true;
    }

    // Update is called once per frame
    void Update()
    {
        player1_camera_x_posion = GameObject.Find("P1/Camera").GetComponent<CameraController>().camera_x_position;
        player2_camera_x_posion = GameObject.Find("P2/Camera").GetComponent<CameraController>().camera_x_position;

        if(player1_camera_x_posion < player2_camera_x_posion)
            winner_player_camera_x_posion = player2_camera_x_posion;
        else if(player1_camera_x_posion > player2_camera_x_posion)
            winner_player_camera_x_posion = player1_camera_x_posion;
        Debug.Log(winner_player_camera_x_posion);
        
        if(winner_player_camera_x_posion > 0 && winner_player_camera_x_posion < 373 && m_play1){
            m_MyAudioSource.Play();
            m_play1 = false;
            m_play2 = true;
        }
            
        else if(winner_player_camera_x_posion >= 373 && winner_player_camera_x_posion < 755 && m_play2){
            //m_MyAudioSource.Stop();
            m_MyAudioSource.clip = stage_2;
            m_MyAudioSource.Play();
            m_play2 = false;
            m_play3 = true;
        }
         else if(winner_player_camera_x_posion >= 755 && m_play3){
            //m_MyAudioSource.Stop();
            m_MyAudioSource.clip = stage_3;
            m_MyAudioSource.Play();
            m_play3 = false;
        }
            
        
    }
}
