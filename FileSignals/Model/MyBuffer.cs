using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FileSignals.Model
{
    class MyBuffer
    {
        private int _Length;
        private static string _Data = "";

        public bool Write( string data )
        {
            if ( Data.Length < 32 )
            {
                Data += data;
                return true;
            }
            else
                return false;
        }
        public string Read( int bytes )
        {
            string temp = Data.Substring( 0, bytes );
            Data.Remove(0, bytes );
            //Data.Replace( temp, "" );
            return temp;  
        }

        //Setters - Getters
        public static string Data
        {
            get
            {
                return _Data;
            }
            set
            {
                _Data = value;
            }
        }
        
        public int Length
        {
            get
            {
                return _Length;
            }
            set
            {
                _Length = value;
            }
        }
        
    }
}
