using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Lofle;

public class AnimalObject : MonoBehaviour
{
    public enum eSprite
    {
        Idle,
        Bark,
        Run,
        Attack
    }
    // Start is called before the first frame update
    [SerializeField]
    private Rigidbody2D _rigidbody = null;
    [SerializeField]
    private SpriteRenderer _spriteIdle = null;
    [SerializeField]
    private SpriteRenderer _spriteBark = null;
    [SerializeField]
    private SpriteRenderer _spriteRun = null;
    [SerializeField]
    private SpriteRenderer _spriteAttack = null;

    private StateMachine<AnimalObject> _stateMachine = null;
    [SerializeField]
    private float _speed = 5.0f;
    public bool enable = false;

    void Start()
    {
        _stateMachine = new StateMachine<AnimalObject>(this);
        StartCoroutine(_stateMachine.Coroutine<IdleState>());
    }

    // Update is called once per frame
    void Update()
    {

    }
    private void OnBecameVisible()
    {
        enable = true;
     
    }
    private void OnBecameInVisible()
    {
        enable = false;

    }
    private void Move(bool bLeft)
    {
        _rigidbody.AddForce(new Vector2((bLeft ? -_speed : _speed), 0));

    }
    private void LookAt(bool bLeft)
    {
        transform.rotation = Quaternion.Euler(new Vector3(transform.rotation.x, bLeft ? 180 : 0, transform.rotation.z));
    }

    private void HidleAllSprite()
    {
        _spriteIdle.enabled = false;
        _spriteBark.enabled = false;
        _spriteRun.enabled = false;
        _spriteAttack.enabled = false;
    }
    private void ShowSprite(eSprite type)
    {
        HidleAllSprite();
        switch (type)
        {
            case eSprite.Idle:
                _spriteIdle.enabled = true;
                break;
            case eSprite.Bark:
                _spriteBark.enabled = true;
                break;
            case eSprite.Run:
                _spriteRun.enabled = true;
                break;
            case eSprite.Attack:
                _spriteAttack.enabled = true;
                break;
        }
    }
    private class IdleState : State<AnimalObject>
    {
        protected override void Begin()
        {
            Owner.ShowSprite(eSprite.Idle);
            Owner.LookAt(true);
        }
        protected override void Update()
        {
            Owner.OnBecameVisible();
            if (Owner.enable)
            {
                Invoke<RunState>();
            }
           
        }
        protected override void End()
        {

        }
    }
    private class BarkState : State<AnimalObject>
    {
        protected override void Begin()
        {
            Owner.ShowSprite(eSprite.Bark);
        }
        protected override void Update()
        {
            if (Input.GetKey(KeyCode.T))
            {
                Owner.Move(true);
                Owner.LookAt(true);
                
            }
            else
            {
                Invoke<IdleState>();
            }
        }
        protected override void End()
        {

        }
    }
    private class RunState : State<AnimalObject>
    {
        protected override void Begin()
        {
            Owner.ShowSprite(eSprite.Run);
        }
        protected override void Update()
        {
            if (Owner.enable)
            {
                Owner.Move(true);
                Owner.LookAt(true);

            }
            else
            {
                Invoke<IdleState>();
            }
        }
        protected override void End()
        {

        }
    }
    private class AttackState : State<AnimalObject>
    {
        protected override void Begin()
        {
            Owner.ShowSprite(eSprite.Attack);

        }
        protected override void Update()
        {
            if (Input.GetKey(KeyCode.T))
            {
                Owner.Move(true);
                Owner.LookAt(true);

            }
            else
            {
                Invoke<IdleState>();
            }
        }
        protected override void End()
        {

        }
    }
}
