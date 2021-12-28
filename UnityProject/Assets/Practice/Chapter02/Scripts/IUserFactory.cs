using System.Collections;
using UnityEngine;

namespace Assets.Practice.Chapter02.Scripts
{
    /// <summary>
    /// Abstract Factory
    /// </summary>
    public interface IUserFactory
    {
        User CreateAdminUser();
        User CreateDomainUser();
        User CreatePowerUser();
    }

    public class WindowsUserFactory : IUserFactory
    {
        public User CreateAdminUser()
        {
            Debug.Log("【抽像工廠】WindowsUserFactory:CreateAdminUser");
            return new Administrator();
        }

        public User CreateDomainUser()
        {
            Debug.Log("【抽像工廠】WindowsUserFactory:CreateDomainUser");
            return new DomainUser();
        }

        public User CreatePowerUser()
        {
            Debug.Log("【抽像工廠】WindowsUserFactory:CreatePowerUser");
            return new PowerUser();
        }
    }

    class LinuxUserFactory : IUserFactory
    {
        public User CreateAdminUser()
        {
            Debug.Log("【抽像工廠】LinuxUserFactory:CreateAdminUser");
            return new Administrator();
        }

        public User CreateDomainUser()
        {
            Debug.Log("【抽像工廠】LinuxUserFactory:CreateDomainUser");
            return new DomainUser();
        }

        public User CreatePowerUser()
        {
            Debug.Log("【抽像工廠】LinuxUserFactory:CreatePowerUser");
            return new PowerUser();
        }
    }
}