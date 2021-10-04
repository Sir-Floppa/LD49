using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonTrigger : MonoBehaviour
{

    public GameplayManager GpM;
    //public ButtonsBugs Bug;
    //public string Action;

    public bool Actionable = true;

    public void SelectOption(string option)
    {
        if(Actionable)
        GpM.SelectOption(this.gameObject, option);
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
