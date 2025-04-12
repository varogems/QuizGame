using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;
using Unity.VisualScripting;
using System.Linq;
using UnityEngine.UI;

public class Quiz : MonoBehaviour
{


[Header("Question")]
    [SerializeField] TextMeshProUGUI    m_questionTextMeshProUGUI;
    [SerializeField] List<QuestionSO>   m_listQuestionSO = new List<QuestionSO>();
    QuestionSO m_curQuestion;


[Header("Color Buttons")]
    [SerializeField] GameObject[]       m_arrButtons;
    [SerializeField] Sprite             m_spriteCorrectAnswer;
    [SerializeField] Sprite             m_spriteDefaultAnswer;
    bool                                m_hasDoneStageAnswer;


[Header("Score")]
    [SerializeField] TextMeshProUGUI    m_scoreTextMeshProGUI;
    ScoreKeeper                         m_scoreKeeper;


[Header("Timer")]
    [SerializeField] Image              m_imageTimer;
    Timer                               m_timer;


[Header("ProgessBar")]
    [SerializeField] Slider             m_progessBar;
    [SerializeField] bool               m_isComplete;



    void Awake()
    {
        m_timer = FindObjectOfType<Timer>();
        m_scoreKeeper = FindObjectOfType<ScoreKeeper>();
    }

    void Start()
    {
        m_hasDoneStageAnswer = false;

        m_progessBar.value = 0;
        m_progessBar.maxValue = m_listQuestionSO.Count;
        m_isComplete = false;
    }

    void Update() 
    {
        m_imageTimer.fillAmount = m_timer.getFillFraction();

        if(m_timer.m_loadNextQuestion)
        {

            if(m_progessBar.value == m_progessBar.maxValue) 
            {
                m_isComplete = true;
                return;
            }
            else m_progessBar.value++;

            m_hasDoneStageAnswer = false;
            m_timer.m_loadNextQuestion = false;

            nextQuestion();
        }
        //! If don't choose answer and run out time answer question.
        else if(!m_hasDoneStageAnswer && !m_timer.isAnsweringQuestion())
            onCheckAnswer(-1);

    }

    public void onCheckAnswer(int index)
    {
        if(index == m_curQuestion.getIndexCorrectAnswer())
        {
            m_questionTextMeshProUGUI.text = "Correct Answer!";
            m_arrButtons[index].GetComponent<Image>().sprite = m_spriteCorrectAnswer;

            //Increase  number correct answers
            m_scoreKeeper.increaseNumberCorrectAnswers();
            m_scoreTextMeshProGUI.text = "Score: " + m_scoreKeeper.getNumberCorrectAnswers();

            Debug.Log("Quiz::onCheckAnswer: Correct Answer!");
        }
        else
        {
            m_questionTextMeshProUGUI.text = "Wrong Answer!";
            m_arrButtons[m_curQuestion.getIndexCorrectAnswer()].GetComponent<Image>().sprite = m_spriteCorrectAnswer;
            Debug.Log("Quiz::onCheckAnswer: Wrong Answer!");
        }

        
        //Disable all answer buttons
        setStateButton(false);

        m_hasDoneStageAnswer = true;
        
        //! If index answer in between 0 to 3 
        if(index > -1) m_timer.skipAnsweringQuestion();

        // Debug.Log(m_spriteCorrectAnswer.name + "/" + m_spriteCorrectAnswer.ToString());
    }


    void displayQuestion()
    {
        m_questionTextMeshProUGUI.text = m_curQuestion.getQuestion().m_content;

        for(int i = 0; i < m_arrButtons.Count(); i++)
            m_arrButtons[i].GetComponentInChildren<TextMeshProUGUI>().text = m_curQuestion.getArrayAnswer()[i].m_content;
            
    }


    void setStateButton(bool state)
    {
        for(int i = 0; i < m_arrButtons.Count(); i++)
            m_arrButtons[i].GetComponent<Button>().interactable = state;
    }

    void setDefaultSpriteButtons()
    {
        for(int i = 0; i < m_arrButtons.Count(); i++)
            m_arrButtons[i].GetComponent<Image>().sprite = m_spriteDefaultAnswer;
    }



    void nextQuestion()
    {
        // if(m_progessBar.value == m_progessBar.maxValue) m_isComplete = true;
        // else m_progessBar.value++;

        setStateButton(true);
        setDefaultSpriteButtons();
        getRandomQuestion();
        
        displayQuestion();
    }

    void getRandomQuestion()
    {
        if(m_listQuestionSO.Count != 0) 
            m_curQuestion = m_listQuestionSO[UnityEngine.Random.Range(0, m_listQuestionSO.Count)];
        
        if(m_listQuestionSO.Contains(m_curQuestion))
            m_listQuestionSO.Remove(m_curQuestion);
    }

    public bool isComplete()
    {
        return m_isComplete;
    }

}
