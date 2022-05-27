using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour
{
    
    // Продукты для пирога: 
    [SerializeField] GameObject milk;       // молоко 0
    [SerializeField] GameObject sugar;      // сахар  1
    [SerializeField] GameObject yeast;      // дрожжи 2
    [SerializeField] GameObject flour;      // мука   3
    [SerializeField] GameObject butter;     // масло  4
    [SerializeField] GameObject salt;       // соль   5
    [SerializeField] GameObject egg;        // яйца   6
    [SerializeField] GameObject pie;        // пирог  7
    [SerializeField] GameObject jam;        // джем   8
    [SerializeField] GameObject flower;     // цветок

    // Продукты в массиве ( 0 - не найден , 1 - найден )
    static public bool[] products = new bool[9];

    static public bool flowerFound = false; // Цветочек найден? ( Нужен для задания с мышкой )


    [SerializeField] AudioSource takeSound; // Звук подбора предмета
    Animator anim;                          // Используется для анимации
    Rigidbody2D rb;                        // Использование rb2D
    public float moveSpeed = 1f;            // Дефолтная скорость персонажа

    public bool onGround = true;            // На земле ли персонаж?
    public Transform groundCheck;           // Ссылка, которая держит в себе ключ
    public LayerMask whatIsGround;          // Ключ, который проверяет персонажа на земле
    public float radiusCheck = 5f;          // Радиус ключа

    
    private float _horizontalMove = 0f;     // Движение по горизонтали

    public Vector2 moveVector;
    private bool rightFace = true;          // Сторона лица ( стандарт - право )
    public float jumpForce = 2f;            // Сила прыжка

    static bool tpCoolDown = false;         // Есть ли сейчас КД после телепорта?

    public static bool onTaskNow = false;   // Находитесь ли вы в задании 
    void Start()
    {
        takeSound = GetComponent<AudioSource>();       // АудиоСурс для звуков
        anim = GetComponent<Animator>();               // Аниматор для анимации
        rb = GetComponent<Rigidbody2D>();              // Рб для физики персонажа
        
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
        if (Input.GetKeyDown(KeyCode.Space) && onGround && DoughPie.isStartingTest == false && onTaskNow == false &&  Intro.introStoryEnd == true)      // Если нажимаем клавишу space и находимся на земле
        {
            rb.AddForce(transform.up * jumpForce, ForceMode2D.Impulse);                                                // Положение вверх * силу прыжка, используем ForceMode2D 
        }

        if (DoughPie.isStartingTest == false && onTaskNow == false && Intro.introStoryEnd == true)
        {
            _horizontalMove = Input.GetAxisRaw("Horizontal") * moveSpeed;                                               // Горизонтальное движение = направление * скорость
            moveVector.x = Input.GetAxis("Horizontal");
        }
        anim.SetFloat("moveX", Mathf.Abs(moveVector.x));                                                                // Передаём нашу скорость переменной из Animator , чтобы включить анимацию ходьбы

        if (_horizontalMove < 0 && rightFace)                                                                          // изменения направления персонажа
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
    void flip()                                                                                 // Отзеркаливаем объект персонажа в нужную сторону
    {
        rightFace = !rightFace;

        Vector3 scale = transform.localScale;
        scale.x *= -1;
        transform.localScale = scale;
    }

    void CheckingGround()
    {
        onGround = Physics2D.OverlapCircle(groundCheck.position, radiusCheck, whatIsGround);    // Проверка ( на земле ли персонаж )
        anim.SetBool("onGround", onGround);                                                     // Анимация прыжка
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
