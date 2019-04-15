using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Linq.Dynamic;
using System.Linq.Expressions;
using System.Text;
using System.Web;
using System.Xml;
using System.Xml.Serialization;
using Ext.Net;
using MyERP.DataAccess;
using MyERP.DataAccess.Enum;
using MyERP.Web.Models;
using MyERP.Web.Others;

namespace MyERP.Web
{
    public partial class EInvFormReleaseRepository
    {
        public Paging<EInvFormRelease> Paging(StoreRequestParameters parameters)
        {
            return Paging(parameters.Start, parameters.Limit, parameters.SimpleSort, parameters.SimpleSortDirection);
        }

        public Paging<EInvFormRelease> Paging(int start, int limit, string sort, SortDirection dir)
        {
            var entities = Get(includePaths: new String[] { "Organization", "Client", "RecCreatedByUser", "RecModifiedByUser", "EInvFormType" });

            if (!string.IsNullOrEmpty(sort))
                entities = dir == SortDirection.ASC ? entities.OrderBy(sort) : entities.OrderBy(sort + " DESC");
            else
                entities = entities.OrderBy("ReleaseDate");

            var count = entities.ToList().Count;
            var ranges = (start < 0 || limit <= 0) ? entities.ToList() : entities.Skip(start).Take(limit).ToList();

            return new Paging<EInvFormRelease>(ranges, count);
        }
    }

    public partial class EInvFormTypeRepository 
    {
        public Paging<EInvFormType> Paging(StoreRequestParameters parameters)
        {
            return Paging(parameters.Start, parameters.Limit, parameters.SimpleSort, parameters.SimpleSortDirection);
        }

        public Paging<EInvFormType> Paging(int start, int limit, string sort, SortDirection dir)
        {
            var entities = Get(includePaths: new String[] { "Organization", "Client", "RecCreatedByUser", "RecModifiedByUser" });

            if (!string.IsNullOrEmpty(sort))
                entities = dir == SortDirection.ASC ? entities.OrderBy(sort) : entities.OrderBy(sort + " DESC");
            else
                entities = entities.OrderBy("RecCreatedAt");

            var count = entities.ToList().Count;
            var ranges = (start < 0 || limit <= 0) ? entities.ToList() : entities.Skip(start).Take(limit).ToList();

            return new Paging<EInvFormType>(ranges, count);
        }

        public bool HasOtherLargerReleaseOfFormType(decimal releaseTo, long formTypeId)
        {
            try
            {
                var formType = Get(includePaths: new String[] { "EInvFormReleases" }).First(x => x.Id == formTypeId);
                var othersLarger = formType.EInvFormReleases.Where(x => x.ReleaseFrom >= releaseTo);
                return othersLarger.Any();
            }
            catch (Exception ex)
            {
                return true;
            }
        }

        public decimal GetMaxReleaseOfFormType(long formTypeId, long formReleaseId)
        {
            try
            {
                var formType = Get(includePaths: new String[] {"EInvFormReleases"}).First(x => x.Id == formTypeId);
                var maxFormReleaseTo = formType.EInvFormReleases.Where(x => x.Id != formReleaseId).Max(x => x.ReleaseTo);
                return maxFormReleaseTo;
            }
            catch (Exception ex)
            {
                return 0;
            }
        }

        public string GetNextReleaseNo(long formTypeId, DateTime invoiceIssuedDate)
        {
            var formType = Get(includePaths: new String[] { "EInvFormReleases" }).First(x => x.Id == formTypeId);
            var formRelease = formType.EInvFormReleases.Where(x => x.StartDate.CompareTo(invoiceIssuedDate) >= 0 
                                                                   && (TaxAuthoritiesStatus) x.TaxAuthoritiesStatus == TaxAuthoritiesStatus.Active);
            
            return "";
        }
    }

    public partial class EInvoiceHeaderRepository 
    {
        public Paging<EInvoiceHeader> Paging(StoreRequestParameters parameters)
        {
            return Paging(parameters.Start, parameters.Limit, parameters.SimpleSort, parameters.SimpleSortDirection);
        }

        public Paging<EInvoiceHeader> Paging(int start, int limit, string sort, SortDirection dir)
        {
            var entities = Get(includePaths: new String[] { "Organization", "Client", "RecCreatedByUser", "RecModifiedByUser", "Buyer", "Currency" });

            if (!string.IsNullOrEmpty(sort))
                entities = dir == SortDirection.ASC ? entities.OrderBy(sort) : entities.OrderBy(sort + " DESC");
            else
                entities = entities.OrderBy("InvoiceIssuedDate");

            var count = entities.ToList().Count;
            var ranges = (start < 0 || limit <= 0) ? entities.ToList() : entities.Skip(start).Take(limit).ToList();

            return new Paging<EInvoiceHeader>(ranges, count);
        }

        public string SetEInvNumber(long id)
        {
            return "";
        }

        public string Print(EInvoiceHeader entity)
        {
            var formTypeRepository = new EInvFormTypeRepository();
            var formType = formTypeRepository.Get(x => x.Id == entity.FormTypeId).First();
            String formVars = Encoding.UTF8.GetString(Convert.FromBase64String(formType.FormVars));
            String formFile = Encoding.UTF8.GetString(Convert.FromBase64String(formType.FormFile));

            using (StringReader sri = new StringReader(formVars))
            {
                EInvXMLInvoiceInfo invoiceInfo = new EInvXMLInvoiceInfo();
                XmlSerializer serializer = new XmlSerializer(invoiceInfo.GetType());
                invoiceInfo = (EInvXMLInvoiceInfo)serializer.Deserialize(sri);
                invoiceInfo.InvoiceDataInfo.InvoiceType = formType.InvoiceType;
                invoiceInfo.InvoiceDataInfo.InvoiceSeries = formType.InvoiceSeries.ToUpper();
                invoiceInfo.InvoiceDataInfo.TemplateCode = formType.InvoiceType + "0/" + formType.InvoiceTypeNo;

                XmlWriterSettings settings = new XmlWriterSettings()
                {
                    Encoding = new UTF8Encoding(false),
                    Indent = true
                };
                using (MemoryStream sww = new MemoryStream())
                {
                    using (System.Xml.XmlWriter writer = System.Xml.XmlWriter.Create(sww, settings))
                    {
                        XmlSerializerNamespaces ns = new XmlSerializerNamespaces();
                        ns.Add("inv", "http://laphoadon.gdt.gov.vn/2014/09/invoicexml/v1");
                        //ns.Add("ns1", "http://www.w3.org/2000/09/xmldsig#");
                        XmlSerializer xsSubmit = new XmlSerializer(invoiceInfo.GetType());
                        xsSubmit.Serialize(writer, invoiceInfo, ns);
                        byte[] textAsBytes = sww.ToArray(); //Encoding.UTF8.GetBytes(Encoding.Default.GetString(sww.ToArray()));
                        formVars = Encoding.UTF8.GetString(textAsBytes);
                    }
                }
            }

            return "";
        }
    }

    public partial class EInvoiceLineRepository 
    {
        public void Update(string columnName, long currencyLcyId, ref EInvHeaderEditViewModel eInvoiceHeader, ref EInvLineEditViewModel eInvoiceLine)
        {
            switch (columnName)
            {
                case "Quantity":
                case "UnitPrice":
                    {
                        eInvoiceLine.ItemTotalAmountWithoutVAT = Round.RoundAmount(eInvoiceLine.Quantity * eInvoiceLine.UnitPrice);

                        CalcVatBaseAmount(ref eInvoiceLine);

                        eInvoiceLine.ItemTotalAmountWithVAT =
                            eInvoiceLine.ItemTotalAmountWithoutVAT + eInvoiceLine.VATAmount;

                        if (eInvoiceHeader.CurrencyId == currencyLcyId)
                        {
                            eInvoiceLine.ItemTotalAmountWithoutVAT = eInvoiceLine.ItemTotalAmountWithoutVATLCY =
                                Round.RoundUnitAmountLCY(eInvoiceLine.ItemTotalAmountWithoutVAT);

                            eInvoiceLine.UnitPrice = eInvoiceLine.UnitPriceLCY = Round.RoundUnitAmountLCY(eInvoiceLine.UnitPrice);

                            SetVatBaseAmountToLCY(ref eInvoiceLine);

                            eInvoiceLine.ItemTotalAmountWithVAT = eInvoiceLine.ItemTotalAmountWithVATLCY =
                                Round.RoundUnitAmountLCY(eInvoiceLine.ItemTotalAmountWithVAT);
                        }
                        else
                        {
                            if (columnName == "UnitPrice")
                            {
                                eInvoiceLine.UnitPriceLCY = Round.RoundUnitAmountLCY(eInvoiceLine.UnitPrice *
                                                             eInvoiceHeader.ExchangeRate);
                            }

                            eInvoiceLine.ItemTotalAmountWithoutVATLCY =
                                Round.RoundAmount(eInvoiceLine.Quantity * eInvoiceLine.UnitPriceLCY);

                            CalcVatBaseAmountLCY(ref eInvoiceLine);

                            eInvoiceLine.ItemTotalAmountWithVATLCY =
                                eInvoiceLine.ItemTotalAmountWithoutVATLCY + eInvoiceLine.VATAmountLCY;
                        }

                        break;
                    }
                
                case "ItemTotalAmountWithoutVAT":
                    {
                        CalcVatBaseAmount(ref eInvoiceLine);

                        eInvoiceLine.ItemTotalAmountWithVAT =
                            eInvoiceLine.ItemTotalAmountWithoutVAT + eInvoiceLine.VATAmount;

                        if (eInvoiceHeader.CurrencyId == currencyLcyId)
                        {
                            SetVatBaseAmountToLCY(ref eInvoiceLine);

                            eInvoiceLine.ItemTotalAmountWithoutVAT = eInvoiceLine.ItemTotalAmountWithoutVATLCY =
                                Round.RoundUnitAmountLCY(eInvoiceLine.ItemTotalAmountWithoutVAT);
                        }
                        else
                        {
                            eInvoiceLine.ItemTotalAmountWithoutVATLCY =
                                Round.RoundAmount(eInvoiceLine.Quantity * eInvoiceLine.UnitPriceLCY) ;

                            CalcVatBaseAmountLCY(ref eInvoiceLine);

                            eInvoiceLine.ItemTotalAmountWithVATLCY =
                                eInvoiceLine.ItemTotalAmountWithoutVATLCY + eInvoiceLine.VATAmountLCY;
                        }
                        break;
                    }
                case "UnitPriceLCY":
                    {
                        eInvoiceLine.ItemTotalAmountWithoutVATLCY = Round.RoundAmount(eInvoiceLine.Quantity * eInvoiceLine.UnitPriceLCY);
                        
                        CalcVatBaseAmountLCY(ref eInvoiceLine);

                        eInvoiceLine.ItemTotalAmountWithVATLCY =
                            eInvoiceLine.ItemTotalAmountWithoutVATLCY + eInvoiceLine.VATAmountLCY;
                        break;
                    }
                case "ItemTotalAmountWithoutVATLCY":
                    {
                        CalcVatBaseAmountLCY(ref eInvoiceLine);

                        eInvoiceLine.ItemTotalAmountWithVATLCY =
                            eInvoiceLine.ItemTotalAmountWithoutVATLCY + eInvoiceLine.VATAmountLCY;
                        break;
                    }

                case "VATPercentage":
                    {
                        eInvoiceLine.VATAmount = eInvoiceLine.VATPercentage > 0
                            ? Round.RoundAmount(eInvoiceLine.ItemTotalAmountWithoutVAT *
                                                eInvoiceLine.VATPercentage / 100)
                            : 0;
                        eInvoiceLine.VATAmountLCY = eInvoiceLine.VATPercentage > 0
                            ? Round.RoundAmountLCY(eInvoiceLine.ItemTotalAmountWithoutVATLCY *
                                                   eInvoiceLine.VATPercentage / 100)
                            : 0;

                        eInvoiceLine.ItemTotalAmountWithVAT =
                            eInvoiceLine.ItemTotalAmountWithoutVAT + eInvoiceLine.VATAmount;

                        eInvoiceLine.ItemTotalAmountWithVATLCY =
                            eInvoiceLine.ItemTotalAmountWithoutVATLCY + eInvoiceLine.VATAmountLCY;
                        break;
                    }
                case "VATAmount":
                    {
                        if (eInvoiceHeader.CurrencyId == currencyLcyId)
                        {
                            eInvoiceLine.VATAmount = eInvoiceLine.VATAmountLCY =
                                Round.RoundAmountLCY(eInvoiceLine.VATAmount);

                            eInvoiceLine.ItemTotalAmountWithoutVAT = eInvoiceLine.ItemTotalAmountWithoutVATLCY =
                                Round.RoundUnitAmountLCY(eInvoiceLine.ItemTotalAmountWithoutVAT);
                        }
                        else
                        {
                            eInvoiceLine.VATAmountLCY =
                                Round.RoundAmountLCY(eInvoiceLine.VATAmount * eInvoiceHeader.ExchangeRate);

                            eInvoiceLine.ItemTotalAmountWithVATLCY =
                                eInvoiceLine.ItemTotalAmountWithoutVATLCY + eInvoiceLine.VATAmountLCY;
                        }
                        break;
                    }
                case "VATAmountLCY":
                    {
                        eInvoiceLine.ItemTotalAmountWithVATLCY =
                            eInvoiceLine.ItemTotalAmountWithoutVATLCY + eInvoiceLine.VATAmountLCY;

                        break;
                    }
            }
        }

        public void UpdateTotal(ref EInvHeaderEditViewModel eInvoiceHeader)
        {
            eInvoiceHeader.TotalAmountWithoutVAT = eInvoiceHeader.EInvoiceLines.Sum(x => x.ItemTotalAmountWithoutVAT);
            eInvoiceHeader.TotalAmountWithoutVATLCY = eInvoiceHeader.EInvoiceLines.Sum(x => x.ItemTotalAmountWithoutVATLCY);

            eInvoiceHeader.TotalVATAmount = eInvoiceHeader.EInvoiceLines.Sum(x => x.VATAmount);
            eInvoiceHeader.TotalVATAmountLCY = eInvoiceHeader.EInvoiceLines.Sum(x => x.VATAmountLCY);

            eInvoiceHeader.TotalAmountWithVAT = eInvoiceHeader.EInvoiceLines.Sum(x => x.ItemTotalAmountWithVAT);

            eInvoiceHeader.TotalAmountWithVATFrn = eInvoiceHeader.EInvoiceLines.Sum(x => x.ItemTotalAmountWithVATLCY);
        }

        public void CalcVatBaseAmount(ref EInvLineEditViewModel eInvoiceLine)
        {
            eInvoiceLine.VATAmount = eInvoiceLine.VATPercentage > 0
                ? Round.RoundAmount(eInvoiceLine.ItemTotalAmountWithoutVAT *
                                    eInvoiceLine.VATPercentage / 100)
                : 0;

        }

        public void CalcVatBaseAmountLCY(ref EInvLineEditViewModel eInvoiceLine)
        {
            eInvoiceLine.VATAmountLCY = eInvoiceLine.VATPercentage > 0
                ? Round.RoundAmount(eInvoiceLine.ItemTotalAmountWithoutVATLCY *
                                    eInvoiceLine.VATPercentage / 100)
                : 0;

        }

        public void SetVatBaseAmountToLCY(ref EInvLineEditViewModel eInvoiceLine)
        {
            eInvoiceLine.VATAmount = eInvoiceLine.VATAmountLCY =
                Round.RoundAmountLCY(eInvoiceLine.VATAmount);
        }

        public void UpdateRecord(EInvLineEditViewModel eInvoiceLine, ref ModelProxy record)
        {
            record.Set("ItemTotalAmountWithoutVAT", eInvoiceLine.ItemTotalAmountWithoutVAT);
            record.Set("UnitPrice", eInvoiceLine.UnitPrice);

            record.Set("ItemTotalAmountWithoutVATLCY", eInvoiceLine.ItemTotalAmountWithoutVATLCY);
            record.Set("UnitPriceLCY", eInvoiceLine.UnitPriceLCY);

            record.Set("VATAmount", eInvoiceLine.VATAmount);
            record.Set("VATAmountLCY", eInvoiceLine.VATAmountLCY);

            record.Set("ItemTotalAmountWithVAT", eInvoiceLine.ItemTotalAmountWithVAT);
            record.Set("ItemTotalAmountWithVATLCY", eInvoiceLine.ItemTotalAmountWithVATLCY);
        }
    }

    public partial class EInvoiceSignedRepository 
    {
        public Paging<EInvoiceSigned> Paging(StoreRequestParameters parameters)
        {
            return Paging(parameters.Start, parameters.Limit, parameters.SimpleSort, parameters.SimpleSortDirection);
        }

        public Paging<EInvoiceSigned> Paging(int start, int limit, string sort, SortDirection dir)
        {
            var entities = Get(includePaths: new String[] { "Organization", "Client", "RecCreatedByUser", "RecModifiedByUser" });

            if (!string.IsNullOrEmpty(sort))
                entities = dir == SortDirection.ASC ? entities.OrderBy(sort) : entities.OrderBy(sort + " DESC");
            else
                entities = entities.OrderBy("InvoiceIssuedDate");

            var count = entities.ToList().Count;
            var ranges = (start < 0 || limit <= 0) ? entities.ToList() : entities.Skip(start).Take(limit).ToList();

            return new Paging<EInvoiceSigned>(ranges, count);
        }
    }
}