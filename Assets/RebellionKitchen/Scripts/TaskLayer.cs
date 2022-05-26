using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TaskLayer : MonoBehaviour
{
    [SerializeField] private InputField inputTastText;   // Текст-бокс объект
    [SerializeField] private Text isTheAnswerTrue;       // Текст о верности ответа
    [SerializeField] private GameObject LayerTask;       // Лист с заданием
    [SerializeField] private GameObject DoorinStorange;  // Дверь в подвал
    public Sprite openDoor;                              // Спрайт открытой двери

    public static bool isAnswerTrue = false;             // Ответ был верным



    private void Update()
    {
        if (Move.onTaskNow == true)
        {
            LayerTask.SetActive(true);
        }
        
    }

    public void GetAnswer()
    {
        if(inputTastText.text == "12")
        {
            isTheAnswerTrue.text = "Верный ответ, так держать! ";
            DoorinStorange.GetComponent<SpriteRenderer>().sprite = openDoor;
            StartCoroutine(EndTask());
        }
        else
        {
            isTheAnswerTrue.text = "Ответ неверный :(";
        }
    }
    IEnumerator EndTask()
    {
        yield return new WaitForSeconds(1f);
        Debug.Log("Task close");
        LayerTask.SetActive(false);
        isAnswerTrue = true;
        Move.onTaskNow = false;
        DoorStorange.doorUnlocked = true;
    }
}
