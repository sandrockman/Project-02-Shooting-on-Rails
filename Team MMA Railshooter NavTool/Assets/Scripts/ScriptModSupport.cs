using UnityEngine;
using System.Collections;
using System.IO;

/// <summary>
/// @Author Marshall Mason
/// ScriptModSupport handles the I/O tasks of reading and outputting 
/// </summary>
public class ScriptModSupport : MonoBehaviour {

    public GameObject movementWaypoint;
    public GameObject facingWaypoint;
    public GameObject effectWaypoint;
    public ScriptEngine player;


    string defaultModFileText = "Edit this file for modding timelines and delete this line";

    FileInfo modFile = null;
    StreamReader reader = null;

	void Start ()
    {
        if (player == null)
        {
            player = GameObject.FindGameObjectWithTag("Player").GetComponent<ScriptEngine>();
            if (player == null)
            {
                ScriptErrorLogging.logError("No Player Object found, please add a player to the scene and check the tag.");
                Application.Quit();
            }
        }
        if (movementWaypoint == null)
        {
            movementWaypoint = (GameObject)Resources.Load("movementWaypoint.prefab",typeof(GameObject));
            if(movementWaypoint == null)
            {
                ScriptErrorLogging.logError("No movementWaypoint prefab found, please place one in the Resources folder");
                Application.Quit();
            }
        }
        if (facingWaypoint == null)
        {
            facingWaypoint = (GameObject)Resources.Load("facingWaypoint.prefab", typeof(GameObject));
            if (facingWaypoint == null)
            {
                ScriptErrorLogging.logError("No facingWaypoint prefab found, please place one in the Resources folder");
                Application.Quit();
            }
        }
        if (effectWaypoint == null)
        {
            effectWaypoint = (GameObject)Resources.Load("effectWaypoint.prefab", typeof(GameObject));
            if (effectWaypoint == null)
            {
                ScriptErrorLogging.logError("No effectWaypoint prefab found, please place one in the Resources folder");
                Application.Quit();
            }
        }

        modFile = new FileInfo(Application.dataPath + "/waypoints.txt");
        if(!modFile.Exists)
        {
            File.WriteAllText(Application.dataPath + "/waypoints.txt", defaultModFileText);
        }
        else
        {
            reader = modFile.OpenText();
            if(reader.ReadLine() != defaultModFileText)
            {
                reader.Close();
                GameObject[] waypoints = GameObject.FindGameObjectsWithTag("Waypoint");
                reader = modFile.OpenText();
                string inputLine = reader.ReadLine();
                string[] keywords = inputLine.Split('_');
                if (keywords[0].ToUpper() == "M")
                {
                    string[] words = keywords[1].Split(' ');
                }
            }
        }
	}
}
