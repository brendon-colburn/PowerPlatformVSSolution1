
// <copyright file="PostOperationbac_trainingrequestCreate.cs" company="">
// Copyright (c) 2021 All Rights Reserved
// </copyright>
// <author></author>
// <date>8/20/2021 2:54:10 PM</date>
// <summary>Implements the PostOperationbac_trainingrequestCreate Plugin.</summary>
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.1
// </auto-generated>

using System;
using System.ServiceModel;
using Microsoft.Crm.Sdk.Messages;
using Microsoft.Xrm.Sdk;

namespace PowerPlatformVSSolution1.DCMTC
{

    /// <summary>
    /// PostOperationbac_trainingrequestCreate Plugin.
    /// </summary>    
    public class PostOperationbac_trainingrequestCreate: PluginBase
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="PostOperationbac_trainingrequestCreate"/> class.
        /// </summary>
        /// <param name="unsecure">Contains public (unsecured) configuration information.</param>
        /// <param name="secure">Contains non-public (secured) configuration information. 
        /// When using Microsoft Dynamics 365 for Outlook with Offline Access, 
        /// the secure string is not passed to a plug-in that executes while the client is offline.</param>
        public PostOperationbac_trainingrequestCreate(string unsecure, string secure)
            : base(typeof(PostOperationbac_trainingrequestCreate))
        {
            
           // TODO: Implement your custom configuration handling.
        }


        /// <summary>
        /// Main entry point for he business logic that the plug-in is to execute.
        /// </summary>
        /// <param name="localContext">The <see cref="LocalPluginContext"/> which contains the
        /// <see cref="IPluginExecutionContext"/>,
        /// <see cref="IOrganizationService"/>
        /// and <see cref="ITracingService"/>
        /// </param>
        /// <remarks>
        /// For improved performance, Microsoft Dynamics 365 caches plug-in instances.
        /// The plug-in's Execute method should be written to be stateless as the constructor
        /// is not called for every invocation of the plug-in. Also, multiple system threads
        /// could execute the plug-in at the same time. All per invocation state information
        /// is stored in the context. This means that you should not use global variables in plug-ins.
        /// </remarks>
        protected override void ExecuteCdsPlugin(ILocalPluginContext localContext)
        {
            if (localContext == null)
            {
                throw new InvalidPluginExecutionException(nameof(localContext));
            }           
            // Obtain the tracing service
            ITracingService tracingService = localContext.TracingService;

            try
            { 
                // Obtain the execution context from the service provider.  
                IPluginExecutionContext context = (IPluginExecutionContext)localContext.PluginExecutionContext;

                // Obtain the organization service reference for web service calls.  
                IOrganizationService currentUserService = localContext.CurrentUserService;

                if (context.Depth > 1) return;
                currentUserService.Create(new bac_Expense()
                {
                    bac_TrainingRequest = new EntityReference("bac_trainingrequest", context.PrimaryEntityId),
                    bac_Cost = new Money(300),
                    bac_Name = "Everything Costs $300"
                });

                currentUserService.Execute(new CalculateRollupFieldRequest()
                {
                    FieldName = "bac_totalcost",
                    Target = new EntityReference("bac_trainingrequest", context.PrimaryEntityId)
                });
            }	
            // Only throw an InvalidPluginExecutionException. Please Refer https://go.microsoft.com/fwlink/?linkid=2153829.
            catch (Exception ex)
            {
                tracingService?.Trace("An error occurred executing Plugin PowerPlatformVSSolution1.DCMTC.PostOperationbac_trainingrequestCreate : {0}", ex.ToString());
                throw new InvalidPluginExecutionException("An error occurred executing Plugin PowerPlatformVSSolution1.DCMTC.PostOperationbac_trainingrequestCreate .", ex);
            }	
        }
    }
}
