using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Calendar.Cls
{
    class Item
    {
        private int id;
        private string texto;

        public Item(string texto, int id)
        {
            this.id = id;
            this.texto = texto;
        }

        public int ID 
        {
            get
            {
                return this.id;
            }
            set
            {
                this.id = value;
            }
        }

        public string Texto 
        {
            get
            {
                return this.texto;
            }
            set
            {
                this.texto = value;
            } 
        }
    }
}
