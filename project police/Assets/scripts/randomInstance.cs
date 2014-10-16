using UnityEngine;
using System.Collections;

public class randomInstance : MonoBehaviour
{
    public GameObject marker;
    public Vector2 mapLimits;
    private int chance;
    public static int count;
    public Texture2D roads;
    

	/*void Update ()
    {
                int hori = (int) (Random.Range (0, mapLimits.x));
                int vert = (int) (Random.Range (0, mapLimits.y));
                Color testColor = roads.GetPixel (hori, vert);
                print (testColor);
                chance = Random.Range(0, 1000);
                if (chance < 10 && count < 10)
                {
                    Vector2 spawnPosition = new Vector2 (hori/200.6f, -vert/200.6f);
                    Quaternion spawnRotation = Quaternion.identity;
                    Instantiate (marker, spawnPosition, spawnRotation);
                    count ++;
                }


	}*/
    
    void Start ()
    {
                int hori = (int) (Random.Range (0, mapLimits.x));
                int vert = (int) (Random.Range (0, mapLimits.y));
                Color testColor = roads.GetPixel (hori, vert);
                print (testColor);
                print (hori);
                print (vert);
                Vector2 spawnPosition = new Vector2 (hori/200.6f, -vert/200.6f);
                Quaternion spawnRotation = Quaternion.identity;
                Instantiate (marker, spawnPosition, spawnRotation);
    }
    
}
