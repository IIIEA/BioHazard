using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using IJunior.TypedScenes;

public class LevelEditor : Singletone<LevelEditor>, ISceneLoadHandler<Level>
{
    private bool _isAddeting { get; set; }
    private Level _level { get; set; }

    public void OnSceneLoaded(Level argument)
    {
        throw new System.NotImplementedException();
    }

    public void Load(Level level)
    {
        _level = level;
        Load();
    }

    public void Load()
    {
        _isAddeting = true;
        Awake();
        _isAddeting = false;
    }

    public void Clear(Transform root)
    {
        while (root.childCount > 0)
        {
            DestroyImmediate(root.GetChild(0).gameObject);
        }
    }

    public void Clear()
    {
        Awake();
    }
}
