using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TheEnd : MonoBehaviour
{
    public GameObject endingStoryLayer;             // ���� ��� �����
    public GameObject pressE;                       // ������� �� E
    [SerializeField] GameObject endStory1;          // ����� ���� 1
    [SerializeField] GameObject endStory2;          // ����� ���� 2
    [SerializeField] GameObject endStory3;          // ����� ���� 3 
    [SerializeField] GameObject endStory4;          // ����� ���� 4


    public static bool introStoryEnd = false;       // ����������� �� �����������
    int numberOfClicks = 0;                         // ���-�� ������� "E" 

    void Update()
    {
        if (cookDialog.dialogCookNow >= 3)
        {
            if (Input.GetKeyDown(KeyCode.E) || Input.GetMouseButtonDown(0) && introStoryEnd == false)
            {
                numberOfClicks++;
                switch(numberOfClicks)
                {
                    case 1:
                        pressE.SetActive(true);
                        endingStoryLayer.SetActive(true);
                        break;
                    case 2:
                        pressE.SetActive(false);
                        endStory1.SetActive(true);
                        break;
                    case 3:
                        endStory2.SetActive(true);
                        break;
                    case 4:
                        endStory3.SetActive(true);
                        break;
                    case 5:
                        endStory4.SetActive(true);
                        break;
                    case 6:
                        introStoryEnd = true;
                        break;
                }

            }

        }
    }
}
