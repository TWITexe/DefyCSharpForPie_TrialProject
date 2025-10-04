using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoughPie : MonoBehaviour
{
    public GameObject pan;                             // Миска с тестом
    public GameObject tablePie;                        // Стол-Духовка
    public GameObject testLayer;                      // Лист с тестом
    public Sprite spritePan;                           // Миска с тестом внутри
    public Sprite spriteTablePie;                      // Стол с пирогом
    public static bool isStartingTest = false;         // Проверка начала теста
    public static bool attemptTest = false;            // Использована ли попытка


    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            if ((isStartingTest == false) && (Input.GetKey(KeyCode.E)) && (formula.foundAllProduct && attemptTest == false))
            {
                attemptTest = true;
                isStartingTest = true;
                testLayer.SetActive(true);
                pan.GetComponent<SpriteRenderer>().sprite = spritePan;
                tablePie.GetComponent<SpriteRenderer>().sprite = spriteTablePie;
            }
        }
    }
}
