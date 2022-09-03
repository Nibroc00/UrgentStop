using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Stops{
    public class LinearStop
    {

        private float instantiationTime;
        public LinearStop(float instantiationTime)
        {
            this.instantiationTime = instantiationTime;
        }

        public float stopLinearily(float time)
        {
            // y = -1   x     + 1
            float y = -1 * (time - instantiationTime) + 1;
            if (y < 0)
                return 0;
            else
                return y;
        }

    }
}