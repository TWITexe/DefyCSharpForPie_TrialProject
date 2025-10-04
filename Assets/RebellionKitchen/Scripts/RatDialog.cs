using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class RatDialog : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI text;                        // ��� �����
    [SerializeField] string[] lines1;                             // ������� 1
    [SerializeField] string[] lines2;                             // ������� 2
    [SerializeField] float TextSpeed;                             // �������� ��������� ������
    [SerializeField] bool isStartedDialog = false;                // ����� �� ������?
    [SerializeField] bool jamSpawn = false;                       // ����������� �� ����?
    [SerializeField] GameObject dialogWindow;                     // �������
    [SerializeField] GameObject jamReal;                          // ������ �����

    [SerializeField] GameObject pointer;

    private int dialogNow = 1;                                    // ����� ������ ������ �������?
    private int index_1;                                          // ������ ��� lines1

    public static bool firstDialog = false;                       // ������ �� ������ ������?
    private bool secondDialog = false;                            // ������ �� ������ ������?
    void Start()
    {
        text.text = string.Empty;
    }

    void Update()
    {
        if (dialogNow >= 3 && jamSpawn == false)
        {
            jamSpawn = true;
            jamReal.SetActive(true);
        }

        if ((Input.GetMouseButtonDown(0) || Input.GetKeyDown(KeyCode.E)) && isStartedDialog)
        {
            if (text.text == lines1[index_1])
            {
                IsNextLine1();
            }
            else
            {
                StopAllCoroutines();
                text.text = lines1[index_1];
            }
        }

        if (Move.flowerFound == true && secondDialog == false)
        {
            pointer.SetActive(true);
        }
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if ((collision.CompareTag("Player")) && isStartedDialog == false && firstDialog == false && ((Input.GetMouseButtonDown(0) || Input.GetKeyDown(KeyCode.E))))
        {
            StartDialog1();
        }
        if (( Move.flowerFound && collision.CompareTag("Player") && secondDialog == false && (Input.GetMouseButtonDown(0) || Input.GetKeyDown(KeyCode.E))))
        {
            pointer.SetActive(false);
            StartDialog2();
        }

    }
    // Первый диалог
    void StartDialog1()
    {
        if (firstDialog == false)
        {
            dialogWindow.SetActive(true);
            isStartedDialog = true;
            index_1 = 0;
            StartCoroutine(TypeLine1());
        }
    }

    IEnumerator TypeLine1()
    {
        foreach (char c in lines1[index_1].ToCharArray())
        {
            text.text += c;
            yield return new WaitForSeconds(TextSpeed);
        }
    }


    void IsNextLine1()
    {
            if (index_1 < lines1.Length - 1)
            {
                index_1++;
                text.text = string.Empty;
                StartCoroutine(TypeLine1());
            }
            else
            {
                dialogWindow.SetActive(false);
                isStartedDialog = false;
                firstDialog = true;
                Debug.Log(firstDialog);
                dialogNow++;
            }
            
    }
    // Второй диалог
    void StartDialog2()
    {   if (dialogNow == 2 && secondDialog == false)
        {
            firstDialog = false;
            secondDialog = true;
            index_1 = 0;
            lines1 = lines2;
            StartDialog1();  
        }
    }

}
