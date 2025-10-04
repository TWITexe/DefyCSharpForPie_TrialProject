using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.Playables;

public class cookDialog : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI text;              // ��� �����
    [SerializeField] string[] lines1;                   // ��������� �������
    [SerializeField] string[] lines2;                   // ������� ������ ������
    [SerializeField] float TextSpeed;                   // �������� ��������� ������
    [SerializeField] GameObject pointer;
    static bool isStartedDialog = false;                // ����� �� ������?
    public GameObject dialogWindow;                     // ������ ���� �������
    public GameObject button_formula;                   // ������ ������ �������
    public static bool formulaIsIssued = false;         // ����� �� ����� ������?
    public bool attemptDialog = false;                  // ������ ������� �������?
    public PlayableDirector TimeLineManager;            // ���-����� ������
    public static int dialogCookNow = 1;                // ������, ������� ����� ���������
    private bool animationOver = false;                 // �������� ���� ���������?
    
    public static bool firstCookDialog = false;         // �� ������ ������ ����� �� ������ ������?
    private bool secondCookDialog = false;              // �� ������ ������ ����� �� ������ ������?

    private int index;
    void Start()
    {
        text.text = string.Empty;
    }
    
    void Update()
    {
        if (QuestionsPanel.isDoughReady)
        {
            StartCoroutine(RunningCook());
        }
        if ((Input.GetMouseButtonDown(0) || Input.GetKeyDown(KeyCode.E)) && isStartedDialog)
        {
            if (text.text == lines1[index])
            {
                IsNextLine1();
            }
            else
            {
                StopAllCoroutines();
                text.text = lines1[index];
            }
        }
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if ((attemptDialog == false && collision.CompareTag("Player")) && isStartedDialog == false && ((Input.GetMouseButtonDown(0) || Input.GetKeyDown(KeyCode.E))))
        {
            StartDialog1();
            pointer.SetActive(false);
            attemptDialog = true;
        }
        if (( animationOver == true && collision.CompareTag("Player") && secondCookDialog == false && (Input.GetMouseButtonDown(0) || Input.GetKeyDown(KeyCode.E))))
        {
            StartDialog2();
        }

    }
    void StartDialog1()
    {
        if (firstCookDialog == false)
        {
            dialogWindow.SetActive(true);
            isStartedDialog = true;
            index = 0;
            StartCoroutine(TypeLine1());
        }
    }

    IEnumerator TypeLine1()
    {
        foreach (char c in lines1[index].ToCharArray())
        {
            text.text += c;
            yield return new WaitForSeconds(TextSpeed);
        }
    }


    void IsNextLine1()
    {
        if (index < lines1.Length - 1)
        {
            index++;
            text.text = string.Empty;
            StartCoroutine(TypeLine1());
        }
        else
        {
            dialogWindow.SetActive(false);
            isStartedDialog = false;
            button_formula.SetActive(true);
            formulaIsIssued = true;
            firstCookDialog = true;
            dialogCookNow++;
        }
    }
    IEnumerator RunningCook()
    {
        yield return new WaitForSeconds(7f);
        TimeLineManager.Play();
        animationOver = true;
    }
    
    void StartDialog2()
    {   if (dialogCookNow == 2 && secondCookDialog == false)
        {
            firstCookDialog = false;
            secondCookDialog = true;
            index = 0;
            lines1 = lines2;
            StartDialog1();  
        }
    }

}
