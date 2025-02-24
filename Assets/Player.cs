using UnityEngine;

public class Player : MonoBehaviour
{
    public float moveSpeed = 5f;
    private Animator animator;

    private string stand = "StandDown"; //player character standing downwards at beginning of game
    private string walk = "";

    void Start()
    {
        animator = GetComponent<Animator>();
        animator.SetTrigger(stand); // get start animation (downwards)
    }

    void Update()
    {
        Move();
    }

    private void Move()
    {
        Vector3 movement = Vector3.zero;


        if (Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.W))
        {

            movement = Vector3.up; // change movement variable in corresponding direction

            if (walk != "GoUp") // control if player is already moving so same animation isnt played every frame
            {
                if (walk != "") // if condition to get rid of warning that "" does not exist
                {
                    animator.ResetTrigger(walk); // disable current walk animation
                }

                animator.SetTrigger("GoUp"); // start new walk animation
                walk = "GoUp";
                stand = "StandUp"; // change standing variable to match walking directio
            }

        }
        else if (Input.GetKey(KeyCode.DownArrow) || Input.GetKey(KeyCode.S))
        {

            movement = Vector3.down;
            if (walk != "GoDown")
            {
                if (walk != "")
                {
                    animator.ResetTrigger(walk);
                }
                animator.SetTrigger("GoDown");
                walk = "GoDown";
                stand = "StandDown";
            }

        }
        else if (Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.A))
        {

            movement = Vector3.left;
            if (walk != "GoLeft")
            {
                if (walk != "")
                {
                    animator.ResetTrigger(walk);
                }
                animator.SetTrigger("GoLeft");
                walk = "GoLeft";
                stand = "StandLeft";
            }
        }
        else if (Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.D))
        {

            movement = Vector3.right;
            if (walk != "GoRight")
            {
                if (walk != "")
                {
                    animator.ResetTrigger(walk);
                }
                animator.SetTrigger("GoRight");
                walk = "GoRight";
                stand = "StandRight";
            }

        }
        else
        {
            if (walk != "")
            {
                animator.ResetTrigger(walk);
                walk = "";
            }
            switch (stand)
            {
                case "StandUp":
                    animator.SetTrigger(stand);
                    break;
                case "StandDown":
                    animator.SetTrigger(stand);
                    break;
                case "StandLeft":
                    animator.SetTrigger(stand);
                    break;
                case "StandRight":
                    animator.SetTrigger(stand);
                    break;
            }
        }
        transform.Translate(movement * moveSpeed * Time.deltaTime);
    }
}

