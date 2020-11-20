using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class FPSController : MonoBehaviour
{
    
   [SerializeField] float moveSpeed = 7f;
    [SerializeField] Transform camTrans;
    [SerializeField] float mouseSensitivity =3f;
    [SerializeField] float sprintSpeed = 10f; 
    [SerializeField] float gravityModifier = 9.81f;
    [SerializeField] Transform groundCheckPoint;
    [SerializeField] LayerMask WhatIsGround;
    [SerializeField] float jumpPower;
    public AudioClip[] audiodata;
    private AudioSource a_source;

    private bool canJump = true,canDoubleJump = true;
    private CharacterController characterController;
    private Vector3 moveInput;
    Vector3 vertMove;
    Vector3 horiMove;

    void Start()
    {
        characterController = GetComponent<CharacterController>();
        a_source = GetComponent<AudioSource>();
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    void Update()
    {
        Movement();
        CamControl();
    }

    private void CamControl()
    {
        Vector2 mouseInput = new Vector2(Input.GetAxisRaw("Mouse X"), Input.GetAxisRaw("Mouse Y")) * mouseSensitivity;
        transform.rotation = Quaternion.Euler(transform.rotation.eulerAngles.x, transform.rotation.eulerAngles.y + mouseInput.x, transform.rotation.eulerAngles.z);
        camTrans.rotation = Quaternion.Euler(camTrans.rotation.eulerAngles + new Vector3(-mouseInput.y, 0, 0));
    }

    private void Movement()
    {
        float yStore = moveInput.y;
        // Vector3 vertMove = transform.forward * Input.GetAxis("Vertical");
         
        
        if(Input.GetKey(GameManager.GM.forward))
        {
           vertMove = transform.forward*10f; 
            int i = Random.Range(0,audiodata.Length);
            if(!a_source.isPlaying)
            {
                a_source.PlayOneShot(audiodata[i]);
            
            }
            
        }
         else if(Input.GetKey(GameManager.GM.Backward))
        {
            vertMove = -transform.forward*10f; 
            int i = Random.Range(0,audiodata.Length);
             if(!a_source.isPlaying)
            {
                a_source.PlayOneShot(audiodata[i]);
            }
        }
        else if(Input.GetKey(GameManager.GM.Right))
        {
            horiMove = transform.right * 10f;
            int i = Random.Range(0,audiodata.Length);
             if(!a_source.isPlaying)
            {
                a_source.PlayOneShot(audiodata[i]);
            }
        }
        else if(Input.GetKey(GameManager.GM.Left))
        {
            horiMove = -transform.right * 10f;
            int i = Random.Range(0,audiodata.Length);
            if(!a_source.isPlaying)
            {
                a_source.PlayOneShot(audiodata[i]);
            }
        }
        else if( Input.GetKeyUp(GameManager.GM.forward) || Input.GetKeyUp(GameManager.GM.Backward) )
        {
            vertMove =transform.forward*0f;

        }
        else if(Input.GetKeyUp(GameManager.GM.Right) || Input.GetKeyUp(GameManager.GM.Left))
        {
            horiMove =transform.right*0f;

        }
        moveInput = vertMove + horiMove;
        
        moveInput.Normalize();
        Sprint();
        moveInput.y = yStore;
        Jump();
        characterController.Move(moveInput * Time.deltaTime);

    }

    private void Jump()
    {
        moveInput.y += Physics.gravity.y * gravityModifier * Time.deltaTime;
        if (characterController.isGrounded)
        {
            moveInput.y = Physics.gravity.y * gravityModifier * Time.deltaTime;
        }
        canJump = Physics.OverlapSphere(groundCheckPoint.position, .25f, WhatIsGround).Length > 0;
        if (canJump)
        {
            canDoubleJump = false;
        }        
        if (Input.GetKeyDown(GameManager.GM.Jump) && canJump)
        {
            moveInput.y = jumpPower;
            canDoubleJump = true;
        }
        else if (canDoubleJump && Input.GetKeyDown(GameManager.GM.Jump))
        {
            moveInput.y = jumpPower;

            canDoubleJump = false;
        }
    }

    private void Sprint()
    {
        if (Input.GetKey(GameManager.GM.Run))
        {
            moveInput *= sprintSpeed;
        }
        else
        {
            moveInput *= moveSpeed;
        }
    }
}
