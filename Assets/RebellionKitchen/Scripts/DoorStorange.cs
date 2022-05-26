using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

public class DoorStorange : MonoBehaviour
{
    public static bool doorUnlocked = false;                 // Открыта ли дверь?
    [SerializeField] PlayableDirector TimeLineRat;           // Кат-сцена повара
    public static bool firstInStorange = false;              // Был ли первый заход в подвал?
    [SerializeField] GameObject jam;                         // ( чтобы влючить коллайдер у джема, во время бега мышки ) 
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
