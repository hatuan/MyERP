﻿using System;
using System.Globalization;
using System.Threading;
using System.Windows;
using MyERP.Helpers;
using Telerik.Windows.Controls;

namespace MyERP
{
    public partial class App: Application 
    {

        public App() 
        {
            this.Startup += this.Application_Startup;
            this.Exit += this.Application_Exit;
            this.UnhandledException += this.Application_UnhandledException;

            InitializeComponent();

            // Create a WebContext and add it to the ApplicationLifetimeObjects
            // collection.  This will then be available as WebContext.Current.
            //MyERP.Repositories.WebContext webContext = new MyERP.Repositories.WebContext();
            //webContext.Authentication = new FormsAuthentication()
            //{
            //    DomainContext = new MyERPAuthenticationDomainContext()
            //};
            //this.ApplicationLifetimeObjects.Add(webContext);
        }

        private void Application_Startup(object sender, StartupEventArgs e) 
        {

            LocalizationManager.DefaultCulture = new CultureInfo("en-US");
            Thread.CurrentThread.CurrentCulture = LocalizationManager.DefaultCulture;
            Thread.CurrentThread.CurrentUICulture = LocalizationManager.DefaultCulture;
            
            //TODO : Thuc hien Update Schema, Create Index & Upload Data
            
            AssemblyCache.Initialize();
            var bootstrapper = new Bootstrapper();
            bootstrapper.Run();
        }

        private void Application_Exit(object sender, EventArgs e) 
        {

        }
        private void Application_UnhandledException(object sender, ApplicationUnhandledExceptionEventArgs e) 
        {
            // If the app is running outside of the debugger then report the exception using
            // the browser's exception mechanism. On IE this will display it a yellow alert 
            // icon in the status bar and Firefox will display a script error.
            if (!System.Diagnostics.Debugger.IsAttached) 
            {

                // NOTE: This will allow the application to continue running after an exception has been thrown
                // but not handled. 
                // For production applications this error handling should be replaced with something that will 
                // report the error to the website and stop the application.
                e.Handled = true;
                Deployment.Current.Dispatcher.BeginInvoke(delegate { ReportErrorToDOM(e); });
            }
        }
        private void ReportErrorToDOM(ApplicationUnhandledExceptionEventArgs e)
        {
  	        try {
                string errorMsg = e.ExceptionObject.Message + e.ExceptionObject.StackTrace;
                errorMsg = errorMsg.Replace('"', '\'').Replace("\r\n", @"\n");

                System.Windows.Browser.HtmlPage.Window.Eval("throw new Error(\"Unhandled Error in Silverlight Application " + errorMsg + "\");");
            }
            catch (Exception) {
            }
        }
    }
}