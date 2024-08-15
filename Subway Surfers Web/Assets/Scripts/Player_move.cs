using System;
using UnityEngine;

public class Player_move : MonoBehaviour
{
    [SerializeField] public float speed;
    [SerializeField] private float jump_force,_mobileForce;
    [SerializeField] private Transform _Isground;
    [SerializeField] private LayerMask _groundLayer;
    private bool dead;
    private Animator _anim;
    private bool _canJump,_Onground;
    private Rigidbody _rb;
    private Collider _col;

    public void Start()
    {
        _anim = GetComponent<Animator>();
        _rb= GetComponent<Rigidbody>();
        _col = GetComponent<Collider>();
    }
    private void Update()
    {
        _Onground = Physics.CheckSphere(_Isground.position, 0.5f, _groundLayer);
        Debug.Log(dead);
        Movement();
        if (Input.GetKey(KeyCode.Space))
        {
            pcJump();
        }

        MoveSideWays_PC();

        Limits();

        slide_pc();

    }
    #region Movement&Jump
    public void Movement()
    {
        if(!dead)
        {
            speed += Time.deltaTime;
            if (!_anim.GetCurrentAnimatorStateInfo(0).IsName("idle"))
            {
                transform.Translate(speed * Vector3.forward * Time.deltaTime);
            }
        }
       

    }

    public void mobile_jump()
    {

        if (_Onground)
        {
            _rb.AddForce(0, _mobileForce, 0, ForceMode.Impulse);
            _anim.SetTrigger("jump");

        }
      
    }
    void pcJump()
    {
       
        if (_Onground)
        {
            _rb.AddForce(0, jump_force, 0, ForceMode.Impulse);

            _anim.SetTrigger("jump");

        }

    }
    #endregion

    #region SideWays
    void MoveSideWays_PC()
    {
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            transform.position = new Vector3(transform.position.x + 6, transform.position.y, transform.position.z);
        }
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            transform.position = new Vector3(transform.position.x - 6, transform.position.y, transform.position.z);
        }
    }
   public void MoveLeftSide()
    {
        transform.position = new Vector3(transform.position.x - 6, transform.position.y, transform.position.z);
    }
    public void MoveRightSide() 
    {
        transform.position = new Vector3(transform.position.x + 6, transform.position.y, transform.position.z);
    }
    void Limits()
    {
        if (transform.position.x < 128)
        {
            transform.position =new Vector3( 128,transform.position.y,transform.position.z);
        }
        else if (transform.position.x > 140)
        {
            transform.position = new Vector3(140, transform.position.y, transform.position.z);
        }
    }
    #endregion

    #region Slide
    void slide_pc()
    {
        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            _anim.SetTrigger("slide");
           
        }
    }
   public void slide_mobile()
    {
            //_rb.AddForce(0, _mobileForce, 0, ForceMode.Impulse);
            _anim.SetTrigger("slide");

    }
    #endregion
    #region collision detection
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "obs")
        {
            dead=true;
            _anim.SetTrigger("death");
        }
    }
    #endregion
}
