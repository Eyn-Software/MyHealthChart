using System;
using System.Collections.Generic;
using System.Text;

namespace MyHealthChart3.Models
{
    /*
    public enum State
    {
        AL, AK, AZ, AR, CA, CO, CT, DE, FL,
        GA, HI, ID, IL, IN, IA, KS, KY, LA,
        ME, MD, MA, MI, MN, MS, MO, MT, NE,
        NV, NH, NJ, NM, NY, NC, ND, OH, OK,
        OR, PA, RI, SC, SD, TN, TX, UT, VT,
        VA, WA, WV, WI, WY
    }
    */
    public class Address
    {
        public string StreetAddress;
        public string City;
        public State State;
        public int Zip;
    }
}
