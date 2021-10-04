using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Decision : MonoBehaviour
{

    public abstract void DecideBtn1();

    public abstract void DecideBtn2();

    public abstract void DecideBtn3();

    public abstract void DecideBtn4();

    public abstract void StartThis();

    public abstract void Updatethis();

    public abstract void FixedUpdateThis();

    // Start is called before the first frame update
    void Start()
    {
        StartThis();
    }

    // Update is called once per frame
    void Update()
    {
        Updatethis();
    }

    void FixedUpdate()
    {
        FixedUpdateThis();
    }
}
