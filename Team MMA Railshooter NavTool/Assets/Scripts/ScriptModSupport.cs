using UnityEngine;
using System.Collections;
using System.IO;

/// <summary>
/// @Author Marshall Mason
/// ScriptModSupport handles the I/O tasks of reading and outputting text files for modding.
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
            GameObject[] moveTimeline;
            GameObject[] effectTimeline;
            GameObject[] facingTimeline;

            reader = modFile.OpenText();
            if(reader.ReadLine() != defaultModFileText)
            {
                reader.Close();
                GameObject[] waypoints = GameObject.FindGameObjectsWithTag("Waypoint");
                foreach (GameObject go in waypoints)
                {
                    Destroy(go);
                }
                reader = modFile.OpenText();
                string inputLine = reader.ReadLine();
                string[] keywords = inputLine.Split('_');
                if (keywords[0].ToUpper() == "M")
                {
                    string[] words = keywords[1].Split(' ');
                    switch ((MovementTypes)System.Enum.Parse(typeof(MovementTypes), words[0].ToUpper()))
                    {
                        case MovementTypes.MOVE:
                            //Movement waypoint spawning Code
                            break;
                        case MovementTypes.WAIT:
                            //Wait waypoint spawning Code
                            break;
                        case MovementTypes.BEZIER:
                            //Bezier waypoint spawning Code
                    }
                }
                else if( keywords[0].ToUpper() == "E")
                {
                    string[] words = keywords[1].Split(' ');
                    switch ((EffectTypes)System.Enum.Parse(typeof(EffectTypes), words[0].ToUpper()))
                    {
                        case EffectTypes.FADE:
                            //Fade waypoint spawning Code
                            break;
                        case EffectTypes.SHAKE:
                            //Shake waypoint spawning Code
                            break;
                        case EffectTypes.SPLATTER:
                            //Splatter waypoint spawning Code
                        case EffectTypes.WAIT:
                            //Effect Wait waypoint spawning Code
                    }
                }
                else if(keywords[0].ToUpper() == "F")
                {
                    string[] words = keywords[1].Split(' ');
                    switch ((FacingTypes)System.Enum.Parse(typeof(FacingTypes), words[0].ToUpper()))
                    {
                        case FacingTypes.LOOKAT:
                            //Look At waypoint spawning Code
                            break;
                        case FacingTypes.LOOKCHAIN:
                            //Look Chain waypoint spawning Code
                            break;
                        case FacingTypes.WAIT:
                            //Facing Wait waypoint spawning Code
                            break;
                    }
                }
            }
        }
	}
}
