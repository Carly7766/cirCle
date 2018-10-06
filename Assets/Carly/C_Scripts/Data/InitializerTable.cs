using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu( menuName = "Scriptable Object/Create InitializerTable", fileName = "InitializerTable")]
public class InitializerTable : ScriptableObject {

    public Managers[] managers;

    private static InitializerTable m_instance;
    public static InitializerTable Instance {
        get{
            if(m_instance != null) return m_instance;

            InitializerTable table = Resources.Load("InitializerTable") as InitializerTable;

            if(table == null){
                Debug.AssertFormat(false,"Missing InitializerTable!");
                table = CreateInstance<InitializerTable>();
            }
            m_instance = table;

            return m_instance;
        }
    }
}

   [System.Serializable]
    public struct Managers {
        public string Name;
        public Object ManagerClass;
        public bool isDontDestroy;
    }