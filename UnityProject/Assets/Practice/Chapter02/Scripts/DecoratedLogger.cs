using System;

namespace Assets.Practice.Chapter02.Scripts
{
    /// <summary>
    /// 裝飾模式 - 將原本的Function，在不更動原Function的邏輯下而變更參數值
    /// </summary>
    public class DecoratedLogger : ILogger
    {
        private ILogger logger;

        public DecoratedLogger(ILogger logger)
        {
            this.logger = logger;
        }

        public void Log(string msg)
        {
            logger.Log($"【裝飾模式】{DateTime.Now.ToString()} - {msg}");
        }
    }

}