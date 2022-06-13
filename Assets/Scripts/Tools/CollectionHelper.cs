using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectionHelper
{ 
    public static bool IsInList<T>(List<T> list,int index)
    {
        return index >= 0 && index < list.Count;
    }
}
