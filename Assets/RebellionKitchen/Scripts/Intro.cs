using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Intro : MonoBehaviour
{
    [SerializeField] GameObject storyLayer;    // Лист для интро

    [SerializeField] GameObject introText;     // Обучение
    [SerializeField] GameObject pressE;        // Нажатие на E
    [SerializeField] GameObject introStory1;   // Предыстория кадр 1
    [SerializeField] GameObject introStory2;   // Предыстория кадр 2
    [SerializeField] GameObject introStory3;   // Предыстория кадр 3 
    [SerializeField] GameObject introStory4;   // Предыстория кадр 4
    [SerializeField] GameObject introStory5;   // Предыстория кадр 5

    public static bool introStoryEnd = false;  // Закончилась ли предыстория
    int numberOfClicks = 0;                    // Кол-во нажатий "E" 

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) || Input.GetMouseButtonDown(0) && introStoryEnd == false)
        {
                numberOfClicks++;
                switch(numberOfClicks)
                {
                    case 1:
                        introText.SetActive(false);
                        break;
                    case 2:
                        pressE.SetActive(false);
                        introStory1.SetActive(true);
                    break;
                    case 3:
                        introStory2.SetActive(true);
                    break;
                    case 4:
                        introStory3.SetActive(true);
                    break;
                    case 5:
                        introStory4.SetActive(true);
                    break;
                    case 6:
                        introStory5.SetActive(true);
                    break;
                    case 7:
                        storyLayer.SetActive(false);
                        introStoryEnd = true;
                    break;
                }

        }
    }
}
