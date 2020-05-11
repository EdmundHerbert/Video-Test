using System;
using AgoraIO.Media;
using Microsoft.AspNetCore.Mvc;

namespace VideoTest.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserInController : ControllerBase //End User side
    {
        private string _appId = "781d2c6384c54f53bf97e30f3ebdd397";
        private string _appCertificate = "77301a5d0caf46a5b8aca316cc6982dd";
        private string _channelName = "globalchoices";
        private string _uid = "1000";
        private uint _ts = 1111111;
        private uint _salt = 1;
        private uint _expiredTs = 0;
        public ActionResult Index()
        {
            //TestGenerateDynamicKey();
            var dateTimeToUnixTimestamp = UnixTimestamp.DateTimeToUnixTimestamp(DateTime.Now);
            var vOut = Convert.ToUInt32(dateTimeToUnixTimestamp);
            var token = new AccessToken(_appId, _appCertificate, _channelName, _uid, vOut, _salt);
            _expiredTs = vOut + 6000;

            token.message.ts = vOut;
            token.message.salt = _salt;
            token.addPrivilege(Privileges.kJoinChannel, _expiredTs);
            var result = token.build();

            var empd = new EmployeeData(_appId, _channelName, _uid, result.Trim());

            

            return RedirectToAction("Index", "Test", new { appid = empd.AppId, channelname = empd.ChannelName, uid = empd.Uid, token = empd.Token });
        }
    }
    public class EmployeeData
    {
        public String AppId { get; set; }
        public String ChannelName { get; set; }
        public String Uid { get; set; }
        public String Token { get; set; }
        

        public EmployeeData() // you must add a parameter-less constructor
        {
        }

        public EmployeeData(String appid, String channelname,String uid,String token)
        {
            AppId = appid;
            ChannelName = channelname;
            Uid = uid;
            Token = token;
        }
    }

    static class UnixTimestamp
    {
        public static DateTime UnixEpoch = new DateTime(1970, 1, 1, 0, 0, 0, 0);

        public static ulong DateTimeToUnixTimestamp(DateTime time)
        {
            return (ulong)(time - UnixEpoch).TotalSeconds;
        }

        public static DateTime UnixTimestampToDateTime(ulong timestamp)
        {
            return UnixEpoch.AddSeconds(timestamp);
        }

        public static ulong Now
        {
            get
            {
                return (ulong)(DateTime.UtcNow - UnixEpoch).TotalSeconds;
            }
        }
    }
}