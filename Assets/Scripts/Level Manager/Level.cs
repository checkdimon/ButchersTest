using UnityEngine;

namespace TestTask
{
    public class Level : MonoBehaviour
    {
        [SerializeField] private Transform playerSpawnPoint;
        [SerializeField] private LevelPath path;

        public static Level Current { get; private set; }
        public LevelPath Path => path;

        private void Awake()
        {
            Current = this;
        }

        private void OnDestroy()
        {
            if (Current == null)
            {
                Current = null;
            }
        }

#if UNITY_EDITOR
        private void OnDrawGizmos()
    {
        if (playerSpawnPoint != null)
        {
            Gizmos.color = Color.magenta;
            var m = Gizmos.matrix;
            Gizmos.matrix = playerSpawnPoint.localToWorldMatrix;
            Gizmos.DrawSphere(Vector3.up * 0.5f + Vector3.forward, 0.5f);
            Gizmos.DrawCube(Vector3.up * 0.5f, Vector3.one);
            Gizmos.matrix = m;
        }
    }
#endif
    }
}