using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Lord : MonoBehaviour
{
    public void LordScene(string str)
    {
        SceneManager.LoadScene(str);
    }
}