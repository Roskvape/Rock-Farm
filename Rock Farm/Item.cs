using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WallDefense
{
    class Item
    {
        private string sItemSymbol;
        private string sItemName;
        private int iItemSize;
        private string sItemType;

        //Constructor
        public Item(string _sItemSymbol)
        {
            sItemSymbol = Legends.dicItemLegend[_sItemSymbol].ItemSymbol;
            sItemName = Legends.dicItemLegend[_sItemSymbol].ItemName;
            iItemSize = Legends.dicItemLegend[_sItemSymbol].ItemSize;
            sItemType = Legends.dicItemLegend[_sItemSymbol].ItemType;
        }

        public Item(string _sItemSymbol, string _sItemName, int _iItemSize, string _sItemType)
        {
            sItemSymbol = _sItemSymbol;
            sItemName = _sItemName;
            iItemSize = _iItemSize;
            sItemType = _sItemType;
        }

        public string ItemSymbol
        {
            get
            {
                return sItemSymbol;
            }
        }

        public string ItemName
        {
            get
            {
                return sItemName;
            }
        }

        public int ItemSize
        {
            get
            {
                return iItemSize;
            }
        }

        public string ItemType
        {
            get
            {
                return sItemType;
            }
        }
    }
}
