using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class P1_Selector : MonoBehaviour
{
    private GameObject _camera;
    private GameObject[] _targets;
    private Animator[] _animators;
    private int PosY = 2;
    private int count;
    private int idx;
    private Vector3 Targetpos;

    void Awake(){
        _camera = GameObject.Find("P1/P1 Cam");
        count = GameSetting.Characters.GetValues(typeof(GameSetting.Characters)).Length;
        _animators = new Animator[count];
        _targets = new GameObject[count];
        for(int i=0; i<count; i++){
            GameSetting.Characters character = (GameSetting.Characters)i;
            _targets[i] = GameObject.Find("P1/"+character.ToString());
            _animators[i] = _targets[i].transform.Find("model").GetComponent<Animator>();
            _animators[i].Play("Idle");
        }
    }

    void Start(){
        idx = 0;
        _animators[0].Play("Run");
        Targetpos = new Vector3(_targets[0].transform.position.x, _targets[0].transform.position.y + PosY, -100);
    }

    void Update(){
        if(Input.GetKeyDown(KeyCode.H)){
            _animators[idx].Play("Idle");
            idx = (idx+1) % count;

            _animators[idx].Play("Run");
            Targetpos = new Vector3(_targets[idx].transform.position.x, _targets[idx].transform.position.y + PosY, -100);
        }
        _camera.transform.position = Vector3.MoveTowards(_camera.transform.position, Targetpos, Time.deltaTime * 35);

        if(Input.GetKeyDown(KeyCode.Q)){
            _animators[idx].Play("Attack");
            GameSetting.selec_p1 = idx;
        }
    }
}