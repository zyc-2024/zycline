using UnityEngine;

public class TaperMaker : MonoBehaviour
{
    public GameObject Taper;
    private MainLine l;

    private GameObject tap;
    private Transform tapHolder;
    private void Awake()
    {
        tapHolder = new GameObject("taps").transform;
    }
    void Start()
    {
        l = GameObject.FindGameObjectWithTag("line").GetComponent<MainLine>();
    }

    void Update()
    {
        if (l.GetComponent<MainLine>().enabled == true && l.isFall == false)
        {
            if (Input.GetMouseButtonDown(0) || Input.GetKeyDown(KeyCode.Space))
            {
                tap=Instantiate(Taper,new Vector3(this.transform.position.x,this.transform.position.y-0.45f,this.transform.position.z),new Quaternion(0.7071068f,0,0, 0.7071068f));

                tap.transform.SetParent(tapHolder);
            }
        }
    }
}
