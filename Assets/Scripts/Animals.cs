using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Animals
{
    public string name;
    public GameObject animal;
    public GameObject[] food;
    [Space(100)]
    public int size;
    public bool active;
}