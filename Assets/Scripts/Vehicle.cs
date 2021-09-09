using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO.Ports;
using UnityEngine.UI;

public class Vehicle : MonoBehaviour
{
    [SerializeField]
    private Text text;
    private SerialPort serialPotenciometro;
    [SerializeField]
    private Rigidbody rigidBody = null;
    [SerializeField]
    GameObject point = null;

    private Vector3 direction;

    [SerializeField]
    private float raio = 0f, angulo = 0f;

    private bool moving = false;

    private void Start()
    {
        serialPotenciometro = new SerialPort();
        serialPotenciometro.PortName = "COM6";
        serialPotenciometro.BaudRate = 9600;
        serialPotenciometro.Open();
        angulo = Mathf.Deg2Rad * PotenciometroParaGrau(float.Parse(serialPotenciometro.ReadLine()));
        serialPotenciometro.Close();
    }

    // Update is called once per frame
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.H))
        {
            Debug.Log("Foi");
            moving = !moving;
        }
        if (serialPotenciometro.IsOpen)
        {
            angulo = PotenciometroParaGrau(float.Parse(serialPotenciometro.ReadLine()));
            text.text = ((int) angulo).ToString();
            if (Input.GetKeyDown(KeyCode.E))
            {
                serialPotenciometro.Close();
            }
        }
        else
        {
            if (Input.GetKeyDown(KeyCode.R))
            {
                serialPotenciometro.Open();
            }
        }
        //Steer();
        direction = GetDirection();
        transform.eulerAngles = new Vector3(transform.rotation.x, angulo, transform.rotation.z);
    }

    private float PotenciometroParaGrau(float value)
    {
        float percentage = value / 1023;
        return percentage * 360;
    }

    private void FixedUpdate()
    {
        if (moving)
        {
            transform.position += direction * 30 * Time.deltaTime;
        }
    }

    private Vector3 GetDirection()
    {
        Vector3 dir = (point.transform.position - transform.position).normalized;
        return dir;
    }
}
