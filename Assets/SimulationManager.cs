using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using UnityEngine;
using UnityEngine.Profiling;
using UnityEngine.SceneManagement;

public class SimulationManager : MonoBehaviour
{
    [SerializeField] private CircleManager manager;
    [SerializeField] private TargetBehaviour target;
    [SerializeField] private Spawner spawner;
    [SerializeField] private string filePath;
    [SerializeField] private DoAllBool doAll;
    private int ammoutOfUpdates;
    private float finaltime;
    private List<float> times = new List<float>();
    private List<float> finaltimes= new List<float>();
    private List<float> circlesTotal= new List<float>();
    private int circles;

    private void Start()
    {
        circlesTotal.Add(spawner.AmountOfCircles);
        circles = spawner.AmountOfCircles;
    }

    private void Update()
    {
        float time = Time.realtimeSinceStartup;
        if (ammoutOfUpdates >=100)
        {
            circles += spawner.AdditionalBalls;
            spawner.InstantiateCircles();
            ammoutOfUpdates = 0;
            var temp = 0f;
            for (int i = 0; i < times.Count; i++)
            {
                temp += times[i];
            }
            finaltimes.Add(temp/times.Count);
            circlesTotal.Add(circles);
        }
        manager.DoUpdate();
        target.DoUpdate();
        ammoutOfUpdates++;
        float time1 = Time.realtimeSinceStartup;
        finaltime = time1 - time;
        times.Add(finaltime);
        if (finaltime > 0.1f)
        {
            Write(finaltimes, false);
            Write(circlesTotal, true);
            if (doAll.DoAll)
            {
                if (manager.sorting.enums.sortingType == Enums.SortingType.Insert)
                {
                    manager.sorting.enums.sortingType = Enums.SortingType.Bubble;
                    DoReset();
                }
                else if (manager.sorting.enums.sortingType == Enums.SortingType.Bubble)
                {
                    manager.sorting.enums.sortingType = Enums.SortingType.Merge;
                    DoReset();
                }
                else if (manager.sorting.enums.sortingType == Enums.SortingType.Merge)
                {
                    doAll.DoAll = false;
                }
            }
            if (!doAll.DoAll)
            {
                DoReset();
                Debug.Log(Time.realtimeSinceStartup);
                SceneManager.LoadScene(0);
            }
            
        }
    }

    private void DoReset()
    {
        manager.ResetAll();
        times.Clear();
        finaltimes.Clear();
        circlesTotal.Clear();
    }
    private void OnDisable()
    {
        Write(finaltimes, false);
        Write(circlesTotal, true);
    }

    private void Write(List<float> list, bool ballnr)
    {
        var path = filePath;
        if (!ballnr)
        {
            path = path + Enum.GetName(typeof(Enums.SortingType), manager.sorting.enums.sortingType)+ ".txt";
        }
        else
        {
            path = path + "Number Of Balls" + Enum.GetName(typeof(Enums.SortingType), manager.sorting.enums.sortingType)+ ".txt";
        }
        

        using (StreamWriter writer = new StreamWriter(path))
        {
            if (!ballnr)
            {
                writer.Write(Enum.GetName(typeof(Enums.SortingType), manager.sorting.enums.sortingType) + ";");
            }
            else
            {
                writer.Write( "Number Of Balls"+ Enum.GetName(typeof(Enums.SortingType), manager.sorting.enums.sortingType)+ ";");
            }
            for (int i = 0; i < list.Count; i++)
            {
                var temp = Decimal.Parse(list[i].ToString(),
                    NumberStyles.AllowExponent | NumberStyles.AllowDecimalPoint);
                writer.Write(temp + ";");
            }
        }
    }
}
