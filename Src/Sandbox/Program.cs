using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sandbox
{
    class Program
    {
        private string json =
@"{
   'id': 1242,
   'name': 'iPhone Skin - Devil Whale',
   'options': {
     'Model': ['6', '6S'],
     'Size': ['S', 'M', 'L']
   },
   'variants': [
     {
       'id': 124427,
       'options': {
         'Model': '6',
         'Size': 'S'
       }
     },
     {
       'id': 124428,
       'options': {
         'Model': '6S',
         'Size': 'M'
       }
     }
   ]
 }";

        static void Main(string[] args)
        {
        }
    }
}
