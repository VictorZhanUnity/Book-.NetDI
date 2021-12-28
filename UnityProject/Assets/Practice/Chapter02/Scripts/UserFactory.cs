using System.Collections;
using UnityEngine;

namespace Assets.Practice.Chapter02.Scripts
{
    /// <summary>
    /// Factory Method
    /// </summary>
    public class UserFactory
    {
        public virtual User CreateUser()
        {
            return new User();
        }
    }

    public class AdminUserFactory : UserFactory {
        override public User CreateUser()
        {
            Debug.Log("【工廠方法】UserFactory:Administrator");
            return new Administrator();
        }
    }
    public class DomainUserFactory : UserFactory {
        override public User CreateUser()
        {
            Debug.Log("【工廠方法】UserFactory:DomainUser");
            return new DomainUser();
        }
    }
}