using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManeger : MonoBehaviour
{

    public GameObject _player;

    public delegate void SendEnemyObject(GameObject enemy);
    public event SendEnemyObject EnemySend;



    void Update()
    {
       if (EnemySend != null)
         EnemySend.Invoke(_player);
    }

    public void Restart()
    {
       
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

}
