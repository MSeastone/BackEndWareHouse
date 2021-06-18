using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackEndWareHouse
{
    public class Cuboid : I3DStorageObject
    {
        ////fields
        private int _xSide; //bredd
        private int _ySide; //höjd
        private int _zSide; //djup
        private int _id;
        private string _description;
        private int _weight; //kg
        private double _volume; //m3
        private double _area; //m2
        private bool _isFragile;
        private double _maxDimension;
        private int _insuranceValue;
        //constructor
        public Cuboid(int _xSide, int _ySide, int _zSide, int _id, string _description, int _weight, bool _isFragile, int _insuranceValue) 
        {
            double convertToKvadratM = Math.Pow(_xSide * _ySide, 3) / 1000000; //area
            double convertToKubikM = ((_xSide * _ySide * _zSide)) / 10000; //volym * 6 tog jag bort
            this.XSide = _xSide;
            this.YSide = _ySide;
            this.ZSide = _zSide;
            this.ID = _id;
            this.Description = _description;
            this.Weight = _weight;
            this.Volume = Math.Round(convertToKvadratM, 2);
            this.Area = Math.Round(convertToKubikM, 2);
            this.IsFragile = _isFragile;
            this.InsuranceValue = _insuranceValue;

        }
        //properties
        public int XSide
        {
            get;
        }
        public int YSide
        {
            get;
        }
        public int ZSide
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
        public double MaxDimension
        {
            get 
            {
                double maxDimension = 0;
                if (XSide < YSide)
                {
                    maxDimension = YSide;
                }
                else
                {
                    maxDimension = XSide;
                }
                if(ZSide > maxDimension) 
                {
                    maxDimension = ZSide;
                }
                return maxDimension;
            }
        }
        public int InsuranceValue
        {
            get;
            set;
        }
        public override string ToString() //this._xSide
        {
            return $"ID:{this._id}\nDescription:{this._description}\nWeight:{this._weight}kg\nDimension:{this._xSide}cm each side\nFragile:{this._isFragile}";
        }
    }
}
