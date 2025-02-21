
using UnityEngine;

namespace TestTask.UI
{
    public abstract class ScreenParameters
    {
    }

    public abstract class ScreenBase : MonoBehaviour
    {
        public virtual void Show(ScreenParameters parameters)
        {
        }

        public virtual void Hide()
        {
            Destroy(gameObject);
        }
    }
}
