using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices.WindowsRuntime;
using Unity.VisualScripting;
using UnityEngine;




[System.Serializable]
public struct Sentence
{

    [SerializeField] public int m_typeSentence;
    [SerializeField, TextArea(2, 6)] public string m_content;

    // public Sentence()
    // {
    //     typeSentence = 1;
    //     content = "Enter your content at here!";
    // }

}





[CreateAssetMenu(menuName = "Create Question", fileName = "Question")]
public class QuestionSO : ScriptableObject
{
    [SerializeField] Sentence   m_question;

    [SerializeField] Sentence[] m_arrAnswer = new Sentence[4];


    [SerializeField]
     byte                       m_indexAnswerCorrect;



    public Sentence getQuestion()
    {
        return m_question;
    }

    public Sentence[] getArrayAnswer()
    {
        return m_arrAnswer;
    }


     public byte getIndexCorrectAnswer()
     {
        return m_indexAnswerCorrect;
     }




}
