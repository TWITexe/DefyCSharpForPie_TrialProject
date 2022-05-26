using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnswerScript : MonoBehaviour
{
    public bool isCorrect = false;

    public QuestionsPanel questionsPanel;
    public void Answer()
    {
        if(isCorrect)
        {
            Debug.Log("Correct Answer");
            questionsPanel.Corrected();
        }
        else
        {
            Debug.Log("Wrong Answer");
            questionsPanel.Wrong();
        }
    }
}
