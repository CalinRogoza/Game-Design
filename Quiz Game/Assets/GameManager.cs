using Mirror;
using System;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : NetworkBehaviour
{
    public List<Question> questions = new List<Question>();
    public int randquest;
    NetworkManagerQuiz nmq;

    /*private void Awake()
    {
        GameObject gameObject = new GameObject("NetworkManagerQuiz");
        nmq = gameObject.AddComponent<NetworkManagerQuiz>();
    }*/

    /*public IEnumerator GetRequest()
    {
        UnityWebRequest www = UnityWebRequest.Get("http://localhost/QuizGame/index.php");
        yield return www.SendWebRequest();

        if (www.isNetworkError || www.isHttpError)
        {
            Debug.LogError(www.error);
        }
        else
        {
            *//*Debug.Log(www.downloadHandler.text);*//*
            int index = 0;

            string[] rows = www.downloadHandler.text.Split('!');
            Debug.Log(rows[0]);
            foreach (string row in rows)
            {
                string[] parts = row.Split('|');
                if (parts.Length == 9)
                {
                    foreach (string part in parts)
                    {
                        Debug.Log(part);
                    }

                    Question question = new Question(parts[1], Convert.ToInt32(parts[2]), parts[3], parts[4], parts[5], parts[6], Convert.ToInt32(parts[7]), parts[8]);


                    questions.Add(question);

                }

            }
            PrepareQuestion();

        }

    }

    public void PopulateQuestionList()
    {
        StartCoroutine(GetRequest());
    }*/

    public static int questionIndex = 0;

    public void PrepareQuestion()
    {
        GameObject go = GameObject.Find("PLAYERUNIT 1");
        Debug.Log("GOOO");
        /*System.Random random = new System.Random();
        randquest = random.Next(0, questions.Count);*/
        GameObject.Find("QuestionPanel").GetComponentInChildren<Text>().text = questions[questionIndex].question;
        GameObject.Find("Button1").GetComponentInChildren<Text>().text = questions[questionIndex].option1;
        GameObject.Find("Button2").GetComponentInChildren<Text>().text = questions[questionIndex].option2;
        GameObject.Find("Button3").GetComponentInChildren<Text>().text = questions[questionIndex].option3;
        GameObject.Find("Button4").GetComponentInChildren<Text>().text = questions[questionIndex].option4;
        
    }

    void TaskOnClick1()
    {
        if (questions[questionIndex].correctAnswer == 1)
        {
            Debug.Log("CORECT!");
            ScoreScript.scoreValue += questions[questionIndex].points;
        }
        questionIndex += 1;
        PrepareQuestion();
    }

    void TaskOnClick2()
    {
        if (questions[questionIndex].correctAnswer == 2)
        {
            Debug.Log("CORECT!");
            ScoreScript.scoreValue +=questions[questionIndex].points;
        }
        questionIndex += 1;
        PrepareQuestion();
    }

    void TaskOnClick3()
    {
        if (questions[questionIndex].correctAnswer == 3)
        {
            Debug.Log("CORECT!");
            ScoreScript.scoreValue += questions[questionIndex].points;
        }
        questionIndex += 1;
        PrepareQuestion();
    }

    void TaskOnClick4()
    {
        if (questions[questionIndex].correctAnswer == 4)
        {
            Debug.Log("CORECT!");
            ScoreScript.scoreValue += questions[questionIndex].points;
        }
        questionIndex += 1;
        PrepareQuestion();
    }


    void Start()
    {
        /*        PopulateQuestionList();*/

        Button btn1 = GameObject.Find("Button1").GetComponent<Button>();
        Button btn2 = GameObject.Find("Button2").GetComponent<Button>();
        Button btn3 = GameObject.Find("Button3").GetComponent<Button>();
        Button btn4 = GameObject.Find("Button4").GetComponent<Button>();

        btn1.onClick.AddListener(TaskOnClick1);
        btn2.onClick.AddListener(TaskOnClick2);
        btn3.onClick.AddListener(TaskOnClick3);
        btn4.onClick.AddListener(TaskOnClick4);

        GameManager nm = FindObjectOfType<GameManager>();
        Debug.Log("ID: " + nm.GetInstanceID());

        /*Debug.Log("INTREBARE: " + questions[0]);*/
        /*if (isClient)
        {
            randquest = 1;
        }
        else if (isServer)
        {
            randquest = 2;
        }*/

        
            // Set a variable to the Documents path.
            string docPath =
              Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);

            // Write the string array to a new file named "WriteLines.txt".
            using (StreamReader inputFile = new StreamReader(Path.Combine(docPath, "WriteLines.txt")))
            {
                string line = inputFile.ReadLine();
                while(line != null)
                {
                    string[] parts = line.Split(';');
                    Question question = new Question(parts[0], Convert.ToInt32(parts[1]), parts[2], parts[3], parts[4], parts[5], Convert.ToInt32(parts[6]), parts[7]);
                    questions.Add(question);
                    line = inputFile.ReadLine();
                }
            }

            PrepareQuestion();
        
    }

}
