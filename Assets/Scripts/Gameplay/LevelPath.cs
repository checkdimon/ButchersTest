
using UnityEngine;

namespace TestTask
{
    public class LevelPath : MonoBehaviour
    {
        private Vector3[] points;
        private int currentPointIndex = -1;

        private void Start()
        {
            points = new Vector3[transform.childCount];
            for (var i = 0; i < transform.childCount; i++)
            {
                points[i] = transform.GetChild(i).position;
            }
        }

        public Vector3 GetNextPoint()
        {
            currentPointIndex++;
            return points[currentPointIndex];
        }

#if UNITY_EDITOR
        private void OnDrawGizmos()
        {
            Gizmos.color = Color.yellow;
            for (var i = 0; i < transform.childCount; i++)
            {
                var point = transform.GetChild(i);
                Gizmos.DrawSphere(point.position, 0.5f);

                if (i > 0)
                {
                    var prevPoint = transform.GetChild(i - 1);
                    Gizmos.DrawLine(prevPoint.position, point.position);
                }
            }
        }
#endif
    }
}
