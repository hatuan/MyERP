<?xml version='1.0' encoding='UTF-8' ?>
<xsl:transform version="1.0" xmlns:xsl="http://www.w3.org/1999/XSL/Transform" xmlns:inv="http://laphoadon.gdt.gov.vn/2014/09/invoicexml/v1" xmlns:ds="http://www.w3.org/2000/09/xmldsig#">
  <xsl:strip-space elements="*"/>
  <xsl:decimal-format decimal-separator="," grouping-separator="."/>
  <xsl:template name="loop">
    <xsl:param name="var"></xsl:param>
    <xsl:choose>
      <xsl:when test="$var &lt; 10 and $var &gt; 0">
        <tr>
          <td align="center" class= "boxSmall itemNormal">
            <font class="labelNormal" ></font>
          </td>
          <td align="left" class= "boxSmall itemNormal">
          </td>
          <td align="center" class= "boxSmall itemNormal">
          </td>
          <td align="right" class= "boxSmall itemNormal">
          </td>
          <td align="right" class= "boxSmall itemNormal">
          </td>
          <td align="right" class= "boxSmall itemNormal">
          </td>
          <td align="right" class= "boxSmall itemNormal">
          </td>
        </tr>
        <xsl:call-template name="loop">
          <xsl:with-param name="var">
            <xsl:number value="number($var)+1" />
          </xsl:with-param>
        </xsl:call-template>
      </xsl:when>
      <xsl:otherwise>
      </xsl:otherwise>
    </xsl:choose>
  </xsl:template>
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
          font-size:18pt;
          }
          .titleInvoice{
          font-weight:bold;
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
          <!--opacity: 0.9;-->
          width: 350px;
          background-image: none;
          background-repeat: no-repeat;
          background-position: center center;
          background-size: cover;
          margin-top:300px;
          margin-bottom: 100px;
          }

          .image-box img[src=""] {
          display: none;
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
          border: 3px double;
          width:838.267px;
          }
          .boxSmall{
          border-collapse: collapse;
          padding : 5px 5px 5px 5px;
          border: 0.1px solid;
          }
          .boxSmallTable{
          border-spacing: 0px;
          padding : 0px 0px 0px 0px;
          border: 0.1px solid;
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
          border-style: double;
          border-width: medium;
          }
          .boxSmall{
          color: #000000;
          }


          .borderBottom{
          border-bottom: 2px solid #000000;
          }
          .BG {
          <!--opacity: 0.3;-->
          background-image: url(signature.png);
          background-repeat: no-repeat;
          background-position: center top;
          background-size: 200px 70px;
          }
          img[src=""] {
          display: none;
          }
          <!--End_custom_nuoc_lai_chau
                    background-image: url("background.jpg");
                    z-index: -16 !important;
                    -->
        </style>
      </head>
      <body >
        <table  id='section-to-print' ALIGN="center" class = "serif boxLarge" style="background-image:url(watermark.png); background-repeat:no-repeat;background-position: center 350px;">
          <tr class = "borderBottom">
            <td colspan="3" align="center">
              <img src="logo.png" style="max-height: 200px; max-width: 100%;" align="middle"/>
            </td>
          </tr>
          <tr>
            <td width="24%" align="center">
            </td>
            <td width="48%" align="center" class="header" style="color:#000000" >
              <font class="invoiceName">
                HÓA ĐƠN GIÁ TRỊ GIA TĂNG
              </font>
              <br/>
              <!--<font class="invoiceNameItalic">
                (VAT INVOICE)
              </font>
              <br/>-->
              <font class="labelBold">Bản thể hiện của hóa đơn điện tử</font>
              <!--<br/>
              <font class="labelItalic">
                (Electronic invoice display)
              </font>-->
              <br/>
              <xsl:choose>
                <xsl:when test="inv:invoiceData/inv:invoiceIssuedDate !='null'">
                  <font class="labelNormal">Ngày </font>
                  <!--<font class="labelItalic" >(date) </font>-->
                  <xsl:value-of select="substring(inv:invoiceData/inv:invoiceIssuedDate, 9, 2)"/>
                  <font class="labelNormal"> tháng </font>
                  <!--<font class="labelItalic" >(month) </font>-->
                  <xsl:value-of select="substring(inv:invoiceData/inv:invoiceIssuedDate, 6, 2)"/>
                  <font class="labelNormal"> năm </font>
                  <!--<font class="labelItalic" >(year) </font>-->
                  <xsl:value-of select="substring(inv:invoiceData/inv:invoiceIssuedDate, 1, 4)"/>
                </xsl:when>
                <xsl:otherwise>
                  <!--Ngày<font class="labelItalic" >(date) </font>..... tháng<font class="labelItalic" >(month) </font>..... năm<font class="labelItalic" >(year) </font>....-->
                  Ngày ..... tháng ...... năm .........
                </xsl:otherwise>
              </xsl:choose>

            </td>
            <td width="28%" style="vertical-align:top; padding-right: 5px">
              <!--<table align="right" class= "boxSmall dataInfoInvoice" style = "border: none !important;">-->
              <table align="right" class= "boxSmall" style = "border: none !important;">
                <tr style="vertical-align:top">
                  <!--<td align="left" class="labelBold">Mẫu số (Form): </td>-->
                  <td align="left">
                    <font class="labelNormal" >Mẫu số: </font>
                    <!--<font class="labelItalic" >(Form): </font>-->
                  </td>
                  <td align="left" class = "labelBold">
                    <xsl:value-of select="inv:invoiceData/inv:templateCode"/>
                  </td>
                </tr>
                <tr>
                  <td align="left">
                    <font class="labelNormal" >Ký hiệu: </font>
                    <!--<font class="labelItalic" >(Serial): </font>-->
                  </td>
                  <td align="left" class = "itemBold">
                    <xsl:value-of select="inv:invoiceData/inv:invoiceSeries"/>
                  </td>
                </tr>
                <tr>
                  <!--<td align="left" class="labelBold">Số (No.): </td>-->
                  <td align="left">
                    <font class="labelNormal" >Số: </font>
                    <!--<font class="labelItalic" >(No.): </font>-->
                  </td>
                  <td align="left" class = "itemBold" style="color: #ff0000">
                    <xsl:value-of select="inv:invoiceData/inv:invoiceNumber"/>
                  </td>
                </tr>
              </table>
            </td>
          </tr>
          <tr>
            <td colspan="3">
              <table width="100%">
                <tr>
                  <td colspan="3">
                    <font class="labelNormal" >Họ tên người mua hàng: </font>
                    <!--<font class="labelItalic" >(Customer's name): </font>-->
                    <font class="itemNormal">
                      <xsl:value-of select="inv:invoiceData/inv:buyer/inv:buyerDisplayName"/>
                    </font>
                  </td>
                </tr>
                <tr>
                  <td colspan="3">
                    <font class="labelNormal" >Tên đơn vị: </font>
                    <!--<font class="labelItalic" >(Company's name): </font>-->
                    <font class="itemNormal">
                      <xsl:value-of select="inv:invoiceData/inv:buyer/inv:buyerLegalName"/>
                    </font>
                  </td>
                </tr>
                <tr>
                  <td colspan="3">
                    <font class="labelNormal" >Địa chỉ: </font>
                    <!--<font class="labelItalic" >(Address): </font>-->
                    <font class="itemNormal">
                      <xsl:value-of select="inv:invoiceData/inv:buyer/inv:buyerAddressLine"/>
                    </font>
                  </td>
                </tr>
                <tr>
                  <td colspan="3">
                    <font class="labelNormal" >Mã số thuế: </font>
                    <!--<font class="labelItalic" >(Tax code): </font>-->
                    <font class="itemNormal">
                      <xsl:value-of select="inv:invoiceData/inv:buyer/inv:buyerTaxCode"/>
                    </font>
                  </td>
                </tr>
                <tr>
                  <td style="width: 30%">
                    <font class="labelNormal" >Hình thức thanh toán:</font>
                    <!--<font class="labelItalic" >(Payment method): </font>-->
                    <font class="itemNormal">
                      <xsl:value-of select="inv:invoiceData/inv:payments/inv:payment/inv:paymentMethodName"/>
                    </font>
                  </td>
                  <td style="width: 40%">
                    <font class="labelNormal" >Số tài khoản: </font>
                    <!--<font class="labelItalic" >(Account No.): </font>-->
                    <font class="itemNormal">
                      <xsl:value-of select="inv:invoiceData/inv:buyer/inv:buyerBankAccount"/>
                    </font>
                  </td>
                  <td style="width: 30%">
                    <font class="labelNormal" >Hạn thanh toán: </font>
                    <!--<font class="labelItalic" >(Account No.): </font>-->
                    <font class="itemNormal">
                      <xsl:value-of select="inv:invoiceData/inv:metadata/inv:limitTerm"/>
                    </font>
                  </td>
                </tr>
              </table>
            </td>
          </tr>
          <tr>
            <td colspan="3">
              <table width="100%" class= "boxSmallTable" >
                <tr width="100%" >
                  <th width="5%" align="center" class= "boxSmall" >
                    <font class="labelBold" >STT</font>
                    <!--<br/>
                    <font class="labelItalicNormal">(No.)</font>-->
                  </th>
                  <th width="37%" align="center" class= "boxSmall" >
                    <font class="labelBold" >Tên hàng hóa, dịch vụ</font>
                    <!--<br/>
                    <font class="labelItalicNormal" >(Description)</font>-->
                    <!--<font class="labelBold" >TÊN HÀNG HÓA, DỊCH VỤ</font>-->
                  </th>
                  <th width="10%" align="center" class= "boxSmall" >
                    <font class="labelBold" >Đơn vị tính</font>
                    <!--<br/>
                    <font class="labelItalicNormal" >(Unit)</font>-->
                    <!--<font class="labelBold" >ĐƠN VỊ TÍNH</font>-->
                  </th>
                  <th width="10%" align="center" class= "boxSmall">
                    <font class="labelBold" >Thuế suất (%)</font>
                  </th>
                  <th width="10%" align="center" class= "boxSmall" >
                    <font class="labelBold" >Số lượng</font>
                    <!--<br/>
                    <font class="labelItalicNormal" >(Qty)</font>-->
                    <!--<font class="labelBold" >SỐ LƯỢNG</font>-->
                  </th>
                  <th width="13%" align="center" class= "boxSmall" >
                    <font class="labelBold" >Đơn giá</font>
                    <!--<br/>
                    <font class="labelItalicNormal" >(Unit price)</font>-->
                    <!--<font class="labelBold" >ĐƠN GIÁ</font>-->
                  </th>
                  <th width="15%" align="center" class= "boxSmall" >
                    <font class="labelBold" >Thành tiền</font>
                    <!--<br/>
                    <font class="labelItalicNormal" >(Total)</font>-->
                    <!--<font class="labelBold" >THÀNH TIỀN</font>-->
                  </th>
                </tr>
                <tr width="100%" >
                  <th align="center" class= "boxSmall" >
                    <font class="labelBold" >A</font>
                  </th>
                  <th align="center" class= "boxSmall" >
                    <font class="labelBold" >B</font>
                  </th>
                  <th align="center" class= "boxSmall" >
                    <font class="labelBold" >C</font>
                  </th>
                  <th align="center" class= "boxSmall" >
                    <font class="labelBold" >1</font>
                  </th>
                  <th align="center" class= "boxSmall" >
                    <font class="labelBold" >2</font>
                  </th>
                  <th align="center" class= "boxSmall" >
                    <font class="labelBold" >3</font>
                  </th>
                  <th align="center" class= "boxSmall" >
                    <font class="labelBold" >4 = 2 x 3</font>
                  </th>
                </tr>
                <xsl:for-each select="inv:invoiceData/inv:items/inv:item">
                  <tr>
                    <td align="center" class= "boxSmall itemNormal">
                      <xsl:choose>
                        <xsl:when test="inv:lineNumber > 0 ">
                          <xsl:value-of select="inv:lineNumber"/>
                        </xsl:when>
                        <xsl:otherwise>
                          <font class="labelNormal" ></font>
                        </xsl:otherwise>
                      </xsl:choose>
                    </td>
                    <td align="left" class= "boxSmall itemNormal">
                      <xsl:value-of select="inv:itemName"/>
                    </td>
                    <td align="center" class= "boxSmall itemNormal">
                      <xsl:value-of select="inv:unitName"/>
                    </td>
                    <td align="right" class= "boxSmall itemNormal">
                      <xsl:if test="inv:vatPercentage != 'null' and inv:vatPercentage >= 0  ">
                        <xsl:value-of select="format-number(inv:vatPercentage, '###.##0,####')"/>
                      </xsl:if>
                    </td>
                    <td align="right" class= "boxSmall itemNormal">
                      <xsl:if test="string-length(inv:quantity) > 0 and inv:quantity > 0  ">
                        <xsl:value-of select="format-number(inv:quantity, '###.##0,####')"/>
                      </xsl:if>
                    </td>
                    <td align="right" class= "boxSmall itemNormal">
                      <xsl:if test="inv:unitPrice != 'null' and inv:unitPrice > 0  ">
                        <xsl:value-of select="format-number(inv:unitPrice, '###.##0,####') "/>
                      </xsl:if>
                    </td>
                    <td align="right" class= "boxSmall itemNormal">
                      <xsl:if test="inv:itemTotalAmountWithoutVat != 'null' and inv:itemTotalAmountWithoutVat > 0  ">
                        <xsl:value-of select="format-number(inv:itemTotalAmountWithoutVat, '###.##0,####')"/>
                      </xsl:if>
                    </td>
                  </tr>
                </xsl:for-each>
                <xsl:call-template name="loop">
                  <xsl:with-param name="var">
                    <xsl:choose>
                      <xsl:when test="count(//inv:invoiceData/inv:items/inv:item) > 10">
                        10
                      </xsl:when>
                      <xsl:otherwise>
                        <xsl:value-of select="count(//inv:invoiceData/inv:items/inv:item) mod 10"/>
                      </xsl:otherwise>
                    </xsl:choose>
                  </xsl:with-param>
                </xsl:call-template>
                <tr>
                  <td colspan="9">
                    <table align="left" width="100%" class= "boxSmallTable">
                      <tr width="100%" style="vertical-align:top">
                        <th width="22%" align="center" class= "boxSmall" >
                        </th>
                        <th width="17%" align="center" class= "boxSmall" >
                          <font class="labelBold" >Không chịu thuế</font>
                        </th>
                        <th width="15%" align="center" class= "boxSmall" >
                          <font class="labelBold" >Thuế suất 0%</font>
                        </th>
                        <th width="15%" align="center" class= "boxSmall" >
                          <font class="labelBold" >Thuế suất 5%</font>
                        </th>
                        <th width="15%" align="center" class= "boxSmall" >
                          <font class="labelBold" >Thuế suất 10%</font>
                        </th>
                        <th width="16%" align="center" class= "boxSmall" >
                          <font class="labelBold" >Tổng cộng</font>
                        </th>
                      </tr>
                      <tr>
                        <td align="left" class= "boxSmall">
                          <font class="itemBold">Tiền hàng hóa dịch vụ</font>
                          <!--<font class="labelItalic" >(Not taxable amount):</font>-->
                        </td>
                        <td align="right" class= "boxSmall">
                          <font class="lableNormal">
                            <xsl:for-each select="inv:invoiceData/inv:invoiceTaxBreakdowns/inv:invoiceTaxBreakdowns">
                              <xsl:if test="inv:vatPercentage = -2">
                                <font class = "lableNormal">
                                  <xsl:value-of select="format-number(inv:vatTaxableAmount, '###.##0,####')"/>
                                </font>
                              </xsl:if>
                            </xsl:for-each>
                          </font>
                          <!--<font class="labelItalic" >(Not taxable amount):</font>-->
                        </td>
                        <td align="right" class= "boxSmall">
                          <xsl:for-each select="inv:invoiceData/inv:invoiceTaxBreakdowns/inv:invoiceTaxBreakdowns">
                            <xsl:if test="inv:vatPercentage = 0">
                              <font class = "lableNormal">
                                <xsl:value-of select="format-number(inv:vatTaxableAmount, '###.##0,####')"/>
                              </font>
                            </xsl:if>
                          </xsl:for-each>
                        </td>
                        <td align="right" class= "boxSmall">
                          <xsl:for-each select="inv:invoiceData/inv:invoiceTaxBreakdowns/inv:invoiceTaxBreakdowns">
                            <xsl:if test="inv:vatPercentage = 5">
                              <font class = "lableNormal">
                                <xsl:value-of select="format-number(inv:vatTaxableAmount, '###.##0,####')"/>
                              </font>
                            </xsl:if>
                          </xsl:for-each>
                        </td>
                        <td align="right" class= "boxSmall">
                          <xsl:for-each select="inv:invoiceData/inv:invoiceTaxBreakdowns/inv:invoiceTaxBreakdowns">
                            <xsl:if test="inv:vatPercentage = 10">
                              <font class = "lableNormal">
                                <xsl:value-of select="format-number(inv:vatTaxableAmount, '###.##0,####')"/>
                              </font>
                            </xsl:if>
                          </xsl:for-each>
                        </td>
                        <td align="right" class= "boxSmall labelBold" >
                          <xsl:if test="inv:invoiceData/inv:totalAmountWithoutVAT != 'null' and inv:invoiceData/inv:totalAmountWithoutVAT &gt; 0">
                            <xsl:value-of select="format-number(inv:invoiceData/inv:totalAmountWithoutVAT, '###.##0,####')"/>
                          </xsl:if>
                        </td>
                      </tr>

                      <tr>
                        <td align="left" class= "boxSmall">
                          <font class="itemBold">Tiền thuế GTGT</font>
                          <!--<font class="labelItalic" >(Not taxable amount):</font>-->
                        </td>
                        <td align="right" class= "boxSmall">
                          <font class="lableNormal">

                          </font>
                          <!--<font class="labelItalic" >(Not taxable amount):</font>-->
                        </td>
                        <td align="right" class= "boxSmall">
                          <xsl:for-each select="inv:invoiceData/inv:invoiceTaxBreakdowns/inv:invoiceTaxBreakdowns">
                            <xsl:if test="inv:vatPercentage = 0">
                              <font class = "lableNormal">
                                <xsl:value-of select="format-number(inv:vatTaxAmount, '###.##0,####')"/>
                              </font>
                            </xsl:if>
                          </xsl:for-each>
                        </td>
                        <td align="right" class= "boxSmall">
                          <xsl:for-each select="inv:invoiceData/inv:invoiceTaxBreakdowns/inv:invoiceTaxBreakdowns">
                            <xsl:if test="inv:vatPercentage = 5">
                              <font class = "lableNormal">
                                <xsl:value-of select="format-number(inv:vatTaxAmount, '###.##0,####')"/>
                              </font>
                            </xsl:if>
                          </xsl:for-each>
                        </td>
                        <td align="right" class= "boxSmall">
                          <xsl:for-each select="inv:invoiceData/inv:invoiceTaxBreakdowns/inv:invoiceTaxBreakdowns">
                            <xsl:if test="inv:vatPercentage = 10">
                              <font class = "lableNormal">
                                <xsl:value-of select="format-number(inv:vatTaxAmount, '###.##0,####')"/>
                              </font>
                            </xsl:if>
                          </xsl:for-each>
                        </td>
                        <td align="right" class= "boxSmall labelBold">
                          <xsl:if test="inv:invoiceData/inv:totalVATAmount != 'null' and inv:invoiceData/inv:totalVATAmount &gt; 0">
                            <xsl:value-of select="format-number(inv:invoiceData/inv:totalVATAmount, '###.##0,####')"/>
                          </xsl:if>
                        </td>
                      </tr>
                      <tr>
                        <td align="left" class= "boxSmall">
                          <font class="itemBold">Tổng tiền thanh toán</font>
                          <!--<font class="labelItalic" >(Not taxable amount):</font>-->
                        </td>
                        <td align="right" class= "boxSmall">
                          <!--<font class="labelItalic" >(Not taxable amount):</font>-->
                          <xsl:for-each select="inv:invoiceData/inv:invoiceTaxBreakdowns/inv:invoiceTaxBreakdowns">
                            <xsl:if test="inv:vatPercentage = -2">
                              <font class = "lableNormal">
                                <xsl:value-of select="format-number(inv:vatTaxableAmount, '###.##0,####')"/>
                              </font>
                            </xsl:if>
                          </xsl:for-each>
                        </td>
                        <td align="right" class= "boxSmall">
                          <!--<font class="labelItalic" >(Not taxable amount):</font>-->
                          <xsl:for-each select="inv:invoiceData/inv:invoiceTaxBreakdowns/inv:invoiceTaxBreakdowns">
                            <xsl:if test="inv:vatPercentage = 0">
                              <font class = "lableNormal">
                                <xsl:value-of select="format-number(inv:vatTaxableAmount + inv:vatTaxAmount, '###.##0,####')"/>
                              </font>
                            </xsl:if>
                          </xsl:for-each>
                        </td>
                        <td align="right" class= "boxSmall">
                          <!--<font class="labelItalic" >(Not taxable amount):</font>-->
                          <xsl:for-each select="inv:invoiceData/inv:invoiceTaxBreakdowns/inv:invoiceTaxBreakdowns">
                            <xsl:if test="inv:vatPercentage = 5">
                              <font class = "lableNormal">
                                <xsl:value-of select="format-number(inv:vatTaxableAmount + inv:vatTaxAmount, '###.##0,####')"/>
                              </font>
                            </xsl:if>
                          </xsl:for-each>
                        </td>
                        <td align="right" class= "boxSmall">
                          <!--<font class="labelItalic" >(Not taxable amount):</font>-->
                          <xsl:for-each select="inv:invoiceData/inv:invoiceTaxBreakdowns/inv:invoiceTaxBreakdowns">
                            <xsl:if test="inv:vatPercentage = 10">
                              <font class = "lableNormal">
                                <xsl:value-of select="format-number(inv:vatTaxableAmount + inv:vatTaxAmount, '###.##0,####')"/>
                              </font>
                            </xsl:if>
                          </xsl:for-each>
                        </td>
                        <td align="right" class= "boxSmall labelBold">
                          <xsl:if test="inv:invoiceData/inv:totalAmountWithVAT != 'null' and inv:invoiceData/inv:totalAmountWithVAT &gt; 0">
                            <xsl:value-of select="format-number(inv:invoiceData/inv:totalAmountWithVAT, '###.##0,####')"/>
                          </xsl:if>
                        </td>
                      </tr>
                      <tr>
                        <td align="left" colspan="6" class= "boxSmall">
                          <font class="labelNormal" >Số tiền viết bằng chữ: </font>
                          <font class = "itemNormal">
                            <xsl:value-of select="inv:invoiceData/inv:totalAmountWithVATInWords"/>
                          </font>
                        </td>
                      </tr>
                    </table>
                  </td>
                </tr>
              </table>
            </td>
          </tr>
          <tr>
            <td colspan="3">
              <table width="100%">
                <tr>
                  <td align="center" width="50%" style="vertical-align: top">
                    <font class="labelBold" text-align="top">Người mua hàng</font>
                    <br/>
                    <font class="labelNormal" >Ký, ghi rõ họ tên</font>
                  </td>
                  <td  align="center" width="50%">
                    <font class="labelBold" >Người bán hàng</font>
                    <br/>
                    <font class="labelNormal" >Ký, đóng dấu, ghi rõ họ tên</font>
                    <br/>
                    <div class="BG">
                      <div style="height: 30px"  ></div>
                      <xsl:if test="inv:invoiceData/inv:seller/inv:sellerLegalName != 'null'">
                        <font class="labelBold" style="font-weight:bold;color: #FF0000;word-wrap:break-word">
                          Ký bởi <xsl:value-of select="inv:invoiceData/inv:seller/inv:sellerLegalName"/>
                        </font>
                        <br/>
                        <font class="labelBold" style="font-weight:bold;color: #FF0000;word-wrap:break-word">
                          Ký ngày <xsl:if test="inv:invoiceData/inv:invoiceSignedDate != 'null' and inv:invoiceData/inv:invoiceSignedDate != ''">
                            <xsl:value-of select="concat(substring(inv:invoiceData/inv:invoiceSignedDate, 9, 2),'/',substring(inv:invoiceData/inv:invoiceSignedDate, 6, 2),'/',substring(inv:invoiceData/inv:invoiceSignedDate, 1, 4))"/>
                          </xsl:if>
                        </font>
                      </xsl:if>
                      <div style="height: 10px"  ></div>
                    </div>

                  </td>
                </tr>
              </table>
            </td>
          </tr>
          <tr>
            <td colspan="3">
              <table width="100%">

                <tr>
                  <td align="center" style="border-top:dotted">
                    <font font-size="7pt" class="labelItalic"> Đơn vị cung cấp Hóa đơn điện tử: Công ty TNHH Đầu Tư Và Phát Triển Doanh Nghiệp BÌNH MINH, MST: 0108196397 </font>
                  </td>
                </tr>
                <tr>
                  <td align="center" >
                    <font font-size="7pt" class="labelItalic">Tra cứu hóa đơn điện tử tại Website: https://ehoadon.com.vn, Mã số bí mật:</font>
                    <font font-size="7pt" class = "itemNormal">
                      <xsl:value-of
                          select ="inv:invoiceData/inv:customDefines/inv:reservationCode" />
                    </font>
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