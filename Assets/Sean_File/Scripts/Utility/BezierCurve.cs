using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Utility
{
    public class BezierCurve
    {
   public static Vector3 QuadraticPoint(Vector3 _startPoint,Vector3 _endPoint,Vector3 _controlPoint,float _by)
        {
            return Vector3.Lerp(
                Vector3.Lerp(_startPoint, _controlPoint, _by),
                Vector3.Lerp(_controlPoint, _endPoint, _by),
                _by);
        }
    }
}