using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RupeeCounter : MonoBehaviour
{
    [SerializeField] private Text text;
    [SerializeField] private int rupees = 4;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            AddRupee(1);
        }

        if (Input.GetKeyDown(KeyCode.E))
        {
            RemoveRupee(1);
        }
    }

    private void AddRupee(int rupeeAmount)
    {
        if (rupees <= 98)
        {
            rupees = rupees + rupeeAmount;
            text.text = "0" + rupees.ToString();
        }
    }

    private void RemoveRupee(int rupeeAmount)
    {
        if(rupees > 0)
        {
            rupees = rupees - rupeeAmount;
            text.text = "0" + rupees.ToString();
        }
    }
}
