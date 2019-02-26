using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ChangeScene : MonoBehaviour
{
    public string Scene;
    private Button Changer;
    public void Change()
    {
        SceneManager.LoadScene(Scene);
    }
}
