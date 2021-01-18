using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIRupee : MonoBehaviour
{
    public Text text;
    [SerializeField] private int rupees = 4;

    private void Start()
    {
        UpdateRupeeUI();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            RemoveRupee(1);
        }

        if (Input.GetKeyDown(KeyCode.E))
        {
            AddRupee(1);
        }
    }

    private void AddRupee(int rupeeAmount)
    {
        if (rupees <= 98)
        {
            rupees = rupees + rupeeAmount;
            UpdateRupeeUI();
        }
    }

    private void RemoveRupee(int rupeeAmount)
    {
        if(rupees > 0)
        {
            rupees = rupees - rupeeAmount;
            UpdateRupeeUI();
        }
    }

    private void UpdateRupeeUI()
    {
        text.text = "0" + rupees.ToString();
    }
}
