using System;
using System.Collections.Generic;
using System.Text;

namespace STPMS11
{
    class Train : IComparable<Train>
    {
        private int h;
        private int m;
        private string town;
        private string time;
        public int H
        {
            get
            {
                return h;
            }
            set
            {
                h = value;
            }
        }
        public int M
        {
            get
            {
                return m;
            }
            set
            {
                m = value;
            }
        }
        public string Town
        {
            get
            {
                return town;
            }
            set
            {
                town = value;
            }
        }
        public string Time
        {
            get
            {
                return time;
            }
            set
            {
                time = value;
            }
        }
        public int CompareTo(Train a)
        {
            return (this.H * 60 + this.M).CompareTo(a.H * 60 + a.M);
        }
        public override string ToString()
        {
            return "[" + Time + "] Hours: " + H + " Mins: " + M + " " + " Пункт назначения: " + Town + " ";
        }
    }
}