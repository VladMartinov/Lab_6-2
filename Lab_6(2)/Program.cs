using System;
using System.IO;
class BinaryRW
{
    static void Main()
    {
        string path = @"C:\SomeDir2";
        string path2 = @"C:\SomeDir2\Test1.dat";
        string path3 = @"C:\SomeDir2\Test2.dat";
        DirectoryInfo dirInfo = new DirectoryInfo(path);
        if (!dirInfo.Exists)
        {
            dirInfo.Create();
        }
        using (BinaryWriter writer = new BinaryWriter(File.Open(path2, FileMode.OpenOrCreate)))
        {
            for (int i = 1; i <= 128; i++)
            {
                writer.Write(i);
                writer.Write(Math.Log(i, 2.0));
            }
            writer.Close();
        }
        using (BinaryReader writer1 = new BinaryReader(File.Open(path2, FileMode.Open)))
        using (BinaryWriter writer2 = new BinaryWriter(File.Open(path3, FileMode.OpenOrCreate)))
            while (writer1.BaseStream.Position != writer1.BaseStream.Length)
            {               
                writer1.BaseStream.Position += 4;
                writer2.Write(writer1.ReadDouble());
            }
        using (BinaryReader reader = new BinaryReader(File.Open(path3, FileMode.Open)))
        {
            while (reader.PeekChar() > -2)
            {
                double age = reader.ReadDouble();
                Console.WriteLine(age);
            }
        }
    }
}