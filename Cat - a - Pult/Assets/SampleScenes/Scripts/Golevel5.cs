using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Golevel5 : MonoBehaviour
{
    public void OnStartGame(int SceneNumber)
    {
        //Application.LoadLevel(SceneNumber);
        SceneManager.LoadScene(5);
    }
}

