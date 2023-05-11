using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CompanionCount : MonoBehaviour
{
    public TextMeshProUGUI companionCountText;
    private List<AIStateController> companions = new List<AIStateController> ();


    private void OnTriggerEnter(Collider collision)
    {
        if (!companions.Contains(collision.gameObject.GetComponent<AIStateController>()))
        {
            if (collision.gameObject.TryGetComponent<AIStateController>(out AIStateController aIState))
            {
                companions.Add(aIState);
                aIState.TransitionToState(aIState.companionState);

                //Updating the UI TMP
                companionCountText.text = string.Format("{0:n0}", companions.Count);
            }
        }
    }

    public void RemoveSelfFromList(AIStateController toRemove)
    {
        companions.Remove(toRemove);

        //Updating the UI TMP
        companionCountText.text = string.Format("{0:n0}", companions.Count);
    }
}
