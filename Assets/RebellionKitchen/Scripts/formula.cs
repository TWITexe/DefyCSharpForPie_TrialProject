using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class formula : MonoBehaviour
{
    [SerializeField] GameObject formula_layer;                            // Лист с формулой пирога
    [SerializeField] Animator _anim;                                      // Ссылка на компонент анимаций
    static public bool formulaActiveNow = false;                          // Формула открыта сейчас? ( стандарт - нет )

    // Отметки "Найдено" в листе с формулой
    [SerializeField] GameObject tick_milk;
    [SerializeField] GameObject tick_sugar;
    [SerializeField] GameObject tick_yeast;
    [SerializeField] GameObject tick_flour;
    [SerializeField] GameObject tick_butter;
    [SerializeField] GameObject tick_salt;
    [SerializeField] GameObject tick_egg;
    [SerializeField] GameObject tick_jam;


    // Объекты и переменные связанные с нахождением продуктов
    [SerializeField] GameObject pointer;                                  // Стрелка указатель ( указывает на кастрюлю для теста )
    public static bool foundAllProduct = false;                           // Все ли объекты собраны?

    private void Start()
    {
        _anim.GetComponent<Animation>();
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
                _anim.SetBool("useFormula", false);
                _anim.SetBool("offFormula", true);
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
            if (Move.products[0] == true) { tick_milk.SetActive(true); }
            if (Move.products[1] == true) { tick_sugar.SetActive(true); }
            if (Move.products[2] == true) { tick_yeast.SetActive(true); }
            if (Move.products[3] == true) { tick_flour.SetActive(true); }
            if (Move.products[4] == true) { tick_butter.SetActive(true); }
            if (Move.products[5] == true) { tick_salt.SetActive(true); }
            if (Move.products[6] == true) { tick_egg.SetActive(true); }
            if (Move.products[8] == true) { tick_jam.SetActive(true); }
            formula_layer.SetActive(true);
            _anim.SetBool("useFormula", true);
            _anim.SetBool("offFormula", false);       
            StartCoroutine(OffAnimFormula());
        }
    }
   
    IEnumerator FormulaUnvisible()
    {
        yield return new WaitForSeconds(0.8f);
        formulaActiveNow = false;
        formula_layer.SetActive(false);

    }
    IEnumerator OffAnimFormula()
    {
        yield return new WaitForSeconds(0.3f);
        _anim.SetBool("useFormula", false);
    }
   


}
