using UnityEngine;

namespace Assets.Practice.Chapter02.Scripts
{
    /// <summary>
    /// 自已實作一個介面，去呼叫別人的介面Function
    /// 這樣就不用需跟對方協調Function或介面的命名方式，自已做轉接頭，做自已的介面接口
    /// 也避免很多處的Class調用別人Class的Function，當別人Function更改名稱時，自已的程式也要到處去修改名稱
    /// </summary>
    public class AdapterLogger :ILogger
    {
        private ThirdPartySDK thirdPartySDK = new ThirdPartySDK();
        public void Log(string msg)
        {
            Debug.Log("【轉換器模式】轉換器Log");
            thirdPartySDK.WriteEntry(msg);
        }
    }

    /// <summary>
    /// 假設此Class為第三方的SDK
    /// </summary>
    internal class ThirdPartySDK
    {
        internal void WriteEntry(string msg)
        {
            Debug.Log("【轉換器模式】透過Interface呼叫第三方SDK Function");
        }
    }
}