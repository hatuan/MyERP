<?xml version='1.0' encoding='UTF-8' ?> 
<xsl:transform version="1.0" xmlns:xsl="http://www.w3.org/1999/XSL/Transform" xmlns:inv="http://laphoadon.gdt.gov.vn/2014/09/invoicexml/v1" xmlns:ds="http://www.w3.org/2000/09/xmldsig#">
    <xsl:strip-space elements="*"/>
    <xsl:decimal-format decimal-separator="," grouping-separator="."/>
    <xsl:template match="inv:invoice">
        <html>
            <head>
                <style>                    
                    tbody{
                    }
                    .header{    
                    vertical-align:top
                    }
                    .invoiceName{
                    font-weight:bold;
                    font-size:18px;                    
                    }
                    .titleInvoice{
                    font-weight:bold;
                    font-style: italic;
                    font-size:16px;                   
                    }
                    .serif {
                    font-family: "Times New Roman", Times, serif;
                    }

                    .sansserif {
                    font-family: Arial, Helvetica, sans-serif;
                    }
                    .image-box {
                    text-align:center;
                    }
                    .image-box img {
                    opacity: 0.3;
                    width: 350px;
                    background-image: none;
                    background-repeat: no-repeat;
                    background-position: center center;
                    background-size: cover;
                    margin-top:300px;
                    margin-bottom: 100px;
                    }

                    img[src=""] {
                    display: none;
                    }

                    .watermark {
                    top: 0;
                    left: 0;
                    bottom: 0;
                    right: 0;
                    position: absolute;
                    z-index: -2;   
                    margin-left:auto;
                    margin-right:auto;                    
                    width:400px;
                    margin-top: 0px;
                    }

                    .itemNormal{
                    font-weight: normal;
                    padding : 2px 2px 2px 2px 
                    }

                    .itemBold{
                    font-weight:bold;
                    /*vertical-align:top;*/
                    padding : 2px 2px 2px 2px 
                    }
                    .labelNormal{
                    padding : 2px 2px 2px 2px 
                    }

                    .labelItalic{
                    padding : 2px 2px 2px 2px;
                    font-style: italic;
                    color: #000000;
                    }
                    
                    .labelItalicNormal{
                    padding : 2px 2px 2px 2px;
                    font-style: italic;
                    font-weight: normal;
                    color: #000000;
                    }
                    
                    .labelBold{
                    font-weight:bold; 
                    /*vertical-align:top;*/
                    padding : 2px 2px 2px 2px 
                    }
                    
                    

                    .boxLarge{
                    margin-left:auto;
                    margin-right:auto;                    
                    border-collapse: collapse;
                    padding : 5px 5px 5px 5px;
                    border: 3px solid;
                    width:838.267px;
                    }
                    .boxSmall{                        
                    border-collapse: collapse;
                    padding : 5px 5px 5px 5px;
                    border: 1px solid;
                    }
                    .boxSmallTable{   
                    border-spacing: 0px;
                    padding : 0px 0px 0px 0px;
                    border: 1px solid;
                    }
                    .dataInfoInvoice{
                    vertical-align:top;
                    font-weight:bold; 
                    padding : 2px 2px 2px 2px 
                    }
                    <!--Bat buoc phai co - dau hieu nhan biet de change color-->
                    <!--Start_color-->
                    .invoiceName{
                    color: #000000;
                    }
                    .invoiceNameItalic{
                    color: #000000;
                    font-style: italic;
                    }
                    .titleInvoice{
                    color: #000000;
                    }
                    .itemNormal{
                    color: #000000;
                    }
                    .itemBold{
                    color: #000000;
                    }
                    .labelNormal{
                    color: #000000;
                    }
                    .labelBold{
                    color: #000000;
                    }
                    .boxLarge{                    
                    color: #000000;
                    border-style: solid;
                    border-width: medium;
                    }
                    .boxSmall{    
                    color: #000000;
                    }						
                    
                    
                    .borderBottom{    
                    border-bottom: 2px solid #4C3F57;
                    }					
                    <!--End_custom_nuoc_lai_chau
                    background-image: url("background.jpg");
                    z-index: -16 !important;
                    -->
                </style>			
            </head>
            <body >	
                <!--<div class = "watermark">
                    <div class="image-box">
                        <img src="" align="middle"/>                    
                    </div>
                </div>-->						
                <table ALIGN="center" class = "serif boxLarge">				
                    <tr class = "borderBottom">
                        <td align="center" width = "23%">						
                            <!--<img src="" align="middle" style="width: 112px;height: 80px;" />-->
                            <!--<img src="logo_xnk1.png" align="middle"/>-->
                            <!--<img src="" align="middle" style="height: 130px;"/>-->
                            <img src="" align="middle" style="max-height: 150px; max-width: 150px;"/>
                            <!--<img src="logo hoa don-02.jpg" align="middle" style="height: 130px;"/>-->
                            <!--<img src="logo hoa don_1-02.jpg" align="middle" style="height: 130px;"/>-->
                            <!--<img src="logo_crop55.png" align="middle" style="height: 130px;"/>-->
                            <br/>
                        </td>
                        <td width="50%" align="center" class="header" style="color:#000000" >
                            <br/>
                            <font class="invoiceName">
                                <!--<xsl:value-of select="inv:invoiceData/inv:invoiceName"/>-->
                                H??A ????N GI?? TR??? GIA T??NG
                            </font>
                            <br/>
                            <font class="titleInvoice">B???n th??? hi???n c???a h??a ????n ??i???n t???</font>
                            <br/>
                            <xsl:choose>
                                <xsl:when test="inv:invoiceData/inv:invoiceIssuedDate !='null'">
                                    <font class="labelNormal">Ng??y</font>
                                    <xsl:value-of select="substring(inv:invoiceData/inv:invoiceIssuedDate, 9, 2)"/> 
                                    <font class="labelNormal">th??ng</font>
                                    <xsl:value-of select="substring(inv:invoiceData/inv:invoiceIssuedDate, 6, 2)"/> 
                                    <font class="labelNormal">n??m</font>
                                    <xsl:value-of select="substring(inv:invoiceData/inv:invoiceIssuedDate, 1, 4)"/> 
                                </xsl:when>
                                <xsl:otherwise>Ng??y.... th??ng.... n??m.... </xsl:otherwise>
                            </xsl:choose>									
                                 
                        </td>
                        <td width="27%" style="vertical-align:top;">
                            <!--<table align="right" class= "boxSmall dataInfoInvoice" style = "border: none !important;">-->
                            <table align="right" class= "boxSmall" style = "border: none !important;">    
                                <tr style="vertical-align:top">
                                    <td align="left">
                                        <font class="labelBold" >M???u s???:</font>
                                    </td>
                                    <td align="left" class = "itemNormal">
                                        <xsl:value-of select="inv:invoiceData/inv:templateCode"/>
                                    </td>
                                </tr>
                                <tr>
                                    <td align="left">
                                        <font class="labelBold" >K?? hi???u:</font>
                                    </td>
                                    <td align="left" class = "itemNormal">
                                        <xsl:value-of select="inv:invoiceData/inv:invoiceSeries"/>
                                    </td>
                                </tr>
                                <tr>
                                    <td align="left">
                                        <font class="labelBold" >S???:</font>
                                    </td>
                                    <td align="left" class = "itemNormal">
                                        <xsl:value-of select="inv:invoiceData/inv:invoiceNumber"/>
                                    </td>
                                </tr>
                            </table>							
                        </td>	
                    </tr>
                    <tr class = "borderBottom">	
                        <td colspan="3">	
                            <table width="100%">
                                <tr width="100%">				
                                    <td width = "80%" >
                                        <table width="100%">	
                                            <tr>					
                                                <td colspan="3" >
                                                    <table>
                                                        <tr>
                                                            <td>
                                                                <font class="labelBold" >????n v??? b??n h??ng: </font>
                                                                <font class="itemNormal">
                                                                    <xsl:value-of select="inv:invoiceData/inv:seller/inv:sellerLegalName"/>
                                                                </font>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td>
                                                                <font class="labelBold" >M?? s??? thu???: </font>
                                                                <font class="itemNormal">
                                                                    <!--<strong style = "border: 1px solid #000;"><xsl:value-of select="inv:invoiceData/inv:seller/inv:sellerTaxCode"/></strong>-->
                                                                    <xsl:variable name = "sellerTaxCodeLength" select = "string-length(inv:invoiceData/inv:seller/inv:sellerTaxCode)"/>
                                                                    <xsl:variable name = "sellerTaxCode" select = "inv:invoiceData/inv:seller/inv:sellerTaxCode"/>
                                                                    <xsl:value-of select="$sellerTaxCode"/>
                                                                    <!--<strong style = "border: 1px solid #000;padding: 0 5px 2px;">
                                                                        <xsl:value-of select="substring($sellerTaxCode,1,1)"/>
                                                                    </strong>
                                                                    <strong style = "border: 1px solid #000;padding: 0 5px 2px;">
                                                                        <xsl:value-of select="substring($sellerTaxCode,2,1)"/>
                                                                    </strong>
                                                                    <strong style = "border: 1px solid #000;padding: 0 5px 2px;">
                                                                        <xsl:value-of select="substring($sellerTaxCode,3,1)"/>
                                                                    </strong>
                                                                    <strong style = "border: 1px solid #000;padding: 0 5px 2px;">
                                                                        <xsl:value-of select="substring($sellerTaxCode,4,1)"/>
                                                                    </strong>
                                                                    <strong style = "border: 1px solid #000;padding: 0 5px 2px;">
                                                                        <xsl:value-of select="substring($sellerTaxCode,5,1)"/>
                                                                    </strong>
                                                                    <strong style = "border: 1px solid #000;padding: 0 5px 2px;">
                                                                        <xsl:value-of select="substring($sellerTaxCode,6,1)"/>
                                                                    </strong>
                                                                    <strong style = "border: 1px solid #000;padding: 0 5px 2px;">
                                                                        <xsl:value-of select="substring($sellerTaxCode,7,1)"/>
                                                                    </strong>
                                                                    <strong style = "border: 1px solid #000;padding: 0 5px 2px;">
                                                                        <xsl:value-of select="substring($sellerTaxCode,8,1)"/>
                                                                    </strong>
                                                                    <strong style = "border: 1px solid #000;padding: 0 5px 2px;">
                                                                        <xsl:value-of select="substring($sellerTaxCode,9,1)"/>
                                                                    </strong>
                                                                    <xsl:if test="$sellerTaxCodeLength>= 10">
                                                                        <strong style = "border: 1px solid #000;padding: 0 5px 2px;">
                                                                            <xsl:value-of select="substring($sellerTaxCode,10,1)"/>
                                                                        </strong>
                                                                    </xsl:if>
                                                                    <xsl:if test="$sellerTaxCodeLength>= 11">
                                                                        <strong style = "border: 1px solid #000;padding: 0 5px 2px;">
                                                                            <xsl:value-of select="substring($sellerTaxCode,11,1)"/>
                                                                        </strong>
                                                                    </xsl:if>
                                                                    <xsl:if test="$sellerTaxCodeLength>= 12">
                                                                        <strong style = "border: 1px solid #000;padding: 0 5px 2px;">
                                                                            <xsl:value-of select="substring($sellerTaxCode,12,1)"/>
                                                                        </strong>
                                                                    </xsl:if>
                                                                    <xsl:if test="$sellerTaxCodeLength>= 13">
                                                                        <strong style = "border: 1px solid #000;padding: 0 5px 2px;">
                                                                            <xsl:value-of select="substring($sellerTaxCode,13,1)"/>
                                                                        </strong>
                                                                    </xsl:if>
                                                                    <xsl:if test="$sellerTaxCodeLength>= 14">
                                                                        <strong style = "border: 1px solid #000;padding: 0 5px 2px;">
                                                                            <xsl:value-of select="substring($sellerTaxCode,14,1)"/>
                                                                        </strong>
                                                                    </xsl:if>-->
                                                                </font>
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </td>							
                                            </tr>
                                            <tr>
                                                <td colspan="3">
                                                    <table>
                                                        <tr>
                                                            <td>
                                                                <font class="labelBold" >?????a ch???: </font>
                                                                <font class="itemNormal">
                                                                    <xsl:value-of select="inv:invoiceData/inv:seller/inv:sellerAddressLine"/>
                                                                </font>
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td colspan="3">
                                                    <table width="100%">
                                                        <tr>
                                                            <td width = "50%" >
                                                                <font class="labelBold" >??i???n tho???i: </font>
                                                                <font class="itemNormal">
                                                                    <xsl:value-of select="inv:invoiceData/inv:seller/inv:sellerPhoneNumber"/>
                                                                </font>
                                                            </td>
                                                            <td>
                                                                <font class="labelBold" >S??? t??i kho???n:</font>
                                                                <font class="itemNormal">
                                                                    <xsl:value-of select="inv:invoiceData/inv:seller/inv:sellerBankAccount"/>
                                                                </font>
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </td>
                                            </tr> 											
                                        </table>
                                    </td>   
                                    <!--dung de dung barcode neu can-->
                                    <!--                                    <td width="20%"   align="center" margin="auto" >
                                        <div id="qrcode" style="width: 105px;height: 105px"></div>
                                    </td>                                  -->
                                </tr>
                            </table>
                        </td>
                    </tr>
                    <tr>	
                        <td colspan="3">	
                            <table width="100%">
                                <tr width="100%">				
                                    <td width = "80%" >
                                        <table width="100%">	
                                            <tr>
                                                <td colspan="2">
                                                    <table width="100%">
                                                        <tr>
                                                            <td colspan="3" style="width: 50%">
                                                                <font class="labelBold" >H??? t??n ng?????i mua h??ng: </font>
                                                                <font class="itemNormal">
                                                                    <xsl:value-of select="inv:invoiceData/inv:buyer/inv:buyerDisplayName"/>    
                                                                </font>
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td colspan="2">
                                                    <table align="left" width="100%">
                                                        <tr>
                                                            <td style="width: 50%">
                                                                <font class="labelBold" >T??n ????n v???: </font>
                                                                <font class="itemNormal">
                                                                    <xsl:value-of select="inv:invoiceData/inv:buyer/inv:buyerLegalName"/>    
                                                                </font>
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td colspan="2">
                                                    <table align="left" width="100%">
                                                        <tr>
                                                            <td style="width: 50%">
                                                                <font class="labelBold" >M?? s??? thu???: </font>
                                                                <font class="itemBold">
                                                                    <xsl:value-of select="inv:invoiceData/inv:buyer/inv:buyerTaxCode"/>
                                                                </font>
                                                            </td>
                                                            <!--<td style="width: 50%">
                                                                <font class="labelNormal" >T???i ng??n h??ng (Bank name): </font>
                                                                <font class="itemNormal">
                                                                    <xsl:value-of select="inv:invoiceData/inv:seller/inv:sellerBankName"/>
                                                                </font>
                                                            </td>-->
                                                        </tr>
                                                    </table>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td colspan="2">
                                                    <table align="left" width="100%">
                                                        <tr>
                                                            <td style="width: 50%">
                                                                <font class="labelBold" >?????a ch???: </font>
                                                                <font class="itemNormal">
                                                                    <xsl:value-of select="inv:invoiceData/inv:buyer/inv:buyerAddressLine"/>
                                                                </font>
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </td>
                                            </tr>
                                            
                                            <tr>
                                                <td colspan="2" style="">
                                                    <table width="100%">
                                                        <tr>
                                                            <td style="width: 50%">
                                                                <font class="labelBold" >H??nh th???c thanh to??n: </font>
                                                                <font class="itemNormal">
                                                                    <xsl:value-of select="inv:invoiceData/inv:payments/inv:payment/inv:paymentMethodName"/>
                                                                </font>
                                                            </td>
                                                            <td style="width: 50%">
                                                                <font class="labelBold" >S??? t??i kho???n: </font>
                                                                <font class="itemNormal">
                                                                    <xsl:value-of select="inv:invoiceData/inv:buyer/inv:buyerBankAccount"/>
                                                                </font>
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td colspan="3">
                                                    <table width="100%">
                                                        <tr>
                                                            <td style="width: 100%">
                                                                <font class="labelBold" >Ghi ch??: </font>
                                                                <font class="itemNormal">
                                                                    <xsl:if test="inv:invoiceData/inv:invoiceNote != ''">
                                                                        <font >
                                                                            <xsl:value-of select="inv:invoiceData/inv:invoiceNote"/>
                                                                        </font>
                                                                    </xsl:if>
                                                                </font>
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </td>
                                            </tr>
                                        </table>
                                    </td>					
                                    <!--                                    <td width="20%"   align="center" margin="auto" >
                                        <div id="qrcode" style="width: 105px;height: 105px"></div>
                                    </td>-->
                                </tr>
                            </table>
                        </td>
                    </tr>
                    <tr>
                        <td colspan="3">
                            <table width="100%" class= "boxSmallTable">
                                <tr width="100%">
                                    <th width="5%" align="center" class= "boxSmall" style="text-align: center">
                                        <font class="labelBold" >STT</font>
                                    </th>
                                    <th width="30%" align="center" class= "boxSmall" style="text-align: center">
                                        <!--<font class="labelBold" >T??n h??ng h??a, d???ch v???</font>-->
                                        <font class="labelBold" >T??N H??NG H??A, D???CH V???</font>
                                    </th>
                                    <th width="13%" align="center" class= "boxSmall" style="text-align: center">
                                        <!--<font class="labelBold" >????n v??? t??nh</font>-->
                                        <font class="labelBold" >????N V??? T??NH</font>
                                    </th>
                                    <th width="10%" align="center" class= "boxSmall" style="text-align: center">
                                        <!--<font class="labelBold" >S??? l?????ng</font>-->
                                        <font class="labelBold" >S??? L?????NG</font>
                                    </th>
                                    <th width="13%" align="center" class= "boxSmall" style="text-align: center">
                                        <!--<font class="labelBold" >????n gi??</font>-->
                                        <font class="labelBold" >????N GI??</font>
                                    </th>
                                    <th width="13%" align="center" class= "boxSmall" style="text-align: center">
                                        <!--<font class="labelBold" >Th??nh ti???n</font>-->
                                        <font class="labelBold" >TH??NH TI???N</font>
                                    </th>
                                </tr>
                                <tr width="100%">
                                    <th width="5%" align="center" class= "boxSmall labelBold"  style="text-align: center">A</th>
                                    <th width="35%" align="center" class= "boxSmall labelBold" style="text-align: center">B</th>
                                    <th width="8%" align="center" class= "boxSmall labelBold"  style="text-align: center">C</th>
                                    <th width="10%" align="center" class= "boxSmall labelBold" style="text-align: center">1</th>
                                    <th width="13%" align="center" class= "boxSmall labelBold" style="text-align: center">2</th>
                                    <th width="13%" align="center" class= "boxSmall labelBold" style="text-align: center">3 = 1 x 2</th>
                                </tr>
                                <xsl:for-each select="inv:invoiceData/inv:items/inv:item">
                                    <tr>
                                        <td align="center" class= "boxSmall itemNormal">
                                            <xsl:value-of select="inv:lineNumber"/>
                                        </td>
                                        <td align="left" class= "boxSmall itemNormal">
                                            <xsl:value-of select="inv:itemName"/>
                                        </td>
                                        <td align="center" class= "boxSmall itemNormal">
                                            <xsl:value-of select="inv:unitName"/>
                                        </td>
                                        <td align="right" class= "boxSmall itemNormal">
                                            <xsl:choose>
                                                <xsl:when test="string-length(inv:quantity) = 0">
	                                              </xsl:when>
                                                <xsl:when test="inv:quantity = null">
                                                    <xsl:value-of select="format-number(inv:quantity, '###.###,####')"/>
                                                </xsl:when>
                                                <xsl:when test="string-length(inv:quantity) = 1">
                                                    <xsl:value-of select="format-number(inv:quantity, '###.###,####')"/>
                                                </xsl:when>
                                                <xsl:when test="string-length(inv:quantity) > 1">
                                                    <xsl:value-of select="format-number(inv:quantity, '###.###,####')"/>
                                                </xsl:when>
                                                <xsl:otherwise>
                                                    <xsl:value-of select="format-number(inv:quantity, '###.###,####')"/>
                                                </xsl:otherwise>
                                            </xsl:choose>
                                        </td>
                                        <td align="right" class= "boxSmall itemNormal">
                                            <xsl:if test="inv:unitPrice != 'null' and inv:unitPrice > 0">
                                                <xsl:value-of select="format-number(inv:unitPrice, '###.###,####')"/>
                                            </xsl:if>
                                        </td>
                                        <td align="right" class= "boxSmall itemNormal">
                                            <xsl:if test="inv:itemTotalAmountWithoutVat != 'null' and inv:itemTotalAmountWithoutVat > 0">
                                                <xsl:value-of select="format-number(inv:itemTotalAmountWithoutVat, '###.###,####')"/>
                                            </xsl:if>
                                        </td>
                                        <!--                                        <td align="right" class= "boxSmall itemNormal">
                                            <xsl:if test="inv:vatPercentage != 'null' and inv:vatPercentage > 0">
                                                <xsl:value-of select="format-number(inv:vatPercentage, '###.###,####')"/>
                                            </xsl:if>
                                        </td>
                                        <td align="right" class= "boxSmall itemNormal">
                                            <xsl:if test="inv:vatAmount != 'null' and inv:vatAmount > 0">
                                                <xsl:value-of select="format-number(inv:vatAmount, '###.###,####')"/>
                                                <xsl:value-of select="format-number(inv:vatAmount, '###.###,####')"/>
                                            </xsl:if>
                                        </td>
                                        <td align="right" class= "boxSmall itemNormal">
                                            <xsl:if test="inv:itemTotalAmountWithoutVat != 'null' and inv:itemTotalAmountWithoutVat > 0 and inv:vatAmount != 'null'">
                                                <xsl:value-of select="format-number(inv:vatAmount+inv:itemTotalAmountWithoutVat, '###.###,####')"/>
                                                <xsl:choose>
                                                    <xsl:when test="inv:vatAmount = null">
                                                        <xsl:value-of select="format-number(inv:itemTotalAmountWithoutVat, '###.###,####')"/>
                                                    </xsl:when>
                                                    <xsl:when test="inv:vatAmount = ''">
                                                        <xsl:value-of select="format-number(inv:itemTotalAmountWithoutVat, '###.###,####')"/>
                                                    </xsl:when>
                                                    <xsl:otherwise>
                                                        <xsl:value-of select="format-number(inv:vatAmount+inv:itemTotalAmountWithoutVat, '###.###,####')"/>
                                                    </xsl:otherwise>
                                                </xsl:choose>
                                            </xsl:if>
                                        </td>-->
                                    </tr>
                                </xsl:for-each>
                                <!--                                <tr width="100%">
                                    <th width="5%" align="center" class= "boxSmall labelBold">II</th>
                                    <th width="35%" align="center" class= "boxSmall labelBold">CHI???T KH???U</th>
                                    <th width="8%" align="center" class= "boxSmall labelBold"/>
                                    <th width="10%" align="center" class= "boxSmall labelBold"/>
                                    <th width="13%" align="center" class= "boxSmall labelBold"/>
                                    <th width="13%" align="center" class= "boxSmall labelBold"/>
                                    <th width="8%" align="center" class= "boxSmall labelBold"/>
                                    <th width="10%" align="center" class= "boxSmall labelBold"/>
                                    <th align="center" class= "boxSmall labelBold"/>
                                </tr>-->
                                <!-- start triet khau-->
                                <!--                                <xsl:for-each select="inv:invoiceData/inv:discountItems/inv:discountItems">
                                    <tr>
                                        <td align="center" class= "boxSmall itemNormal">
                                            <xsl:value-of select="inv:lineNumber"/>
                                        </td>
                                        <td align="left" class= "boxSmall itemNormal">
                                            <xsl:value-of select="inv:itemName"/>
                                        </td>
                                        <td align="center" class= "boxSmall itemNormal">
                                            <xsl:value-of select="inv:unitName"/>
                                        </td>
                                        <td align="right" class= "boxSmall itemNormal">
                                            <xsl:choose>
                                                <xsl:when test="string-length(inv:quantity) = 0">
	</xsl:when>
     <xsl:when test="inv:quantity = null">
                                                    <xsl:value-of select="format-number(inv:quantity, '###.###,####')"/>
                                                </xsl:when>
                                                <xsl:when test="string-length(inv:quantity) = 1">
                                                    <xsl:value-of select="format-number(inv:quantity, '###.###,####')"/>
                                                </xsl:when>
                                                <xsl:when test="string-length(inv:quantity) > 1">
                                                    <xsl:value-of select="format-number(inv:quantity, '###.###,####')"/>
                                                </xsl:when>
                                                <xsl:otherwise>
                                                    <xsl:value-of select="format-number(inv:quantity, '###.###,####')"/>
                                                </xsl:otherwise>
                                            </xsl:choose>
                                        </td>
                                        <td align="right" class= "boxSmall itemNormal">
                                                                                        <xsl:if test="inv:itemTotalAmountWithoutVat != 'null' and inv:itemTotalAmountWithoutVat > 0">
                                                <xsl:value-of select="format-number(inv:unitPrice, '###.###,####')"/>
                                            </xsl:if>
                                        </td>
                                        <td align="right" class= "boxSmall itemNormal">
                                            <xsl:if test="inv:itemTotalAmountWithoutVat != 'null' and inv:itemTotalAmountWithoutVat > 0">
                                                <xsl:value-of select="format-number(inv:itemTotalAmountWithoutVat, '###.###,####')"/>
                                            </xsl:if>
                                        </td>
                                        <td align="right" class= "boxSmall itemNormal">
                                            <xsl:if test="inv:vatPercentage != 'null' and inv:vatPercentage > 0">
                                                <xsl:value-of select="format-number(inv:vatPercentage, '###.###,####')"/>
                                            </xsl:if>
                                        </td>
                                        <td align="right" class= "boxSmall itemNormal">
                                            <xsl:if test="inv:vatAmount != 'null' and inv:vatAmount > 0">
                                                <xsl:value-of select="format-number(inv:vatAmount, '###.###,####')"/>
                                                <xsl:value-of select="format-number(inv:vatAmount, '###.###,####')"/>
                                            </xsl:if>
                                        </td>
                                        <td align="right" class= "boxSmall itemNormal">
                                            <xsl:if test="inv:itemTotalAmountWithoutVat != 'null' and inv:itemTotalAmountWithoutVat > 0 and inv:vatAmount != 'null'">
                                                <xsl:value-of select="format-number(inv:vatAmount+inv:itemTotalAmountWithoutVat, '###.###,####')"/>
                                                <xsl:choose>
                                                    <xsl:when test="inv:vatAmount = null">
                                                        <xsl:value-of select="format-number(inv:itemTotalAmountWithoutVat, '###.###,####')"/>
                                                    </xsl:when>
                                                    <xsl:when test="inv:vatAmount = ''">
                                                        <xsl:value-of select="format-number(inv:itemTotalAmountWithoutVat, '###.###,####')"/>
                                                    </xsl:when>
                                                    <xsl:otherwise>
                                                        <xsl:value-of select="format-number(inv:vatAmount+inv:itemTotalAmountWithoutVat, '###.###,####')"/>
                                                    </xsl:otherwise>
                                                </xsl:choose>
                                            </xsl:if>
                                        </td>
                                    </tr>
                                </xsl:for-each>-->
                                <!--end triet khau-->
                                <tr>
                                    <td align="right" colspan="5" class= "boxSmall">
                                        <font class="labelBold" >C???ng ti???n h??ng h??a, d???ch v???:</font>
                                    </td>
                                    <td align="right" class= "boxSmall itemNormal">
                                        <xsl:if test="inv:invoiceData/inv:totalAmountWithoutVAT != 'null' and inv:invoiceData/inv:totalAmountWithoutVAT > 0">
                                            <xsl:value-of select="format-number(inv:invoiceData/inv:totalAmountWithoutVAT, '###.###,####')"/>
                                        </xsl:if>
                                    </td>
                                    <!--                                    <td align="right" class= "boxSmall itemNormal"></td>
                                    <td align="right" class= "boxSmall itemNormal">
                                        <xsl:if test="inv:invoiceData/inv:totalVATAmount != 'null' and inv:invoiceData/inv:totalVATAmount > 0">
                                            <xsl:value-of select="format-number(inv:invoiceData/inv:totalVATAmount, '###.###,####')"/>
                                        </xsl:if>
                                    </td>
                                    <td align="right" rowspan="2" class= "boxSmall itemNormal">
                                        <xsl:if test="inv:invoiceData/inv:totalAmountWithVAT != 'null' and inv:invoiceData/inv:totalAmountWithVAT > 0">
                                            <xsl:value-of select="format-number(inv:invoiceData/inv:totalAmountWithVAT, '###.###')"/>
                                        </xsl:if>
                                    </td>-->
                                </tr>
                                <xsl:choose>
                                    <xsl:when test="inv:invoiceData/inv:invoiceTaxBreakdowns/inv:invoiceTaxBreakdowns != 'null'">
                                        <xsl:for-each select="inv:invoiceData/inv:invoiceTaxBreakdowns/inv:invoiceTaxBreakdowns">
                                            <tr>
                                                <td align="left"  colspan="5" class= "boxSmall labelNormal">
                                                    <font style = "float: left;" class="labelBold">Thu??? su???t GTGT:</font>
                                                    <font style = "float: left;" class="labelNormal">
                                                        <xsl:value-of select="inv:vatPercentage"/>% 
                                                    </font>
                                                    <font style= "float: right;" class="labelBold">Ti???n thu??? GTGT:</font>                                                      
                                                </td>
                                                <xsl:choose>
                                                    <xsl:when test="inv:vatPercentage != 'null' and inv:vatPercentage > 0">
                                                        <td align="right" colspan="1" class= "boxSmall itemNormal">
                                                            <xsl:if test="inv:vatTaxAmount != 'null' and inv:vatTaxAmount > 0">
                                                                <font class = "itemNormal">
                                                                    <xsl:value-of select="format-number(inv:vatTaxAmount, '###.###,####')"/>
                                                                </font>
                                                            </xsl:if>       
                                                        </td>
                                                    </xsl:when>
                                                    <xsl:otherwise>
                                                        <td align="right" colspan="1" class= "boxSmall itemNormal">
                                                        </td>
                                                    </xsl:otherwise>      
                                                </xsl:choose>        
<!--                                                <xsl:if test="inv:vatPercentage != 'null' and inv:vatPercentage > 0">
                                                    <td align="right" colspan="1" class= "boxSmall itemNormal">
                                                        <xsl:if test="inv:vatTaxAmount != 'null' and inv:vatTaxAmount > 0">
                                                            <font class = "itemNormal">
                                                                <xsl:value-of select="format-number(inv:vatTaxAmount, '###.###,####')"/>
                                                            </font>
                                                        </xsl:if>       
                                                    </td>
                                                </xsl:if>-->
                                            </tr>
                                        </xsl:for-each>
                                    </xsl:when>
                                    <xsl:otherwise>
                                        <tr>
                                            <td align="left"  colspan="5" class= "boxSmall labelNormal">
                                                <font style = "float: left;" class="labelBold">Thu??? su???t GTGT:</font>
                                                <font style = "float: left;" class="labelNormal">
                                                    x  % 
                                                </font>
                                                <font style= "float: right;" class="labelBold">Ti???n thu??? GTGT:</font>                                                      
                                            </td>
                                            <td align="right" colspan="1" class= "boxSmall itemNormal">      
                                            </td>
                                        </tr>
                                    </xsl:otherwise>
                                </xsl:choose>
                                <tr>
                                    <td align="right" colspan="5" class= "boxSmall">
                                        <font class="labelBold" >T???ng c???ng ti???n thanh to??n:</font>
                                    </td>
                                    <td align="right" class= "boxSmall itemNormal">
                                        <xsl:if test="inv:invoiceData/inv:totalAmountWithVAT != 'null' and inv:invoiceData/inv:totalAmountWithVAT > 0">
                                            <xsl:value-of select="format-number(inv:invoiceData/inv:totalAmountWithVAT, '###.###')"/>
                                        </xsl:if>
                                    </td>
                                </tr>
                                <tr>
                                    <td align="left" colspan="9" class= "boxSmall">
                                        <font class="labelBold" >S??? ti???n vi???t b???ng ch???:</font>
                                        <font class = "itemNormal">
                                            <xsl:value-of select="inv:invoiceData/inv:totalAmountWithVATInWords"/>
                                        </font>
                                    </td>
                                </tr>
                            </table>                            					
                        </td>
                    </tr>
                    <tr>	
                        <td colspan="3">
                            <table width="100%">
                                <!--<td>
                                    <div id="pdf147"></div>
                                </td>	
                                <input type="hidden" id="barcode">
                                    <xsl:attribute name="value">
                                        <xsl:value-of select="Barcode"/>
                                    </xsl:attribute>
                                </input> 							
                                <td>
                                    <font id="signature" style="font-weight:bold;color: #FF0000;font-size:8pt align:center"></font>
                                </td>-->
                                <tr>
                                    <td align="center" width="50%">
                                        <font class="labelBold" text-align="top">Ng?????i mua h??ng</font>
                                    </td>
                                    <td  align="center" width="50%">
                                        <font class="labelBold" >Ng?????i b??n h??ng</font>
                                    </td>
                                </tr>
                                <tr>
                                    <td></td>
                                    <td align="center" width="50%">
                                        <xsl:if test="inv:invoiceData/inv:seller/inv:sellerLegalName != 'null'">
                                            <font class="labelBold" style="font-weight:bold;color: #FF0000;word-wrap:break-word">K?? b???i <xsl:value-of select="inv:invoiceData/inv:seller/inv:sellerLegalName"/></font>                                                                    
                                        </xsl:if>
                                    </td>
                                </tr>    
                                <!--<input type="hidden" id="signatureValue">
                                    <xsl:attribute name="value">
                                        <xsl:if test="inv:invoiceData/inv:seller/inv:sellerLegalName != 'null'">
                                            K?? b???i <xsl:value-of select="inv:invoiceData/inv:seller/inv:sellerLegalName"/>                                                                    
                                        </xsl:if>       
                                    </xsl:attribute>
                                </input>-->
                            </table>
                        </td>                         					
                    </tr>
                    <tr>
                        <td colspan="3">	
                            <table width="100%">
                                <tr width="100%">
                                    <hr style="border-bottom:dotted"/><!--style="border-top: 1px dashed #8c8b8b;" --> 
                                </tr>
                                <tr width="100%">				
                                    <td width = "80%">
                                        <table width="100%">	
                                            <tr>					
                                                <td align="center" >
                                                    <table>
                                                        <tr>
                                                            <td align="center" >
                                                                <font class="labelItalic"> ????n v??? cung c???p H??a ????n ??i???n t???: C??ng ty TNHH ?????u T?? V?? Ph??t Tri???n Doanh Nghi???p B??NH MINH, MST: 0108196397 </font>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td align="center" >
                                                                <font class="labelItalic">Tra c???u h??a ????n ??i???n t??? t???i Website: https://ehoadon.com.vn, M?? s??? b?? m???t:</font>
                                                                <font class = "itemNormal">
                                                                    <xsl:value-of 
                                                                        select ="substring-after(substring-before(inv:invoiceData/inv:userDefines,'&lt;/reservationCode>'),'&lt;reservationCode>')" />
                                                                </font>
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </td>        
                                            </tr>
                                        </table>
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                </table>				 
            </body>
        </html>
    </xsl:template>
</xsl:transform>