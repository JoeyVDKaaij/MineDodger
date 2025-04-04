using System;
using UnityEngine;

public class ParentManager : MonoBehaviour
{
    private static ParentManager _instance;
    
    private void Awake()
    {
        if (_instance == null)
        {
            DontDestroyOnLoad(gameObject);
            _instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }
}