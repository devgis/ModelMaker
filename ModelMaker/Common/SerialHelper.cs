using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DEVGIS.ModelMaker.Common
{
    public class SerialHelper
    {
        public static object LoadFromXML(string fileName,Type t)
        {
            object o = null;
            System.IO.FileStream fs = null;
            try
            {
                System.Xml.Serialization.XmlSerializer serializer
                    = new System.Xml.Serialization.XmlSerializer(t);
                fs = new System.IO.FileStream(fileName, System.IO.FileMode.Open);
                o = (object)serializer.Deserialize(fs);
            }
            catch
            {
                throw new Exception("文件无法正确读取！");
            }
            finally
            {
                if (fs != null)
                {
                    fs.Close();
                }
            }

            return o;
        }

        public static bool SaveToXML(string fileName, System.Type type, object target)
        {
            System.Xml.Serialization.XmlSerializer serializer = null;
            System.IO.StreamWriter writer = null;
            bool isSaved = false;

            try
            {
                writer = new System.IO.StreamWriter(fileName, false);
                serializer = new System.Xml.Serialization.XmlSerializer(type);
                serializer.Serialize(writer, target);
                isSaved = true;
            }
            catch (System.Exception ex)
            {
                throw new Exception("保存数据出错！");
            }
            finally
            {
                if (writer != null)
                {
                    writer.Close();
                }
            }

            return isSaved;
       }


    }
}
