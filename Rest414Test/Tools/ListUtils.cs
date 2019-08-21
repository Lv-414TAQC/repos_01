using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rest414Test.Tools
{
    public sealed class ListUtils
    {
        private ListUtils()
        {
        }

        public static object[] ToMultiArray(object argList)
        {
            IList list = ((IList)argList);
            object[] array = new object[list.Count];
            for (int i = 0; i < list.Count; i++)
            {
                array[i] = new object[] { list[i] };
            }
            return array;
        }

        public static object[] ToMultiArray(object argList, object source)
        {
            IList list = ((IList)argList);
            object[] array = new object[list.Count];
            for (int i = 0; i < list.Count; i++)
            {
                array[i] = new object[] { list[i], source };
            }
            return array;
        }

    }
}
