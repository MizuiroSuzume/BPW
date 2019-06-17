using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Cip_Score : MonoBehaviour
{
    public Text scoreText;
    public Pen Pen;

    // Update is called once per frame
    void Update()
    {
        scoreText.text = Pen.cip.ToString();
    }
}
