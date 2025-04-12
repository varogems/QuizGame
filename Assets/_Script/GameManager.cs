using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{


    Quiz        m_quizScriptObj;
    EndScreen   m_endScreenScriptObj;



    void Awake()
    {
        m_quizScriptObj         = FindObjectOfType<Quiz>();
        m_endScreenScriptObj    = FindObjectOfType<EndScreen>();
    }

    // Start is called before the first frame update
    void Start()
    {
        m_quizScriptObj.gameObject.SetActive(true);
        m_endScreenScriptObj.gameObject.SetActive(false);
    }


    // Update is called once per frame
    void Update()
    {
        if(m_quizScriptObj.isComplete())
        {
            m_quizScriptObj.gameObject.SetActive(false);
            
            m_endScreenScriptObj.gameObject.SetActive(true);
            m_endScreenScriptObj.showFinalScore();
        }
        
    }

    public void onReplay()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

}
