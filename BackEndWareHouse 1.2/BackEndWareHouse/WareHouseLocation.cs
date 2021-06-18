using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackEndWareHouse
{
    public class WareHouseLocation //mom class, här finns alla hyllor
    {
        //fields
        private int _height;
        private int _width;
        private int _depth;
        private int _maxWeight;
        private double _maxVolume;
        private double _currentVolume;
        private int _currentWeight;
        private bool isBoxFragile = false;

        //constructor
        public WareHouseLocation()
        {

        }
        //properties
        public int Height
        {
            get {return 200; }
        }
        public int Width
        {
            get { return 300; }
        }
        public int Depth
        {
            get { return 200; }
        }
        public int MaxWeight
        {
            get { return 1000; }
        }
        public double MaxVolume //m3 varje sida måste delas på 100 för att omvandla kubikcm till kubikmeter
        {
            get { return Height/100 * Width/100 * Depth/100; }
        }
        public double MaxDimension 
        {
            get { return Width; }
        }
        public int CurrentWeight
        {
            get { return CalculateWeight(); }
        }
        public double CurrentVolume
        {
            get { return CalculateVolume(); }
        }

        //lista av hyllor
        private List<I3DStorageObject> location = new List<I3DStorageObject>();

        //Methods   
        public bool AddBox(I3DStorageObject box)
        { 
            if (IsThereRoomForNewBox(box))
            {
                location.Add(box);
                _currentVolume += box.Volume;
                _currentWeight += box.Weight;
                if (box.IsFragile)
                {
                    isBoxFragile = true;
                }
                return true;
            }
            return false;
        }
        public bool IsThereRoomForNewBox(I3DStorageObject box)
        {
            if (isBoxFragile)
            {
                return false;
            }
            if (_currentVolume != 0 && box.IsFragile)
            {
                return false;
            }
            if (_currentVolume + box.Volume > MaxVolume)
            {
                return false;
            }
            if (_currentWeight + box.Weight > MaxWeight)
            {
                return false;
            }
            return true;
        } // finns det plats för ny låda?
        public I3DStorageObject GetBoxById(int id) //hämta ut box med id
        {
            for (int i = 0; i < location.Count; i++)
            {
                if (location[i].ID == id)
                {
                    if (location[i].IsFragile)
                    {
                        isBoxFragile = false;
                    }
                    _currentVolume -= location[i].Volume;
                    _currentWeight -= location[i].Weight;

                    I3DStorageObject getBox = location[i];
                    location.RemoveAt(i);
                    return getBox;
                }
            }
            return null;
        }
        public int CalculateWeight() //räkna ut nuvarande vikt
        {
            int currentWeight = 0; //tilldelar ett nuvarande värde
            foreach (var box in location) //för varje låda i hyllan
            {
                currentWeight = currentWeight + box.Weight;
            }
            return currentWeight;
        }
        public double CalculateVolume() //räkna ut nuvarande volym
        {
            double currentVolume = 0; //tilldelar ett nuvarande värde
            foreach (var box in location) // för varje låda på platsen, om det finns det 5 st lådor så loopar vi igenom alla dessa för att få ut nuvarande volym på platsen.
            {
                currentVolume = currentVolume + box.Volume; // propertyn Volume ger oss volymen av lådan som finns på platsen,
            }
            return currentVolume;
        }
        public bool DoesBoxIdExist(int id) // kollar om låda med id finns med hjälp av propertyn ID
        {
            for (int  i = 0;  i < location.Count;  i++)
            {
                if (this.location[i].ID == id)
                {
                    return true;
                }   
            }
            return false;
        }
        public override string ToString()
        {
            return base.ToString();
        }
    }//end of class
}//end of namespace