using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
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

        public ActionResult LookupData(StoreRequestParameters parameters, long? id = null)
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
                        OrganizationCode = c.Organization.Code,
                        Status = (DefaultStatusType)c.Status
                    });
                return this.Store(data, 1);
            }
            else
            {
                var paging = ((EInvFormTypeRepository)repository).Paging(parameters.Start, parameters.Limit,
                    parameters.SimpleSort, parameters.SimpleSortDirection);

                var data = paging.Data.Where(c => c.Status == (short)DefaultStatusType.Active)
                    .Select(c => new EInvFormTypeLookupViewModel
                    {
                        Id = c.Id,
                        InvoiceType = c.InvoiceType,
                        TemplateCode = c.TemplateCode,
                        InvoiceForm = c.InvoiceForm,
                        InvoiceSeries = c.InvoiceSeries,
                        OrganizationCode = c.Organization.Code,
                        Status = (DefaultStatusType)c.Status
                    }).ToList();
                return this.Store(data, paging.TotalRecords);
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
                string formVars = Convert.ToBase64String(Encoding.UTF8.GetBytes(entity.FormVars));
                string formFile = Convert.ToBase64String(Encoding.UTF8.GetBytes(entity.FormFile));
                model = new EInvFormTypeEditViewModel()
                {
                    Id = entity.Id,
                    InvoiceType = entity.InvoiceType,
                    InvoiceTypeNo = entity.InvoiceTypeNo,
                    TemplateCode = entity.TemplateCode,
                    InvoiceForm = entity.InvoiceForm,
                    InvoiceSeries = entity.InvoiceSeries,
                    FormFileName = entity.FormFileName,
                    FormFile = formFile,
                    FormVars = formVars,
                    Logo = entity.Logo,
                    Watermark = entity.Watermark,
                    HasFormRelease = entity.EInvFormReleases.Count > 0,
                    Status = (DefaultStatusType)entity.Status,
                    Version = entity.Version
                };
            }
            else
            {
                Client _client = (new ClientRepository()).Get(User);
                EInvXMLInvoiceInfo invoiceInfo = new EInvXMLInvoiceInfo
                {
                    InvoiceDataInfo = new EInvXMLInvoiceDataInfo()
                    {
                        InvoiceNumber = "00000000"
                    }
                };
                invoiceInfo.InvoiceDataInfo.SellerInfo = new EInvXMLSellerInfo
                {
                    SellerLegalName = _client.Description,
                    SellerAddressLine = _client.Adress,
                    SellerTaxCode = _client.TaxCode,
                    SellerEmail = _client.Email,
                    SellerPhoneNumber = _client.Telephone,
                };

                XmlWriterSettings settings = new XmlWriterSettings()
                {
                    Encoding = new UTF8Encoding(false),
                    Indent = true
                };
                using (MemoryStream sww = new MemoryStream())
                {
                    using (System.Xml.XmlWriter writer = System.Xml.XmlWriter.Create(sww, settings))
                    //using (System.Xml.XmlWriter writer = System.Xml.XmlWriter.Create(sww))
                    {
                        XmlSerializerNamespaces ns = new XmlSerializerNamespaces();
                        ns.Add("inv", "http://laphoadon.gdt.gov.vn/2014/09/invoicexml/v1");
                        //ns.Add("ns1", "http://www.w3.org/2000/09/xmldsig#");
                        XmlSerializer xsSubmit = new XmlSerializer(invoiceInfo.GetType());
                        xsSubmit.Serialize(writer, invoiceInfo, ns);
                        byte[] textAsBytes = sww.ToArray(); //Encoding.UTF8.GetBytes(Encoding.Default.GetString(sww.ToArray()));
                        model.FormVars = Convert.ToBase64String(textAsBytes); // Your XML
                    }
                }

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
                String formVars = Encoding.UTF8.GetString(Convert.FromBase64String(model.FormVars));
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
                    _update.FormVars = formVars;
                    _update.Logo = model.Logo;
                    _update.Watermark = model.Watermark;
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
                        FormVars = formVars,
                        Logo = model.Logo,
                        Watermark = model.Watermark,
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
            
            String formVars = Encoding.UTF8.GetString(Convert.FromBase64String(model.FormVars));
            String formFile = Encoding.UTF8.GetString(Convert.FromBase64String(model.FormFile));

            using (StringReader sri = new StringReader(formVars))
            {
                EInvXMLInvoiceInfo invoiceInfo = new EInvXMLInvoiceInfo();
                XmlSerializer serializer = new XmlSerializer(invoiceInfo.GetType());
                invoiceInfo = (EInvXMLInvoiceInfo) serializer.Deserialize(sri);
                invoiceInfo.InvoiceDataInfo.InvoiceType = model.InvoiceType;
                invoiceInfo.InvoiceDataInfo.InvoiceSeries = model.InvoiceSeries.ToUpper();
                invoiceInfo.InvoiceDataInfo.TemplateCode = model.InvoiceType + "0/" + model.InvoiceTypeNo;

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
                        model.FormVars = Convert.ToBase64String(textAsBytes); // Your XML
                        formVars = Encoding.UTF8.GetString(textAsBytes);
                    }
                }
            }

            string fileHtmlRenderName = $"formTypeRender_{User.Identity.Name}_{DateTime.Now:yyyyMMddhhmmss}";
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
                        System.IO.File.WriteAllText(Server.MapPath($"~/Resources/PrintReports/EInvoices/{fileHtmlRenderName}.html"), sw.ToString(), Encoding.UTF8);
                    }
                }
            }

            Panel invoiceFormViewer = X.GetCmp<Panel>("InvoiceFormViewer");
            invoiceFormViewer.Loader = new ComponentLoader()
            {
                Mode = LoadMode.Frame,
                DisableCaching = true,
                Url = $"~/Resources/PrintReports/EInvoices/{fileHtmlRenderName}.html"
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
    }
}