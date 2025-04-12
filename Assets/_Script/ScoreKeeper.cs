using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreKeeper : MonoBehaviour
{

    int m_numberCorrectAnswers;
    int m_numberQuestions;


    public void increaseNumberCorrectAnswers()
    {
        m_numberCorrectAnswers++;
    }

    public void increaseNumberQuestions()
    {
        m_numberQuestions++;
    }
    
    public int getNumberCorrectAnswers()
    {
        return m_numberCorrectAnswers;
    }

}
