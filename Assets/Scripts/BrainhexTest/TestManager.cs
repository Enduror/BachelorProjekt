using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class TestManager : MonoBehaviour
{    
    public Text questionText;
    public Question[] question;
    public int currentQuestion;
    public ToggleGroup toggleGroup;
    public GameObject nextButton;
    public GameObject endQuizButton;
    


    public Toggle Answer1;
    public Toggle Answer2;
    public Toggle Answer3;

    public int achieverScore;
    public int killerScore;
    public int explorerScore;

    // Use this for initialization
    void Start()
    {
        currentQuestion = 0;
        //Answer1.text = question[currentQuestion].answer1;
        //Answer2.text = question[currentQuestion].answer2;
        //Answer3.text = question[currentQuestion].answer3;
        questionText.text = question[currentQuestion].questionText;
        Answer1.GetComponentInChildren<Text>().text = question[currentQuestion].answerArray[0].answerText;
        Answer2.GetComponentInChildren<Text>().text = question[currentQuestion].answerArray[1].answerText;
        Answer3.GetComponentInChildren<Text>().text = question[currentQuestion].answerArray[2].answerText;


    }


    public void NextQuestion()
    {
        if (currentQuestion < question.Length)
        {
            Debug.Log(question[currentQuestion].gameObject.name);
            if (question[currentQuestion+1].gameObject.name == "Ende")
            {
                questionText.text = question[currentQuestion+1].questionText;
                Answer1.gameObject.SetActive(false);
                Answer2.gameObject.SetActive(false);
                Answer3.gameObject.SetActive(false);
                nextButton.SetActive(false);
                endQuizButton.SetActive(true);
                Debug.Log("Keine Fragen mehr übrig");
                return;
            }
            if (toggleGroup.AnyTogglesOn())
            {
                CheckActiveToggle();                                                   // jetzt die antwort die getoogled is auf is true
                question[currentQuestion].CheckThisOut();                               // Erhöhrt den Score beim jeweiligen spielertyp
                toggleGroup.SetAllTogglesOff();                                      // schließt alle toggles für die nächste frage  
                currentQuestion++;
                questionText.text = question[currentQuestion].questionText;

                
                    Answer1.GetComponentInChildren<Text>().text = question[currentQuestion].answerArray[0].answerText;
                    Answer2.GetComponentInChildren<Text>().text = question[currentQuestion].answerArray[1].answerText;
                    Answer3.GetComponentInChildren<Text>().text = question[currentQuestion].answerArray[2].answerText;

                    toggleGroup.SetAllTogglesOff();
               
                

                Debug.Log("achieverScore: " + achieverScore);
                Debug.Log("killerScore: " + killerScore);
                Debug.Log("explorerScore: " + explorerScore);
            }
            else
            {
                Debug.Log("Keine Antwort ausgesucht");
            }

        }
        
    }

    public void EndQuiz()
    {
        SceneManager.LoadScene("TutorialScene");

    }

    public void CheckActiveToggle()
    {
        if (Answer1.isOn)
        {
            question[currentQuestion].answerArray[0].isChecked = true;
        }
        if (Answer2.isOn)
        {
            question[currentQuestion].answerArray[1].isChecked = true;
        }
        if (Answer3.isOn)
        {
            question[currentQuestion].answerArray[2].isChecked = true;
        }
    }
}
