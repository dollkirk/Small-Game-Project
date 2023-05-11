using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.AI;

public class WindStateController : MonoBehaviour
{
    //Wind timer variables
    [Header("Timer")]
    [Range(0.01f, 60)]
    public float givenTimeCountDown;
    private float timeCountDown;
    public TextMeshProUGUI CountText;


    //Moving objects by wind variables
    [Header("Wind")]
    public ObjectsAffectedByWind[] objs;
    public float windSpeed = 5f;
    private int windDirection;


    //Changing state variables
    private WindState currentState;
    public readonly WindOffState offState = new WindOffState();
    public readonly WindOnState onState = new WindOnState();


    // Start is called before the first frame update
    void Start()
    {
        TransitionToState(offState);
        windDirection = 1;
    }




    void Update()
    {
        currentState.UpdateState(this);
        //Countdown when WindOn
        if (timeCountDown > 0)
        {
            timeCountDown -= Time.deltaTime;
        }
        CountText.text = string.Format("{0:n0}", timeCountDown);
        if (timeCountDown < 0)
        {
            if (currentState == onState)
            {
                Debug.Log("Checking");
                onState.Destroyed(offState, this);
                offState.UpdateState(this);
            }
            offState.Destroyed(onState, this);
            onState.UpdateState(this);
            timeCountDown = 5;
        }
    }




    //Triggers the windOn state
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Debug.Log("Colliding");
            if (currentState == offState)
            {
                Debug.Log("Checking");
                timeCountDown = givenTimeCountDown;
                offState.Destroyed(onState, this);
                onState.UpdateState(this);
            }
        }
    }




    //Applies wind force
    public void ApplyForce()
    {
        foreach (var item in objs)
        {
            //rb.AddForce(windDirection * windSpeed, 0, 0, ForceMode.Force);
            if (windDirection > 0)
            {
                item.rb.AddForce(windDirection * windSpeed, 0, 0, ForceMode.Force);
                
            }
            else 
            {
                item.rb.AddForce(windDirection * windSpeed, 0, 0, ForceMode.Force);
            }
        }
    }




    public void TransitionToState(WindState state)
    {
        currentState = state;
        currentState.EnterState(this);
    }
}
