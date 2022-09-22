using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class QuizManager : MonoBehaviour
{
    
    public List<QandA> QnA;

    public GameObject[] options;

    public int currentQuestion;

    public Text QuestionTxt;

    public int trigger_counter = 0;


    private void Start()
    {
        trigger_counter++;
        if (trigger_counter != 1)
        {
            QnA.RemoveAt(currentQuestion);
        }

        generateQuestion();


    }

    public void correct()
    {
        QnA.RemoveAt(currentQuestion);
        generateQuestion();
    }

    void SetAnswers()
    {
        for (int i = 0; i < options.Length; i++)
        {
            options[i].GetComponent<AnswerScript>().isCorrect = false;
            options[i].transform.GetChild(0).GetComponent<Text>().text = QnA[currentQuestion].Answers[i];

            if(QnA[currentQuestion].CorrectAnswer == i + 1)
            {
                options[i].GetComponent<AnswerScript>().isCorrect = true;
            }
        }
    }

    

    void generateQuestion()
    {
        if(QnA.Count != 0)
        {
            currentQuestion = Random.Range(0, QnA.Count);

            QuestionTxt.text = QnA[currentQuestion].Question;

            SetAnswers();
        }
        else 
        {
            // Change Scene
        }

    }


}
