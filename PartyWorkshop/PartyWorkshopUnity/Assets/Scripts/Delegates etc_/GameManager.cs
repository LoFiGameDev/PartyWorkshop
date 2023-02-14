using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.Events;

public class GameManager : MonoBehaviour
{
    private static GameManager instance;
    public static GameManager Instance => instance;

    private void OnEnable()
    {
        if (!instance)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    // Im sorry for everyone who has to read this.

    public delegate void MekGehm();
    public delegate bool MekGehmBuhl();

    public event MekGehm OnMekGehm;
    public static event MekGehm OnMekGehmStettikk;
    public static event MekGehmBuhl OnMekGehmBuhlStettikk;

    public static Action<string> OnMekGehmAkschn;

    public UnityEvent SbaunEmimem;
    public UnityEvent<bool> SbaunEmimemBuhl;

    public Func<int, int> OnFunky;

    public void StartMekGehm()
    {
        OnMekGehm?.Invoke();
        OnMekGehmStettikk?.Invoke();
        OnMekGehmAkschn?.Invoke("Pleha");
        SbaunEmimemBuhl?.Invoke(true);
        OnFunky?.Invoke(5);

        if ((bool)(OnMekGehmBuhlStettikk?.Invoke()))
        {
            Debug.Log("Reb gohd");
        }
    }
}
