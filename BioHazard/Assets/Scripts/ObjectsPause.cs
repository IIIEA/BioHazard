using System.Linq;
using System.Collections.Generic;
using UnityEngine;

public class ObjectsPause : Singletone<ObjectsPause>
{
    [SerializeField] private List<IPause> _pauseObjects = new List<IPause>();

    private void Start()
    {
        Time.timeScale = 1;
        _pauseObjects = FindObjectsOfType<GameObject>().Select(x => x.GetComponent<IPause>()).Where(x => x != null).ToList();
    }

    public void PauseOn()
    {
        _pauseObjects.ForEach(x => x.Pause());
        Time.timeScale = 0;
    }

    public void PauseOff()
    {
        _pauseObjects.ForEach(x => x.Resume());
        Time.timeScale = 1;
    }
}
