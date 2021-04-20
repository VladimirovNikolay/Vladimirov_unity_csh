using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move_ball : MonoBehaviour
{
    //скорость персонажа
    public float speed = 4f;
    //сила прыжка персонажа
    public float jumpSpeed = 8f;
    //переменная гравитации персонажа
    public float graviry = 20f;
    //переменная движения персонажа
    private Vector3 moveDir = Vector3.zero;
    //переменная для CharacterController
    private CharacterController controller;
    void Start()
    {
        Cursor.visible = false;
        controller = GetComponent<CharacterController>();
    }

    
    private void FixedUpdate()
    {
        if (controller.isGrounded)
        {
            moveDir = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
            moveDir = transform.TransformDirection(moveDir);
            moveDir *= speed;
        }
        if (Input.GetKeyDown(KeyCode.Space) && controller.isGrounded)
        {
            moveDir.y = jumpSpeed;
        }

        moveDir.y -= graviry * Time.deltaTime;
        controller.Move(moveDir * Time.deltaTime);
    }
}
