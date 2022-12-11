using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Controls;

public class Patient : MonoBehaviour
{

    public float maxMedicine = 100;
    public float minMedicine = 0;
    public float currentMedicine;
    public float _canDose = 0f;
    public float _doseRate = 1f;
    public static event Action OnMedZero;

    public MedBar medBar;

    // Start is called before the first frame update
    void Start()
    {
        currentMedicine = maxMedicine;
        medBar.SetMaxMedicine(maxMedicine);
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetAxis("Vertical") < -0.8 && Time.time > _canDose)
        {
            TakeDose(2);
            Debug.Log("Greater than 0.8");
        }

        else if (Input.GetAxis("Vertical") < 0 && Time.time > _canDose)
        {
            TakeDose(1);
            Debug.Log("Greater than 0");
        }

        if (currentMedicine <= 0)
        {
            currentMedicine = 0;
            Debug.Log("Simulation has ended");
            OnMedZero?.Invoke();
        }

        currentMedicine = Mathf.Clamp(currentMedicine, 0, 100);
    }

    void TakeDose(float dose)
    {
        _canDose = Time.time + _doseRate;
        currentMedicine -= dose;

        medBar.SetMedicine(currentMedicine);
    }

}
