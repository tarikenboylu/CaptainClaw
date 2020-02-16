using UnityEngine;
using UnityEngine.Events;
using System.Collections;
using System.Collections.Generic;
public class CharacterController2D : MonoBehaviour
{
    public float minGroundNormalY = .65f;
    public float gravityModifier = 1;
    public bool fall = false;
    public AudioSource swordSound;

    public float maxSpeed = 4;
    public float jumpTakeOffSpeed = 4;
    public bool stable = true;
    public bool moveRight = false;
    public bool moveLeft = false;
    public bool isJump = false;
    public bool isCrouch = false;
    public bool melee = false;
    public bool gun = false;
    public bool dynamit = false;
    public bool magic = false;
    int meleeRandom = 0;

    protected const float shellRadius = 0.01f;
    protected const float minMoveDistance = 0.001f;

    private SpriteRenderer spriteRenderer;
    private Animator animator;
    Vector2 move;

    public Vector2 velocity;
    public Vector2 targetVelocity;

    protected bool grounded;
    protected Vector2 groundNormal;

    protected Rigidbody2D rb2d;
    protected ContactFilter2D contactFilter;
    protected RaycastHit2D[] hitBuffer = new RaycastHit2D[16];
    protected List<RaycastHit2D> hitBufferList = new List<RaycastHit2D>(16);

    void Start()
    {
        contactFilter.useTriggers = false;
        contactFilter.SetLayerMask(Physics2D.GetLayerCollisionMask(gameObject.layer));
        contactFilter.useLayerMask = true;
    }
    void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();
    }

    void OnEnable()
    {
        rb2d = GetComponent<Rigidbody2D>();    
    }

    void Update()
    {
        targetVelocity = Vector2.zero;
        move = Vector2.zero;

        if (moveRight || Input.GetKey(KeyCode.RightArrow))
        {
            move.x = 1;
            animator.SetBool("Move", true);
        }
        else if (moveLeft || Input.GetKey(KeyCode.LeftArrow))
        {
            move.x = -1;
            animator.SetBool("Move", true);
        }
        else
        {
            animator.SetBool("Move", false);
        }

        if (isJump && grounded)
        {
            velocity.y = jumpTakeOffSpeed;
            animator.SetBool("Jump", true);
        }

        else if (!isJump)
        {
            if (velocity.y > 0)
            {
                velocity.y *= 0.5f;
            }
        }

        if (isCrouch)
        {
            /////collider disabling***
        }


        if (melee && grounded)
        {
            if (animator.GetCurrentAnimatorStateInfo(0).IsName("SwordAttack"))
                print(animator.GetCurrentAnimatorStateInfo(0).normalizedTime);
            //if (animator.GetCurrentAnimatorStateInfo(0).normalizedTime > 0.1f && animator.GetCurrentAnimatorStateInfo(0).normalizedTime < 0.2f)

            meleeRandom = Random.Range(0, 4);
            if (meleeRandom == 0)
            {
                animator.SetBool("Sword Attack", true);
            }
            if (meleeRandom == 1)
                animator.SetBool("Melee Attack 1", true);
            if (meleeRandom == 2)
                animator.SetBool("Melee Attack 2", true);
            if (meleeRandom == 3)
                animator.SetBool("Melee Attack 3", true);
            /////collider enabling***
        }

        if (!melee)
        {
            animator.SetBool("Sword Attack", false);
            animator.SetBool("Melee Attack 1", false);
            animator.SetBool("Melee Attack 2", false);
            animator.SetBool("Melee Attack 3", false);
        }

        if (gun)
            animator.SetBool("Gun", gun);

        if (dynamit)
            animator.SetBool("Dynamit", dynamit);

        if (magic)
            animator.SetBool("Magic", magic);

        bool flipSprite = (spriteRenderer.flipX ? (move.x > 0) : (move.x < 0));

        if (flipSprite)
        {
            spriteRenderer.flipX = !spriteRenderer.flipX;
        }

        animator.SetBool("Crouch", isCrouch);
        animator.SetBool("Grounded", grounded);

        targetVelocity = move * maxSpeed;

        if (velocity == Vector2.zero)
            stable = true;
        else
            stable = false;

        if (velocity.y <= 0)
            fall = true;
        else
            fall = false;

        if(animator.GetCurrentAnimatorStateInfo(0).IsName("SwordAttack"))
            if (animator.GetCurrentAnimatorStateInfo(0).normalizedTime <= 0.05f)
                swordSound.Play();
    }

    public void RightMove(bool isMove)
    {
        moveRight = isMove;
    }

    public void LeftMove(bool isMove)
    {
        moveLeft = isMove;
    }

    public void Jump(bool jump)
    {
        isJump = jump;
    }

    public void Crouch(bool crouch)
    {
        isCrouch = crouch;
    }

    public void MeleeAttack(bool ctrl)
    {
        melee = ctrl;
    }

    public void Gun(bool fire)
    {
        gun = fire;
    }

    public void Dynamit(bool fire)
    {
        dynamit = fire;
    }

    public void Magic(bool fire)
    {
        magic = fire;
    }

    private void FixedUpdate()
    {
        velocity += gravityModifier * Physics2D.gravity * Time.deltaTime;
        velocity.x = targetVelocity.x;

        grounded = false;

        Vector2 deltaPosition = velocity * Time.deltaTime;

        Vector2 moveAlongGround = new Vector2(groundNormal.y, -groundNormal.x);
        Vector2 move = moveAlongGround * deltaPosition.x;
        Movement(move * 0.4f, false);

        move = Vector2.up * deltaPosition.y;
        Movement(move, true);
    }

    void Movement(Vector2 move, bool yMovement)
    {
        float distance = move.magnitude;

        if (distance > minMoveDistance)
        {
            int count = rb2d.Cast(move, contactFilter, hitBuffer, distance + shellRadius);
            hitBufferList.Clear();

            for (int i = 0; i < count; i++)
            {
                hitBufferList.Add(hitBuffer[i]);
            }

            for (int i = 0; i < hitBufferList.Count; i++)
            {
                Vector2 currentNormal = hitBufferList[i].normal;

                if (currentNormal.y > minGroundNormalY)
                {
                    grounded = true;
                    if (yMovement)
                    {
                        groundNormal = currentNormal;
                        currentNormal.x = 0;
                    }
                }

                float projection = Vector2.Dot(velocity, currentNormal);

                if (projection < 0)
                    velocity -= projection * currentNormal;

                float modifiedDistance = hitBufferList[i].distance - shellRadius;
                distance = modifiedDistance < distance ? modifiedDistance : distance;
            }
        }
        rb2d.position += move.normalized * distance;
    }
}