using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterControl : MonoBehaviour
{
    //Движение
    [SerializeField, Range(0,5)]
    float speedWalk, speedRun;

    [SerializeField, Range(1,20)]
    float gravityForce;
    float gravity;
    CharacterController characterController;

    //Анимации
    Animator animator;


    
    void Start()
    {
        characterController = GetComponent<CharacterController>();
        animator = GetComponent<Animator>();
    }

    
    void Update()
    {
        if(Input.GetAxis("Horizontal") != 0 || Input.GetAxis("Vertical") != 0)
            if(Input.GetKey(KeyCode.LeftShift))
                Movement(speedRun, "Run");
            else
                Movement(speedWalk, "Walk");
    }


    private void Movement(float speed, string anim){

        animator.SetBool(anim, true);

        Vector3 moveVector = Vector3.zero;
        moveVector.x = Input.GetAxis("Horizontal") * speed;
        moveVector.z = Input.GetAxis("Vertical") * speed;

        RotateCh(speed, moveVector);
        
        moveVector.y = Gravity();

        


        characterController.Move(moveVector * Time.deltaTime);
    }

    private float Gravity(){
        if(!characterController.isGrounded)
            gravity -= gravityForce * Time.deltaTime;
            else
            gravity = -1f;

        return gravity;
    }

    private void RotateCh(float speed, Vector3 moveV3){
        if(Vector3.Angle(Vector3.forward, moveV3) > 1f || Vector3.Angle(Vector3.forward, moveV3) == 0){
            Vector3 direct = Vector3.RotateTowards(transform.forward, moveV3, speed, 0f);
            transform.rotation = Quaternion.LookRotation(direct);
        }
    }
    
}
