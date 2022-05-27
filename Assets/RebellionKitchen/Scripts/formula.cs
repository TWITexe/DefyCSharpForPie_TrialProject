using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class formula : MonoBehaviour
{
    [SerializeField] GameObject formulaLayer;                            // Лист с формулой пирога
    [SerializeField] Animator anim;                                      // Ссылка на компонент анимаций
    static public bool formulaActiveNow = false;                          // Проверка показа формулы

    // Отметки "Найдено" в листе с формулой
    [SerializeField] GameObject tickMilk;
    [SerializeField] GameObject tickSugar;
    [SerializeField] GameObject tickYeast;
    [SerializeField] GameObject tickFlour;
    [SerializeField] GameObject tickButter;
    [SerializeField] GameObject tickSalt;
    [SerializeField] GameObject tickEgg;
    [SerializeField] GameObject tickJam;


    // Объекты и переменные связанные с нахождением продуктов
    [SerializeField] GameObject pointer;                                  // Стрелка указатель
    public static bool foundAllProduct = false;                           // Проверка на собранность всех объектов

    private void Start()
    {
        anim.GetComponent<Animation>();
    }
    void Update()
    {
        if (Move.products[0] && Move.products[1] && Move.products[2] && Move.products[3] && Move.products[4] && Move.products[5] && Move.products[6] && Move.products[8])
        {
            foundAllProduct = true;
            pointer.SetActive(true);

            if (DoughPie.attemptTest == true) 
            {
                pointer.SetActive(false);
            }

        }

        if (Input.GetKeyDown(KeyCode.Q) && cookDialog.formulaIsIssued && DoughPie.isStartingTest == false && Move.onTaskNow == false)
        {
            if (formulaActiveNow == true)
            {
                anim.SetBool("useFormula", false);
                anim.SetBool("offFormula", true);
                StartCoroutine(FormulaUnvisible());
            }
        }
        if (Input.GetKeyDown(KeyCode.Q) && formulaActiveNow == false && cookDialog.formulaIsIssued && DoughPie.isStartingTest == false && Move.onTaskNow == false)
        {
            FormulaOn();
        }
    }
    public void FormulaOn()
    {
        if (formulaActiveNow == false)
        {
            
            formulaActiveNow = true;
            if (Move.products[0] == true) { tickMilk.SetActive(true);  }
            if (Move.products[1] == true) { tickSugar.SetActive(true); }
            if (Move.products[2] == true) { tickYeast.SetActive(true); }
            if (Move.products[3] == true) { tickFlour.SetActive(true); }
            if (Move.products[4] == true) { tickButter.SetActive(true);}
            if (Move.products[5] == true) { tickSalt.SetActive(true);  }
            if (Move.products[6] == true) { tickEgg.SetActive(true);   }
            if (Move.products[8] == true) { tickJam.SetActive(true);   }
            formulaLayer.SetActive(true);
            anim.SetBool("useFormula", true);
            anim.SetBool("offFormula", false);       
            StartCoroutine(OffAnimFormula());
        }
    }
   
    IEnumerator FormulaUnvisible()
    {
        yield return new WaitForSeconds(0.8f);
        formulaActiveNow = false;
        formulaLayer.SetActive(false);

    }
    IEnumerator OffAnimFormula()
    {
        yield return new WaitForSeconds(0.3f);
        anim.SetBool("useFormula", false);
    }
   


}
