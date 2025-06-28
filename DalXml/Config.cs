using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Dal;

internal static class Config
{
    private const string FILE_PATH = @"..\xml\data-config.xml";
    //private const string CODE_PRODUCT = "codeProduct";
    //private const string CODE_SALE = "codeSale";
    //private static XElement configXml = XElement.Load(FILE_PATH);

    public static int CodeProduct
    {
        get
        {
            //int codeProduct = int.Parse(configXml.Element(CODE_PRODUCT)?.Value ?? "150");
            //codeProduct++;
            //configXml.Element(CODE_PRODUCT)?.SetValue(codeProduct);
            //configXml.Save(FILE_PATH);
            //return codeProduct;

            XElement xml = XElement.Load(FILE_PATH);
            int nextId = (int)xml.Element("CodeProduct");
            xml.Element("CodeProduct").SetValue((nextId + 1).ToString());
            xml.Save(FILE_PATH);
            return nextId;
        }
    }


    public static int CodeSale
    {
        get
        {
            XElement xml = XElement.Load(FILE_PATH);
            int nextId = (int)xml.Element("CodeSale");
            xml.Element("CodeSale").SetValue((nextId + 1).ToString());
            xml.Save(FILE_PATH);
            return nextId;
        }
    }
}
