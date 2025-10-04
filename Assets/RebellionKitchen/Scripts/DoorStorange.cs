using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

public class DoorStorange : MonoBehaviour
{
    public static bool doorUnlocked = false;                 // ������� �� �����?
    [SerializeField] PlayableDirector TimeLineRat;           // ����� ������
    public static bool firstInStorange = false;              // ��������� ������� ���� ������������?
    [SerializeField] GameObject jam;
    void Start()
    {
        
    }

    void Update()
    {
        if (firstInStorange)
        {
            TimeLineRat.Play();
            jam.GetComponent<BoxCollider2D>().enabled = false;
            StartCoroutine(JamCollider());
        }
        
    }
    IEnumerator JamCollider()
    {
        yield return new WaitForSeconds(15f);
        jam.GetComponent<BoxCollider2D>().enabled = true;
    }
}
