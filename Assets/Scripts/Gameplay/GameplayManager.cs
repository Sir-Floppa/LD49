using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameplayManager : MonoBehaviour
{

    [Header("Gestures")]
    public TouchManager GestureManager;

    [Header("Gameplay")]
    public GameObject Canvas;
    public GameObject PlaceToSpawn;
    public GameObject SelectedObject;
    public bool IsSelected = false;
    public ButtonsBugs SelectedBug;

    // Start is called before the first frame update
    void Start()
    {
        IsSelected = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(SelectedBug == ButtonsBugs.eachClickClone)
        {
            if (GestureManager.Touching && IsSelected && SelectedObject != null)
            {

                Vector2 pos;

                RectTransformUtility.ScreenPointToLocalPointInRectangle(
                                            Canvas.transform as RectTransform,
                                            Input.mousePosition,
                                            Canvas.GetComponent<Canvas>().worldCamera, out pos);


                SelectedObject.transform.position = Canvas.transform.TransformPoint(pos);
            }
        }
        else if(SelectedBug == ButtonsBugs.OnlyDraggable)
        {
            if (GestureManager.Touching && IsSelected && SelectedObject != null)
            {

                Vector2 pos;

                RectTransformUtility.ScreenPointToLocalPointInRectangle(
                                            Canvas.transform as RectTransform,
                                            Input.mousePosition,
                                            Canvas.GetComponent<Canvas>().worldCamera, out pos);


                SelectedObject.transform.position = Canvas.transform.TransformPoint(pos);
            }
        }
    }

    public void SelectOption(GameObject Selected, string option)
    {
        //GameObject GO = GameObject.Instantiate(Selected, Selected.GetComponent<RectTransform>());

        //GO.GetComponent<ButtonTrigger>().Actionable = false;

        //GO.transform.parent = PlaceToSpawn.transform;

        //GO.transform.localScale = new Vector3(1, 1, 1);

        //SelectedObject = GO;

        ////SelectedBug = Way;
        //IsSelected = true;


        if(option == "1")
        {
            DecisionActions.DecideBtn1();
        }
        else if(option == "2")
        {
            DecisionActions.DecideBtn2();
        }
        else if(option == "3")
        {
            DecisionActions.DecideBtn3();
        }
        else if(option == "4")
        {
            DecisionActions.DecideBtn4();
        }

    }


    [Header("Dialog Management")]
    public GameObject DialoguePanel;
    public GameObject DecisionsPanel;

    public void StartDialogue()
    {
        DialoguePanel.SetActive(true);
        DecisionsPanel.SetActive(false);
    }





    public Decision DecisionActions;

    [Header("Buttton Titles")]
    public Text ButtonTitle1;
    public Text ButtonTitle2;
    public Text ButtonTitle3;
    public Text ButtonTitle4;

    public void StartDecisionMenu(Decision deci, ActionMenu Btn1, ActionMenu Btn2, ActionMenu Btn3, ActionMenu Btn4)
    {
        DecisionsPanel.SetActive(true);
        DialoguePanel.SetActive(false);

        DecisionActions = deci;

        ButtonTitle1.text = Btn1.Title;
        ButtonTitle2.text = Btn2.Title;
        ButtonTitle3.text = Btn3.Title;
        ButtonTitle4.text = Btn4.Title;

        Debug.Log("BUTTON LIST: ");
        Debug.Log(ButtonTitle1.text);
        Debug.Log(ButtonTitle2.text);
        Debug.Log(ButtonTitle3.text);
        Debug.Log(ButtonTitle4.text);

    }
}

public enum ButtonsBugs
{
    Default,
    eachClickClone,
    OnlyDraggable,
}
