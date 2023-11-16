using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimulationManager : MonoBehaviour
{
    [SerializeField] private CircleManager manager;
    [SerializeField] private TargetBehaviour target;
    void Update()
    {
        //TODO uppdatera alla updates och hålla koll på tiden mellan uppdateringar
        //Time.realtimeSinceStartup
        //ska spara hur många updates som gjort och gå till nästa iteration när de är gjorda 
    }

    private void FixedUpdate()
    {
        manager.DoUpdate();
        target.DoUpdate();
    }
}
