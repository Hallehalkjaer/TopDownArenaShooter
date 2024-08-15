using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class AgentInput : MonoBehaviour, IAgentInput

{

    private Camera mainCamera;

    [NonSerialized]
    protected bool FireButtonHeld;

    //private bool fireButtonHeld = false;

    //public bool FireButtonHeld
    //{
    //    get { return fireButtonHeld; }
    //    set { fireButtonHeld = value; }
    //}


    [field: SerializeField]
    public UnityEvent<Vector2> OnMovmentKeyPressed { get; set; }

    [field: SerializeField]
    public UnityEvent<Vector3> OnPointerPositionChange { get; set; }

    [field: SerializeField]
    public UnityEvent OnFireButtonHeld { get; set; }

    [field: SerializeField]
    public UnityEvent OnFireButtonReleased { get; set; }

    private void Awake()
    {
        mainCamera = Camera.main;
    }

    private void Update()
    {
        GetMovementInput();
        GetPointerInput();
        GetFireInput();
    }

    private void GetFireInput()
    {
        //FireButtonHeld = false;
        if (Input.GetAxisRaw("Fire1") > 0)
        {

            if (!FireButtonHeld)
            {
                FireButtonHeld = true;
                OnFireButtonHeld?.Invoke();
            }
        }
        else
        {
            if (FireButtonHeld)
            {
                FireButtonHeld = false;
                OnFireButtonReleased?.Invoke();
            }

        }
    }

    private void GetPointerInput()
    {
        var pointerInWorldSpace = mainCamera.ScreenToWorldPoint(Input.mousePosition);
        OnPointerPositionChange?.Invoke(pointerInWorldSpace);
    }

    private void GetMovementInput()
    {
        OnMovmentKeyPressed?.Invoke(new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical")));
       
    }
}
