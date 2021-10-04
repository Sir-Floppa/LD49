using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveImage : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float newXpos = 0.75f * Mathf.Sin(0.25f * Time.realtimeSinceStartup) + 2;
        gameObject.transform.position = new Vector3(newXpos, -0.75f, 0);
    }
}
