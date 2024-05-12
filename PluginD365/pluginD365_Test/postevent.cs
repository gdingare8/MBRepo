using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ServiceModel;
using Microsoft.Xrm.Sdk;
using System.Runtime.Serialization;

namespace pluginD365_Test
{
     class postevent : IPlugin
    {
        public void Execute(IServiceProvider oServiceProvider)
        {
            ITracingService oITracingService = (ITracingService)oServiceProvider.GetService(typeof(ITracingService));
            IPluginExecutionContext oIpluginExecutionContext = (IPluginExecutionContext)oServiceProvider.GetService(typeof(IPluginExecutionContext));
            if (oIpluginExecutionContext.InputParameters.Contains("Target") && oIpluginExecutionContext.InputParameters["Target"] is Entity)
            {
                //Obtain target Entity
                Entity oEntity = (Entity)oIpluginExecutionContext.InputParameters["Target"];
                string sharedvariable = oIpluginExecutionContext.SharedVariables["test"].ToString();
                //update created entity(this will be updated only when you register plugin as pre-operation)
                oEntity["cr353_desciption"] = "Created by user " + oIpluginExecutionContext.UserId;

                ////Create task activity to followup with customer after 7 days
                //Entity followup = new Entity("task");

                //followup["subject"] = "Send e-mail to the new customer.";
                //followup["description"] =
                //"Follow up with the customer. Check if there are any new issues that need resolution.";
                //followup["scheduledstart"] = DateTime.Now.AddDays(7);
                //followup["scheduledend"] = DateTime.Now.AddDays(7);
                //followup["category"] = oIpluginExecutionContext.PrimaryEntityName;

                //// Refer to the account in the task activity.
                //if (oIpluginExecutionContext.OutputParameters.Contains("id"))
                //{
                //    Guid regardingobjectid = new Guid(oIpluginExecutionContext.OutputParameters["id"].ToString());
                //    string regardingobjectidType = "account";

                //    followup["regardingobjectid"] =
                //    new EntityReference(regardingobjectidType, regardingobjectid);
                //}

                ////Create organization service
                //IOrganizationServiceFactory serviceFactory = (IOrganizationServiceFactory)oServiceProvider.GetService(typeof(IOrganizationServiceFactory));
                //IOrganizationService service = serviceFactory.CreateOrganizationService(oIpluginExecutionContext.UserId);
                //service.Create(followup);
            }
        }
    }
}
