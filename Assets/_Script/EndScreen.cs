using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;


public class EndScreen : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI    m_finalScoreText;
    ScoreKeeper                         m_scoreKeeper;

    void Awake()
    {
        m_scoreKeeper = FindObjectOfType<ScoreKeeper>();
    }


    public void showFinalScore()
    {
        m_finalScoreText.text = "Congratulation\n" +
                                "Your Score " + m_scoreKeeper.getNumberCorrectAnswers();
    }

}
