#pragma warning disable 1591
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
// Code is generated by Telerik Add OpenAccess Service Wizard
// using Astoria3DataService.tt template

namespace MyERP.Web
{
	using System.Data.Services;
	using System.Data.Services.Common;
	using Telerik.OpenAccess.DataServices;
	using System;
	using System.Linq;
	using System.Linq.Expressions;
	using System.Collections;
	using System.Collections.Generic;
	using System.Runtime.Serialization;

	/// <summary>
	/// MyERPDataService service class handler.
	/// </summary>
	[System.ServiceModel.ServiceBehavior(IncludeExceptionDetailInFaults = true)]
	public partial class MyERPDataService : OpenAccessDataService<MyERP.DataAccess.EntitiesModel>
	{
	    /// <summary>
	    /// Initializes the service.
	    /// </summary>
	    /// <param name="config">The configuration object.</param>
	    public static void InitializeService(DataServiceConfiguration config)
	    {
	        config.SetEntitySetAccessRule("Ct11s", EntitySetRights.All);
	        config.SetEntitySetAccessRule("Dmcts", EntitySetRights.All);
	        config.SetEntitySetAccessRule("Dmdvcss", EntitySetRights.All);
	        config.SetEntitySetAccessRule("Dmkhs", EntitySetRights.All);
	        config.SetEntitySetAccessRule("Dmnhkhs", EntitySetRights.All);
	        config.SetEntitySetAccessRule("Dmnhvvs", EntitySetRights.All);
	        config.SetEntitySetAccessRule("Dmnts", EntitySetRights.All);
	        config.SetEntitySetAccessRule("Dmtds", EntitySetRights.All);
	        config.SetEntitySetAccessRule("Dmtks", EntitySetRights.All);
	        config.SetEntitySetAccessRule("Dmtts", EntitySetRights.All);
	        config.SetEntitySetAccessRule("Dmvvs", EntitySetRights.All);
	        config.SetEntitySetAccessRule("Ph11s", EntitySetRights.All);
	        config.SetEntitySetAccessRule("Userinfos", EntitySetRights.All);
	
	        // TODO: Set service behavior configuration options
	        // Examples:
	        // config.DataServiceBehavior.AcceptCountRequests = true;
	        // config.DataServiceBehavior.AcceptProjectionRequests = true;
	        config.DataServiceBehavior.MaxProtocolVersion = DataServiceProtocolVersion.V3;
	    }
	}
}
#pragma warning restore 1591