using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{

    public static PlayerManager instance;

    private PlayerController[] players;

    // private Transform playerCamera;

    private int currentPlayer;

    private void Awake(){
        if (instance != null){
            Destroy(this);
        }
        else{
            instance = this;
        }
        
    }

    private void Start(){
        players = GameObject.FindObjectsOfType<PlayerController>();
        // playerCamera = Camera.main.transform;
        for (int i = 0; i < players.Length; i++){
            players[i].playerID = i;
        }

        NextPlayer();
    }

    public bool IsMyTurn(int i){
        return i == currentPlayer;
    }

    public void NextPlayer(){
        StartCoroutine(_NextPlayer());
    }

    public IEnumerator _NextPlayer(){
        int nextPlayer = currentPlayer + 1;
        currentPlayer -= 1;

        yield return new WaitForSeconds(2f);

        currentPlayer = nextPlayer;

        if (currentPlayer >= players.Length){
            currentPlayer = 0;
        }

        // playerCamera.SetParent(players[currentPlayer].transform);
        // playerCamera.localPosition = Vector3.zero + Vector3.back * 10f;
    }
}


// code from Youtube: https://www.youtube.com/watch?v=PpGJLOolp3Q&ab_channel=AwesomeTuts-AnyoneCanLearnToMakeGames