using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameplayManager : MonoBehaviour
{

    [Header("Gestures")]
    public TouchManager GestureManager;

    [Header("Gameplay")]
    public GameObject Canvas;
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

    public void SelectOption(GameObject Selected, ButtonsBugs Way)
    {

        GameObject GO = GameObject.Instantiate(Selected);

        GO.transform.parent = Canvas.transform;

        GO.transform.localScale = new Vector3(1, 1, 1);

        SelectedObject = GO;

        SelectedBug = Way;
        IsSelected = true;
    }
}

public enum ButtonsBugs
{
    stucked,
    eachClickClone,
    OnlyDraggable
}
