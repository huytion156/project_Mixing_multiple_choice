using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;
using System.IO;

namespace TronTracNghiem.Tut
{
    static class ContentLoading
    {
        public static string GetXmlContent_user()
        {
            Assembly assembly = Assembly.GetExecutingAssembly();
            const string NAME = "TronTracNghiem.Tut.Myuser.xml";
            using (Stream stream=assembly.GetManifestResourceStream(NAME))
            {
                using (StreamReader reader=new StreamReader(stream))
                {
                    return reader.ReadToEnd();
                }
            }
        }

    }
}
