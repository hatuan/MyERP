using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Linq.Dynamic;
using System.Text;
using System.Threading;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using System.Xml;
using System.Xml.Serialization;
using System.Xml.Xsl;
using Ext.Net;
using Ext.Net.MVC;
using MyERP.DataAccess;
using MyERP.DataAccess.Enum;
using MyERP.Web.Controllers;
using MyERP.Web.Models;
using Newtonsoft.Json;

namespace MyERP.Web.Areas.EInvoice.Controllers
{
    public class FormTypeController : EntityBaseController<MyERP.DataAccess.EInvFormType, MyERP.DataAccess.EntitiesModel>
    {
        public FormTypeController() : this(new EInvFormTypeRepository())
        {

        }

        /// <summary>
        /// Dependency Injection ready constructor.
        /// Usable also for unit testing.
        /// </summary>
        /// <remarks>Controller will ALWAYS use the default constructor!</remarks>
        /// <param name="repository">Repository instance of the specific type</param>
        public FormTypeController(IBaseRepository<MyERP.DataAccess.EInvFormType, MyERP.DataAccess.EntitiesModel> repository)
        {
            this.repository = repository;
        }

        // GET: EInvoice/FormType
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult _List(string containerId = "MainCenterPanel")
        {
            return new Ext.Net.MVC.PartialViewResult
            {
                ContainerId = containerId,
                ViewName = "_List",
                WrapByScriptTag = false,
                RenderMode = RenderMode.AddTo,
                ClearContainer = true
            };
        }

        public ActionResult GetData(StoreRequestParameters parameters)
        {
            var paging = ((EInvFormTypeRepository)repository).Paging(parameters);

            var data = paging.Data.Select(c => new EInvFormTypeViewModel
            {
                OrganizationCode = c.Organization.Code,
                Id = c.Id,
                InvoiceType = c.InvoiceType,
                TemplateCode = c.TemplateCode,
                InvoiceForm = c.InvoiceForm,
                InvoiceSeries = c.InvoiceSeries,
                RecCreateBy = c.RecCreatedByUser.Name,
                RecCreatedAt = c.RecCreatedAt,
                RecModifiedBy = c.RecModifiedByUser.Name,
                RecModifiedAt = c.RecModifiedAt,
                Status = (DefaultStatusType)c.Status,
                Version = c.Version
            }).ToList();

            Session.Add("StoreFormTypeList_StoreRequestParameters", parameters);

            return this.Store(data, paging.TotalRecords);
        }

        public ActionResult LookupData(StoreRequestParameters parameters, long? id = null, TaxAuthoritiesStatus? taxAuthoritiesStatus = null)
        {
            if (id != null && id > 0)
            {
                var data = repository.Get(c => c.Id == id, new[] { "Organization" }).Select(c =>
                    new EInvFormTypeLookupViewModel()
                    {
                        Id = c.Id,
                        InvoiceType = c.InvoiceType,
                        TemplateCode = c.TemplateCode,
                        InvoiceForm = c.InvoiceForm,
                        InvoiceSeries = c.InvoiceSeries,
                        SellerLegalName = c.SellerLegalName,
                        SellerTaxCode = c.SellerTaxCode,
                        SellerAddressLine = c.SellerAddressLine,
                        SellerPostalCode = c.SellerPostalCode,
                        SellerDistrictName = c.SellerDistrictName,
                        SellerCityName = c.SellerCityName,
                        SellerCountryCode = c.SellerCountryCode,
                        SellerPhoneNumber = c.SellerPhoneNumber,
                        SellerFaxNumber = c.SellerFaxNumber,
                        SellerEmail = c.SellerEmail,
                        SellerBankName = c.SellerBankName,
                        SellerBankAccount = c.SellerBankAccount,
                        SellerContactPersonName = c.SellerContactPersonName,
                        SellerSignedPersonName = c.SellerSignedPersonName,
                        OrganizationCode = c.Organization.Code,
                        Status = (DefaultStatusType)c.Status
                    });
                return this.Store(data, 1);
            }
            else
            {
                var entities = repository.Get(includePaths: new String[] { "Organization", "EInvFormReleases" });

                entities = entities.Where(c => c.Status == (short)DefaultStatusType.Active);
                if (taxAuthoritiesStatus != null)
                    entities = entities.Where(c => c.EInvFormReleases.Any(d => d.TaxAuthoritiesStatus == (short)taxAuthoritiesStatus));

                if (!string.IsNullOrEmpty(parameters.SimpleSort))
                    entities = parameters.SimpleSortDirection == SortDirection.ASC ? entities.OrderBy(parameters.SimpleSort) : entities.OrderBy(parameters.SimpleSort + " DESC");
                else
                    entities = entities.OrderBy(c => c.InvoiceTypeNo);

                var count = entities.ToList().Count;
                var ranges = (parameters.Start < 0 || parameters.Limit <= 0) ? entities.ToList() : entities.Skip(parameters.Start).Take(parameters.Limit).ToList();
                var data = ranges.Select(c => new EInvFormTypeLookupViewModel
                {
                    Id = c.Id,
                    InvoiceType = c.InvoiceType,
                    TemplateCode = c.TemplateCode,
                    InvoiceForm = c.InvoiceForm,
                    InvoiceSeries = c.InvoiceSeries,
                    SellerLegalName = c.SellerLegalName,
                    SellerTaxCode = c.SellerTaxCode,
                    SellerAddressLine = c.SellerAddressLine,
                    SellerPostalCode = c.SellerPostalCode,
                    SellerDistrictName = c.SellerDistrictName,
                    SellerCityName = c.SellerCityName,
                    SellerCountryCode = c.SellerCountryCode,
                    SellerPhoneNumber = c.SellerPhoneNumber,
                    SellerFaxNumber = c.SellerFaxNumber,
                    SellerEmail = c.SellerEmail,
                    SellerBankName = c.SellerBankName,
                    SellerBankAccount = c.SellerBankAccount,
                    SellerContactPersonName = c.SellerContactPersonName,
                    SellerSignedPersonName = c.SellerSignedPersonName,
                    OrganizationCode = c.Organization.Code,
                    Status = (DefaultStatusType)c.Status
                }).ToList();

                return this.Store(data, data.Count);
            }
        }

        [HttpGet]
        public ActionResult _Maintenance(string id = null)
        {
            
            var model = new EInvFormTypeEditViewModel()
            {
                Id = null,
                Status = DefaultStatusType.Active
            };

            if (!String.IsNullOrEmpty(id))
            {
                var _id = Convert.ToInt64(id);
                var entity = repository.Get(c => c.Id == _id, new string[] { "EInvFormReleases" }).Single();
                string formFile = Convert.ToBase64String(Encoding.UTF8.GetBytes(entity.FormFile));
                model = new EInvFormTypeEditViewModel()
                {
                    Id = entity.Id,
                    InvoiceName = entity.InvoiceName,
                    InvoiceType = entity.InvoiceType,
                    InvoiceTypeNo = entity.InvoiceTypeNo,
                    TemplateCode = entity.TemplateCode,
                    InvoiceForm = entity.InvoiceForm,
                    InvoiceSeries = entity.InvoiceSeries,
                    FormFileName = entity.FormFileName,
                    FormFile = formFile,
                    Logo = entity.Logo,
                    Watermark = entity.Watermark,
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
                    HasFormRelease = entity.EInvFormReleases.Count > 0,
                    Status = (DefaultStatusType)entity.Status,
                    Version = entity.Version
                };
            }
            else
            {
                Client _client = (new ClientRepository()).Get(User);
                model.FormFileName = "01GTKT_001";
                try
                {
                    Byte[] textAsBytes = System.IO.File.ReadAllBytes(Server.MapPath("~/Resources/Reports/EInvoices/01GTKT_001.xsl"));
                    model.FormFile = Convert.ToBase64String(textAsBytes);
                }
                catch
                {
                    model.FormFile = "";
                }

                model.InvoiceForm = "E";
                model.InvoiceName = Resources.Resources.VAT_Invoice;
                model.SellerLegalName = _client.Description;
                model.SellerAddressLine = _client.Address;
                model.SellerTaxCode = _client.TaxCode;
                model.SellerEmail = _client.Email;
                model.SellerPhoneNumber = _client.Telephone;
                model.SellerContactPersonName = _client.ContactName;
                model.SellerSignedPersonName = _client.RepresentativeName;
                model.HasFormRelease = false;
            }
            return new Ext.Net.MVC.PartialViewResult() { Model = model };
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult _Maintenance(EInvFormTypeEditViewModel model)
        {
            DirectResult r = new DirectResult();

            if (ModelState.IsValid)
            {
                MyERPMembershipUser user = (MyERPMembershipUser)Membership.GetUser(User.Identity.Name, true);
                long clientId = user.ClientId ?? 0;
                long organizationId = user.OrganizationId ?? 0;

                if (clientId == 0 || organizationId == 0)
                {
                    r.Success = false;
                    r.ErrorMessage = Resources.Resources.User_dont_have_Client_or_Organization_Please_set;
                    return r;
                }
                bool isEdit = model.Id.HasValue;
                String formFile = Encoding.UTF8.GetString(Convert.FromBase64String(model.FormFile));

                if (model.Id.HasValue)
                {
                    var _update = repository.Get(c => c.Id == model.Id, new string[] { "EInvFormReleases" }).SingleOrDefault();
                    if (_update == null || _update.Version != model.Version)
                    {
                        r.Success = false;
                        r.ErrorMessage = "Form has been changed or deleted! Please check";
                        return r;
                    }

                    if (_update.EInvFormReleases.Count > 0)
                    {
                        r.Success = false;
                        r.ErrorMessage = "Form has release number! Can not Edit or Delete";
                        return r;
                    }

                    _update.InvoiceType = model.InvoiceType;
                    _update.InvoiceTypeNo = model.InvoiceTypeNo;
                    _update.TemplateCode = model.InvoiceType + "0/" + model.InvoiceTypeNo;
                    _update.InvoiceForm = model.InvoiceForm;
                    _update.InvoiceSeries = model.InvoiceSeries.ToUpper();
                    _update.FormFileName = model.FormFileName;
                    _update.FormFile = formFile;
                    _update.Logo = model.Logo;
                    _update.Watermark = model.Watermark;
                    _update.SellerLegalName = model.SellerLegalName;
                    _update.SellerTaxCode = model.SellerTaxCode;
                    _update.SellerAddressLine = model.SellerAddressLine;
                    _update.SellerPostalCode = String.IsNullOrWhiteSpace(model.SellerPostalCode) ? null : model.SellerPostalCode;
                    _update.SellerDistrictName = String.IsNullOrWhiteSpace(model.SellerDistrictName) ? null : model.SellerDistrictName;
                    _update.SellerCityName = String.IsNullOrWhiteSpace(model.SellerCityName) ? null : model.SellerCityName;
                    _update.SellerCountryCode = String.IsNullOrWhiteSpace(model.SellerCountryCode) ? null : model.SellerCountryCode;
                    _update.SellerPhoneNumber = String.IsNullOrWhiteSpace(model.SellerPhoneNumber) ? null : model.SellerPhoneNumber;
                    _update.SellerFaxNumber = String.IsNullOrWhiteSpace(model.SellerFaxNumber) ? null : model.SellerFaxNumber;
                    _update.SellerEmail = String.IsNullOrWhiteSpace(model.SellerEmail) ? null : model.SellerEmail;
                    _update.SellerBankName = String.IsNullOrWhiteSpace(model.SellerBankName) ? null : model.SellerBankName;
                    _update.SellerBankAccount = String.IsNullOrWhiteSpace(model.SellerBankAccount) ? null : model.SellerBankAccount;
                    _update.SellerContactPersonName = String.IsNullOrWhiteSpace(model.SellerContactPersonName) ? null : model.SellerContactPersonName;
                    _update.SellerSignedPersonName = String.IsNullOrWhiteSpace(model.SellerSignedPersonName) ? null : model.SellerSignedPersonName;
                    _update.Status = (byte)model.Status;
                    _update.RecModifiedAt = DateTime.Now;
                    _update.RecModifiedBy = (long)user.ProviderUserKey;
                    _update.Version++;

                    try
                    {
                        this.repository.Update(_update);
                    }
                    catch (Exception ex)
                    {
                        r.Success = false;
                        r.ErrorMessage = ex.Message;
                        return r;
                    }

                }
                else
                {
                    var _newModel = new DataAccess.EInvFormType()
                    {
                        ClientId = clientId,
                        OrganizationId = organizationId,
                        InvoiceType = model.InvoiceType,
                        InvoiceTypeNo = model.InvoiceTypeNo,
                        TemplateCode = model.InvoiceType + "0/" + model.InvoiceTypeNo,
                        InvoiceForm = model.InvoiceForm,
                        InvoiceSeries = model.InvoiceSeries.ToUpper(),
                        FormFileName = model.FormFileName,
                        FormFile = formFile,
                        Logo = model.Logo,
                        Watermark = model.Watermark,
                        SellerLegalName = model.SellerLegalName,
                        SellerTaxCode = model.SellerTaxCode,
                        SellerAddressLine = model.SellerAddressLine,
                        SellerPostalCode = String.IsNullOrWhiteSpace(model.SellerPostalCode) ? null : model.SellerPostalCode,
                        SellerDistrictName = String.IsNullOrWhiteSpace(model.SellerDistrictName) ? null : model.SellerDistrictName,
                        SellerCityName = String.IsNullOrWhiteSpace(model.SellerCityName) ? null : model.SellerCityName,
                        SellerCountryCode = String.IsNullOrWhiteSpace(model.SellerCountryCode) ? null : model.SellerCountryCode,
                        SellerPhoneNumber = String.IsNullOrWhiteSpace(model.SellerPhoneNumber) ? null : model.SellerPhoneNumber,
                        SellerFaxNumber = String.IsNullOrWhiteSpace(model.SellerFaxNumber) ? null : model.SellerFaxNumber,
                        SellerEmail = String.IsNullOrWhiteSpace(model.SellerEmail) ? null : model.SellerEmail,
                        SellerBankName = String.IsNullOrWhiteSpace(model.SellerBankName) ? null : model.SellerBankName,
                        SellerBankAccount = String.IsNullOrWhiteSpace(model.SellerBankAccount) ? null : model.SellerBankAccount,
                        SellerContactPersonName = String.IsNullOrWhiteSpace(model.SellerContactPersonName) ? null : model.SellerContactPersonName,
                        SellerSignedPersonName = String.IsNullOrWhiteSpace(model.SellerSignedPersonName) ? null : model.SellerSignedPersonName,
                        Status = (byte)model.Status,
                        Version = 1,
                        RecModifiedAt = DateTime.Now,
                        RecCreatedBy = (long)user.ProviderUserKey,
                        RecCreatedAt = DateTime.Now,
                        RecModifiedBy = (long)user.ProviderUserKey
                    };

                    try
                    {
                        var newEntity = this.repository.AddNew(_newModel);
                        model.Id = newEntity.Id;
                    }
                    catch (Exception ex)
                    {
                        r.Success = false;
                        r.ErrorMessage = ex.Message;
                        return r;
                    }
                }

                r.Success = true;
                r.Result = new { Id = model.Id };
                return r;
            }
            r.Success = false;
            return r;
        }

        [HttpGet]
        public ActionResult Delete(string id)
        {
            DirectResult r = new DirectResult();
            if (!String.IsNullOrEmpty(id))
            {
                var _id = Convert.ToInt64(id);
                var entity = repository.Get(c => c.Id == _id, new string[] { "EInvFormReleases" }).SingleOrDefault();
                if (entity == null)
                {
                    r.Success = false;
                    r.ErrorMessage = "Form not found! Please check";
                    return r;
                }

                if (entity.EInvFormReleases.Count > 0)
                {
                    r.Success = false;
                    r.ErrorMessage = "Form has release number! Can not Edit or Delete";
                    return r;
                }

                try
                {
                    this.repository.Delete(entity);
                }
                catch (Exception e)
                {
                    r.Success = false;
                    r.ErrorMessage = e.Message;
                    return r;
                }
            }
            else
            {
                throw new ArgumentNullException(nameof(id));
            }

            return this.Direct();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult InvoiceFormRender(string modelJson)
        {
            EInvFormTypeEditViewModel model = JSON.Deserialize<EInvFormTypeEditViewModel>(modelJson, new JsonSerializerSettings
            {
                Culture = Thread.CurrentThread.CurrentCulture
            });
            
            String formFile = Encoding.UTF8.GetString(Convert.FromBase64String(model.FormFile));

            EInvXMLInvoiceInfo invoiceInfo = new EInvXMLInvoiceInfo();
            invoiceInfo.InvoiceDataInfo = new EInvXMLInvoiceDataInfo() {
                InvoiceName = model.InvoiceName,
                InvoiceType = model.InvoiceType,
                InvoiceSeries = model.InvoiceSeries.ToUpper(),
                TemplateCode = model.InvoiceType + "0/" + model.InvoiceTypeNo
            };

            invoiceInfo.InvoiceDataInfo.SellerInfo = new EInvXMLSellerInfo()
            {
                SellerLegalName = model.SellerLegalName,
                SellerAddressLine = model.SellerAddressLine,
                SellerTaxCode = model.SellerTaxCode,
                SellerBankAccount = String.IsNullOrWhiteSpace(model.SellerBankAccount) ? null : model.SellerBankAccount,
                SellerBankName = String.IsNullOrWhiteSpace(model.SellerBankName) ? null : model.SellerBankName,
                SellerPostalCode = String.IsNullOrWhiteSpace(model.SellerPostalCode) ? null : model.SellerPostalCode,
                SellerDistrictName = String.IsNullOrWhiteSpace(model.SellerDistrictName) ? null : model.SellerDistrictName,
                SellerCityName = String.IsNullOrWhiteSpace(model.SellerCityName) ? null : model.SellerCityName,
                SellerCountryCode = String.IsNullOrWhiteSpace(model.SellerCountryCode) ? null : model.SellerCountryCode,
                SellerPhoneNumber = String.IsNullOrWhiteSpace(model.SellerPhoneNumber) ? null : model.SellerPhoneNumber,
                SellerFaxNumber = String.IsNullOrWhiteSpace(model.SellerFaxNumber) ? null : model.SellerFaxNumber,
                SellerEmail = String.IsNullOrWhiteSpace(model.SellerEmail) ? null : model.SellerEmail,
                SellerContactPersonName = String.IsNullOrWhiteSpace(model.SellerContactPersonName) ? null : model.SellerContactPersonName,
                SellerSignedPersonName = String.IsNullOrWhiteSpace(model.SellerSignedPersonName) ? null : model.SellerSignedPersonName
            };

            String formVars = "";
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
                    formVars = Encoding.UTF8.GetString(textAsBytes); // Your XML
                }
            }
            
            string renderName = $"formTypeRender_{User.Identity.Name}_{DateTime.Now:yyyyMMddhhmmss}";
            string dirPath = Server.MapPath($"~/Resources/PrintReports/EInvoices/{renderName}");
            if (!System.IO.Directory.Exists(dirPath))
            {
                System.IO.Directory.CreateDirectory(dirPath);
            }
            using (StringReader srt = new StringReader(formFile)) // xslInput is a string that contains xsl
            using (StringReader sri = new StringReader(formVars)) // xmlInput is a string that contains xml
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
                        System.IO.File.WriteAllText(dirPath + $"/{renderName}.html", sw.ToString(), Encoding.UTF8);
                    }
                }
            }
            if (!String.IsNullOrEmpty(model.Logo))
            {
                System.IO.File.WriteAllBytes(dirPath + "/logo.png", Convert.FromBase64String(model.Logo));
            }

            Panel invoiceFormViewer = X.GetCmp<Panel>("InvoiceFormViewer");
            invoiceFormViewer.Loader = new ComponentLoader()
            {
                Mode = LoadMode.Frame,
                DisableCaching = true,
                Url = $"~/Resources/PrintReports/EInvoices/{renderName}/{renderName}.html"
            };
            invoiceFormViewer.Loader.SuspendScripting();
            invoiceFormViewer.LoadContent();

            return this.Direct();
        }

        [HttpGet]
        public ActionResult _ListInvoiceTemplate()
        {
            string path = Server.MapPath("~/Resources/Reports/EInvoices");
            var ext = new List<string> { ".png" };
            var files = System.IO.Directory.GetFiles(path, "*.png", SearchOption.AllDirectories).Where(s => !s.ToLower().Contains("blank.png")).ToArray();

            List<object> model = new List<object>(files.Length);
            foreach (string fileName in files)
            {
                System.IO.FileInfo fi = new System.IO.FileInfo(fileName);
                model.Add(new
                {
                    Name = fi.Name.Substring(0, fi.Name.IndexOf(".png", StringComparison.Ordinal)),
                    Url = Url.Content("~/Resources/Reports/EInvoices/") + fi.Name
                });
            }

            return PartialView(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult _SelectInvoiceTemplate(string selectedInvoiceTemplateID)
        {
            X.GetCmp<TextField>("FormFileName").SetValue(selectedInvoiceTemplateID);
            try
            {
                Byte[] textAsBytes = System.IO.File.ReadAllBytes(Server.MapPath($"~/Resources/Reports/EInvoices/{selectedInvoiceTemplateID}.xsl"));
                X.GetCmp<TextField>("FormFile").SetValue(Convert.ToBase64String(textAsBytes));
            }
            catch
            {
                return this.Direct(false, $"ERROR : In Function _SelectInvoiceTemplate with template : {selectedInvoiceTemplateID}");
            }

            return this.Direct();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult _SelectLogo()
        {
            var btnSelectLogo = this.GetCmp<FileUploadField>("btnSelectLogo");
            if (btnSelectLogo.HasFile)
            {
                var contentLength = btnSelectLogo.PostedFile.ContentLength;
                var contentType = btnSelectLogo.PostedFile.ContentType;
                var stream = btnSelectLogo.PostedFile.InputStream;
                using (MemoryStream ms = new MemoryStream())
                {
                    stream.CopyTo(ms);
                    string base64 = Convert.ToBase64String(ms.ToArray());
                    this.GetCmp<Hidden>("Logo").SetValue(base64);
                }
            }
            return this.Direct();
        }
    }
}