using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CalculatorAPI.Models
{
    public class Action
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Number1 { get; set; }
        public int Number2 { get; set; }
        public int Result { get; set; }
        public Action() { }
        public Action(string Name, int Number1, int Number2)
        {
            this.Name = Name;
            this.Number1 = Number1;
            this.Number2 = Number2;
        }
    }
}