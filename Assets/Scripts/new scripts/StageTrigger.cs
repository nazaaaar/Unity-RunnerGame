using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageTrigger : MonoBehaviour
{
    public event EventHandler OnStageAchieved;

    private void OnTriggerEnter(Collider other)
    {
        OnStageAchieved.Invoke(this, EventArgs.Empty);
        Destroy(gameObject);
    }
}
