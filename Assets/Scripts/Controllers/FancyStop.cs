using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static System.Math;

namespace Stops{
    public class FancyStop
    {
        private float instantiationTime;
        public FancyStop(float instantiationTime)
        {
            this.instantiationTime = instantiationTime;
        }

        public float stopOhSoFancy(float time)
        {
            
            return (float)Sin(instantiationTime - time);
            
        }

    }
}