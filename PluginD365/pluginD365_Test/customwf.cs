using System.Threading.Tasks;
using System.ServiceModel;
using System.Runtime.Serialization;
using Microsoft.Xrm.Sdk.Workflow;
using System.Activities;
using Microsoft.Xrm.Sdk;
using System;

namespace pluginD365_Test
{
    public class customwf : CodeActivity
    {
        [RequiredArgument]
        [Input("input text")]
        public InArgument<string> InputText { get; set; }

        [Output("output text")]
        public OutArgument<int> CountOfWords { get; set; }
        protected override void Execute(CodeActivityContext context)
        {
            this.CountOfWords.Set(
                context,
                this.InputText.Get<string>(context).Split(
                    new char[] { ' ', '\r', '\n' },
                    StringSplitOptions.RemoveEmptyEntries).Length);
        }
    }
}
