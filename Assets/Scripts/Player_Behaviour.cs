using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Player_Behaviour : MonoBehaviour
{
    private Rigidbody rb; //Rigidbody to add force (movement) to
    private Animator anim; //Animator to add animations like walking animations/idle animations
    private bool idle = true; //Is the player idle? (standing still doing nothing)
    private bool facingRight = true; //Is the player facing right?
    private bool facingForward = false; //Is the player facing 

    [SerializeField] private float movementSpeed; //The speed of how the player moves
    [SerializeField] private Vector3 movementInput; //The input strings (Horizontal / Vertical)
    [SerializeField] private Vector3 movementVector; //The vector the movement gets send toward

    //[Header("Directional Materials")]
    //#region Materials
    //[SerializeField] private Material frontMat;
    //[SerializeField] private Material backMat;
    //[SerializeField] private Material leftMat;
    //[SerializeField] private Material rightMat;
    //[SerializeField] private Material idleMat;
    //#endregion

    public Vector3 MovementInput { get => movementInput; private set => movementInput = value; }

    private void Awake() //Get components from same object
    {
        rb = GetComponent<Rigidbody>();
        anim = GetComponent<Animator>();
    }

    private void Update() //Gets called every frame
    {
        Movement();
        //AnimateCharacter();
    }

    private void Movement() //Handles player movement
    {
        MovementInput = new Vector3(Input.GetAxisRaw("Horizontal"), 0f, Input.GetAxisRaw("Vertical")); //Transforms input into vector movement

        if (movementInput != Vector3.zero)
            movementVector = new Vector3(MovementInput.x * movementSpeed, 0f, MovementInput.z * movementSpeed) * Time.fixedDeltaTime; //If the playerinput is pressed move the player
        else
            movementVector = Vector3.zero; //else don't move the player

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
        rb.MovePosition(transform.position + movementVector); //Add the force to the rigidbody to move the player
    }

    private void Flip(string lookAt) //Makes the player look in the direction it is moving
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
