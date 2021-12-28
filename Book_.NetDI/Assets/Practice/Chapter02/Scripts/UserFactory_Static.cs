using UnityEngine;

namespace Assets.Practice.Chapter02.Scripts
{
    /// <summary>
    /// Simple Factory
    /// </summary>
    public static class UserFactory_Static
    {
        public static User CreateAdministrator(string name, int id)
        {
            Debug.Log("【簡單工廠】UserFactory_Static:CreateAdministrator");
            return new Administrator();
        }
        public static User CreateDomainUser(string name, int id)
        {
            Debug.Log("【簡單工廠】UserFactory_Static:CreateDomainUser");
            return new DomainUser();
        }
    }

    #region {========== User類別 ==========}
    public interface IUser
    {
        string GetUserName();
    }
    public class User : IUser
    {
        protected string userName;
        public string GetUserName()
        {
            return userName;
        }
    }
    public class Administrator : User { }
    public class DomainUser : User { }
    public class PowerUser : User { }
    #endregion
}