using Mirror;
using UnityEngine;
using UnityEngine.SceneManagement;

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
        SceneManager.LoadScene("StarterScene");
        /*CmdSpawnMyUnit();*/
    }

    public GameObject PlayerUnitPrefab;
    public int ServerPoints = 0;
    public int ClientPoints = 0;

    // Update is called once per frame
    void Update()
    {
        if (isLocalPlayer)
        {
            Debug.Log("SERVER: " + GameManager.questionIndex);
        }

/*        if (isClient)
        {
            Debug.Log("Client: " + GameManager.questionIndex);
        }*/
    }

 /*   [Command]
    void CmdSpawnMyUnit()
    {
        GameObject go = Instantiate(PlayerUnitPrefab);

        NetworkServer.Spawn(go);

        *//*NetworkManager.singleton.ServerChangeScene("StarterScene");*/
        /*Application.LoadLevel("StarterScene");*//*
        
    }*/

}
