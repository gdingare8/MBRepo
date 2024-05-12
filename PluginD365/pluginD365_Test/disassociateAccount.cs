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
     class disassociateAccount : IPlugin
    {
        public void Execute(IServiceProvider oServiceProvider)
        {
            ITracingService oITracingService = (ITracingService)oServiceProvider.GetService(typeof(ITracingService));
            IPluginExecutionContext oIpluginExecutionContext = (IPluginExecutionContext)oServiceProvider.GetService(typeof(IPluginExecutionContext));
            if (oIpluginExecutionContext.InputParameters.Contains("Target") && oIpluginExecutionContext.InputParameters["Target"] is Entity)
            {
                //Obtain target Entity
                Entity oEntity = (Entity)oIpluginExecutionContext.InputParameters["Target"];

                //update created entity(this will be updated only when you register plugin as pre-operation)
                oEntity["cr353_desciption"] = "Created by user " + oIpluginExecutionContext.UserId;

            }
        }
    }
}