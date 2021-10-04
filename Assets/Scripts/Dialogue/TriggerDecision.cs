using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Events;
using UnityEngine.UI;

public class TriggerDecision : MonoBehaviour
{

    public GameplayManager GM;

    public ActionMenu Button1;
    public ActionMenu Button2;
    public ActionMenu Button3;
    public ActionMenu Button4;

    public Decision decision;

    public void StartDecition()
    {
        GM.StartDecisionMenu(decision ,Button1, Button2, Button3, Button4);
    }

    // Start is called before the first frame update
    void Start()
    {
        decision = GetComponent<Decision>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

[System.Serializable]
public class ActionMenu {
    public string Title;
    public string Description;
}
