using System;
using UnityEditor;
using UnityEngine;

namespace NumericalMethods
{
    public class TestInterpolation : MonoBehaviour
    {
        [SerializeField] private Point2D[] _points;
        [SerializeField] private double _min;
        [SerializeField] private double _max;
        [SerializeField, Min(1)] private int _segmentCount;
        [SerializeField] private double _x;

        [Header("Colors")] 
        [SerializeField] private Color _backgroundColor;


        private void OnValidate()
        {
            if (_x < _min)
            {
                _x = _min;
            }

            if (_x > _max)
            {
                _x = _max;
            }

            if (_min > _max)
            {
                _min = _max;
            }
        }

        private void OnDrawGizmos()
        {
            if (_points.Length < 2) return;
            
            var minY = double.PositiveInfinity;
            var maxY = double.NegativeInfinity;

            for (var i = 1; i < _segmentCount + 1; i++)
            {
                var prevT = Mathf.InverseLerp(0, _segmentCount, i - 1);
                var prevX = _min + (_max - _min) * prevT;
                var prevY = Interpolation.Lagrange(prevX, _points);
                var prevPosition = new Vector3((float) prevX, (float) prevY);

                if (prevY < minY)
                {
                    minY = prevY;
                }

                if (prevY > maxY)
                {
                    maxY = prevY;
                }
                
                var t = Mathf.InverseLerp(0, _segmentCount, i);
                var x = _min + (_max - _min) * t;
                var y = Interpolation.Lagrange(x, _points);
                var position = new Vector3((float) x, (float) y);

                if (y < minY)
                {
                    minY = y;
                }

                if (y > maxY)
                {
                    maxY = y;
                }

                var realPrevPosition = prevPosition;
                var realPosition = position;
                
                realPrevPosition.y = (float) Math.Log10(prevX);
                realPosition.y = (float) Math.Log10(x);
                
                Gizmos.color = Color.white;
                Gizmos.DrawLine(prevPosition, position);
                Gizmos.color = Color.blue;
                Gizmos.DrawLine(realPrevPosition, realPosition);
            }
            
            var evalY = Interpolation.Lagrange(_x, _points);
            var evalPosition = new Vector3((float) _x, (float) evalY);
            var width = (float) (_max - _min);
            var height = (float) (maxY - minY);

            if (_min < 0 && _max > 0)
            {
                Gizmos.color = Handles.xAxisColor;
                Gizmos.DrawLine(new Vector3((float) _min, 0f), new Vector3((float) _max, 0f));
            }

            if (minY < 0 && maxY > 0)
            {
                Gizmos.color = Handles.yAxisColor;
                Gizmos.DrawLine(new Vector3(0f, (float) minY), new Vector3(0f, (float) maxY));
            }
            
            Handles.DrawSolidRectangleWithOutline(new Rect((float) _min, (float) minY, width, height), _backgroundColor, _backgroundColor);
            Handles.color = Color.white;
            Handles.DrawSolidDisc(evalPosition, Vector3.forward, 0.2f);
        }
    }
}