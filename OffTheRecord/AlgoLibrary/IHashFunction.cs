using System;
using System.Collections.Generic;
using System.Text;

namespace AlgoLibrary
{
    interface IHashFunction
    {
        public byte[] ComputeHash(byte[] input);
        public string ComputeHash(string input);
    }
}
