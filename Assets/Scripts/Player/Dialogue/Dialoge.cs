using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Dialoge
{
    public int index; //index of the dialoge
    public string name; //name for the dialoge
    [TextArea(3, 10)]
    public string[] sentences; //dialoge sentences
}
