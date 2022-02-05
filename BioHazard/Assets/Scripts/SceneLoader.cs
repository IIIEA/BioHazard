using UnityEngine;
using IJunior.TypedScenes;
using System;

public class SceneLoader : MonoBehaviour
{
    [Serializable]
    public enum Scenes
    {
        MainMenu,
    }

    private Scenes _scene;

    public void LoadScene()
    {
        switch (_scene)
        {
            case Scenes.MainMenu:
                MainMenu.Load();
                break;
            default:
                break;
        }
    }
}
