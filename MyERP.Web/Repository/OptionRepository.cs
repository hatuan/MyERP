﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic;
using System.Security.Principal;
using System.Web;
using System.Web.Security;
using Ext.Net;
using MyERP.DataAccess;
using MyERP.DataAccess.Enum;

namespace MyERP.Web
{
    public partial class OptionRepository 
    {
        public Paging<Option> Paging(StoreRequestParameters parameters)
        {
            return Paging(parameters.Start, parameters.Limit, parameters.SimpleSort, parameters.SimpleSortDirection, null);
        }

        public  Paging<Option> Paging(int start, int limit, string sort, SortDirection dir, string filter)
        {
            var entities = Get(includePaths: new String[] { "Organization", "Client", "RecCreatedByUser", "RecModifiedByUser"});

            if (!string.IsNullOrEmpty(sort))
                entities = dir == SortDirection.ASC ? entities.OrderBy(sort) : entities.OrderBy(sort + " DESC");
            else
                entities = entities.OrderBy(x => x.Organization.Code);

            var count = entities.ToList().Count;
            var ranges = (start < 0 || limit <= 0) ? entities.ToList() : entities.Skip(start).Take(limit).ToList();

            return new Paging<Option>(ranges, count);
        }

        public dynamic OptionParameter(Int64 orgId, OptionParameter optionParameter)
        {
            var organizationRepository = new OrganizationRepository();
            var organization = organizationRepository.Get(x => x.Id == orgId).SingleOrDefault();
            if (organization == null)
                return 0;

            var rootOrganization = organizationRepository.GetRootOrganization(organization);
            if (rootOrganization == null)
                return 0;

            var option = this.Get(x => x.OrganizationId == orgId).SingleOrDefault();
            if (option == null)
            {
                var rootOption = this.Get(x => x.OrganizationId == rootOrganization.Id).SingleOrDefault();

                switch (optionParameter)
                {
                    case DataAccess.Enum.OptionParameter.SalesPosLocationId:
                        return rootOption?.SalesPosLocationId ?? 0;
                    case DataAccess.Enum.OptionParameter.OneTimeBusinessPartnerId:
                        return rootOption?.OneTimeBusinessPartnerId ?? 0;
                }
                
            }
            else
            {
                switch (optionParameter)
                {
                    case DataAccess.Enum.OptionParameter.OneTimeBusinessPartnerId:
                        if (option.OneTimeBusinessPartnerId == null)
                        {
                            var rootOption = this.Get(x => x.OrganizationId == rootOrganization.Id).SingleOrDefault();
                            return rootOption?.OneTimeBusinessPartnerId ?? 0;
                        }
                        else
                        {
                            return option?.OneTimeBusinessPartnerId ?? 0;

                        }
                    case DataAccess.Enum.OptionParameter.SalesPosLocationId:
                        if (option.SalesPosLocationId == null)
                        {
                            var rootOption = this.Get(x => x.OrganizationId == rootOrganization.Id).SingleOrDefault();
                            return rootOption?.SalesPosLocationId ?? 0;
                        }
                        else
                        {
                            return option?.OneTimeBusinessPartnerId ?? 0;

                        }
                    case DataAccess.Enum.OptionParameter.SalesPosSequenceId:
                        if (option.OneTimeBusinessPartnerId == null)
                        {
                            var rootOption = this.Get(x => x.OrganizationId == rootOrganization.Id).SingleOrDefault();
                            return rootOption?.SalesPosSequenceId ?? 0;
                        }
                        else
                        {
                            return option?.SalesPosSequenceId ?? 0;

                        }
                    case DataAccess.Enum.OptionParameter.SalesInvoiceSeqId:
                        if (option.OneTimeBusinessPartnerId == null)
                        {
                            var rootOption = this.Get(x => x.OrganizationId == rootOrganization.Id).SingleOrDefault();
                            return rootOption?.SalesInvoiceSeqId ?? 0;
                        }
                        else
                        {
                            return option?.SalesInvoiceSeqId ?? 0;

                        }
                    case DataAccess.Enum.OptionParameter.SalesOrderSequenceId:
                        if (option.OneTimeBusinessPartnerId == null)
                        {
                            var rootOption = this.Get(x => x.OrganizationId == rootOrganization.Id).SingleOrDefault();
                            return rootOption?.SalesOrderSequenceId ?? 0;
                        }
                        else
                        {
                            return option?.SalesOrderSequenceId ?? 0;

                        }
                    case DataAccess.Enum.OptionParameter.SalesShipmentSeqId:
                        if (option.OneTimeBusinessPartnerId == null)
                        {
                            var rootOption = this.Get(x => x.OrganizationId == rootOrganization.Id).SingleOrDefault();
                            return rootOption?.SalesShipmentSeqId ?? 0;
                        }
                        else
                        {
                            return option?.SalesShipmentSeqId ?? 0;

                        }
                    case DataAccess.Enum.OptionParameter.PurchOrderSequenceId:
                        if (option.OneTimeBusinessPartnerId == null)
                        {
                            var rootOption = this.Get(x => x.OrganizationId == rootOrganization.Id).SingleOrDefault();
                            return rootOption?.PurchOrderSequenceId ?? 0;
                        }
                        else
                        {
                            return option?.PurchOrderSequenceId ?? 0;

                        }
                    case DataAccess.Enum.OptionParameter.PurchReceiveSeqId:
                        if (option.OneTimeBusinessPartnerId == null)
                        {
                            var rootOption = this.Get(x => x.OrganizationId == rootOrganization.Id).SingleOrDefault();
                            return rootOption?.PurchReceiveSeqId ?? 0;
                        }
                        else
                        {
                            return option?.PurchReceiveSeqId ?? 0;

                        }
                    case DataAccess.Enum.OptionParameter.PurchInvoiceSeqId:
                        if (option.OneTimeBusinessPartnerId == null)
                        {
                            var rootOption = this.Get(x => x.OrganizationId == rootOrganization.Id).SingleOrDefault();
                            return rootOption?.PurchInvoiceSeqId ?? 0;
                        }
                        else
                        {
                            return option?.PurchInvoiceSeqId ?? 0;

                        }
                }
            }

            return 0;
        }
    }

}