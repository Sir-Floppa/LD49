using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonTrigger : MonoBehaviour
{

    public GameplayManager GpM;
    public ButtonsBugs Bug;

    public void SelectOption()
    {
        GpM.SelectOption(this.gameObject, Bug);
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
