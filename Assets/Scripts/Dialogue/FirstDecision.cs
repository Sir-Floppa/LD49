using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirstDecision : Decision
{
    public DialogueTrigger fstOpTrigger;
    public DialogueTrigger secOpTrigger;
    public DialogueTrigger trdOpTrigger;
    public DialogueTrigger frtOpTrigger;

    public override void DecideBtn1()
    {
        fstOpTrigger.TriggerDialogue();
    }

    public override void DecideBtn2()
    {
        secOpTrigger.TriggerDialogue();
    }

    public override void DecideBtn3()
    {
        trdOpTrigger.TriggerDialogue();
    }
    public override void DecideBtn4()
    {
        frtOpTrigger.TriggerDialogue();
    }

    public override void StartThis()
    {

    }

    public override void Updatethis()
    {
        
    }

    public override void FixedUpdateThis()
    {
        
    }

}
