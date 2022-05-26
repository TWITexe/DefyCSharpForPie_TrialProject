using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoughPie : MonoBehaviour
{
    public GameObject pan;                             // Миска с тестом
    public GameObject tablePie;                        // Стол-Духовка
    public GameObject test_layer;                      // Лист с тестом
    public static bool isStartingTest = false;         // Начан ли тест?
    public static bool attemptTest = false;            // Попытка теста использованна?
    public Sprite spritePan;                           // Миска с тестом внутри
    public Sprite spriteTablePie;                      // Стол с пирогом


    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            if ((isStartingTest == false) && (Input.GetKey(KeyCode.E)) && (formula.foundAllProduct && attemptTest == false))
            {
                attemptTest = true;
                isStartingTest = true;
                test_layer.SetActive(true);
                pan.GetComponent<SpriteRenderer>().sprite = spritePan;
                tablePie.GetComponent<SpriteRenderer>().sprite = spriteTablePie;
            }
        }
    }
}
