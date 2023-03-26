using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WarriorMove : MonoBehaviour
{
    public Animator anim;
    public Camera cam;
    public GameObject axeCollider;
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
        }

        /*
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (Time.timeScale == 0)
            {
                // unpausing
                pauseText.SetActive(false);
                Time.timeScale = 1;
            }
            else
            {
                // pausing
                pauseText.SetActive(true);
                Time.timeScale = 0;
            }
        }

        if (Input.GetKeyDown(KeyCode.Q))
        {
            countDown = true;
        }


        if (countDown) //if countdown is true
        {

            if (timer < 3)
            {
                timer += Time.deltaTime;
                Debug.Log("Game is paused" + timer);
            }
            else
            {
                UnityEditor.EditorApplication.isPlaying = false;
            }
        }*/

    }
}