using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TerrainBuilder : MonoBehaviour
{
    private void OnEnable()
    {
        GameManager.Instance.OnMekGehm += MekPlehn;
        //GameManager.Instance.OnMekGehm += () => Debug.Log("Hallo"); // Böse
    }

    private void OnDisable()
    {
        GameManager.Instance.OnMekGehm -= MekPlehn;
        //GameManager.Instance.OnMekGehm -= () => Debug.Log("Hallo"); // Nicht machen
    }

    public void MekPlehn()
    {
        GameObject plehn = GameObject.CreatePrimitive(PrimitiveType.Plane);
        plehn.name = "plehn";
        plehn.transform.position = new Vector3(0, -2, 0);
        plehn.transform.localScale = new Vector3(50, 1, 50);
    }
}
