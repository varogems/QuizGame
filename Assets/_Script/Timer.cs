using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Timer : MonoBehaviour
{

    [SerializeField] float  m_timeToCompleteQuestion = 30f;
    [SerializeField] float  m_timeToShowCorrectAnswer = 5f;


    float                   m_timeStamp;
    [SerializeField] bool   m_isAnsweringQuestion;

    public float            m_fillFraction;

    public bool             m_loadNextQuestion;

    void Start()
    {
        m_isAnsweringQuestion   = true;
        m_loadNextQuestion      = true;
        m_timeStamp             = m_timeToCompleteQuestion;
    }

    void Update()
    {
        updateTimer();
    }


    public void skipAnsweringQuestion()
    {
        m_timeStamp = m_timeToShowCorrectAnswer;
        m_isAnsweringQuestion = false;

        // m_timeStamp = 0;
    }

    void updateTimer()
    {
        m_timeStamp -= Time.deltaTime;


        if(m_isAnsweringQuestion)
        {
            if(m_timeStamp > 0)
            {
                m_fillFraction = m_timeStamp/m_timeToCompleteQuestion;
            }
            else
            {
                m_timeStamp = m_timeToShowCorrectAnswer;
                m_isAnsweringQuestion = false;
            }
        }
        else
        {
            if(m_timeStamp > 0)
            {
                m_fillFraction = m_timeStamp/m_timeToShowCorrectAnswer;
            }
            else
            {
                m_timeStamp = m_timeToCompleteQuestion;
                m_isAnsweringQuestion = true;
                
                m_loadNextQuestion = true;
            }
        }


        //Debug.Log("m_isAnsweringQuestion: "+ m_isAnsweringQuestion + " Fill Fraction: " + m_fillFraction);


    }

    public float getFillFraction()
    {
        return m_fillFraction;
    }

    public bool isAnsweringQuestion()
    {
        return m_isAnsweringQuestion;
    }



}
