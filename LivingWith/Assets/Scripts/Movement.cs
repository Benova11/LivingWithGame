using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    [Header("Components")]
    private Rigidbody2D rb;

    [Header("Layer Mask")]
    [SerializeField] private LayerMask groundLayer;

    [Header("Movement Variables")]
    [SerializeField] private float movementAcceleration;
    [SerializeField] private float maxMoveSpeed;
    [SerializeField] private float groundLinearDrag;
    private float horizontalDirection;
    private bool changingDirection => (rb.velocity.x > 0f && horizontalDirection < 0f) || (rb.velocity.x < 0f && horizontalDirection > 0f);

    [Header("Jump Variables")]
    [SerializeField] private float jumpForce = 12f;
    [SerializeField] private float airLinearDrag = 2.5f;
    [SerializeField] private float fallMultiplier = 8f;
    [SerializeField] private float lowJumpFallMultiplier = 5f;
    [SerializeField] private int extraJumps = 1;
    private int extraJumpsValue;
    private bool canJump => Input.GetButtonDown("Jump") && (onGround || extraJumpsValue > 0);
    public bool isOnGround => onGround;

    [Header("Ground Collision Variables")]
    [SerializeField] private float groundRaycastLength ;
    private bool onGround;
    

    SpriteRenderer sr;
    Animator animator;
    float Horizontal;

    GirlActions girlActions;

    private void Start() {
        rb = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();
        girlActions = GetComponent<GirlActions>();
    }

    void Update()
    {
        horizontalDirection = GetInput().x;
        if (horizontalDirection == 0){
            rb.velocity = new Vector2(0, rb.velocity.y);
        }
        if (canJump) Jump();
    }

    private void FixedUpdate(){
        CheckCollisions();
        MoveGirl();
        if (onGround){
            extraJumpsValue = extraJumps;
            //if (horizontalDirection != 0 ){
            //ApplyGroundLinearDrag();
            //}
        }else{
            ApplyAirLinearDrag();
            FallMultiplier();
        }
        HandelAnimtoin();
    }

    void HandelAnimtoin()
    {
        if (Horizontal > 0)
        {
            sr.flipX = false;
            animator.SetBool("inMove", true);

            if (girlActions.playMode == true)
            {
                animator.SetBool("inPlayMode", true);
            }
            else
            {
                animator.SetBool("inPlayMode", false);
            }
        }
        else if (Horizontal < 0)
        {
            sr.flipX = true;
            animator.SetBool("inMove", true);

            if (girlActions.playMode == true)
            {
                animator.SetBool("inPlayMode", true);
            }
            else
            {
                animator.SetBool("inPlayMode", false);
            }
        }
        else
        {
            animator.SetBool("inMove", false);

            if (girlActions.playMode == true)
            {
                animator.SetBool("inPlayMode", true);
            }
            else
            {
                animator.SetBool("inPlayMode", false);
            }
        }
    }
    private Vector2 GetInput()
    {
        Horizontal = Input.GetAxisRaw("Horizontal");
        return new Vector2(Horizontal,Input.GetAxisRaw("Vertical"));
    }

    private void MoveGirl()
    {
        rb.AddForce(new Vector2(horizontalDirection, 0f) * movementAcceleration);

        if(Mathf.Abs(rb.velocity.x) > maxMoveSpeed){
            rb.velocity = new Vector2(Mathf.Sign(rb.velocity.x) * maxMoveSpeed, rb.velocity.y);
        }
    }

    private void Jump()
    {
        Debug.Log("problem");
        if(!onGround) extraJumpsValue--;
        rb.velocity = new Vector2(rb.velocity.x , 0f);
        rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
    }

    private void FallMultiplier()
    {
        if(rb.velocity.y < 0){
            rb.gravityScale = fallMultiplier;
        }else if(rb.velocity.y > 0 && !Input.GetButtonDown("Jump")){
            rb.gravityScale = lowJumpFallMultiplier;
        }else{
            rb.gravityScale = 1f;
        }
    }

    private void ApplyGroundLinearDrag()
    {
        if(Mathf.Abs(horizontalDirection) < 0.4f || changingDirection){
            rb.drag = groundLinearDrag;
        }else{
            rb.drag = 0f;
        }
    }

    private void ApplyAirLinearDrag()
    {
        rb.drag = airLinearDrag;
    }

    private void CheckCollisions()
    {
        onGround = Physics2D.Raycast(transform.position, transform.TransformDirection(Vector3.down) ,groundRaycastLength,groundLayer);
    }

    private void OnDrawGizmos() {
        Gizmos.color = Color.green;
        Gizmos.DrawLine(transform.position, transform.position + Vector3.down * groundRaycastLength);
    }
}
