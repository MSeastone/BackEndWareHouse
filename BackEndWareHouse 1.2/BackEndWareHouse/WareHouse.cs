using System;

namespace BackEndWareHouse
{
    public class WareHouse // mitt lager
    {
        public WareHouseLocation[,] _location = new WareHouseLocation[100, 3]; // lagerlyllor 300 platser fördelat på 3 våningar


        //konstructor för att tilldela något från start
        public WareHouse()
        {
            Initialise();
        }
        public bool AddBox(I3DStorageObject box)
        {
            for (int i = 0; i < _location.GetLength(0); i++) //.Length är en property och är till för att kunna se värdet av något men inte röra värdet (alltså ingen set;).
            {
                for (int j = 0; j < _location.GetLength(1); j++)
                {
                    if (_location[i, j].IsThereRoomForNewBox(box))
                    {
                        _location[i, j].AddBox(box);
                        return true; // return gör att metoden bryts och vi kommer tillbaka till metodanropet.
                    }
                }
            }
            return false;
        }
        public bool GetBox(int id, out int location, out int level)// hämta låda
        {
            for (int i = 0; i < _location.GetLength(0); i++) // kollar varje hyllplats
            {
                for (int j = 0; j < _location.GetLength(1); j++) //kollar alla våningar, kolla om lådan id finns i arrayen
                {
                    if (_location[i, j].DoesBoxIdExist(id))
                    {
                        location = i; //hylla
                        level = j; // våning
                        return true;
                    }
                }
            }
            location = -1;
            level = -1;
            return false;
        }
        public bool RemoveBoxFromWareHouse(int id)// ta bort låda från lagret
        {
            bool foundBox = GetBox(id, out int location, out int level);
            if (foundBox)
            {
                _location[location, level].GetBoxById(id);
                return true;
            }
            else
            {
                return false;
            }
        }
        public bool TryAddOnSpecifiedLocation(I3DStorageObject box, int level, int location) // pröva lägg till låda på specifik plats
        {
            if (_location[location, level].AddBox(box))// om det finns plats i arrayen på detta platsnr på denna våning lägg till lådan
            {
                return true;
            }
            return false;
        }

        public bool MoveBox(int id, int location, int level)
        {
            bool movedBox = SearchBox(id, out int oldLocation,  out int oldLevel);

            if (movedBox) // Om förra platsen är lika med 0 så finns ingen låda med sökt ID
            {
                I3DStorageObject boxToMove = _location[oldLocation, oldLevel].GetBoxById(id);
                bool isSuccsessfull = TryAddOnSpecifiedLocation(boxToMove, location, level);
                if (isSuccsessfull)
                {
                    bool isRemoved = RemoveBoxFromWareHouse(id);
                    if (isRemoved == true)
                    {
                        return true;
                    }
                }                
            }
            return false;
        }
        public bool SearchBox(int id, out int location, out int level) //söker efter id nr
        {
            for (int i = 0; i < _location.GetLength(0); i++) // kollar varje hyllplats
            {
                for (int j = 0; j < _location.GetLength(1); j++) //kollar alla våningar, kolla om lådan id finns i arrayen
                {
                    if (_location[i, j].DoesBoxIdExist(id))
                    {
                        location = i; //hylla
                        level = j; // våning
                        return true;
                    }
                }
            }
            location = -1;
            level = -1;
            return false;
        }
        public void Initialise() // tilldelar något från start, vill alltså tilldela arrayen Listor.
        {
            for (int i = 0; i < _location.Length / 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {       //för varje position i arrayen
                    _location[i, j] = new WareHouseLocation();
                }
            }
        }
        public override string ToString()
        {
            return base.ToString();
        }

    }//end of class
}//end of namespace
