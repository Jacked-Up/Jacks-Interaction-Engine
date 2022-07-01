using JacksInteractions.Core;
using UnityEngine;

namespace JacksInteractions
{
    public static class Initializer
    {
        #region Variables

        public static MonoBehaviorCommunicator MonoBehaviorComm { get; private set; }

        #endregion

        [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSceneLoad)]
        private static void BeforeSceneLoadCallback()
        {
            var parentObject = new GameObject("Jack's Interaction Engine");
            Object.DontDestroyOnLoad(parentObject);

            MonoBehaviorComm = parentObject.AddComponent<MonoBehaviorCommunicator>();

#if UNITY_EDITOR
            Debug.Log("[<color=green>Jack's Interaction Engine</color>] Initialization was successful.");
#endif
        }
    }
}
