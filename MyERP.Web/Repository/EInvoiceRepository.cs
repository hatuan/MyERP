using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Linq.Dynamic;
using System.Linq.Expressions;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Security.Principal;
using System.Text;
using System.Transactions;
using System.Web;
using System.Xml;
using System.Xml.Serialization;
using System.Xml.Xsl;
using Ext.Net;
using log4net;
using MyERP.DataAccess;
using MyERP.DataAccess.Enum;
using MyERP.Web.Models;
using MyERP.Web.Others;
using Newtonsoft.Json;

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

        public decimal GetNextReleaseNo(long formTypeId, DateTime invoiceIssuedDate)
        {
            /*
            TransactionOptions TransOpt = new TransactionOptions();
            TransOpt.IsolationLevel = System.Transactions.IsolationLevel.RepeatableRead;
            using (TransactionScope scope = new TransactionScope(TransactionScopeOption.Required, TransOpt))
            {
                var formReleases = dataContext.EInvFormReleases.SqlQuery("SELECT * FROM einv_form_release WITH (INDEX(idx_einv_form_release_form_type_id)) WHERE form_type_id = @form_type_id", new SqlParameter("@form_type_id", formTypeId));
                var formRelease = formReleases.Where(x => x.StartDate.CompareTo(invoiceIssuedDate) >= 0
                                                                       && (TaxAuthoritiesStatus)x.TaxAuthoritiesStatus == TaxAuthoritiesStatus.Active);
                scope.Complete();
            }
            */
            decimal _nextReleaseNo = 0;
            using (DbContextTransaction scope = dataContext.Database.BeginTransaction())
            {
                var formReleases = dataContext.EInvFormReleases.SqlQuery("SELECT * FROM einv_form_release WITH (UPDLOCK, INDEX(idx_einv_form_release_form_type_id)) WHERE form_type_id = @form_type_id", new SqlParameter("@form_type_id", formTypeId))
                    .ToList<EInvFormRelease>();
                var formRelease = formReleases.Where(x => x.StartDate.CompareTo(invoiceIssuedDate) >= 0 && x.ReleaseUsed < x.ReleaseTotal && (TaxAuthoritiesStatus)x.TaxAuthoritiesStatus == TaxAuthoritiesStatus.Active)
                    .OrderBy(x => x.ReleaseFrom)
                    .FirstOrDefault();
                if (formRelease == null)
                    throw new System.Data.Entity.Core.ObjectNotFoundException();

                _nextReleaseNo = formRelease.ReleaseFrom + formRelease.ReleaseUsed;
                formRelease.ReleaseUsed = formRelease.ReleaseUsed + 1;
                dataContext.SaveChanges();
                scope.Commit();
            }

            return _nextReleaseNo;
        }
    }

    public partial class EInvoiceHeaderRepository 
    {
        ILog log = log4net.LogManager.GetLogger(typeof(EInvoiceHeaderRepository));

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

        /// <summary>
        /// return true if reservationCode is avaliable
        /// </summary>
        /// <param name="reservationCode"></param>
        /// <returns></returns>
        public bool CheckReservationCode(string reservationCode)
        {
            //because index condition is reservation_code != null so where must include x.ReservationCode != null
            var entity = DataContext.EInvoiceHeaders.WithHint("INDEX(idx_einvoice_header_reservation_code)").Where(x => x.ReservationCode == reservationCode && x.ReservationCode != null).FirstOrDefault();
            return entity == null;
        }

        public string SetEInvNumber(long eInvoiceHeaderId, ref long version, long userId, string reservationCode)
        {
            decimal _nextReleaseNo = 0;
            using (DbContextTransaction scope = dataContext.Database.BeginTransaction())
            {
                try
                {
                    var _version = version;
                    var eInvoiceHeader = dataContext.EInvoiceHeaders.WithHint("UPDLOCK, INDEX(pk_einvoice_header)").Where(x => x.Id == eInvoiceHeaderId && x.Version == _version).FirstOrDefault();
                    if (eInvoiceHeader == null)
                        throw new System.Data.Entity.Core.ObjectNotFoundException("Invoice Header has been changed or deleted! Please check");
                    if(!String.IsNullOrWhiteSpace(eInvoiceHeader.InvoiceNumber)) //skip if invoice has number  
                    {
                        var _invoiceNumber = eInvoiceHeader.InvoiceNumber;
                        scope.Rollback();
                        return _invoiceNumber;
                    }
                    var formReleases = dataContext.EInvFormReleases.WithHint("UPDLOCK, INDEX(idx_einv_form_release_form_type_id)").Where(x => x.FormTypeId == eInvoiceHeader.FormTypeId)
                        .ToList<EInvFormRelease>();
                    var formRelease = formReleases.Where(x => x.StartDate.CompareTo(eInvoiceHeader.InvoiceIssuedDate) <= 0 && x.ReleaseUsed < x.ReleaseTotal && (TaxAuthoritiesStatus)x.TaxAuthoritiesStatus == TaxAuthoritiesStatus.Active)
                        .OrderBy(x => x.ReleaseFrom)
                        .FirstOrDefault();
                    if (formRelease == null)
                        throw new System.Data.Entity.Core.ObjectNotFoundException("Invoice Form Release not found! Please check");

                    _nextReleaseNo = formRelease.ReleaseFrom + formRelease.ReleaseUsed;
                    formRelease.ReleaseUsed++;

                    eInvoiceHeader.InvoiceNumber = _nextReleaseNo.ToString().PadLeft(7, '0');
                    eInvoiceHeader.ReservationCode = reservationCode;
                    eInvoiceHeader.Status = (byte)EInvoiceDocumentStatusType.Released;
                    eInvoiceHeader.RecModifiedAt = DateTime.Now;
                    eInvoiceHeader.RecModifiedBy = userId;
                    eInvoiceHeader.Version = ++version;

                    dataContext.SaveChanges();

                    scope.Commit();

                    return eInvoiceHeader.InvoiceNumber;
                }
                catch (System.Data.Entity.Core.ObjectNotFoundException ex)
                {
                    scope.Rollback();
                    throw ex;
                }
                catch (Exception ex)
                {
                    scope.Rollback();
                    throw ex;
                }
            }

        }
        public string GetXmlInvoiceInfo(long id)
        {
            var entity = Get(c => c.Id == id, new string[] { "Currency", "EInvFormType", "EInvoiceLines", "EInvoiceLines.Item", "EInvoiceLines.Vat", "EInvoiceLines.Uom" }).SingleOrDefault();
            if (entity == null)
            {
                throw new System.Data.Entity.Core.ObjectNotFoundException("Invoice Header has been changed or deleted! Please check");
            }

            return GetXmlInvoiceInfo(entity);
        }

        public string GetXmlInvoiceInfo(long id, long version)
        {
            var entity = Get(c => c.Id == id && c.Version == version, new string[] { "Currency", "EInvFormType", "EInvoiceLines", "EInvoiceLines.Item", "EInvoiceLines.Vat", "EInvoiceLines.Uom" }).SingleOrDefault();
            if (entity == null)
            {
                throw new System.Data.Entity.Core.ObjectNotFoundException("Invoice Header has been changed or deleted! Please check");
            }

            return GetXmlInvoiceInfo(entity);
        }
        
        public string GetXmlInvoiceInfo(EInvoiceHeader entity)
        {
            var formTypeRepository = new EInvFormTypeRepository();
            var formType = formTypeRepository.Get(x => x.Id == entity.FormTypeId).First();

            EInvXMLInvoiceInfo invoiceInfo = new EInvXMLInvoiceInfo();
            invoiceInfo.InvoiceDataInfo = new EInvXMLInvoiceDataInfo();
            invoiceInfo.InvoiceDataInfo.Id = "data";
            invoiceInfo.InvoiceDataInfo.InvoiceType = formType.InvoiceType;
            invoiceInfo.InvoiceDataInfo.InvoiceSeries = formType.InvoiceSeries.ToUpper();
            invoiceInfo.InvoiceDataInfo.TemplateCode = formType.InvoiceType + "0/" + formType.InvoiceTypeNo;

            //invoiceInfo.InvoiceDataInfo.OriginalInvoiceId = entity.OriginalInvoiceId;
            //invoiceInfo.InvoiceDataInfo.OriginalInvoiceIssueDate = entity.OriginalInvoiceIssueDate == null ? "" : entity.OriginalInvoiceIssueDate?.ToString("yyyy'-'MM'-'dd'T'HH':'mm':'ss");
            invoiceInfo.InvoiceDataInfo.CurrencyCode = entity.Currency.Code;
            invoiceInfo.InvoiceDataInfo.ExchangeRate = entity.ExchangeRate;
            invoiceInfo.InvoiceDataInfo.InvoiceNote = entity.InvoiceNote;
            invoiceInfo.InvoiceDataInfo.AdjustmentType = Convert.ToString(entity.AdjustmentType);
            invoiceInfo.InvoiceDataInfo.AdditionalReferenceDesc = entity.AdditionalReferenceDesc;
            invoiceInfo.InvoiceDataInfo.AdditionalReferenceDate = entity.AdditionalReferenceDate == null ? "" : entity.AdditionalReferenceDate?.ToString("yyyy'-'MM'-'dd'T'HH':'mm':'ss");

            invoiceInfo.InvoiceDataInfo.InvoiceNumber = entity.InvoiceNumber;
            invoiceInfo.InvoiceDataInfo.InvoiceName = entity.InvoiceName;
            invoiceInfo.InvoiceDataInfo.InvoiceIssuedDate = entity.InvoiceIssuedDate;
            invoiceInfo.InvoiceDataInfo.SignedDate = DateTime.Now;

            invoiceInfo.InvoiceDataInfo.SellerInfo = new EInvXMLSellerInfo()
            {
                SellerLegalName = formType.SellerLegalName,
                SellerAddressLine = formType.SellerAddressLine,
                SellerTaxCode = formType.SellerTaxCode,
                SellerBankAccount = String.IsNullOrWhiteSpace(formType.SellerBankAccount) ? null : formType.SellerBankAccount,
                SellerBankName = String.IsNullOrWhiteSpace(formType.SellerBankName) ? null : formType.SellerBankName,
                SellerPostalCode = String.IsNullOrWhiteSpace(formType.SellerPostalCode) ? null : formType.SellerPostalCode,
                SellerDistrictName = String.IsNullOrWhiteSpace(formType.SellerDistrictName) ? null : formType.SellerDistrictName,
                SellerCityName = String.IsNullOrWhiteSpace(formType.SellerCityName) ? null : formType.SellerCityName,
                SellerCountryCode = String.IsNullOrWhiteSpace(formType.SellerCountryCode) ? null : formType.SellerCountryCode,
                SellerPhoneNumber = String.IsNullOrWhiteSpace(formType.SellerPhoneNumber) ? null : formType.SellerPhoneNumber,
                SellerFaxNumber = String.IsNullOrWhiteSpace(formType.SellerFaxNumber) ? null : formType.SellerFaxNumber,
                SellerEmail = String.IsNullOrWhiteSpace(formType.SellerEmail) ? null : formType.SellerEmail,
                SellerContactPersonName = String.IsNullOrWhiteSpace(formType.SellerContactPersonName) ? null : formType.SellerContactPersonName,
                SellerSignedPersonName = String.IsNullOrWhiteSpace(formType.SellerSignedPersonName) ? null : formType.SellerSignedPersonName
            };


            invoiceInfo.InvoiceDataInfo.BuyerInfo = new EInvXMLBuyerInfo()
            {
                BuyerLegalName = entity.BuyerLegalName,
                BuyerTaxCode = entity.BuyerTaxCode,
                BuyerDisplayName = entity.BuyerDisplayName,
                BuyerAddressLine = entity.BuyerAddressLine,
                BuyerBankAccount = entity.BuyerBankAccount,
                BuyerBankName = entity.BuyerBankName,
            };

            invoiceInfo.InvoiceDataInfo.PaymentInfos = new List<EInvXMLPaymentInfo> {
                new EInvXMLPaymentInfo
                {
                    PaymentMethodName = entity.PaymentMethodName
                }
            };

            invoiceInfo.InvoiceDataInfo.SumOfTotalLineAmountWithoutVat = entity.SumOfTotalLineAmountWithoutVAT;
            invoiceInfo.InvoiceDataInfo.TotalAmountWithoutVAT = entity.TotalAmountWithoutVAT;
            invoiceInfo.InvoiceDataInfo.IsTotalAmtWithoutVATPos = entity.IsTotalAmountWithoutVATPos;
            invoiceInfo.InvoiceDataInfo.TotalVATAmount = entity.TotalVATAmount;
            invoiceInfo.InvoiceDataInfo.IsTotalVATAmountPos = entity.IsTotalVATAmountPos;
            invoiceInfo.InvoiceDataInfo.TotalAmountWithVAT = entity.TotalAmountWithVAT;
            invoiceInfo.InvoiceDataInfo.TotalAmountWithVATFrn = entity.TotalAmountWithVATFrn;
            invoiceInfo.InvoiceDataInfo.TotalAmountWithVATInWords = entity.TotalAmountWithVATInWords;
            invoiceInfo.InvoiceDataInfo.IsTotalAmountPos = entity.IsTotalAmountPos;
            invoiceInfo.InvoiceDataInfo.DiscountAmount = entity.DiscountAmount;
            invoiceInfo.InvoiceDataInfo.IsDiscountAmtPos = entity.IsDiscountAmtPos;

            int lineNumber = 1;
            foreach(var line in entity.EInvoiceLines)
            {
                if (invoiceInfo.InvoiceDataInfo.ItemInfos == null)
                    invoiceInfo.InvoiceDataInfo.ItemInfos = new List<EInvXMLItemInfo>
                    {
                        new EInvXMLItemInfo()
                        {
                            LineNumber = lineNumber,
                            ItemCode = line.ItemCode,
                            ItemName = line.ItemName,
                            UnitCode = line.UnitCode,
                            UnitName = line.UnitName,
                            UnitPrice = line.UnitPrice,
                            Quantity = line.Quantity,
                            ItemTotalAmountWithoutVAT = line.ItemTotalAmountWithoutVAT,
                            VatPercentage = line.VATPercentage,
                            VatAmount = line.VATAmount,
                            ItemTotalAmountWithVAT = line.ItemTotalAmountWithVAT,
                            Promotion = line.Promotion,
                            //ItemDiscount = line.ItemDiscount,
                            AdjustmentVatAmount = line.AdjustmentVATAmount,
                            IsIncreaseItem = line.IsIncreaseItem,
                        }
                    };
                else
                    invoiceInfo.InvoiceDataInfo.ItemInfos.Add(
                        new EInvXMLItemInfo
                        {
                            LineNumber = lineNumber,
                            ItemCode = line.ItemCode,
                            ItemName = line.ItemName,
                            UnitCode = line.UnitCode,
                            UnitName = line.UnitName,
                            UnitPrice = line.UnitPrice,
                            Quantity = line.Quantity,
                            ItemTotalAmountWithoutVAT = line.ItemTotalAmountWithoutVAT,
                            VatPercentage = line.VATPercentage,
                            VatAmount = line.VATAmount,
                            ItemTotalAmountWithVAT = line.ItemTotalAmountWithVAT,
                            Promotion = line.Promotion,
                            //ItemDiscount = line.ItemDiscount,
                            AdjustmentVatAmount = line.AdjustmentVATAmount,
                            IsIncreaseItem = line.IsIncreaseItem,
                        });
                
                if(invoiceInfo.InvoiceDataInfo.InvoiceTaxBreakdowns == null)
                {
                    invoiceInfo.InvoiceDataInfo.InvoiceTaxBreakdowns = new List<EInvXMLTaxBreakdowns>
                    {
                        new EInvXMLTaxBreakdowns
                        {
                            VatPercentage = line.VATPercentage,
                            VatTaxableAmount = line.ItemTotalAmountWithoutVAT,
                            VatTaxAmount = line.VATAmount,
                            IsVatTaxableAmountPos = line.IsIncreaseItem,
                            IsVatTaxAmountPos = line.IsIncreaseItem,
                        }
                    };
                }
                else
                {
                    EInvXMLTaxBreakdowns foundTaxBreakdown = invoiceInfo.InvoiceDataInfo.InvoiceTaxBreakdowns.Where(x => x.VatPercentage == line.VATPercentage).FirstOrDefault();
                    if(foundTaxBreakdown == null)
                    {
                        invoiceInfo.InvoiceDataInfo.InvoiceTaxBreakdowns.Add(
                            new EInvXMLTaxBreakdowns
                            {
                                VatPercentage = line.VATPercentage,
                                VatTaxableAmount = line.ItemTotalAmountWithoutVAT,
                                VatTaxAmount = line.VATAmount,
                                IsVatTaxableAmountPos = line.IsIncreaseItem,
                                IsVatTaxAmountPos = line.IsIncreaseItem,
                            }
                        );
                    }
                    else
                    {
                        foundTaxBreakdown.VatTaxableAmount += line.ItemTotalAmountWithoutVAT;
                        foundTaxBreakdown.VatTaxAmount += line.VATAmount;
                    }
                }

                lineNumber++;
            }
            //UserDefines
            invoiceInfo.InvoiceDataInfo.UserDefines = $"<reservationCode>{entity.ReservationCode}</reservationCode>";

            XmlWriterSettings settings = new XmlWriterSettings()
            {
                Encoding = new UTF8Encoding(false),
                Indent = false, //Default false - indent elements
                NewLineHandling = NewLineHandling.None
            };

            using (MemoryStream sww = new MemoryStream())
            using (System.Xml.XmlWriter writer = System.Xml.XmlWriter.Create(sww, settings))
            {
                XmlSerializerNamespaces ns = new XmlSerializerNamespaces();
                ns.Add("ns1", "http://www.w3.org/2000/09/xmldsig#");
                ns.Add("inv", "http://laphoadon.gdt.gov.vn/2014/09/invoicexml/v1");
                XmlSerializer xsSubmit = new XmlSerializer(invoiceInfo.GetType());
                xsSubmit.Serialize(writer, invoiceInfo, ns);
                byte[] textAsBytes = sww.ToArray(); //Encoding.UTF8.GetBytes(Encoding.Default.GetString(sww.ToArray()));
                return Encoding.UTF8.GetString(textAsBytes);
            }

        }

        public void CreateHtmlFile(EInvoiceHeader entity, string dirPath, string fullHtmlPath)
        {
            try
            {
                var formType = entity.EInvFormType;
                String xslInput = formType.FormFile;

                if (entity.Status < (byte)EInvoiceDocumentStatusType.Signed) //Clear reservationCode if not signed document
                {
                    entity.ReservationCode = "";
                    entity.SignedDate = null;
                }
                String xmlInput = GetXmlInvoiceInfo(entity);

                System.IO.File.WriteAllText(dirPath + "/xslTemplate.xsl", xslInput, Encoding.UTF8);
                System.IO.File.WriteAllText(dirPath + "/xmlInput.xml", xmlInput, Encoding.UTF8);

                using (StringReader srt = new StringReader(xslInput)) // xslInput is a string that contains xsl
                using (StringReader sri = new StringReader(xmlInput)) // xmlInput is a string that contains xml
                {
                    using (System.Xml.XmlReader xrt = System.Xml.XmlReader.Create(srt))
                    using (System.Xml.XmlReader xri = System.Xml.XmlReader.Create(sri))
                    {
                        XslCompiledTransform xslt = new XslCompiledTransform();
                        xslt.Load(xrt);
                        using (StringWriter sw = new StringWriter())
                        using (System.Xml.XmlWriter xwo = System.Xml.XmlWriter.Create(sw, xslt.OutputSettings)) // use OutputSettings of xsl, so it can be output as HTML
                        {
                            xslt.Transform(xri, xwo);
                            System.IO.File.WriteAllText(fullHtmlPath, sw.ToString(), Encoding.UTF8);
                        }
                    }
                }
                if (!String.IsNullOrEmpty(formType.Logo))
                {
                    System.IO.File.WriteAllBytes(dirPath + "/logo.png", Convert.FromBase64String(formType.Logo));
                }
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        /// <summary>
        /// Return EInvoiceSigned Id
        /// </summary>
        /// <param name="id"></param>
        /// <param name="signedXMLDTO"></param>
        /// <returns></returns>
        public long PublicSignedInvoice(long id, SignXMLDTO signedXMLDTO, long userId)
        {
            using (DbContextTransaction scope = dataContext.Database.BeginTransaction())
            {
                try
                {
                    var entity = Get(c => c.Id == id && c.Status == (byte)EInvoiceDocumentStatusType.Released, new string[] { "Currency", "EInvFormType" }).SingleOrDefault();
                    if (entity == null)
                    {
                        throw new System.Data.Entity.Core.ObjectNotFoundException("Invoice Header has been changed or deleted! Please check");
                    }
                    //save to EInvoiceHeader
                    entity.SignedDate = DateTime.Now;
                    entity.Version++;
                    entity.Status = (byte)EInvoiceDocumentStatusType.Signed;
                    entity.RecModifiedAt = DateTime.Now;
                    dataContext.SaveChanges();

                    var newEInvoiceSigned = new EInvoiceSigned
                    {
                        EInvoiceHeaderId = id,
                        FormTypeId = entity.FormTypeId,
                        OriginalEInvoiceId = entity.OriginalEInvoiceId,
                        OriginalInvoiceId = entity.OriginalInvoiceId,
                        OriginalInvoiceIssueDate = entity.OriginalInvoiceIssueDate,
                        InvoiceType = entity.EInvFormType.InvoiceType,
                        TemplateCode = entity.EInvFormType.TemplateCode,
                        InvoiceSeries = entity.EInvFormType.InvoiceSeries,
                        InvoiceNumber = entity.InvoiceNumber,
                        InvoiceName = entity.EInvFormType.InvoiceName,
                        InvoiceIssuedDate = entity.InvoiceIssuedDate,
                        SignedDate = entity.SignedDate,
                        SubmittedDate = entity.SubmittedDate,
                        ContractNumber = entity.ContractNumber,
                        ContractDate = entity.ContractDate,
                        Description = entity.Description,
                        CurrencyCode = entity.Currency.Code,
                        ExchangeRate = entity.ExchangeRate,
                        InvoiceNote = entity.InvoiceNote,
                        AdjustmentType = entity.AdjustmentType,
                        AdditionalReferenceDate = entity.AdditionalReferenceDate,
                        AdditionalReferenceDesc = entity.AdditionalReferenceDesc,
                        BuyerDisplayName = entity.BuyerDisplayName,
                        BuyerLegalName = entity.BuyerLegalName,
                        BuyerTaxCode = entity.BuyerTaxCode,
                        BuyerAddressLine = entity.BuyerAddressLine,
                        BuyerPostalCode = entity.BuyerPostalCode,
                        BuyerDistrictName = entity.BuyerDistrictName,
                        BuyerCityName = entity.BuyerCityName,
                        BuyerCountryCode = entity.BuyerCountryCode,
                        BuyerPhoneNumber = entity.BuyerPhoneNumber,
                        BuyerFaxNumber = entity.BuyerFaxNumber,
                        BuyerEmail = entity.BuyerEmail,
                        BuyerBankName = entity.BuyerBankName,
                        BuyerBankAccount = entity.BuyerBankAccount,
                        SellerLegalName = entity.SellerLegalName,
                        SellerTaxCode = entity.SellerTaxCode,
                        SellerAddressLine = entity.SellerAddressLine,
                        SellerPostalCode = entity.SellerPostalCode,
                        SellerDistrictName = entity.SellerDistrictName,
                        SellerCityName = entity.SellerCityName,
                        SellerCountryCode = entity.SellerCountryCode,
                        SellerPhoneNumber = entity.SellerPhoneNumber,
                        SellerFaxNumber = entity.SellerFaxNumber,
                        SellerEmail = entity.SellerEmail,
                        SellerBankName = entity.SellerBankName,
                        SellerBankAccount = entity.SellerBankAccount,
                        SellerContactPersonName = entity.SellerContactPersonName,
                        SellerSignedPersonName = entity.SellerSignedPersonName,
                        SellerSubmittedPersonName = entity.SellerSubmittedPersonName,
                        PaymentMethodName = entity.PaymentMethodName,
                        SumOfTotalLineAmountWithoutVAT = entity.SumOfTotalLineAmountWithoutVAT,
                        TotalAmountWithoutVAT = entity.TotalAmountWithoutVAT,
                        IsTotalAmountWithoutVATPos = entity.IsTotalAmountWithoutVATPos,
                        TotalVATAmount = entity.TotalVATAmount,
                        IsTotalVATAmountPos = entity.IsTotalVATAmountPos,
                        TotalAmountWithVAT = entity.TotalAmountWithVAT,
                        TotalAmountWithVATFrn = entity.TotalAmountWithVATFrn,
                        TotalAmountWithVATInWords = entity.TotalAmountWithVATInWords,
                        IsTotalAmountPos = entity.IsTotalAmountPos,
                        DiscountAmount = entity.DiscountAmount,
                        IsDiscountAmtPos = entity.IsDiscountAmtPos,
                        ReservationCode = entity.ReservationCode,
                        Logo = entity.EInvFormType.Logo,
                        Watermark = entity.EInvFormType.Watermark,
                        SignedXML = signedXMLDTO.SignedXML,
                        SignedXSL = entity.EInvFormType.FormFile,
                        SignedFileName = entity.EInvFormType.FormFileName,
                        ClientId = entity.ClientId,
                        OrganizationId = entity.OrganizationId,
                        Version = 1,
                        Status = (byte)EInvoiceDocumentStatusType.Signed,
                        RecCreatedAt = DateTime.Now,
                        RecCreatedBy = userId,
                        RecModifiedAt = DateTime.Now,
                        RecModifiedBy = userId
                    };
                    //save to EInvoiceSigned table before send to EHoaDon server
                    //if error in EHoaDon server, will rollback
                    newEInvoiceSigned = dataContext.Set<EInvoiceSigned>().Add(newEInvoiceSigned);
                    dataContext.SaveChanges();

                    string URL = Functions.GetEHoaDonUrl("/EInvoiceSigned");

                    using (var httpClient = new HttpClient())
                    {
                        httpClient.BaseAddress = new Uri(URL);
                        httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                        var content = new StringContent(JsonConvert.SerializeObject(newEInvoiceSigned), Encoding.UTF8, "application/json");
                        string urlParameters = $"";

                        log.Info($"URL AbsoluteUri = {httpClient.BaseAddress.AbsoluteUri}");

                        try
                        {
                            var response = httpClient.PostAsync(urlParameters, content);
                            var result = response.Result;
                            if (!result.IsSuccessStatusCode)
                            {
                                log.Error("Failed", new Exception(result.StatusCode.ToString() + " " + result.ToString()));
                                throw new Exception("PublicSignedInvoice failed");
                            }
                        }
                        catch (Exception e)
                        {
                            log.Error("Failed", e);
                            throw e;
                        }
                    }
                                        
                    //If dont have error on EHoaDon server : commit                    
                    scope.Commit();

                    return newEInvoiceSigned.Id;
                }
                catch (System.Data.Entity.Core.ObjectNotFoundException ex)
                {
                    scope.Rollback();
                    throw ex;
                }
                catch (Exception ex)
                {
                    scope.Rollback();
                    throw ex;
                }
            }
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
            var entities = Get(includePaths: new String[] { "Organization", "Client", "RecCreatedByUser", "RecModifiedByUser", "EInvFormType" });

            if (!string.IsNullOrEmpty(sort))
                entities = dir == SortDirection.ASC ? entities.OrderBy(sort) : entities.OrderBy(sort + " DESC");
            else
                entities = entities.OrderBy("InvoiceIssuedDate");

            var count = entities.ToList().Count;
            var ranges = (start < 0 || limit <= 0) ? entities.ToList() : entities.Skip(start).Take(limit).ToList();

            return new Paging<EInvoiceSigned>(ranges, count);
        }

        public List<EInvoiceSignedViewModel> Search(string sellerTaxCode, string clientUUID, string buyerTaxCode, string reservationCode)
        {
            var client = dataContext.Clients.Where(x => x.UUID == clientUUID).FirstOrDefault();
            if(client == null)
                throw new System.Data.Entity.Core.ObjectNotFoundException($"Client UUID {clientUUID} not found! Please check");

            var query = dataContext.EInvoiceSigneds.Where(x => x.ClientId == client.Id && x.SellerTaxCode == sellerTaxCode);
            if (!String.IsNullOrWhiteSpace(buyerTaxCode))
                query = query.Where(x => x.BuyerTaxCode == buyerTaxCode);
            if (!String.IsNullOrWhiteSpace(reservationCode))
                query = query.Where(x => x.ReservationCode == reservationCode);

            return query.Select(x => new EInvoiceSignedViewModel() {
                Id = x.Id,
                InvoiceNumber = x.InvoiceNumber,
                InvoiceIssuedDate = x.InvoiceIssuedDate,
                BuyerLegalName = x.BuyerLegalName,
                BuyerTaxCode = x.BuyerTaxCode,
                BuyerAddressLine = x.BuyerAddressLine,
                Description = x.Description,
                TotalAmountWithoutVAT = x.TotalAmountWithoutVAT,
                TotalVATAmount = x.TotalVATAmount,
                TotalAmountWithVAT = x.TotalAmountWithVAT,
                Status = (EInvoiceDocumentStatusType)x.Status,
                ReservationCode = x.ReservationCode,
                Logo = x.Logo,
                Watermark = x.Watermark,
                SignedXML = x.SignedXML,
                SignedXSL = x.SignedXSL
            }).ToList();
        }

        internal void CreateHtmlFile(EInvoiceSignedViewModel printInvoice, string dirPath, string fullHtmlPath)
        {
            try
            {
                String xmlInput = Encoding.UTF8.GetString(Convert.FromBase64String(printInvoice.SignedXML));
                String xslInput = printInvoice.SignedXSL;

                System.IO.File.WriteAllText(dirPath + "/xslTemplate.xsl", xslInput, Encoding.UTF8);
                System.IO.File.WriteAllText(dirPath + "/xmlInput.xml", xmlInput, Encoding.UTF8);

                using (StringReader srt = new StringReader(xslInput)) // xslInput is a string that contains xsl
                using (StringReader sri = new StringReader(xmlInput)) // xmlInput is a string that contains xml
                {
                    using (System.Xml.XmlReader xrt = System.Xml.XmlReader.Create(srt))
                    using (System.Xml.XmlReader xri = System.Xml.XmlReader.Create(sri))
                    {
                        XslCompiledTransform xslt = new XslCompiledTransform();
                        xslt.Load(xrt);
                        using (StringWriter sw = new StringWriter())
                        using (System.Xml.XmlWriter xwo = System.Xml.XmlWriter.Create(sw, xslt.OutputSettings)) // use OutputSettings of xsl, so it can be output as HTML
                        {
                            xslt.Transform(xri, xwo);
                            System.IO.File.WriteAllText(fullHtmlPath, sw.ToString(), Encoding.UTF8);
                        }
                    }
                }
                if (!String.IsNullOrEmpty(printInvoice.Logo))
                {
                    System.IO.File.WriteAllBytes(dirPath + "/logo.png", Convert.FromBase64String(printInvoice.Logo));
                }
            }
            catch (Exception ex) {
                throw ex;
            }
        }
    }
}