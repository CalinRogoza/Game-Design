using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;
using UnityEngine.Networking;
using System;
using System.IO;

public class NetworkManagerQuiz : NetworkManager
{
    public List<Question> questions = new List<Question>();

/*    public override void OnServerAddPlayer(NetworkConnection conn)
    {
        GameObject player = Instantiate(playerPrefab);
        NetworkServer.AddPlayerForConnection(conn, player);
    }*/

    public IEnumerator GetRequest()
    {
        UnityWebRequest www = UnityWebRequest.Get("http://localhost/QuizGame/index.php");
        yield return www.SendWebRequest();

        if (www.isNetworkError || www.isHttpError)
        {
            Debug.LogError(www.error);
        }
        else
        {
            /*Debug.Log(www.downloadHandler.text);*/
            /*int index = 0;*/

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
            

            // Set a variable to the Documents path.
            string docPath =
              Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);

            // Write the string array to a new file named "WriteLines.txt".
            using (StreamWriter outputFile = new StreamWriter(Path.Combine(docPath, "WriteLines.txt")))
            {
                foreach (Question question in questions)
                    outputFile.WriteLine(question);
            }
        }

    }

    public void PopulateQuestionList()
    {
        StartCoroutine(GetRequest());
    }

    private void Start()
    {
        PopulateQuestionList();

        /*Debug.Log("JKFOSAF: " + questions[0]);*/

        
    }
}
