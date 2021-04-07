using Mirror;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerObject : NetworkBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        if (!isLocalPlayer)
        {
            return;
        }

        Debug.Log("THIS IS MY oBJECT");
        /*SceneManager.LoadScene("StarterScene");*/
        CmdSpawnMyUnit();
    }

    public GameObject PlayerUnitPrefab;
    [SyncVar]
    public int ServerPoints = 0;
    [SyncVar]
    public int ClientPoints = 0;

    // Update is called once per frame
    void Update()
    {
        if (isServer && GameManager.questionIndex == 10)
        {
            int scor = ScoreScript.scoreValue;
            Debug.Log("SERVER: " + GameManager.questionIndex);
            SceneManager.LoadScene("EndScene");
            /*GameObject.Find("Canvas").GetComponentInChildren<Text>().text = scor.ToString();*/
        }

        if (isClient && GameManager.questionIndex == 10)
        {
            Debug.Log("Client: " + GameManager.questionIndex);
        }
    }

    [Command]
    void CmdSpawnMyUnit()
    {
        NetworkManager nm = FindObjectOfType<NetworkManager>();
       
        if(nm.numPlayers == 2)
        {
            GameObject go = Instantiate(PlayerUnitPrefab);

            NetworkServer.Spawn(go);
        }

        /*NetworkManager.singleton.ServerChangeScene("StarterScene");
        Application.LoadLevel("StarterScene");*/

    }

}
