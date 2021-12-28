using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Practice.Chapter02.Scripts
{
    public class GameManager02 : MonoBehaviour
    {
        [SerializeField] private InterfacePattern interfacePattern;
        [SerializeField] private FactoryPattern factoryPattern;
        [ContextMenu("- Find Parameters")]
        private void FindParameters()
        {
            interfacePattern.button_ConsoleLogger = GameObject.Find("Button_ConsoleLogger").GetComponent<Button>();
            interfacePattern.button_DecoratedLogger = GameObject.Find("Button_DecoratedLogger").GetComponent<Button>();
            interfacePattern.button_AdapterLogger = GameObject.Find("Button_AdapterLogger").GetComponent<Button>();
            factoryPattern.button_FactoryMethod = GameObject.Find("Button_FactoryMethod").GetComponent<Button>();
            factoryPattern.button_SimpleFactory = GameObject.Find("Button_SimpleFactory").GetComponent<Button>();
            factoryPattern.button_AbstractFactory = GameObject.Find("Button_AbstractFactory").GetComponent<Button>();
        }

        void Start()
        {
            ToLog(new NullLogger());

            interfacePattern.button_ConsoleLogger.onClick.AddListener(() => ToLog(new ConsoleLogger()) );
            interfacePattern.button_DecoratedLogger.onClick.AddListener(() => ToLog(new DecoratedLogger(new ConsoleLogger())) );
            interfacePattern.button_AdapterLogger.onClick.AddListener(() => ToLog(new AdapterLogger()) );

            factoryPattern.button_FactoryMethod.onClick.AddListener(FactoryMethod);
            factoryPattern.button_SimpleFactory.onClick.AddListener(SimpleFactory);
            factoryPattern.button_AbstractFactory.onClick.AddListener(AbstractFactory);
        }

        private void FactoryMethod()
        {
            UserFactory userFactory = new AdminUserFactory();
            userFactory.CreateUser();
            userFactory = new DomainUserFactory();
            userFactory.CreateUser();
        }
        private void SimpleFactory()
        {
            UserFactory_Static.CreateAdministrator("Victor", 666);
            UserFactory_Static.CreateDomainUser("Avril", 104);
        }
        private void AbstractFactory()
        {
            IUserFactory iUserFactory = new WindowsUserFactory();
            iUserFactory.CreateAdminUser();
            iUserFactory.CreateDomainUser();
            iUserFactory.CreatePowerUser();
            iUserFactory = new LinuxUserFactory();
            iUserFactory.CreateAdminUser();
            iUserFactory.CreateDomainUser();
            iUserFactory.CreatePowerUser();
        }

        private void ToLog(ILogger logger)
        {
            logger.Log("呼叫Log");
        }
    }

    [Serializable]
    internal class InterfacePattern
    { 
        public Button button_ConsoleLogger, button_DecoratedLogger, button_AdapterLogger;
    }
    [Serializable]
    internal class FactoryPattern
    {
        public Button button_FactoryMethod, button_SimpleFactory, button_AbstractFactory;
    }
}