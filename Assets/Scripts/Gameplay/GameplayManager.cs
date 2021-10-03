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

    // Start is called before the first frame update
    void Start()
    {
        IsSelected = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (IsSelected)
        {

            Vector2 pos;

            RectTransformUtility.ScreenPointToLocalPointInRectangle(
                                        Canvas.transform as RectTransform, 
                                        Input.mousePosition, 
                                        Canvas.GetComponent<Canvas>().worldCamera, out pos);
            SelectedObject.transform.position = Canvas.transform.TransformPoint(pos);
        }
        else { 
        }
    }

    public void SelectOption(GameObject Selected)
    {

        GameObject GO = GameObject.Instantiate(Selected);

        GO.transform.parent = Canvas.transform;

        SelectedObject = GO;

        IsSelected = true;
    }
}
