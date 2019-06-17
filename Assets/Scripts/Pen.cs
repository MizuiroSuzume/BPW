using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pen : MonoBehaviour
{
    public GameObject[] Fences = new GameObject[2];
    public int cip = 0;

    // Start is called before the first frame update
    void Start()
    {
        foreach (GameObject Fence in Fences)
        {
            Fence.SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (cip == 10)
        {
            if (!Fences[0].activeSelf)
            {
                Debug.Log("test");

                foreach (GameObject Fence in Fences)
                {
                    Fence.SetActive(true);
                }
            }
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Kip")
            //cip == chicken in pen
        {
            cip += 1;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Kip")
        {
            cip += -1;
        }
    }
}
