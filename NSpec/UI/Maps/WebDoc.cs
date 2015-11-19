using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ranorex;

namespace UI_Ranorex.Maps
{
    public class WebDoc
    {
        private WebDocument _doc;
        private static WebDoc _instance;

        private WebDoc()
        {
            _doc = "/dom[@domain='localhost:8057']";  
            _doc.WaitForDocumentLoaded();
        }

        public static WebDoc instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new WebDoc();
                }

                return _instance;
            }
        }

        public WebDocument doc
        {
            get
            {
                return _doc;
            }
        }
    }
}
