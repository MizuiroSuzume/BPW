using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance = null;
    public GameObject WinText;
    public GameObject blur;

    private void Awake()
    {
        if (instance == null)
            instance = this;
        else if (instance != null)
            Destroy (gameObject);
    }

    public void Win()
    {
        WinText.SetActive (true);
        blur.SetActive(true);
    }
}
