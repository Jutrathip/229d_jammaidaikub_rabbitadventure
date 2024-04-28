using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

public class DataManagement : MonoBehaviour
{
    public static DataManagement dataManagement;

    public int hightScore;

    void Awake()
    {
        if (dataManagement == null) 
        { 
            DontDestroyOnLoad(gameObject);
            dataManagement = this;
        }
        else if (dataManagement == null) 
        {
            Destroy(gameObject);
        
        }
    }
}
