using System.Collections;
using UnityEngine;

public class TimeManager : MonoBehaviour
{

    public static TimeManager instance { get; private set; }

    [SerializeField]
    public GameTimestamp timestamp;

    public float timeScale = 1f;

    public Transform sunTransform;


    private void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(this);
        }
        else
        {
            instance = this;
        }
    }

    private void Start()
    {
        timestamp = new GameTimestamp(0, GameTimestamp.Season.Spring, 1, 6, 0);
        StartCoroutine(TimeUpdate());
    }


    IEnumerator TimeUpdate()
    {
        while (true)
        {
            yield return new WaitForSeconds(1 / timeScale);
            Tick();
        }
    }


    /*
    Dünya, güneşin etrafında 1 günde 360 derece döndüğünü varsayarak 
    Bunu oyun mekaniklerinde güneşi 1 günde 360 derece döndererek sağlıyoruz.
    1 günde 360 derece ise saatte 360/24 den 15 derece döner
    dakikada ise 15/60 dan 0.25 derece dönüyor demektir.
    yani güneği dakikada 0.25 derece rotate ederek gece gündüz eklemiş olacağız.
    90 derece çıkarma sebebimiz ise saat 12 de güneşin tam tepede olmasını istememiz.
    */

    public void Tick()
    {
        timestamp.UpdateClock();

        int timeInMinutes = GameTimestamp.HoursToMinutes(timestamp.hour) + timestamp.minute;

        float sunAngle = 0.25f * timeInMinutes - 90;

        sunTransform.eulerAngles = new Vector3(sunAngle, 0, 0);
    }
    


}
