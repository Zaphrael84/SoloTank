using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turret : Base_Controller
{
    [SerializeField] private GameObject TurretTarget;
    [SerializeField] private float DetectionRange = 10f;
        

    private void Update()
    {
        RotateToTarget(TurretTarget.transform.position);
        if (CheckTargetDistance()) ;
        {
            Fire();
        }
    }

    private bool CheckTargetDistance()
    {
        RaycastHit hit;
        if (Physics.Raycast(BulletSpawnPosition.position,BulletSpawnPosition.up, out hit, DetectionRange))
        {
            return true;
        }
        
        return false;
    }
}
