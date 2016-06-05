using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WaveLab.Model
{
    [Serializable]
   public class SMTFileInduceNewDVSInfo:SMTFileInduceInfo
    {
       private string _NewGenBoardDVS;

       private string _NewSpeBoardDVS;

       private string _NewSMTFabricationDVS;

       private string _NewComponentPartDVS;

       private string _NewGroupPartDVS;

       private string _NewBondingFabricationDVS;


       public string NewGenBoardDVS
       {
           get
           {
               return _NewGenBoardDVS;
           }
           set
           {
               _NewGenBoardDVS = value;
           }
       }

       public string NewSpeBoardDVS
       {
           get
           {
               return _NewSpeBoardDVS;
           }
           set
           {
               _NewSpeBoardDVS = value;
           }
       }

       public string NewSMTFabricationDVS
       {
           get
           {
               return _NewSMTFabricationDVS;
           }
           set
           {
               _NewSMTFabricationDVS = value;
           }
       }

       public string NewComponentPartDVS
       {
           get
           {
               return _NewComponentPartDVS;
           }
           set
           {
               _NewComponentPartDVS = value;
           }
       }

       public string NewGroupPartDVS
       {
           get
           {
               return _NewGroupPartDVS;
           }
           set
           {
               _NewGroupPartDVS = value;
           }
       }

       public string NewBondingFabricationDVS
       {
           get
           {
               return _NewBondingFabricationDVS;
           }
           set
           {
               _NewBondingFabricationDVS = value;
           }
       }
    }
}
