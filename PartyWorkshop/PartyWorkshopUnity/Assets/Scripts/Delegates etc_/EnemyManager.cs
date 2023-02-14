using Newtonsoft.Json.Linq;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    public Enemy Emimem;

    private void OnEnable()
    {
        GameManager.OnMekGehmBuhlStettikk += SbaunEmimen;
    }

    private void OnDisable()
    {
        GameManager.OnMekGehmBuhlStettikk -= SbaunEmimen;
    }

    public bool SbaunEmimen()
    {
        Enemy emimem = Instantiate(Emimem, Vector3.zero, Quaternion.identity, transform);
        emimem.name = "Eminem";
        emimem.transform.position = new Vector3(-3, 0, 0);

        return true;
    }
}
