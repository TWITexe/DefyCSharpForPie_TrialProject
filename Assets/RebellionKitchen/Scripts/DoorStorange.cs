using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

public class DoorStorange : MonoBehaviour
{
    public static bool doorUnlocked = false;                 // Открыта ли дверь?
    [SerializeField] PlayableDirector TimeLineRat;           // Сцена повара
    public static bool firstInStorange = false;              // Активация подвала была осуществлена?
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
