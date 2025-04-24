// Isaac Bustad
// 4/17/2025


using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using System.Linq;
using BugFreeProductions.Tools;

public class ReadRoomsInPath
{
    // Vars



    // Methods
    static public List<string> FindRoomNames()
    {
        // collect found rooms
        List<string> roomsFound = new List<string>();

        // paths in directory
        List<string> roomPaths = new List<string>();
        roomPaths = Directory.GetFiles(Application.persistentDataPath).ToList();

        foreach (string name in roomPaths)
        {
            //Debug.Log("This Room is = " + name);

            string[] pathComps = name.Split('/');
            foreach(string comp in pathComps)
            {
                //Debug.Log("Comp = " + comp);
            }

            string finComp = pathComps[pathComps.Length - 1].Split('\\')[1];
            string dotRemoved = finComp.Split('.')[0];
            string extentionsRemoved = dotRemoved.Substring(0, dotRemoved.Length - JSONPlacementMannager.Instance.ObjectPlacementPath.Length + 5);
            //Debug.Log("Fin Com = " + extentionsRemoved);
            roomsFound.Add(extentionsRemoved);
        }

        foreach (string r in roomsFound)
        {
            //Debug.Log("room = " + r);
        }
        
        return roomsFound;
    }


    // Accessors
}
