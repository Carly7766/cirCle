using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RuntimeInitializer {

    InitializerTable table;
    [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSceneLoad)]
    private static void InitializeBeforeSceneLoad() {
        Managers[] managers = InitializerTable.Instance.managers;

        foreach(Managers m in managers){
            GameObject obj = new GameObject(m.Name,System.Type.GetType(m.ManagerClass.name));
            if(m.isDontDestroy == true) GameObject.DontDestroyOnLoad(obj);
        }
    }
}