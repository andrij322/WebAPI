using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Configuration;
using Autofac;
using CalculatorAPI.Utils;

namespace CalculatorAPI.Models
{
    public class CalculatorManager
    {
        private IContainer container = AutofacConfig.ConfigureContainer();



        public int WriteAction(Action action)
        {
            using (var connectionManager = container.Resolve<IConnectionManager>())
            {
                calculateResult(ref action);
                return connectionManager.WriteAction(action);
            }
        }


        public List<Action> GetActions()
        {
            using (var connectionManager = container.Resolve<IConnectionManager>())
            {
                return connectionManager.GetActions();
            }
        }


        public Action GetActionById(int id)
        {
            using (var connectionManager = container.Resolve<IConnectionManager>())
            {
                return connectionManager.GetActionById(id);
            }
        }


        public int DeleteAction(int id)
        {
            using (var connectionManager = container.Resolve<IConnectionManager>())
            {
                return connectionManager.DeleteAction(id);
            }
        }


        private void calculateResult(ref Action action)
        {
            switch(action.Name)
            {
                case "Plus":
                    action.Result = action.Number1 + action.Number2;
                    break;
                case "Minus":
                    action.Result = action.Number1 - action.Number2;
                    break;
                case "Divide":
                    action.Result = action.Number1 / action.Number2;
                    break;
                case "Multiply":
                    action.Result = action.Number1 * action.Number2;
                    break;
                default:
                    action.Result = 0;
                    break;
            }
        }
    }
}