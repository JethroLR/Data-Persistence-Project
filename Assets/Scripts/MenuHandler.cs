using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
#if UNITY_EDITOR
using UnityEditor;
#endif


[DefaultExecutionOrder(1000)]
public class MenuHandler : MonoBehaviour
{
    public void StartGame() {
        SceneManager.LoadScene(1);
    }

    public void TextChanged(string inputText) {
        Debug.Log($"MenuHandler - TextChanged {inputText}");
        GameManger.Instance.PlayerName = inputText;
    }
 }
