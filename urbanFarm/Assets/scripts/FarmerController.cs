﻿using System.Collections;
using UnityEngine;

[RequireComponent(typeof(PlayerMotor))]
public class FarmerController : MonoBehaviour {

    public LayerMask movement;

    Camera cam;
    PlayerMotor motor;

    bool enablePlant;

    public GameObject[] plotList;

    GameObject plot;

	void Start () {
        cam = Camera.main;
        motor = GetComponent<PlayerMotor>();

        enablePlant = false;
	}
	
	void Update () {
		
        if (Input.GetMouseButtonDown(0))
        {
            Ray rayo = cam.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(rayo, out hit, 100, movement))
            {
                motor.MoveToPoint(hit.point);
            }
        }

        if (Input.GetKeyDown(KeyCode.P))
        {
            // Send message to plot to get the seed going!
            plot.GetComponent<Renderer>().material.color = Color.red;
            Inventory.UseSeed();
        }

    }

    void OnTriggerEnter(Collider c)
    {
        if (c.gameObject.tag == "GameController")
        {
            Inventory.PickSeeds(3);
        }

        if (c.gameObject.name == "Plot")
        {
            plot = c.gameObject;
        }

        if (c.gameObject.name == "Door")
        {
            // Fadeout
            // 
        }
    }

    void OnTriggerExit(Collider c)
    {
        if (c.gameObject.name == "Plot")
        {
            enablePlant = false;
        }
    }
}
