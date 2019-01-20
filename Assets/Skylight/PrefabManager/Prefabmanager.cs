using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Skylight;
public class PrefabManager : GameModule<PrefabManager> {

    Dictionary<string, GameObject> mAllScenes = new Dictionary<string, GameObject>();

    public GameObject LoadPrefab(string prefabName)
    {
        string name = "Prefabs/" + prefabName;
        if (mAllScenes.ContainsKey(prefabName))
        {
            return mAllScenes[prefabName];
        }
        else
        {
            GameObject perfb = AssetsManager.LoadPrefab<GameObject>(name);
            if (perfb == null)
            {
                Debug.Log(prefabName + "can`t find in Prefabs/" + prefabName);
                return null;
            }
            mAllScenes.Add(prefabName, perfb);
            return perfb;
        }


        
    }

    public void UploadPrefab(string name)
    {

    }

    public void UploadAllPrefab()
    {

        Dictionary<string, GameObject>.Enumerator etor = mAllScenes.GetEnumerator();
        while (etor.MoveNext())
        {

            Destroy(etor.Current.Value);

        }
        mAllScenes.Clear();

    }
}
