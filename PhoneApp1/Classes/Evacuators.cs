using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhoneApp1.Classes
{
    class Evacuators
    {
        private string _name;
        private string _number;

        public string Name { 
            get { return this._name; }
            set {this._name = value; } 
        }
        public string Number
        {
            get { return this._number; }
            set { this._number = value; }
        }


        public List<Evacuators> GetEvacuators()
        {
            List<Evacuators> evacuators = new List<Evacuators>();
            Evacuators evacuator = new Evacuators();
            evacuator._name = "Xodovik Vzgo";
            evacuator._number = "094828688";
            evacuators.Add(evacuator);

            //List<Evacuators> evacuators2 = new List<Evacuators>();
            Evacuators evacuator2 = new Evacuators();
            evacuator2._name = "Xodovik Abo";
            evacuator2._number = "098489219";
            evacuators.Add(evacuator2);

            return evacuators;
        }
    }
}
