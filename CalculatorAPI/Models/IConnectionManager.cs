using System;
using System.Collections.Generic;

namespace CalculatorAPI.Models
{
    
    interface IConnectionManager:IDisposable
    {
        int WriteAction(Action action);
        List<Action> GetActions();
        Action GetActionById(int id);
        int DeleteAction(int id);
    }
}
