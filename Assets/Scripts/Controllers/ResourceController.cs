using System.Collections;
using System.Collections.Generic;
using System.Xml.Linq;
using UnityEngine;

public class ResourceController : ISingleton<ResourceController>
{
    private readonly Dictionary<string, GameObject> m_rsPrefabs = new Dictionary<string, GameObject>();
    private ItemConfig m_itemConfig;

    public GameObject GetPrefabs(string name)
    {
        m_rsPrefabs.TryGetValue(name, out GameObject obj);
        if (obj == null)
        {
            obj = Resources.Load<GameObject>(name);
        }
        return obj;
    }

    public ItemConfigDetail GetItemConfigDetail(NormalItem.eNormalType eNormalType)
    {
        if (m_itemConfig == null) { m_itemConfig = Resources.Load<ItemConfig>(Constants.ITEM_CONFIG); }

        return m_itemConfig.Items.Find(x => x.ItemType == eNormalType);
    }
}
