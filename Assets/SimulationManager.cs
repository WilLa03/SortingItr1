using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Profiling;

public class SimulationManager : MonoBehaviour
{
    [SerializeField] private CircleManager manager;
    [SerializeField] private TargetBehaviour target;
    [SerializeField] private Spawner spawner;
    private int ammoutOfUpdates;

    private void FixedUpdate()
    {
        float time = Time.realtimeSinceStartup;
        if (ammoutOfUpdates >=50)
        {
            manager.ResetAll();
            spawner.InstantiateCircles();
            ammoutOfUpdates = 0;
        }
        manager.DoUpdate();
        target.DoUpdate();
        ammoutOfUpdates++;
        float time1 = Time.realtimeSinceStartup;
        float finaltime = time1 - time;
        if (finaltime > 0.3f)
        {
            Debug.Log($"quit{manager.circles.Count}");
            Application.Quit();
        }
    }
}
