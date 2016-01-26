using System.Collections;
using System.Collections.Generic;
using OfflineStatus;
using OnlineStatus;


namespace GameMainData
{
    public static class GameData
    {
        //public static bool VRDeviceEnabled { get; set; }

        public static E_OFFLINE_STATE  offlineState { get; set; }
        public static E_ONLINE_STATE   onlineState { get; set; }
		public static E_OFFLINE_STATE  nextState{ get; set;}

    }

}