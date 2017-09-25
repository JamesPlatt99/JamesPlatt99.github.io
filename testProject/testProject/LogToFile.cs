using System;
using System.IO;

namespace testProject
{
    class LogToFile
    {
        public void WriteText(String text)
        {
            using (System.IO.StreamWriter file =
            new System.IO.StreamWriter("log.txt",true))
            {
                file.WriteLine(text);
            }
        }
        public void ClearLog()
        {
            File.WriteAllText("log.txt","");
        }
    }
}
