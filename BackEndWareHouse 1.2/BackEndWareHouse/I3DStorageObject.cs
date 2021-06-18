using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackEndWareHouse
{
    public interface I3DStorageObject
    {
        //properties
        int ID
        { get;}
        string Description
        { get;}
        int Weight //kg
        { get;}
        double Volume //m3
        { get;}
        double Area//m2
        { get;}
        bool IsFragile
        { get;}
        double MaxDimension
        { get;}
        int InsuranceValue
        { get; set; }
    }
}
