using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveData : MonoBehaviour
{
    public TypeOfScene WhatSceneIsThis;

    public static SaveData current;

    public SD_Path sdpath;
    public SD_Mode sdmode;

    public string path;

    public void save()
    {
        //save data path is universal
        if (WhatSceneIsThis == TypeOfScene.start)
        {
            sdpath.SaveToJson();
        }
        if (WhatSceneIsThis == TypeOfScene.home)
        {
            sdmode.SaveToJson();
        }
    }

    public void load()
    {
        sdpath.LoadFromJson();
        path = sdpath.path.path;
        if (WhatSceneIsThis == TypeOfScene.home)
        {
            sdmode.LoadFromJson();
        }
        if (WhatSceneIsThis == TypeOfScene.level)
        {
            sdmode.LoadFromJson();
        }
    }

    public void PathFinding(string Path)
    {
        sdpath.path.path = Path;
        path = sdpath.path.path;
    }

    void Start()
    {
        load();
        save();
    }

    public enum TypeOfScene
    {
        start, home, level, world
    }
}
