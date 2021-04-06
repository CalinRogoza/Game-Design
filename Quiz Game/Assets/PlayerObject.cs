using Mirror;
using System.Collections;
using System.Collections.Generic;
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

    // Update is called once per frame
    void Update()
    {
        
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
