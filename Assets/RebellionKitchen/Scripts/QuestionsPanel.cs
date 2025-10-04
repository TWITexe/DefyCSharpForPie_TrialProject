using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;



public class QuestionsPanel : MonoBehaviour
{
    public static bool isDoughReady = false;
             

    public List<QuestionsAndAnswers> QnA;
    public GameObject[] button_answer;

    public GameObject layer;
    
    public int currentQuestion;
    public int score;

    public Text score_text;
    public Text QuestionText;
    
    private void Start()
    {
        GenerateQuestion();
    }

    void EndTest()
    {
        if (score == 10)
        {
            layer.SetActive(false);
            DoughPie.isStartingTest = false;
            isDoughReady = true;
        }
        else
        {
            GenerateQuestion();
        }
    }

    public void Corrected()
    {  
        score++;
        score_text.text = score + " / 10";
        QnA.RemoveAt(currentQuestion);
        GenerateQuestion();
    }
    public void Wrong()
    {
        GenerateQuestion();
    }

    void SetAnswers()
    {
        for (int i = 0; i < button_answer.Length; i++)
        {
            button_answer[i].GetComponent<AnswerScript>().isCorrect = false;
            button_answer[i].transform.GetChild(0).GetComponent<Text>().text = QnA[currentQuestion].Answer[i];

            if(QnA[currentQuestion].CorrectAnser == i+1)
            {
                button_answer[i].GetComponent<AnswerScript>().isCorrect = true;
            }
        }
    }

    void GenerateQuestion()
    {
        if (QnA.Count > 0)
        {

        
            currentQuestion = Random.Range(0, QnA.Count);

            QuestionText.text = QnA[currentQuestion].Question;
            SetAnswers();
        }
        else
        {
            EndTest();
        }
    }
}
