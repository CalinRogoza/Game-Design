using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public Question[] questions;
    public int randquest;

    public void PopulateQuestionList()
    {
        questions = new Question[11];
        questions[0] = new Question("Care este capitala Romaniei?", 1, "Bucuresti", "Anglia", "Suceava", "Craiova", 1);
        questions[1] = new Question("Care este cel mai inalt munte din lume?", 2, "Carpati", "Everest", "Bucegi", "Alpi", 2);
        questions[2] = new Question("In ce an a avut loc Batalia din Normandia?", 3, "2010", "1970", "1944", "1921", 2);
        questions[3] = new Question("In ce an s-a scufundat vasul de croaziera Titanic?", 4, "2020", "1970", "1956", "1912", 1);
        questions[4] = new Question("In ce ani a avut loc Primul Razboi Mondial?", 4, "2019-2020", "1955-1970", "1939-1945", "1914-1918", 1);
        questions[5] = new Question("Care este cel mai mic stat din Europa?", 1, "Vatican", "Luxembourg", "Malta", "Rusia", 1);
        questions[6] = new Question("In ce an a fost lansat DotA2?", 3, "2010", "2007", "2013", "2019", 4);
        questions[7] = new Question("De catre ce companie a fost dezvoltat Skyrim?", 1, "Bethesda", "Riot", "Rockstar", "Valve", 3);
        questions[8] = new Question("League of Legends este un:", 2, "FPS", "MOBA", "Battle Royale", "Survival horror", 2);
        questions[9] = new Question("Care a fost cel mai vandut joc in 2020 in USA?", 1, "Call of Duty: Black Ops: Cold War", "Assassin’s Creed: Valhalla", "The Last of Us: Part II", "FIFA 21", 1);
        questions[10] = new Question("Care dintre urmatoarele jocuri a inregistrat cel mai mare numar de jucatori?", 2, "CS:GO", "CrossFire", "PUBG", "DotA2", 3);

    }

    public void PrepareQuestion()
    {
        System.Random random = new System.Random();
        randquest = random.Next(0, questions.Length);
        GameObject.Find("QuestionPanel").GetComponentInChildren<Text>().text = questions[randquest].question;
        GameObject.Find("Button1").GetComponentInChildren<Text>().text = questions[randquest].option1;
        GameObject.Find("Button2").GetComponentInChildren<Text>().text = questions[randquest].option2;
        GameObject.Find("Button3").GetComponentInChildren<Text>().text = questions[randquest].option3;
        GameObject.Find("Button4").GetComponentInChildren<Text>().text = questions[randquest].option4;
    }

    void TaskOnClick1()
    {
        if (questions[randquest].correctAnswer == 1)
        {
            Debug.Log("CORECT!");
            ScoreScript.scoreValue += questions[randquest].points;
        }
        PrepareQuestion();
        /*SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);*/
        /*GameObject.Find("Panel").GetComponentInChildren<Text>().text = points.ToString();
        GetComponent<Text>().text = points.ToString();*/

        /* text = GetComponent<Text>();
         text.text = "Score" + points.ToString();*/
        

    }

    void TaskOnClick2()
    {
        if (questions[randquest].correctAnswer == 2)
        {
            Debug.Log("CORECT!");
            ScoreScript.scoreValue += questions[randquest].points;
        }
        PrepareQuestion();
        /*SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);*/
        /*GameObject.Find("Panel").GetComponentInChildren<Text>().text = points.ToString();
        GetComponent<Text>().text = points.ToString();*/
        /*text = GetComponent<Text>();
        text.text = "Score" + points.ToString();*/
        
    }

    void TaskOnClick3()
    {
        if (questions[randquest].correctAnswer == 3)
        {
            Debug.Log("CORECT!");
            ScoreScript.scoreValue += questions[randquest].points;
        }
        PrepareQuestion();
        /*SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);*/
        /*GameObject.Find("Panel").GetComponentInChildren<Text>().text = points.ToString();
        GetComponent<GUIText>().text = points.ToString();*/
        /*text = GetComponent<Text>();
        text.text = "Score" + points.ToString();*/
       
    }

    void TaskOnClick4()
    {
        if (questions[randquest].correctAnswer == 4)
        {
            Debug.Log("CORECT!");
            ScoreScript.scoreValue += questions[randquest].points;
        }
        PrepareQuestion();
        /*        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        */        /*GameObject.Find("Panel").GetComponentInChildren<Text>().text = points.ToString();
                GetComponent<Text>().text = points.ToString();*/
        /*text = GetComponent<Text>();
        text.text = "Score" + points.ToString();*/
        
    }


    void Start()
    {
        PopulateQuestionList();
        
        PrepareQuestion();


        Button btn1 = GameObject.Find("Button1").GetComponent<Button>();
        Button btn2 = GameObject.Find("Button2").GetComponent<Button>();
        Button btn3 = GameObject.Find("Button3").GetComponent<Button>();
        Button btn4 = GameObject.Find("Button4").GetComponent<Button>();

        btn1.onClick.AddListener(TaskOnClick1);
        btn2.onClick.AddListener(TaskOnClick2);
        btn3.onClick.AddListener(TaskOnClick3);
        btn4.onClick.AddListener(TaskOnClick4);

    }
}
