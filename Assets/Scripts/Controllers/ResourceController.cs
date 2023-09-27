using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResourceController : ISingleton<ResourceController>
{
    private readonly Dictionary<string, GameObject> m_rsPrefabs = new Dictionary<string, GameObject>();

    public GameObject GetPrefabs(string name)
    {
        m_rsPrefabs.TryGetValue(name, out GameObject obj);
        if (obj == null)
        {
            obj = Resources.Load<GameObject>(name);
        }
        return obj;
    }
}
