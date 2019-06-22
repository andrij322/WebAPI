using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SQLite;

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
