<%@ Page Language="C#" AutoEventWireup="true" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml" >
	<head runat="server">
		<title>MyERP</title>
		<style type="text/css">
			html, body {
			height: 100%;
			overflow: auto;
			}
			body {
			padding: 0;
			margin: 0;
			}
			#silverlightControlHost {
			height: 100%;
			text-align:center;
			}
		</style>
		<script type="text/javascript" src="Silverlight.js"></script>
		<script type="text/javascript" src="SplashScreen.js"></script>
		<script type="text/javascript">
		    var _gaq = _gaq || [];
		    _gaq.push(['_setAccount', 'UA-111455-1']);
		    _gaq.push(['_setDomainName', '.telerik.com']);
		    _gaq.push(['_addIgnoredRef', 'telerik.com']);
		    _gaq.push(['_trackPageview', location.pathname + location.search + location.hash]);

		    (function () {
		        var ga = document.createElement('script');
		        ga.type = 'text/javascript';
		        ga.async = true;
		        ga.src = ('https:' == document.location.protocol ? 'https://ssl' : 'http://www') + '.google-analytics.com/ga.js';

		        var s = document.getElementsByTagName('script')[0];
		        s.parentNode.insertBefore(ga, s);
		    })();
		</script>
		<script type="text/javascript">
		    function onSilverlightError(sender, args) {
		        var appSource = "";
		        if (sender != null && sender != 0) {
		            appSource = sender.getHost().Source;
		        }

		        var errorType = args.ErrorType;
		        var iErrorCode = args.ErrorCode;

		        if (errorType == "ImageError" || errorType == "MediaError") {
		            return;
		        }

		        var errMsg = "Unhandled Error in Silverlight Application " + appSource + "\n";

		        errMsg += "Code: " + iErrorCode + "    \n";
		        errMsg += "Category: " + errorType + "       \n";
		        errMsg += "Message: " + args.ErrorMessage + "     \n";

		        if (errorType == "ParserError") {
		            errMsg += "File: " + args.xamlFile + "     \n";
		            errMsg += "Line: " + args.lineNumber + "     \n";
		            errMsg += "Position: " + args.charPosition + "     \n";
		        }
		        else if (errorType == "RuntimeError") {
		            if (args.lineNumber != 0) {
		                errMsg += "Line: " + args.lineNumber + "     \n";
		                errMsg += "Position: " + args.charPosition + "     \n";
		            }
		            errMsg += "MethodName: " + args.methodName + "     \n";
		        }

		        throw new Error(errMsg);
		    }
		</script>
	</head>
	<body>
		<!-- Google Tag Manager -->
		<noscript>
			<iframe src="//www.googletagmanager.com/ns.html?id=GTM-6X92"
					height="0" width="0" style="display:none;visibility:hidden"></iframe>
		</noscript>
		<script>(function (w, d, s, l, i) {
                    w[l] = w[l] || [];
                    w[l].push({
                        'gtm.start':
                        new Date().getTime(), event: 'gtm.js'
                    });
                    var f = d.getElementsByTagName(s)[0],
                    j = d.createElement(s), dl = l != 'dataLayer' ? '&l=' + l : '';
                    j.async = true;
                    j.src =
                    '//www.googletagmanager.com/gtm.js?id=' + i + dl;
                    f.parentNode.insertBefore(j, f);
                })(window, document, 'script', 'dataLayer', 'GTM-6X92');
		</script>
		<!-- End Google Tag Manager -->
		<form id="form1" runat="server" style="height:100%">
			<div id="silverlightControlHost">
				<object data="data:application/x-silverlight-2," type="application/x-silverlight-2" width="100%" height="100%">
					<param name="source" value="ClientBin/MyERP.xap"/>
					<param name="onError" value="onSilverlightError" />
					<param name="background" value="white" />
					<param name="minRuntimeVersion" value="4.0.60310.0" />
					<param name="splashscreensource" value="SplashScreen.xaml"/>
					<param name="onSourceDownloadProgressChanged" value="onSourceDownloadProgressChanged" />
					<param name="autoUpgrade" value="true" />
					<a href="http://go.microsoft.com/fwlink/?LinkID=149156&v=4.0.60310.0" style="text-decoration:none">
						<img src="http://go.microsoft.com/fwlink/?LinkId=161376" alt="Get Microsoft Silverlight" style="border-style:none"/>
					</a>
				</object>
				<iframe id="_sl_historyFrame" style="visibility:hidden;height:0px;width:0px;border:0px"></iframe>
			</div>
		</form>
	</body>
</html>
