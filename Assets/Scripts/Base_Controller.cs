using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Base_Controller : MonoBehaviour
{
    [SerializeField] private GameObject BulletPrefab;
    [SerializeField] protected Transform BulletSpawnPosition;
    [SerializeField] private GameObject TurretHead;
    [SerializeField] private Transform temp;
    [SerializeField] private bool IsAlreadyFiring = false;


    protected void Fire()
    {
        if (!IsAlreadyFiring)
        {
            IsAlreadyFiring = true;
            StartCoroutine(fireDelay());
        }
    }

    IEnumerator fireDelay()
    {
        Instantiate(BulletPrefab, BulletSpawnPosition.position, BulletSpawnPosition.rotation);
        yield return new WaitForSeconds(2f);
        IsAlreadyFiring = false;
    }
    protected void RotateToTarget(Vector3 targetPos)
    {
        temp.position = new Vector3(targetPos.x, TurretHead.transform.position.y, targetPos.z);
        TurretHead.transform.LookAt(temp);
    }
}
