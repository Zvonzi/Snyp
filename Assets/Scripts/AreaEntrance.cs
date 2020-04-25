using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AreaEntrance : MonoBehaviour
{ 
    void Start()
        {
            var transitionName = transform.parent.GetComponent<AreaExit>().areaTransitionName;

            if (transitionName == PlayerController.instance.areaTransitionName)
            {
                PlayerController.instance.transform.position = transform.position;
            }
    }
}
