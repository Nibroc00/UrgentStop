using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public sealed class Controller
{
    // Controller is a singleton object, meaning there can only be one of it
    // call Controller.Instance to get the Controller
    public Controller() { }
    private static Controller instance = null;
    //public static Controller Instance
    //{
    //    get
    //    {
    //        if (instance == null)
    //        {

    //            instance =  new Controller();
    //        }
    //        return instance;
    //    }
    //}

    /// <summary>
    /// This variable mimics the signal sent via radio waves to Zombi. 
    /// It must be a value between -1 and 1. 
    /// </summary>
    //private float speed = 1;
    private delegate float SomeSpeedCalculator(float timedelta);
    private SomeSpeedCalculator currentCalculator = delegate (float time) { return 1f; }; // simply keeps Zombi at top speed. 
    public float Speed
    {
        get { return currentCalculator(Time.time); }
    }

    // Responsible from switching from a "go" order of 1, 
    // to some stopping strategy
    public void activate(float time)
    {
        Stops.UrgentStop urgentStop = new Stops.UrgentStop(time);
        this.currentCalculator = urgentStop.Stop;
        // Stops.TrentsStop trentStop = new Stops.TrentsStop();
        // this.currentCalculator = trentStop.makeItStop;
        // Stops.LinearStop linearStop = new Stops.LinearStop(time);
        // this.currentCalculator = linearStop.stopLinearily;
        // Stops.FancyStop fancyStop = new Stops.FancyStop(time);
        // this.currentCalculator = fancyStop.stopOhSoFancy;

    }

    // delete later
    public float arbitraryTime = 5f;
    bool hasBeenCalled = false;
    
    public void Update(float time)
    {
        
    }

}
