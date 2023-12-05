using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Enemy
{
    public static class StaticHelper
    {
        public static Vector3 GetDirection(Vector3 curPos)
        {
            float xVal = 0;
            if (curPos.x > 0)
            {
                xVal = -1;
            }
            else
            {
                xVal = 1;
            }

            Vector3 dir = new Vector3(xVal, 0f, 0f);
            return dir;
        }
    }
}
