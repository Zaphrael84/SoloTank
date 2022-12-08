using System;
using System.Collections;
using System.Collections.Generic;using System.Runtime.CompilerServices;
using UnityEngine;

public class Tank : Base_Controller
  

{[SerializeField] private float Speed = 0.02f;
    [SerializeField] private float RotationSpeed = 0.02f;
    private bool IsBoosted = false;
    private void Update()
    {
        if (Input.GetKey(KeyCode.Z))
        {
            transform.Translate(0f, 0f, Speed);
        }

        if (Input.GetKey(KeyCode.S))
        {
            transform.Translate(0f, 0f, -Speed);
        }

        if (Input.GetKey(KeyCode.Q))
        {
            transform.Rotate(0f, -RotationSpeed, 0f);
        }

        if (Input.GetKey(KeyCode.D))
        {
            transform.Rotate(0f, RotationSpeed, 0f);
        }
        AimToTarget();
        if (Input.GetMouseButtonDown(0))
        {
            Fire();
        }
    }

    private void AimToTarget()
    {
        Ray tempRay = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        if (Physics.Raycast(tempRay, out hit))
        {
            RotateToTarget(hit.point);
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("SpeedBoost") && !IsBoosted)
        {
            IsBoosted = true;
            StartCoroutine(Boost());
        }
    }

    IEnumerator Boost()
    {
        float tempSpeed = Speed;
        Speed = 0.07f;
        yield return new WaitForSeconds(3f);
        Speed = tempSpeed;

    }
}
