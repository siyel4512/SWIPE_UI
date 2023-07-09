using System.Timers;
using UnityEngine;
using Cysharp.Threading.Tasks;

public class AutoSwipe : MonoBehaviour
{
    public Timer timer;
    public int refleshTime = 1000;

    // Start is called before the first frame update
    void Start()
    {
        timer = new Timer();
        timer.Interval = refleshTime;
        timer.Elapsed += (sender, e) => HandleTimer().Forget();

        //timer.Start();
    }

    private async UniTaskVoid HandleTimer()
    {
        await UniTask.SwitchToThreadPool();

        // swipe
        Debug.Log("DDDd");

        await UniTask.SwitchToMainThread();
    }

    private void OnApplicationQuit()
    {
        timer.Stop();
        timer.Dispose();
    }
}
