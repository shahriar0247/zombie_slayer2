using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class menu_play : MonoBehaviour
{
   
    public void play_offline(int level)
    {
       SceneManager.LoadScene(level);
    }
}
