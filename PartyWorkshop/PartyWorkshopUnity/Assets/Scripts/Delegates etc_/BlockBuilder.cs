using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockBuilder : MonoBehaviour
{
    private void OnEnable()
    {
        GameManager.OnMekGehmStettikk += MekBlocc;
    }

    private void OnDisable()
    {
        GameManager.OnMekGehmStettikk -= MekBlocc;
    }

    public void MekBlocc()
    {
        Vector3 pos = Random.insideUnitSphere * 3;

        if (pos.y < 0) pos.y *= -1;

        GameObject blocc = GameObject.CreatePrimitive(PrimitiveType.Cube);
        blocc.name = "Blocc";
        blocc.transform.position = pos;
        blocc.transform.localScale = new Vector3(Random.value * 5, Random.value * 5, Random.value * 5); // Hardcoden ist tol
    }
}
