using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private float MS;
    private float currentMS;
    private float diagonalMS;
    private bool isMoving;
    private float maxTurnSpeed;

    private float DashTimer;
    private float DashCD = 2.5f;
    private bool isDashing = false;

  
    private Quaternion RotTo;
    private float RotDeg;
    private Rigidbody2D pRB;
    private Animator anim;
    public GameObject head; 
    public GameObject body;
    private Collider2D currentCollider;
    
    // Start is called before the first frame update

    void Start()
    {
        MS = 7f;
        diagonalMS = 1f;
        RotDeg = 0;
        maxTurnSpeed = 900f;
        pRB = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        currentCollider = head.GetComponent<Collider2D>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        float horizontalMovement = Input.GetAxis("Horizontal");
        float verticalMovement = Input.GetAxis("Vertical");
        
        Vector3 targetPosition = new Vector3(transform.position.x - horizontalMovement, transform.position.y + verticalMovement, 0);
        float angle = Mathf.Atan2(targetPosition.x - transform.position.x, targetPosition.y - transform.position.y) * Mathf.Rad2Deg;
        Quaternion rotTo = Quaternion.AngleAxis(angle, Vector3.forward);

        if (horizontalMovement > .5f || horizontalMovement < -.5f)
        {
            pRB.velocity = new Vector2(currentMS * horizontalMovement, pRB.velocity.y);
            transform.rotation = Quaternion.RotateTowards(transform.rotation, rotTo, maxTurnSpeed * Time.deltaTime);
        }
        if (verticalMovement > .5f || verticalMovement < -.5f)
        {
            pRB.velocity = new Vector2(pRB.velocity.x, verticalMovement * currentMS);
            transform.rotation = Quaternion.RotateTowards(transform.rotation, rotTo, maxTurnSpeed * Time.deltaTime);
        }
        if (horizontalMovement < .5f && horizontalMovement > -.5f)
        {
            pRB.velocity = new Vector2(0f, pRB.velocity.y);
        }

        if (verticalMovement < .5f && verticalMovement > -.5f)
        {
            pRB.velocity = new Vector2(pRB.velocity.x, 0f);
        }

        if (Mathf.Abs(horizontalMovement) > 0.5f && Mathf.Abs(verticalMovement) > 0.5f)
        {
            currentMS = MS * diagonalMS;
        }
        else
        {
            currentMS = MS;
        }

        if (!isDashing)
        {
            if (Input.GetButtonDown("Jump"))
            {
                isDashing = true;
                DashTimer = DashCD;
                MS = 15f;
                anim.SetBool("isDashing", true);
                currentCollider = body.GetComponent<Collider2D>();
            }
        }

    }

        
        

    void Update()
    {
        
        if(isDashing)
        {
            DashTimer -= Time.deltaTime;
            if(DashTimer <= 1.5f && DashTimer > 0f)
            {
                MS -= .05f;
            }
            if(DashTimer <= 0f)
            {
                isDashing = false;
                MS = 7f;
                anim.SetBool("isDashing", false);
                currentCollider = head.GetComponent<Collider2D>();
            }
        }

    }

}
