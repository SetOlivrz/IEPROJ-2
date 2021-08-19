using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirePointController : MonoBehaviour
{


    [SerializeField] Camera cam;
    private Vector2 mousePos;

    public Rigidbody2D player;
    public Rigidbody2D rb;

    public Animator animator;

    public bool lookLeft = false;
    public bool lookRight = false;
    public bool lookForward = false;
    public bool lookBack = false; 

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        this.rb.position = player.position;
        mousePos = cam.ScreenToWorldPoint(Input.mousePosition);

        UpdateLookDir();

        Debug.Log("x: " + (player.position.x - mousePos.x));
        Debug.Log("y: " + (player.position.y - mousePos.y));


    }
    private void FixedUpdate()
    {
        Vector2 lookDir = mousePos - rb.position;
        float angle = Mathf.Atan2(lookDir.y, lookDir.x) * Mathf.Rad2Deg - 90f;
        rb.rotation = angle;
    }

    public void UpdateLookDir()
    {
        Vector2 distance = mousePos - player.position;
        //Mathf.Abs(distance.x);
        //Mathf.Abs(distance.y);

        if (mousePos.y > player.position.y)
        {
            ResetLookDir();
            animator.SetBool("LookBack", true);
        }
        else
        {
            ResetLookDir();
            animator.SetBool("LookForward", true);
        }
        
        if (distance.x > 2 ) // right
        {
            ResetLookDir();
            animator.SetBool("LookRight", true);
        }
        else if (distance.x < -2)
        {
            ResetLookDir();
            animator.SetBool("LookLeft", true);
        }

       
    }

    public void ResetLookDir()
    {
        animator.SetBool("LookRight", false);
        animator.SetBool("LookLeft", false);
        animator.SetBool("LookBack", false);
        animator.SetBool("LookForward", false);


    }
}
