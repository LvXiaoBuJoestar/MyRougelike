using UnityEngine;

public class MonoSingleton<T> : MonoBehaviour where T : Component
{
    private static T instance;
    public static T Instance { get { return instance; } }

    private void Awake()
    {
        if (instance != null && instance != this as T)
            Destroy(gameObject);
        instance = this as T;
        DontDestroyOnLoad(gameObject);

        OnAwake();
    }

    protected virtual void OnAwake()
    {

    }
}
