using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WarriorMove : MonoBehaviour
{
    public Animator anim;
    public Camera cam;
    public GameObject swordCollider;
    public UIManager UI;


    private bool attacking = false;
    private float timer, attackTime = 1f, speed =5f, camSensitivity = 100f;
    private Vector3 movement;

    
    void Update()
    {
        float moveH = Input.GetAxisRaw("Horizontal");
        float moveV = Input.GetAxisRaw("Vertical");

        movement = new Vector3(moveH, 0f, moveV);
        movement = transform.TransformDirection(movement.normalized * Time.deltaTime * speed);
        transform.position += movement;

        float camX = Input.GetAxis("Mouse X") * camSensitivity * Time.deltaTime;
        Vector3 rotate = new Vector3(0, camX, 0);  
        transform.Rotate(rotate);

        
        if (moveH != 0 || moveV != 0)
        {
            anim.SetBool("Run", true);
            anim.SetBool("Idle", false);
        }
        else
        {
            anim.SetBool("Run", false);
            anim.SetBool("Idle", true);
        }

        if (Input.GetMouseButtonDown(0) && Time.timeScale == 1)
        {
            anim.SetTrigger("Attack");
            attacking = true;
            swordCollider.SetActive(true);
            timer = 0;
        }

        if(attacking)
        {
            if (timer >= attackTime)
            {
                attacking = false;
                swordCollider.SetActive(false);
            }
            else
                timer += Time.deltaTime;
        }
    }
}