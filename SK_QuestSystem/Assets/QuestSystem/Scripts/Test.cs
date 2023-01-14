using System.Collections;
using UnityEngine;

public class Test : MonoBehaviour
{
    private void Start()
    {
        Bla bla1 = null;
        Queue bla2 = null;
        Compare(bla1, bla2);
    }

    private void Compare(object value1, object value2)
    {
        var check1 = value1 is Bla;
        var check2 = value2 is Bla;
    }

    private class Bla
    {
        
    }
}
