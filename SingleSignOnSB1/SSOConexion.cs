using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SingleSignOnSB1
{
    class SSOConexion
    {

        private SAPbouiCOM.Application SBO_Application;
        private SAPbobsCOM.Company oCompany;

        private void SetApplication()
        {
            SAPbouiCOM.SboGuiApi sboGuiApi;
            string sConnectionString;

            sboGuiApi = new SAPbouiCOM.SboGuiApi();

            // by following the steps specified above, the following
            // statment should be suficient for either development or run mode
            sConnectionString = "0030002C0030002C00530041005000420044005F00440061007400650076002C0050004C006F006D0056004900490056";
            // connect to a running SBO Application
            sboGuiApi.Connect(sConnectionString);

            // get an initialized application object
            SBO_Application = sboGuiApi.GetApplication(-1);
        }

        public SSOConexion()
        {
            try
            {
                SetApplication();

                oCompany = new SAPbobsCOM.Company();

                oCompany = (SAPbobsCOM.Company)SBO_Application.Company.GetDICompany();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}
