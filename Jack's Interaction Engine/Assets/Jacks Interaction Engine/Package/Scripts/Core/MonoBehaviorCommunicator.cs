using UnityEngine;
using UnityEngine.InputSystem;

namespace JacksInteractions.Core
{
    /// <summary>
    /// Communicates when specific event functions fire.
    /// </summary>
    public class MonoBehaviorCommunicator : MonoBehaviour
    {
        #region Variables

        public event EventFunctionCallback BeforeUpdate;
        public event EventFunctionCallback DuringUpdate;
        public event EventFunctionCallback AfterUpdate;
        public delegate void EventFunctionCallback();

        #endregion

        private void Start()
        {
            if (FindObjectsOfType<MonoBehaviorCommunicator>().Length > 1)
                gameObject.SetActive(false);
        }

        private void OnEnable()
        {
            InputSystem.onBeforeUpdate += BeforeUpdateCallback;
            InputSystem.onAfterUpdate += AfterUpdateCallback;
        }

        private void OnDisable()
        {
            InputSystem.onBeforeUpdate -= BeforeUpdateCallback;
            InputSystem.onAfterUpdate -= AfterUpdateCallback;
        }

        private void BeforeUpdateCallback()
            => BeforeUpdate?.Invoke();
        
        private void Update()
            => DuringUpdate?.Invoke();

        private void AfterUpdateCallback()
            => AfterUpdate?.Invoke();
    }
}
