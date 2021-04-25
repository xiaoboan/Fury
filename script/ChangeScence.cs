using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeScence : MonoBehaviour
{
    private float duration=42.0f;
    public static string loadName="test4";
    // Start is called before the first frame update
    void Start()
    {
        Invoke("Change", duration);
    }
    private void Change()
    {
        Application.LoadLevelAsync(loadName);
    }
    
}
