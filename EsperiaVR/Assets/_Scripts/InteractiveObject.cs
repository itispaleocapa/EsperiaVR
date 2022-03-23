using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class InteractiveObject : MonoBehaviour {

    public bool interactionEnabled = true;
    public float maxGazeTime = 1;
    [Range(0.0f, 100.0f)]
    public float distance = 3;

    private EventTrigger myTrigger;
    private bool isGazedAt=false;
    private float timer = 0;

	// Use this for initialization
	void Start () {
        myTrigger = gameObject.GetComponent<EventTrigger>();
        if(myTrigger == null)
        {
            myTrigger = gameObject.AddComponent<EventTrigger>();
        }

        EventTrigger.Entry entryPointerEnter = new EventTrigger.Entry();
        entryPointerEnter.eventID = EventTriggerType.PointerEnter;
        entryPointerEnter.callback.AddListener((eventData) => { OnPointerEnter(); });
        myTrigger.triggers.Add(entryPointerEnter);

        EventTrigger.Entry entryPointerExit = new EventTrigger.Entry();
        entryPointerExit.eventID = EventTriggerType.PointerExit;
        entryPointerExit.callback.AddListener((eventData) => { OnPointerExit(); });
        myTrigger.triggers.Add(entryPointerExit);

        EventTrigger.Entry entryPointerDown = new EventTrigger.Entry();
        entryPointerDown.eventID = EventTriggerType.PointerDown;
        entryPointerDown.callback.AddListener((eventData) => { OnPointerDown(); });
        myTrigger.triggers.Add(entryPointerDown);
    }

    private void OnPointerEnter()
    {
        isGazedAt = true;
    }

    private void OnPointerExit()
    {
        isGazedAt = false;
    }

    private void OnPointerDown()
    {
        timer = 0f;
    }

    void Update()
    {
        if (!interactionEnabled) return;

        if (isGazedAt)
        {
            timer += Time.deltaTime;

            if(timer>maxGazeTime)
            {
                timer = 0f;
                ExecuteEvents.Execute(gameObject, new PointerEventData(EventSystem.current), ExecuteEvents.pointerDownHandler);
                ExecuteEvents.Execute(gameObject, new PointerEventData(EventSystem.current), ExecuteEvents.pointerUpHandler);
            }
        }
        else
        {
            timer = 0f;
        }
    }

}
