using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour
{
    
    // �������� ��� ������: 
    [SerializeField] GameObject milk;       // ������ 0
    [SerializeField] GameObject sugar;      // �����  1
    [SerializeField] GameObject yeast;      // ������ 2
    [SerializeField] GameObject flour;      // ����   3
    [SerializeField] GameObject butter;     // �����  4
    [SerializeField] GameObject salt;       // ����   5
    [SerializeField] GameObject egg;        // ����   6
    [SerializeField] GameObject pie;        // �����  7
    [SerializeField] GameObject jam;        // ����   8
    [SerializeField] GameObject flower;     // ������

    // �������� � ������� ( 0 - �� ������ , 1 - ������ )
    static public bool[] products = new bool[9];

    static public bool flowerFound = false; // �������� ������? ( ����� ��� ������� � ������ )


    [SerializeField] AudioSource takeSound; // ���� ������� ��������
    Animator anim;                          // ������������ ��� ��������
    Rigidbody2D rb;                        // ������������� rb2D
    public float moveSpeed = 1f;            // ��������� �������� ���������

    public bool onGround = true;            // �� ����� �� ��������?
    public Transform groundCheck;           // ������, ������� ������ � ���� ����
    public LayerMask whatIsGround;          // ����, ������� ��������� ��������� �� �����
    public float radiusCheck = 5f;          // ������ �����

    
    private float _horizontalMove = 0f;     // �������� �� �����������

    public Vector2 moveVector;
    private bool rightFace = true;          // ������� ���� ( �������� - ����� )
    public float jumpForce = 2f;            // ���� ������

    static bool tpCoolDown = false;         // ���� �� ������ �� ����� ���������?

    public static bool onTaskNow = false;   // ���������� �� �� � ������� 
    void Start()
    {
        takeSound = GetComponent<AudioSource>();       // ��������� ��� ������
        anim = GetComponent<Animator>();               // �������� ��� ��������
        rb = GetComponent<Rigidbody2D>();              // �� ��� ������ ���������
        rb.sleepMode = RigidbodySleepMode2D.NeverSleep;

        
        for (int i = 0; i < products.Length; i++)
        {
            products[i] = false;
        }
    }

    void Update()
    {
        CheckingGround();

        if (_horizontalMove < 0.1f)
        {
            rb.WakeUp();
        }
        if (Input.GetKeyDown(KeyCode.Space) && onGround && DoughPie.isStartingTest == false && onTaskNow == false &&  Intro.introStoryEnd == true)      // ���� �������� ������� space � ��������� �� �����
        {
            rb.AddForce(transform.up * jumpForce, ForceMode2D.Impulse);                                                // ��������� ����� * ���� ������, ���������� ForceMode2D 
        }

        if (DoughPie.isStartingTest == false && onTaskNow == false && Intro.introStoryEnd == true)
        {
            _horizontalMove = Input.GetAxisRaw("Horizontal") * moveSpeed;                                               // �������������� �������� = ����������� * ��������
            moveVector.x = Input.GetAxis("Horizontal");
        }
        anim.SetFloat("moveX", Mathf.Abs(moveVector.x));                                                                // ������� ���� �������� ���������� �� Animator , ����� �������� �������� ������

        if (_horizontalMove < 0 && rightFace)                                                                          // ��������� ����������� ���������
        {
            flip();
        }
        else if (_horizontalMove > 0 && !rightFace)
        {
            flip();
        }
    }
    private void FixedUpdate()
    {
        Vector2 TargetVelocity = new Vector2(_horizontalMove * 2f, rb.velocity.y);
        rb.velocity = TargetVelocity;
    }
    void flip()                                                                                 // ������������� ������ ��������� � ������ �������
    {
        rightFace = !rightFace;

        Vector3 scale = transform.localScale;
        scale.x *= -1;
        transform.localScale = scale;
    }

    void CheckingGround()
    {
        onGround = Physics2D.OverlapCircle(groundCheck.position, radiusCheck, whatIsGround);    // �������� ( �� ����� �� �������� )
        anim.SetBool("onGround", onGround);                                                     // �������� ������
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (Input.GetKey(KeyCode.E))
        {
            if (collision.gameObject.CompareTag("flower") && RatDialog.firstDialog == true)
            {
                takeSound.Play();
                flowerFound = true;
                flower.SetActive(false);
                
                Debug.Log("Found Flower = " + flowerFound);
            }

            if ( cookDialog.formulaIsIssued)
            {
                if (collision.gameObject.CompareTag("milk"))
                {   
                    takeSound.Play();
                    products[0] = true;
                    milk.SetActive(false);
                    
                    Debug.Log(products[0]);
                }
                if (collision.gameObject.CompareTag("sugar"))
                {
                    takeSound.Play();
                    products[1] = true;
                    sugar.SetActive(false);

                    Debug.Log(products[1]);
                }
                if (collision.gameObject.CompareTag("yeast"))
                {
                    takeSound.Play();
                    products[2] = true;
                    yeast.SetActive(false);

                    Debug.Log(products[2]);
                }
                if (collision.gameObject.CompareTag("flour"))
                {
                    takeSound.Play();
                    products[3] = true;
                    flour.SetActive(false);
                }
                if (collision.gameObject.CompareTag("butter"))
                {
                    takeSound.Play();
                    products[4] = true;
                    butter.SetActive(false);
                }
                if (collision.gameObject.CompareTag("salt"))
                {
                    takeSound.Play();
                    products[5] = true;
                    salt.SetActive(false);
                }
                if (collision.gameObject.CompareTag("egg"))
                {
                    takeSound.Play();
                    products[6] = true;
                    egg.SetActive(false);
                }
                if (collision.gameObject.CompareTag("pie"))
                {
                    takeSound.Play();
                    products[7] = true;
                    pie.SetActive(false);
                }
                if (collision.gameObject.CompareTag("jam"))
                {
                    takeSound.Play();
                    products[8] = true;
                    jam.SetActive(false);
                }
            }
        }

        if (Input.GetKey(KeyCode.E) && collision.gameObject.CompareTag("doorStorage") && DoorStorange.doorUnlocked == false && TaskLayer.isAnswerTrue == false)
        {
            onTaskNow = true;
        }
        if (Input.GetKey(KeyCode.E) && collision.gameObject.CompareTag("doorStorage") && tpCoolDown == false && DoorStorange.doorUnlocked)
        {
            transform.localPosition = new Vector2(200.4f, -3.44f);
            tpCoolDown = true;
            DoorStorange.firstInStorange = true;
            StartCoroutine(CoolDownTeleport());
        }
        else if (Input.GetKey(KeyCode.E) && collision.gameObject.CompareTag("doorInChickenStorage") && tpCoolDown == false)
        {
            transform.localPosition = new Vector2(121.66f, -4.56f);
            tpCoolDown = true;
            StartCoroutine(CoolDownTeleport());
        }

    }

    IEnumerator CoolDownTeleport()
    {
        yield return new WaitForSeconds(1.5f);
        tpCoolDown = false;
    }

   
}
