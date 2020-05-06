using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Player_Behaviour : MonoBehaviour
{
    private Rigidbody rb;
    private Animator anim;
    private bool idle = true;
    private bool facingRight = true;
    private bool facingUp = false;

    [SerializeField] private float moveForce;
    [SerializeField] private Vector3 movementInput;
    [SerializeField] private Vector3 movementVector;

    //[Header("Directional Materials")]
    //#region Materials
    //[SerializeField] private Material frontMat;
    //[SerializeField] private Material backMat;
    //[SerializeField] private Material leftMat;
    //[SerializeField] private Material rightMat;
    //[SerializeField] private Material idleMat;
    //#endregion

    public Vector3 MovementInput { get => movementInput; private set => movementInput = value; }

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
        anim = GetComponent<Animator>();
    }

    private void Update()
    {
        Movement();
        //AnimateCharacter();
    }

    private void Movement()
    {
        MovementInput = new Vector3(Input.GetAxisRaw("Horizontal"), 0f, Input.GetAxisRaw("Vertical"));
        if (movementInput != Vector3.zero)
            movementVector = new Vector3(MovementInput.x * moveForce, 0f, MovementInput.z * moveForce) * Time.fixedDeltaTime;
        else
            movementVector = Vector3.zero;

    }

    private void AnimateCharacter()
    {
        idle = true;
        if (Input.GetKey(KeyCode.W))
        {
            idle = false;
            Flip("Up");
        }
        if (Input.GetKey(KeyCode.A))
        {
            idle = false;
            Flip("Left");
        }
        if (Input.GetKey(KeyCode.S))
        {
            idle = false;
            Flip("Back");
        }
        if (Input.GetKey(KeyCode.D))
        {
            idle = false;
            Flip("Right");
        }
        if (idle)
        {
            Flip("Idle");
        }
    }

    private void FixedUpdate()
    {
        rb.MovePosition(transform.position + movementVector);
    }

    private void Flip(string lookAt)
    {
        //SpriteRenderer sr = GetComponent<SpriteRenderer>();
        //      switch (lookAt)
        //      {
        //          case "Right":
        //              sr.material = rightMat;
        //              SetWalkingAnimBlend(0f);
        //              break;
        //          case "Left":
        //              sr.material = leftMat;
        //              SetWalkingAnimBlend(0.33f);
        //              break;
        //          case "Back":
        //              sr.material = backMat;
        //              SetWalkingAnimBlend(0.66f);
        //              break;
        //          case "Up":
        //              sr.material = frontMat;
        //              SetWalkingAnimBlend(1f);
        //              break;
        //          case "Idle":
        //              sr.material = idleMat;
        //              SetWalkingAnimBlend(1.34f);
        //              break;
        //      }
    }

    private void SetWalkingAnimBlend(float blend)
    {
        anim.SetFloat("WalkingAnim", blend);
    }
}
