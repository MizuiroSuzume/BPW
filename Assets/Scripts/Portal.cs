using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Portal : MonoBehaviour
    
{
    public GameObject RedPortal;
    public GameObject Blueportal;

    private void Update()
    {
        if (Blueportal == true)
        {
            RedPortal.SetActive(false);
        }
    }
    void OnTriggerEnter()
    {
        GameManager.instance.Win();
    }
}
