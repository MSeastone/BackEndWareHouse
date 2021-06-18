using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackEndWareHouse
{
    public class Cube : I3DStorageObject
    {
        //fields
        private int _side;
        private int _id;
        private string _description;
        private int _weight; //kg
        private double _volume; //m3
        private double _area; //m2
        private bool _isFragile;
        private double _maxDimension;
        private int _insuranceValue;

        //constructor
        public Cube(int _id, string _description, int _weight, bool _isFragile, int _side, int _insuranceValue)
        {
            double convertToKvadratM = Math.Pow(_side, 3) / 1000000; //Volym???
            double convertToKubikM = ((_side * _side) * 6) / 10000; //Area
            this.Side = _side;
            this.ID = _id;
            this.Description = _description;
            this.Weight = _weight;
            this.Volume = Math.Round(convertToKvadratM, 2);
            this.Area = Math.Round(convertToKubikM, 2);
            this.IsFragile = _isFragile;
            this.InsuranceValue = _insuranceValue;
        }
        //properties
        public int Side
        {
            get;
        }
        public int ID
        {
            get;
        }
        public string Description
        {
            get;
        }
        public int Weight
        {
            get;
        }
        public double Volume
        {
            get;
        }
        public double Area
        {
            get;
        }
        public bool IsFragile
        {
            get;
        }
        public double MaxDimension //Kub har samma längd och höjd
        {
            get {return Side; }
        }
        public int InsuranceValue
        {
            get;
            set;
        }
        public override string ToString()
        {
            return $"ID:{this._id}\nDescription:{this._description}\nWeight:{this._weight}kg\nDimension:{this._side}cm each side\nFragile:{this._isFragile}";
        }
    }
}
