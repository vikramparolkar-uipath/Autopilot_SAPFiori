using Autopilot_SAPFiori.ObjectRepository;
using System;
using System.Collections.Generic;
using System.Data;
using UiPath.CodedWorkflows;
using UiPath.Core;
using UiPath.Core.Activities.Storage;
using UiPath.Excel;
using UiPath.Excel.Activities;
using UiPath.Excel.Activities.API;
using UiPath.Excel.Activities.API.Models;
using UiPath.Orchestrator.Client.Models;
using UiPath.Testing;
using UiPath.Testing.Activities.TestData;
using UiPath.Testing.Activities.TestDataQueues.Enums;
using UiPath.Testing.Enums;
using UiPath.UIAutomationNext.API.Contracts;
using UiPath.UIAutomationNext.API.Models;
using UiPath.UIAutomationNext.Enums;

namespace Autopilot_SAPFiori
{
    public class VerifyPOLookupInFiori : CodedWorkflow
    {
        [TestCase]
        public void Execute()
        {
            Log("Test run started for CodedTestCase.");
            var in_PurchaseOrder = "4500000411";
            var SAPusername = "S4H_MM";
            var SAPpasswordunsecure = "Welcome1";
            //Open SAP Fiori to Logon Screen
            var sapFioriApp = uiAutomation.Open("Logon Screen", "SAP Fiori");
            // Get Credentials 'SAP Credentials MM'
            //string SAPusername = system. GetCredential("SAP Credentials MM", out var SAPpassword);
            // Enter Username into Username field
            sapFioriApp.TypeInto("Username", SAPusername);
            // Convert SAPpassword into a string
            //string SAPpasswordunsecure = new NetworkCredential("", SAPpassword).Password;
            // Enter SAPpassword as a Secure String into Password field
            sapFioriApp.TypeInto("Password", SAPpasswordunsecure);
            // Click Log On
            sapFioriApp.Click("Log On");
            // Click the Search Icon
            var homeScreen = uiAutomation.Attach("Home Screen", "SAP Fiori");
            homeScreen.Click("DismissPopup");
            homeScreen.Click("DismissPopup");
            homeScreen.Click("Search Icon");
            // Type "Manage Purchase Orders" into the Search Bar
            homeScreen.TypeInto("Search Bar", "Manage Purchase Orders");
            // Hit Enter Key
            homeScreen.KeyboardShortcut("Search Bar", "[d(hk)][k(enter)] [u(hk)]");
            // Click the Manage Purchase Order Tile
            var SearchScreen = uiAutomation.Attach("Search Screen", "SAP Fiori");
            SearchScreen.Click("Manage Purchase Order Tile");
            // Type Purchase Order (input argument) into the Purchase Order
            var ManagePOScreen = uiAutomation.Attach("Manage Purchase Orders", "SAP Fiori");
            ManagePOScreen.TypeInto("Purchase Order", in_PurchaseOrder);
            // Click Go
            ManagePOScreen.Click("Go");
            // Double Click on Purchase Order # Input
            ManagePOScreen.Click("Purchase Order # Input", NClickType.Double);
            // Extract data from PO Item Table and output as a datatable argument
        }
    }
}