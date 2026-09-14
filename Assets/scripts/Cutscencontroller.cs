using UnityEngine;
using UnityEngine.Playables;
public class CutsceneController : MonoBehaviour
{
    [SerializeField] PlayableDirector director;
    [SerializeField] GameObject canvas;
    private void Awake()
    {
        if (director == null) canvas.SetActive(false);
    }
    private void OnEnable()
    {
        if (director != null)
        {
            director.stopped += OnCutsceneFinished;
        }
    }
    private void OnDisable()
    {
        if (director != null)
        {
            director.stopped -= OnCutsceneFinished;
        }
    }
    private void OnCutsceneFinished(PlayableDirector pd)
    {
        if (canvas != null)
        {
            canvas.SetActive(false);
        }
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created

}