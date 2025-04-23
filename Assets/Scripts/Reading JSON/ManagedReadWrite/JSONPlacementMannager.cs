// Isaac Bustad
// 4/3/2025


using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;


namespace BugFreeProductions.Tools
{
    public class JSONPlacementMannager : MonoBehaviour
    {
        // Vars
        // Singaton instance
        private static JSONPlacementMannager instance = null;

        // factory Refferences
        [SerializeField] private AbstractFactory_SCO abf_SCO = null;

        // pathing varriables
        [SerializeField] private string roomConfigPath = "Default";
        private string objectPlacementPath = "ObjectPlacements.json";
        private string roomPlacementPath = "RoomPointPlacements.json";
        private string roomNamePath = "RoomNames.json";


        // Mannaged readers and writers
        private MannagedJSONReader jsonReader = new MannagedJSONReader();
        private MannagedJSONWriter jsonWriter = new MannagedJSONWriter();

        // Room object ID and Pool
        [SerializeField] private string roomID = "Room";
        [SerializeField] private GenericPool pool = new GenericPool();

        // 



        // Methods
        private void OnEnable()
        {
            if (instance != null)
            {
                if (instance != this)
                {
                    Destroy(gameObject);
                }
            }
            else
            {
                instance = this;
                ReadRoomConfif();
                ReadRoomsInPath.FindRoomNames();
            }
        }

        #region Room Saving
        public void ReadRoomConfif()
        {
            jsonReader.SpawnObjects("/" + roomConfigPath + objectPlacementPath);
        }

        public void WriteRoomConfig()
        {            
            jsonWriter.WriteObjPlacementData("/" + roomConfigPath + roomPlacementPath, "/" + roomConfigPath + objectPlacementPath);
        }
        

        public void AddRoom(string aString)
        {
            JSONRoomList rooms = JsonUtility.FromJson<JSONRoomList>(CustomGatewayJSON.Instance.ReadJsonFile("/" + roomNamePath));

            if (rooms.roomsLST.Contains(aString) == false)
            {
                List<string> nRoomLST = new List<string>();
                
                foreach (string n in rooms.roomsLST)
                {
                    nRoomLST.Add(n);
                }
                nRoomLST.Add((aString));

                rooms.roomsLST = nRoomLST.ToArray();
            }
        }

        #endregion

        #region Get Room Info

        /*private List<string> ReadRooms()
        {
            List<string> roomsLST = new List<string>();



            return roomsLST;
        }*/


        #endregion






        // Accessors
        // Singalton Accesseors
        public static JSONPlacementMannager Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new GameObject("JSONPlacementMannager").AddComponent<JSONPlacementMannager>();
                }
                return instance;
            }
        }

        // Accessors for managed read write
        public AbstractFactory_SCO ABF_SCO { get { return abf_SCO; } }

        public string RoomID { get { return roomID; } }

        public GenericPool Pool { get { return pool; } set { pool = value; } }

        //public string RoomConfigPath { get { return roomConfigPath; } set {  roomConfigPath = value; } }

        public JSONRoomList RoomList { get { return JsonUtility.FromJson<JSONRoomList>(CustomGatewayJSON.Instance.ReadJsonFile("/" + roomNamePath)); } }

        public string ObjectPlacementPath { get { return objectPlacementPath; }  }

    }
}