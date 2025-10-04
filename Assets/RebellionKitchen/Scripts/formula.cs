using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class formula : MonoBehaviour
{
    [SerializeField] GameObject formulaLayer;                            // ���� � �������� ������
    [SerializeField] Animator anim;                                      // ������ �� ��������� ��������
    static public bool formulaActiveNow = false;                          // �������� ������ �������
    private bool isAnimating = false; // 🚀 блокировка повторных нажатий

    // ������� "�������" � ����� � ��������
    [SerializeField] GameObject tickMilk;
    [SerializeField] GameObject tickSugar;
    [SerializeField] GameObject tickYeast;
    [SerializeField] GameObject tickFlour;
    [SerializeField] GameObject tickButter;
    [SerializeField] GameObject tickSalt;
    [SerializeField] GameObject tickEgg;
    [SerializeField] GameObject tickJam;


    // ������� � ���������� ��������� � ����������� ���������
    [SerializeField] GameObject pointer;                                  // ������� ���������
    public static bool foundAllProduct = false;                           // �������� �� ����������� ���� ��������

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

        if (Input.GetKeyDown(KeyCode.Q) && !isAnimating &&
            cookDialog.formulaIsIssued && !DoughPie.isStartingTest && !Move.onTaskNow)
        {
            if (formulaActiveNow)
                StartCoroutine(CloseFormula());
            else
                StartCoroutine(OpenFormula());
        }
    }
    private IEnumerator OpenFormula()
    {
        isAnimating = true;
        formulaActiveNow = true;

        // включаем галочки
        if (Move.products[0]) tickMilk.SetActive(true);
        if (Move.products[1]) tickSugar.SetActive(true);
        if (Move.products[2]) tickYeast.SetActive(true);
        if (Move.products[3]) tickFlour.SetActive(true);
        if (Move.products[4]) tickButter.SetActive(true);
        if (Move.products[5]) tickSalt.SetActive(true);
        if (Move.products[6]) tickEgg.SetActive(true);
        if (Move.products[8]) tickJam.SetActive(true);

        formulaLayer.SetActive(true);
        anim.SetBool("useFormula", true);
        anim.SetBool("offFormula", false);

        yield return new WaitForSeconds(0.3f); // время анимации открытия

        anim.SetBool("useFormula", false);
        isAnimating = false;
    }

    private IEnumerator CloseFormula()
    {
        isAnimating = true;

        anim.SetBool("useFormula", false);
        anim.SetBool("offFormula", true);

        yield return new WaitForSeconds(0.8f); // время анимации закрытия

        formulaActiveNow = false;
        formulaLayer.SetActive(false);
        isAnimating = false;
    }
   


}
