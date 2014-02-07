﻿<?xml version="1.0" encoding="utf-8"?>
<DomainModel xmlns:dm0="http://schemas.microsoft.com/VisualStudio/2008/DslTools/Core" dslVersion="2.0.0.0" name="MyERPModel" namespace="MyERPModel" showPropertiesCompartment="true" xmlns="http://www.telerik.com/ORM">
  <orm:orm name="MyERPModel" backend="postgresql" default-schema="public" xmlns:orm="http://tempuri.org/ORM">
    <orm:namespace name="MyERPModel" default="true">
      <orm:class name="Dmtk" uniqueId="6eb72546-4b19-4be3-bc2f-147db413bae3">
        <orm:table name="dmtk" />
        <orm:identity>
          <orm:single-field field-name="_tk" />
        </orm:identity>
        <orm:concurrency strategy="changed" />
        <orm:field name="_tk" property="Tk" behavior="readwrite" uniqueId="1bca08b6-06ed-403b-b789-1b0d0792338d" type="System.String">
          <orm:column name="tk" sql-type="text" nullable="false" length="0" scale="0" primary-key="true" ado-type="" />
        </orm:field>
        <orm:field name="_ten_tk" property="Ten_Tk" behavior="readwrite" uniqueId="b5ea29c0-b4ce-4a1d-bfd5-83abd4c14eea" type="System.String">
          <orm:column name="ten_tk" sql-type="text" nullable="false" length="0" scale="0" ado-type="" />
        </orm:field>
        <orm:field name="_ten_tk2" property="Ten_Tk2" behavior="readwrite" uniqueId="016bedd5-965e-40d0-8c6b-1cc475603e0b" type="System.String">
          <orm:column name="ten_tk2" sql-type="text" nullable="false" length="0" scale="0" ado-type="" />
        </orm:field>
        <orm:field name="_ma_nt" property="Ma_Nt" behavior="readwrite" uniqueId="29788ee2-2b0d-492f-809e-2ffdd40e1958" type="System.String">
          <orm:column name="ma_nt" sql-type="text" nullable="false" length="0" scale="0" ado-type="" />
        </orm:field>
        <orm:field name="_loai_tk" property="Loai_Tk" behavior="readwrite" uniqueId="bd4c79f5-ba9f-4971-bd04-5b9f675f41c5" type="System.Int16">
          <orm:column name="loai_tk" sql-type="int2" nullable="false" length="0" scale="0" ado-type="" />
        </orm:field>
        <orm:field name="_tk_me" property="Tk_Me" behavior="readwrite" uniqueId="6917e972-319f-48ff-8113-74f988f8f207" type="System.String">
          <orm:column name="tk_me" sql-type="text" nullable="false" length="0" scale="0" ado-type="" />
        </orm:field>
        <orm:field name="_bac_tk" property="Bac_Tk" behavior="readwrite" uniqueId="4479f3d5-2c52-420f-b4aa-854f3522673a" type="System.Int16">
          <orm:column name="bac_tk" sql-type="int2" nullable="false" length="0" scale="0" ado-type="" />
        </orm:field>
        <orm:field name="_tk_sc" property="Tk_Sc" behavior="readwrite" uniqueId="7d7c5901-188c-4d08-85cf-ba14a2dab0c9" type="System.Int16">
          <orm:column name="tk_sc" sql-type="int2" nullable="false" length="0" scale="0" ado-type="" />
        </orm:field>
        <orm:field name="_tk_cn" property="Tk_Cn" behavior="readwrite" uniqueId="e00c6586-0a6a-4383-ac9a-f6edb8f25ffe" type="System.Int16">
          <orm:column name="tk_cn" sql-type="int2" nullable="false" length="0" scale="0" ado-type="" />
        </orm:field>
        <orm:field name="_nh_tk2" property="Nh_Tk2" behavior="readwrite" uniqueId="ecfda42c-4724-43fb-a854-f0266d07dd78" type="System.String">
          <orm:column name="nh_tk2" sql-type="text" nullable="false" length="0" scale="0" ado-type="" />
        </orm:field>
        <orm:field name="_date0" property="Date0" behavior="readwrite" uniqueId="b195e850-7f51-4985-8d77-0caa89229611" type="System.DateTime">
          <orm:column name="date0" sql-type="timestamp" nullable="false" length="0" scale="0" ado-type="" />
        </orm:field>
        <orm:field name="_user_id0" property="User_Id0" behavior="readwrite" uniqueId="b2400957-7187-4b47-a8bb-9c3e896f861f" type="System.Int64">
          <orm:column name="user_id0" sql-type="int8" nullable="false" length="0" scale="0" ado-type="" />
        </orm:field>
        <orm:field name="_date2" property="Date2" behavior="readwrite" uniqueId="fc891926-702d-4fae-bda7-9a3b3a1930ce" type="System.DateTime">
          <orm:column name="date2" sql-type="timestamp" nullable="false" length="0" scale="0" ado-type="" />
        </orm:field>
        <orm:field name="_user_id2" property="User_Id2" behavior="readwrite" uniqueId="814a2a82-f889-4130-a895-c13cb4cf2f72" type="System.Int64">
          <orm:column name="user_id2" sql-type="int8" nullable="false" length="0" scale="0" ado-type="" />
        </orm:field>
        <orm:field name="_nh_tk0" property="Nh_Tk0" behavior="readwrite" uniqueId="975aabdf-092a-4ec1-baa3-72e0bb179933" type="System.String">
          <orm:column name="nh_tk0" sql-type="text" nullable="false" length="0" scale="0" ado-type="" />
        </orm:field>
        <orm:field name="_status" property="Status" behavior="readwrite" uniqueId="566c75e1-121f-4b7f-8faa-7c6c7f5b3626" type="System.String">
          <orm:column name="status" sql-type="text" nullable="false" length="0" scale="0" ado-type="" />
        </orm:field>
        <orm:field name="_userinfo2" property="Userinfo2" behavior="readwrite" uniqueId="146c96cd-d45f-4027-8e48-a484b606d9a1" type="MyERPModel.Userinfo">
          <orm:reference uniqueId="c3cdcc6e-97e8-45ee-a368-e904724c9fe5" association-name="DmtkHasUserinfo1">
            <orm:sharedfield name="_user_id2" target-class="MyERPModel.Userinfo" target-field="_user_id" />
          </orm:reference>
        </orm:field>
        <orm:field name="_userinfo0" property="Userinfo0" behavior="readwrite" uniqueId="69fae26b-c824-4ae7-9d5c-0a64d36df88a" type="MyERPModel.Userinfo">
          <orm:reference uniqueId="6fad391b-70de-401d-96ff-e53ac29cf9bf" association-name="DmtkHasUserinfo">
            <orm:sharedfield name="_user_id0" target-class="MyERPModel.Userinfo" target-field="_user_id" />
          </orm:reference>
        </orm:field>
        <orm:field name="_dmnt" property="Dmnt" behavior="readwrite" uniqueId="ece23fbc-8340-4545-a74b-b5d25c87c9ac" type="MyERPModel.Dmnt">
          <orm:reference uniqueId="fcbb016d-6494-434d-8c91-4779bd0cc5b7" association-name="DmtkHasDmnt">
            <orm:sharedfield name="_ma_nt" target-class="MyERPModel.Dmnt" target-field="_ma_nt" />
          </orm:reference>
        </orm:field>
      </orm:class>
      <orm:class name="Userinfo" uniqueId="6ac6097f-bd1d-4391-ae80-67131f49d19f">
        <orm:table name="userinfo" />
        <orm:identity>
          <orm:single-field field-name="_user_id" />
        </orm:identity>
        <orm:concurrency strategy="changed" />
        <orm:field name="_user_id" property="User_Id" behavior="readwrite" uniqueId="022c9ba3-96ec-44f2-9646-99dc0465bf3f" type="System.Int64">
          <orm:column name="user_id" sql-type="int8" nullable="false" length="0" scale="0" primary-key="true" ado-type="" />
        </orm:field>
        <orm:field name="_user_name" property="User_Name" behavior="readwrite" uniqueId="6ae63020-9951-458b-8e73-ed65d7804f92" type="System.String">
          <orm:column name="user_name" sql-type="text" nullable="false" length="0" scale="0" ado-type="" />
        </orm:field>
        <orm:field name="_user_pre" property="User_Pre" behavior="readwrite" uniqueId="b42a8a0c-4280-48d8-97be-7be1396df0ea" type="System.String">
          <orm:column name="user_pre" sql-type="text" nullable="false" length="0" scale="0" ado-type="" />
        </orm:field>
        <orm:field name="_pass" property="Pass" behavior="readwrite" uniqueId="23aee6ac-aa1b-43a4-a54e-2a144eae16fc" type="System.String">
          <orm:column name="pass" sql-type="text" nullable="false" length="0" scale="0" ado-type="" />
        </orm:field>
        <orm:field name="_comment" property="Comment" behavior="readwrite" uniqueId="0df610ae-aa0b-4637-887b-7f5773153de8" type="System.String">
          <orm:column name="comment" sql-type="text" nullable="false" length="0" scale="0" ado-type="" />
        </orm:field>
        <orm:field name="_is_admin" property="Is_Admin" behavior="readwrite" uniqueId="a5458d89-c31c-43a6-92a0-73918937ca74" type="System.Int16">
          <orm:column name="is_admin" sql-type="int2" nullable="false" length="0" scale="0" ado-type="" />
        </orm:field>
        <orm:field name="_del_yn" property="Del_Yn" behavior="readwrite" uniqueId="ec9517bb-b132-4153-a42d-f658b15ee411" type="System.Int16">
          <orm:column name="del_yn" sql-type="int2" nullable="false" length="0" scale="0" ado-type="" />
        </orm:field>
        <orm:field name="_rights" property="Rights" behavior="readwrite" uniqueId="beffb284-542e-4a59-8660-19bd353fa7dd" type="System.String">
          <orm:column name="rights" sql-type="text" nullable="false" length="0" scale="0" ado-type="" />
        </orm:field>
        <orm:field name="_r_access" property="R_Access" behavior="readwrite" uniqueId="488f1b84-d91e-4095-afd8-c3b0eb409252" type="System.String">
          <orm:column name="r_access" sql-type="text" nullable="false" length="0" scale="0" ado-type="" />
        </orm:field>
        <orm:field name="_r_add" property="R_Add" behavior="readwrite" uniqueId="793af9aa-3f83-41c8-89b2-fb63c7a7d13b" type="System.String">
          <orm:column name="r_add" sql-type="text" nullable="false" length="0" scale="0" ado-type="" />
        </orm:field>
        <orm:field name="_r_edit" property="R_Edit" behavior="readwrite" uniqueId="5105fc27-8a90-4f9f-9730-8c5e3474aa3b" type="System.String">
          <orm:column name="r_edit" sql-type="text" nullable="false" length="0" scale="0" ado-type="" />
        </orm:field>
        <orm:field name="_r_del" property="R_Del" behavior="readwrite" uniqueId="3a33e58a-2af1-489c-941b-bb6042d025e6" type="System.String">
          <orm:column name="r_del" sql-type="text" nullable="false" length="0" scale="0" ado-type="" />
        </orm:field>
        <orm:field name="_r_print" property="R_Print" behavior="readwrite" uniqueId="2e2b3fc1-6d0d-4488-bea0-8dd1cb9766a0" type="System.String">
          <orm:column name="r_print" sql-type="text" nullable="false" length="0" scale="0" ado-type="" />
        </orm:field>
        <orm:field name="_r_read" property="R_Read" behavior="readwrite" uniqueId="b6548582-2a8a-4074-be7d-2f4af96362be" type="System.String">
          <orm:column name="r_read" sql-type="text" nullable="false" length="0" scale="0" ado-type="" />
        </orm:field>
        <orm:field name="_date0" property="Date0" behavior="readwrite" uniqueId="119799e7-413a-4e1b-9624-9839c541ec81" type="System.DateTime">
          <orm:column name="date0" sql-type="timestamp" nullable="false" length="0" scale="0" ado-type="" />
        </orm:field>
        <orm:field name="_user_id0" property="User_Id0" behavior="readwrite" uniqueId="a814172d-fd22-4d88-9a8e-881ad75f5afe" type="System.Int64">
          <orm:column name="user_id0" sql-type="int8" nullable="false" length="0" scale="0" ado-type="" />
        </orm:field>
        <orm:field name="_status" property="Status" behavior="readwrite" uniqueId="daf42c0e-9011-4140-8ecc-2bd7cf035cfe" type="System.String">
          <orm:column name="status" sql-type="text" nullable="false" length="0" scale="0" ado-type="" />
        </orm:field>
        <orm:field name="_date2" property="Date2" behavior="readwrite" uniqueId="d0c33e18-8018-4470-bdc3-3bcf2d098235" type="System.DateTime">
          <orm:column name="date2" sql-type="timestamp" nullable="false" length="0" scale="0" ado-type="" />
        </orm:field>
        <orm:field name="_user_id2" property="User_Id2" behavior="readwrite" uniqueId="ccceba67-fc02-4bca-861c-17e3d901d42e" type="System.Int64">
          <orm:column name="user_id2" sql-type="int8" nullable="false" length="0" scale="0" ado-type="" />
        </orm:field>
        <orm:field name="_r_search" property="R_Search" behavior="readwrite" uniqueId="31853449-8600-474a-9304-925c581530b9" type="System.String">
          <orm:column name="r_search" sql-type="text" nullable="false" length="0" scale="0" ado-type="" />
        </orm:field>
      </orm:class>
      <orm:class name="Dmnt" uniqueId="9d8598ff-424c-4d4a-bac3-97f1835b25b3">
        <orm:table name="dmnt" />
        <orm:identity>
          <orm:single-field field-name="_ma_nt" />
        </orm:identity>
        <orm:concurrency strategy="changed" />
        <orm:field name="_ma_nt" property="Ma_Nt" behavior="readwrite" uniqueId="efd62e43-197b-4369-acac-e213606c2517" type="System.String">
          <orm:column name="ma_nt" sql-type="text" nullable="false" length="0" scale="0" primary-key="true" ado-type="" />
        </orm:field>
        <orm:field name="_ten_nt" property="Ten_Nt" behavior="readwrite" uniqueId="5153ee1e-7f0f-46a4-9ef4-0826242f6bf5" type="System.String">
          <orm:column name="ten_nt" sql-type="text" nullable="false" length="0" scale="0" ado-type="" />
        </orm:field>
        <orm:field name="_date0" property="Date0" behavior="readwrite" uniqueId="310d5722-6515-41f0-86c0-db94a491a637" type="System.DateTime">
          <orm:column name="date0" sql-type="timestamp" nullable="false" length="0" scale="0" ado-type="" />
        </orm:field>
        <orm:field name="_user_id0" property="User_Id0" behavior="readwrite" uniqueId="ecc8cdc8-b792-442b-95e0-421914c140ef" type="System.Int64">
          <orm:column name="user_id0" sql-type="int8" nullable="false" length="0" scale="0" ado-type="" />
        </orm:field>
        <orm:field name="_ten_nt2" property="Ten_Nt2" behavior="readwrite" uniqueId="131ab654-e17c-4d11-9f80-851ec5b41271" type="System.String">
          <orm:column name="ten_nt2" sql-type="text" nullable="false" length="0" scale="0" ado-type="" />
        </orm:field>
        <orm:field name="_date2" property="Date2" behavior="readwrite" uniqueId="4285a20c-477a-4f21-a8c8-9f76ff97b472" type="System.DateTime">
          <orm:column name="date2" sql-type="timestamp" nullable="false" length="0" scale="0" ado-type="" />
        </orm:field>
        <orm:field name="_user_id2" property="User_Id2" behavior="readwrite" uniqueId="93b8f6f0-afa8-4b8c-8531-cf053bf20da3" type="System.Int64">
          <orm:column name="user_id2" sql-type="int8" nullable="false" length="0" scale="0" ado-type="" />
        </orm:field>
        <orm:field name="_status" property="Status" behavior="readwrite" uniqueId="62df353b-ffe6-49b5-ad14-d89d88d2df6d" type="System.String">
          <orm:column name="status" sql-type="text" nullable="false" length="0" scale="0" ado-type="" />
        </orm:field>
        <orm:field name="_userinfo0" property="Userinfo0" behavior="readwrite" uniqueId="f6a45702-6eb3-4f49-a3e1-e2b527a0a0cc" type="MyERPModel.Userinfo">
          <orm:reference uniqueId="44358b57-de56-4243-9a5e-ab005df600fd" association-name="DmntHasUserinfo">
            <orm:sharedfield name="_user_id0" target-class="MyERPModel.Userinfo" target-field="_user_id" />
          </orm:reference>
        </orm:field>
        <orm:field name="_userinfo2" property="Userinfo2" behavior="readwrite" uniqueId="dda1e6ff-7f62-4b3d-afd5-ab3f746e20dd" type="MyERPModel.Userinfo">
          <orm:reference uniqueId="e299cd57-305f-4f78-a63a-9b44719d1682" association-name="DmntHasUserinfo1">
            <orm:sharedfield name="_user_id2" target-class="MyERPModel.Userinfo" target-field="_user_id" />
          </orm:reference>
        </orm:field>
      </orm:class>
      <orm:class name="Dmkh" uniqueId="e5450aef-1d4d-4529-afab-ed799b140a9b">
        <orm:table name="dmkh" />
        <orm:identity>
          <orm:single-field field-name="_ma_kh" />
        </orm:identity>
        <orm:concurrency strategy="changed" />
        <orm:field name="_ma_kh" property="Ma_Kh" behavior="readwrite" uniqueId="0f11fb69-72e9-4b0f-badd-59611caee9fd" type="System.String">
          <orm:column name="ma_kh" sql-type="text" nullable="false" length="0" scale="0" primary-key="true" ado-type="" />
        </orm:field>
        <orm:field name="_ten_kh" property="Ten_Kh" behavior="readwrite" uniqueId="da861d07-fe52-4189-91b4-f143d124f93e" type="System.String">
          <orm:column name="ten_kh" sql-type="text" nullable="false" length="0" scale="0" ado-type="" />
        </orm:field>
        <orm:field name="_ten_kh2" property="Ten_Kh2" behavior="readwrite" uniqueId="31015d40-cefd-4723-9790-18ec5914cfc4" type="System.String">
          <orm:column name="ten_kh2" sql-type="text" nullable="false" length="0" scale="0" ado-type="" />
        </orm:field>
        <orm:field name="_ma_so_thue" property="Ma_So_Thue" behavior="readwrite" uniqueId="77b9d0e7-62bc-4d04-9474-37a24657b39f" type="System.String">
          <orm:column name="ma_so_thue" sql-type="text" nullable="false" length="0" scale="0" ado-type="" />
        </orm:field>
        <orm:field name="_dia_chi" property="Dia_Chi" behavior="readwrite" uniqueId="6036d69d-8761-439c-add6-5182985f786d" type="System.String">
          <orm:column name="dia_chi" sql-type="text" nullable="false" length="0" scale="0" ado-type="" />
        </orm:field>
        <orm:field name="_dien_thoai" property="Dien_Thoai" behavior="readwrite" uniqueId="7e1d6de7-d68b-4417-8d87-ec38952ee0b2" type="System.String">
          <orm:column name="dien_thoai" sql-type="text" nullable="false" length="0" scale="0" ado-type="" />
        </orm:field>
        <orm:field name="_fax" property="Fax" behavior="readwrite" uniqueId="447024bd-3e3f-4caf-b94f-fd41e302006b" type="System.String">
          <orm:column name="fax" sql-type="text" nullable="false" length="0" scale="0" ado-type="" />
        </orm:field>
        <orm:field name="_e_mail" property="E_Mail" behavior="readwrite" uniqueId="6b59f4b3-e517-406b-b84b-66f497dbf983" type="System.String">
          <orm:column name="e_mail" sql-type="text" nullable="false" length="0" scale="0" ado-type="" />
        </orm:field>
        <orm:field name="_home_page" property="Home_Page" behavior="readwrite" uniqueId="11111f51-46ab-49a8-a88a-075b4bbbf05c" type="System.String">
          <orm:column name="home_page" sql-type="text" nullable="false" length="0" scale="0" ado-type="" />
        </orm:field>
        <orm:field name="_doi_tac" property="Doi_Tac" behavior="readwrite" uniqueId="e123c7da-fa58-4aab-9136-f1b71109ad43" type="System.String">
          <orm:column name="doi_tac" sql-type="text" nullable="false" length="0" scale="0" ado-type="" />
        </orm:field>
        <orm:field name="_ong_ba" property="Ong_Ba" behavior="readwrite" uniqueId="a38bc99c-6a02-467e-8fce-e10439a5b2d4" type="System.String">
          <orm:column name="ong_ba" sql-type="text" nullable="false" length="0" scale="0" ado-type="" />
        </orm:field>
        <orm:field name="_ten_bp" property="Ten_Bp" behavior="readwrite" uniqueId="a6760443-b692-4b99-8a78-006830936acb" type="System.String">
          <orm:column name="ten_bp" sql-type="text" nullable="false" length="0" scale="0" ado-type="" />
        </orm:field>
        <orm:field name="_ngan_hang" property="Ngan_Hang" behavior="readwrite" uniqueId="ff889bd4-eb1a-4217-beda-a1cfbf32f3c3" type="System.String">
          <orm:column name="ngan_hang" sql-type="text" nullable="false" length="0" scale="0" ado-type="" />
        </orm:field>
        <orm:field name="_ghi_chu" property="Ghi_Chu" behavior="readwrite" uniqueId="1131484d-5d15-4e6b-92d4-8f45af9fad71" type="System.String">
          <orm:column name="ghi_chu" sql-type="text" nullable="false" length="0" scale="0" ado-type="" />
        </orm:field>
        <orm:field name="_tk" property="Tk" behavior="readwrite" uniqueId="4a359004-7e62-4e84-ac55-1246711f6d28" type="System.String">
          <orm:column name="tk" sql-type="text" nullable="false" length="0" scale="0" ado-type="" />
        </orm:field>
        <orm:field name="_tk_nh" property="Tk_Nh" behavior="readwrite" uniqueId="a70ee86f-4228-4eff-9fb9-b337e2396824" type="System.String">
          <orm:column name="tk_nh" sql-type="text" nullable="false" length="0" scale="0" ado-type="" />
        </orm:field>
        <orm:field name="_nh_kh1" property="Nh_Kh1" behavior="readwrite" uniqueId="c573f019-bbd0-44b0-ac0c-371423259210" type="System.String">
          <orm:column name="nh_kh1" sql-type="text" nullable="false" length="0" scale="0" ado-type="" />
        </orm:field>
        <orm:field name="_nh_kh2" property="Nh_Kh2" behavior="readwrite" uniqueId="d213780a-b613-4029-8b8a-72c1846d2de0" type="System.String">
          <orm:column name="nh_kh2" sql-type="text" nullable="false" length="0" scale="0" ado-type="" />
        </orm:field>
        <orm:field name="_nh_kh3" property="Nh_Kh3" behavior="readwrite" uniqueId="0a0e6c4f-541b-4e5a-abfc-b3ccc64d6fde" type="System.String">
          <orm:column name="nh_kh3" sql-type="text" nullable="false" length="0" scale="0" ado-type="" />
        </orm:field>
        <orm:field name="_du_nt13" property="Du_Nt13" behavior="readwrite" uniqueId="68d0bd94-d454-4f7d-9328-bbe49ab09764" type="System.Decimal">
          <orm:column name="du_nt13" sql-type="numeric" nullable="false" length="38" scale="20" ado-type="" />
        </orm:field>
        <orm:field name="_t_tien_cn" property="T_Tien_Cn" behavior="readwrite" uniqueId="ce3a3d4f-030e-4eb3-b30e-aa2a74601f96" type="System.Decimal">
          <orm:column name="t_tien_cn" sql-type="numeric" nullable="false" length="38" scale="20" ado-type="" />
        </orm:field>
        <orm:field name="_t_tien_hd" property="T_Tien_Hd" behavior="readwrite" uniqueId="87e79ed1-2e2f-48b7-afe7-164ffa8bb5a0" type="System.Decimal">
          <orm:column name="t_tien_hd" sql-type="numeric" nullable="false" length="38" scale="20" ado-type="" />
        </orm:field>
        <orm:field name="_date0" property="Date0" behavior="readwrite" uniqueId="0c5a86db-29b4-43d2-a101-5bca88ea1bc2" type="System.DateTime">
          <orm:column name="date0" sql-type="timestamp" nullable="false" length="0" scale="0" ado-type="" />
        </orm:field>
        <orm:field name="_user_id0" property="User_Id0" behavior="readwrite" uniqueId="430d5d25-978d-4b5a-8579-945c4f47d5eb" type="System.Int64">
          <orm:column name="user_id0" sql-type="int8" nullable="false" length="0" scale="0" ado-type="" />
        </orm:field>
        <orm:field name="_date2" property="Date2" behavior="readwrite" uniqueId="fef07b89-7622-4ce6-a151-345e1507818a" type="System.DateTime">
          <orm:column name="date2" sql-type="timestamp" nullable="false" length="0" scale="0" ado-type="" />
        </orm:field>
        <orm:field name="_user_id2" property="User_Id2" behavior="readwrite" uniqueId="38f2bfcc-6b2e-408b-90b2-aeaf66f90c1e" type="System.Int64">
          <orm:column name="user_id2" sql-type="int8" nullable="false" length="0" scale="0" ado-type="" />
        </orm:field>
        <orm:field name="_ma_tt" property="Ma_Tt" behavior="readwrite" uniqueId="26b210e4-c0f7-49c7-aa7e-0b211a44cb3d" type="System.String">
          <orm:column name="ma_tt" sql-type="text" nullable="false" length="0" scale="0" ado-type="" />
        </orm:field>
        <orm:field name="_kh_yn" property="Kh_Yn" behavior="readwrite" uniqueId="cd412faf-9873-40fb-9877-a6fc1c2db011" type="System.Int16">
          <orm:column name="kh_yn" sql-type="int2" nullable="false" length="0" scale="0" ado-type="" />
        </orm:field>
        <orm:field name="_cc_yn" property="Cc_Yn" behavior="readwrite" uniqueId="cb1833d2-e863-49aa-b4fc-3086f79adff3" type="System.Int16">
          <orm:column name="cc_yn" sql-type="int2" nullable="false" length="0" scale="0" ado-type="" />
        </orm:field>
        <orm:field name="_nv_yn" property="Nv_Yn" behavior="readwrite" uniqueId="27f8e1e9-8bde-4c7d-a710-020bbdb365d9" type="System.Int16">
          <orm:column name="nv_yn" sql-type="int2" nullable="false" length="0" scale="0" ado-type="" />
        </orm:field>
        <orm:field name="_dmtk" property="Dmtk" behavior="readwrite" uniqueId="453216c0-c4f7-4570-bfb0-236b03957604" type="MyERPModel.Dmtk">
          <orm:reference uniqueId="79bd3038-4073-4c52-bf4d-dc84d849109e" association-name="DmkhHasDmtk">
            <orm:sharedfield name="_tk" target-class="MyERPModel.Dmtk" target-field="_tk" />
          </orm:reference>
        </orm:field>
        <orm:field name="_userinfo2" property="Userinfo2" behavior="readwrite" uniqueId="46ef6cad-0a0f-4f30-95bb-21e6431fa3bb" type="MyERPModel.Userinfo">
          <orm:reference uniqueId="ae4042d9-a1c9-4bc7-ade1-181aab777e31" association-name="DmkhHasUserinfo2">
            <orm:sharedfield name="_user_id2" target-class="MyERPModel.Userinfo" target-field="_user_id" />
          </orm:reference>
        </orm:field>
        <orm:field name="_userinfo0" property="Userinfo0" behavior="readwrite" uniqueId="b51bbab1-9e7e-4a0b-a851-54398a619bec" type="MyERPModel.Userinfo">
          <orm:reference uniqueId="4814469e-705d-44ca-a892-be2d6b4f0e54" association-name="DmkhHasUserinfo0">
            <orm:sharedfield name="_user_id0" target-class="MyERPModel.Userinfo" target-field="_user_id" />
          </orm:reference>
        </orm:field>
        <orm:field name="_dmnhkh1" property="Dmnhkh2" behavior="readwrite" uniqueId="61e5597f-cdd3-40e4-8bfe-a3c463c39601" type="MyERPModel.Dmnhkh">
          <orm:reference uniqueId="6176261b-02b5-4de6-9957-dcda7975d456" association-name="DmkhHasDmnhkh2">
            <orm:sharedfield name="_nh_kh2" target-class="MyERPModel.Dmnhkh" target-field="_ma_nh" />
          </orm:reference>
        </orm:field>
        <orm:field name="_dmnhkh" property="Dmnhkh1" behavior="readwrite" uniqueId="cea30193-3631-4412-9776-d37e5eef7be0" type="MyERPModel.Dmnhkh">
          <orm:reference uniqueId="b2126885-36d0-49a2-8539-2121cf44542f" association-name="DmkhHasDmnhkh1">
            <orm:sharedfield name="_nh_kh1" target-class="MyERPModel.Dmnhkh" target-field="_ma_nh" />
          </orm:reference>
        </orm:field>
        <orm:field name="_dmnhkh2" property="Dmnhkh3" behavior="readwrite" uniqueId="42cd3516-8c42-4df7-87f2-16b471280e5d" type="MyERPModel.Dmnhkh">
          <orm:reference uniqueId="7d1337b8-4f28-4167-ad98-da3144edd038" association-name="DmkhHasDmnhkh3">
            <orm:sharedfield name="_nh_kh3" target-class="MyERPModel.Dmnhkh" target-field="_ma_nh" />
          </orm:reference>
        </orm:field>
        <orm:field name="_dmtt" property="Dmtt" behavior="readwrite" uniqueId="f72b6dff-fd80-4e47-9f70-200af9bd898c" type="MyERPModel.Dmtt">
          <orm:reference uniqueId="bab23a19-ce7b-4953-88cf-999afbc304e2" association-name="DmkhHasDmtt">
            <orm:sharedfield name="_ma_tt" target-class="MyERPModel.Dmtt" target-field="_ma_tt" />
          </orm:reference>
        </orm:field>
      </orm:class>
      <orm:class name="Dmnhkh" uniqueId="f2451eb6-4641-45a3-bcdf-230e9f344ef2">
        <orm:table name="dmnhkh" />
        <orm:identity>
          <orm:single-field field-name="_ma_nh" />
        </orm:identity>
        <orm:concurrency strategy="changed" />
        <orm:field name="_loai_nh" property="Loai_Nh" behavior="readwrite" uniqueId="630699bf-4f30-4efb-8a46-617c5caef057" type="System.Int16">
          <orm:column name="loai_nh" sql-type="int2" nullable="false" length="0" scale="0" ado-type="" />
        </orm:field>
        <orm:field name="_ma_nh" property="Ma_Nh" behavior="readwrite" uniqueId="42010cbf-48ba-4309-844f-155498b0ddd6" type="System.String">
          <orm:column name="ma_nh" sql-type="text" nullable="false" length="0" scale="0" primary-key="true" ado-type="" />
        </orm:field>
        <orm:field name="_ten_nh" property="Ten_Nh" behavior="readwrite" uniqueId="95fe9fbd-2959-4d84-bdec-d4e6c1d3406f" type="System.String">
          <orm:column name="ten_nh" sql-type="text" nullable="false" length="0" scale="0" ado-type="" />
        </orm:field>
        <orm:field name="_ten_nh2" property="Ten_Nh2" behavior="readwrite" uniqueId="1e898604-198e-4a90-8890-c95c0ff50fec" type="System.String">
          <orm:column name="ten_nh2" sql-type="text" nullable="false" length="0" scale="0" ado-type="" />
        </orm:field>
        <orm:field name="_date0" property="Date0" behavior="readwrite" uniqueId="00edf15b-3172-46b2-acc5-41e736324121" type="System.DateTime">
          <orm:column name="date0" sql-type="timestamp" nullable="false" length="0" scale="0" ado-type="" />
        </orm:field>
        <orm:field name="_user_id0" property="User_Id0" behavior="readwrite" uniqueId="9a4dc6c4-e7da-4652-9ae8-23233d5313f5" type="System.Int64">
          <orm:column name="user_id0" sql-type="int8" nullable="false" length="0" scale="0" ado-type="" />
        </orm:field>
        <orm:field name="_date2" property="Date2" behavior="readwrite" uniqueId="3780b134-9e0b-43e1-b6ef-5cc77e2cd1dd" type="System.DateTime">
          <orm:column name="date2" sql-type="timestamp" nullable="false" length="0" scale="0" ado-type="" />
        </orm:field>
        <orm:field name="_user_id2" property="User_Id2" behavior="readwrite" uniqueId="bba63813-0787-46ca-b2aa-834bb3aadf9a" type="System.Int64">
          <orm:column name="user_id2" sql-type="int8" nullable="false" length="0" scale="0" ado-type="" />
        </orm:field>
        <orm:field name="_status" property="Status" behavior="readwrite" uniqueId="a44d60c2-7102-4045-8c8d-839b0ed412b6" type="System.String">
          <orm:column name="status" sql-type="text" nullable="false" length="0" scale="0" ado-type="" />
        </orm:field>
        <orm:field name="_dmkhs" property="Dmkh2s" behavior="readwrite" uniqueId="d371ffbe-26bc-48dc-a839-29029ee8deec" type="MyERPModel.Dmkh">
          <orm:collection element-class="MyERPModel.Dmkh" inverse-field="_dmnhkh1" order-by="" uniqueId="6176261b-02b5-4de6-9957-dcda7975d456" />
        </orm:field>
        <orm:field name="_dmkhs1" property="Dmkh1s" behavior="readwrite" uniqueId="2b67b638-39d0-439c-be67-5ad46760e7d1" type="MyERPModel.Dmkh">
          <orm:collection element-class="MyERPModel.Dmkh" inverse-field="_dmnhkh" order-by="" uniqueId="b2126885-36d0-49a2-8539-2121cf44542f" />
        </orm:field>
        <orm:field name="_dmkhs2" property="Dmkh3s" behavior="readwrite" uniqueId="021a8314-58fe-473f-becd-12f230f69c85" type="MyERPModel.Dmkh">
          <orm:collection element-class="MyERPModel.Dmkh" inverse-field="_dmnhkh2" order-by="" uniqueId="7d1337b8-4f28-4167-ad98-da3144edd038" />
        </orm:field>
      </orm:class>
      <orm:class name="Dmtt" uniqueId="b0ff094e-1f92-4ae4-86c5-45512a524e98">
        <orm:table name="dmtt" />
        <orm:identity>
          <orm:single-field field-name="_ma_tt" />
        </orm:identity>
        <orm:concurrency strategy="changed" />
        <orm:field name="_ma_tt" property="Ma_Tt" behavior="readwrite" uniqueId="0e0ff67f-9bed-4525-917e-22c5e8ce05a6" type="System.String">
          <orm:column name="ma_tt" sql-type="text" nullable="false" length="0" scale="0" primary-key="true" ado-type="" />
        </orm:field>
        <orm:field name="_ten_tt" property="Ten_Tt" behavior="readwrite" uniqueId="65829b43-f1af-483c-a7f8-3b535c695e74" type="System.String">
          <orm:column name="ten_tt" sql-type="text" nullable="false" length="0" scale="0" ado-type="" />
        </orm:field>
        <orm:field name="_ten_tt2" property="Ten_Tt2" behavior="readwrite" uniqueId="974234b0-7c29-43c7-881c-15499283f958" type="System.String">
          <orm:column name="ten_tt2" sql-type="text" nullable="false" length="0" scale="0" ado-type="" />
        </orm:field>
        <orm:field name="_han_tt" property="Han_Tt" behavior="readwrite" uniqueId="0680a919-4bfc-405b-894b-d3499b44379e" type="System.Int16">
          <orm:column name="han_tt" sql-type="int2" nullable="false" length="0" scale="0" ado-type="" />
        </orm:field>
        <orm:field name="_han_tt_gg" property="Han_Tt_Gg" behavior="readwrite" uniqueId="594ee366-a7df-499b-ba68-35028e8cd806" type="System.Int16">
          <orm:column name="han_tt_gg" sql-type="int2" nullable="false" length="0" scale="0" ado-type="" />
        </orm:field>
        <orm:field name="_pt_gg" property="Pt_Gg" behavior="readwrite" uniqueId="38db80c8-a6b0-4179-a2e7-94bc55e7fbd2" type="System.Decimal">
          <orm:column name="pt_gg" sql-type="numeric" nullable="false" length="38" scale="20" ado-type="" />
        </orm:field>
        <orm:field name="_date0" property="Date0" behavior="readwrite" uniqueId="9175b1db-6b73-48bd-ace4-12381407a5a3" type="System.DateTime">
          <orm:column name="date0" sql-type="timestamp" nullable="false" length="0" scale="0" ado-type="" />
        </orm:field>
        <orm:field name="_user_id0" property="User_Id0" behavior="readwrite" uniqueId="31b31c92-f0af-48a1-a066-bd0a1ea2bafd" type="System.Int64">
          <orm:column name="user_id0" sql-type="int8" nullable="false" length="0" scale="0" ado-type="" />
        </orm:field>
        <orm:field name="_date2" property="Date2" behavior="readwrite" uniqueId="23db19d5-5e55-43de-8f05-21c6b606fcbc" type="System.DateTime">
          <orm:column name="date2" sql-type="timestamp" nullable="false" length="0" scale="0" ado-type="" />
        </orm:field>
        <orm:field name="_user_id2" property="User_Id2" behavior="readwrite" uniqueId="67c598f4-89c8-44b2-a85e-31a41ad0db03" type="System.Int64">
          <orm:column name="user_id2" sql-type="int8" nullable="false" length="0" scale="0" ado-type="" />
        </orm:field>
        <orm:field name="_status" property="Status" behavior="readwrite" uniqueId="ae70066e-d99c-4df0-9972-ccdee0f0fde9" type="System.String">
          <orm:column name="status" sql-type="text" nullable="false" length="0" scale="0" ado-type="" />
        </orm:field>
      </orm:class>
      <orm:class name="Dmvv" uniqueId="295c1357-df0e-4eef-b13d-68e20e43c403">
        <orm:table name="dmvv" />
        <orm:identity>
          <orm:single-field field-name="_ma_vv" />
        </orm:identity>
        <orm:concurrency strategy="changed" />
        <orm:field name="_ma_vv" property="Ma_Vv" behavior="readwrite" uniqueId="f5ec11cf-95ce-4da4-a64b-85ded41e39ea" type="System.String">
          <orm:column name="ma_vv" sql-type="text" nullable="false" length="0" scale="0" primary-key="true" ado-type="" />
        </orm:field>
        <orm:field name="_ten_vv" property="Ten_Vv" behavior="readwrite" uniqueId="a3b7a577-c36b-433b-a8f1-80ef160b0f00" type="System.String">
          <orm:column name="ten_vv" sql-type="text" nullable="false" length="0" scale="0" ado-type="" />
        </orm:field>
        <orm:field name="_ten_vv2" property="Ten_Vv2" behavior="readwrite" uniqueId="ea68ac13-3d62-4a09-9145-2615b0586d7c" type="System.String">
          <orm:column name="ten_vv2" sql-type="text" nullable="false" length="0" scale="0" ado-type="" />
        </orm:field>
        <orm:field name="_ma_kh" property="Ma_Kh" behavior="readwrite" uniqueId="d5f85a8d-43ba-42c6-a932-271e0a952c91" type="System.String">
          <orm:column name="ma_kh" sql-type="text" nullable="false" length="0" scale="0" ado-type="" />
        </orm:field>
        <orm:field name="_nh_vv1" property="Nh_Vv1" behavior="readwrite" uniqueId="3614177a-a906-4835-a652-0b23c7d39576" type="System.String">
          <orm:column name="nh_vv1" sql-type="text" nullable="false" length="0" scale="0" ado-type="" />
        </orm:field>
        <orm:field name="_nh_vv2" property="Nh_Vv2" behavior="readwrite" uniqueId="b137becf-e416-4b4a-a178-ecba99feba3e" type="System.String">
          <orm:column name="nh_vv2" sql-type="text" nullable="false" length="0" scale="0" ado-type="" />
        </orm:field>
        <orm:field name="_nh_vv3" property="Nh_Vv3" behavior="readwrite" uniqueId="919c27e1-78b7-4a84-899c-b51862a39189" type="System.String">
          <orm:column name="nh_vv3" sql-type="text" nullable="false" length="0" scale="0" ado-type="" />
        </orm:field>
        <orm:field name="_ngay_vv1" property="Ngay_Vv1" behavior="readwrite" uniqueId="8008ba90-9603-4e69-979c-81bb8c3be707" type="System.DateTime">
          <orm:column name="ngay_vv1" sql-type="date" nullable="false" length="0" scale="0" ado-type="" />
        </orm:field>
        <orm:field name="_ngay_vv2" property="Ngay_Vv2" behavior="readwrite" uniqueId="e25ec3b9-de9f-479b-8316-901db8c24cf1" type="System.DateTime">
          <orm:column name="ngay_vv2" sql-type="date" nullable="false" length="0" scale="0" ado-type="" />
        </orm:field>
        <orm:field name="_ma_nt" property="Ma_Nt" behavior="readwrite" uniqueId="bc0e7671-92ff-4805-8c4b-87134830a877" type="System.String">
          <orm:column name="ma_nt" sql-type="text" nullable="false" length="0" scale="0" ado-type="" />
        </orm:field>
        <orm:field name="_tien_nt" property="Tien_Nt" behavior="readwrite" uniqueId="293b25e8-35f2-4100-afde-a7de663e51c4" type="System.Decimal">
          <orm:column name="tien_nt" sql-type="numeric" nullable="false" length="38" scale="20" ado-type="" />
        </orm:field>
        <orm:field name="_tien" property="Tien" behavior="readwrite" uniqueId="230b8eb7-20ec-457a-9776-f4ac9ef7b8d1" type="System.Decimal">
          <orm:column name="tien" sql-type="numeric" nullable="false" length="38" scale="20" ado-type="" />
        </orm:field>
        <orm:field name="_ghi_chu" property="Ghi_Chu" behavior="readwrite" uniqueId="ed9bf5aa-8b4f-46dc-b94f-476b44afa95b" type="System.String">
          <orm:column name="ghi_chu" sql-type="text" nullable="false" length="0" scale="0" ado-type="" />
        </orm:field>
        <orm:field name="_date0" property="Date0" behavior="readwrite" uniqueId="4fd8ddbd-506d-4153-993e-ae4e886557a6" type="System.DateTime">
          <orm:column name="date0" sql-type="timestamp" nullable="false" length="0" scale="0" ado-type="" />
        </orm:field>
        <orm:field name="_user_id0" property="User_Id0" behavior="readwrite" uniqueId="8153d3a8-1acf-4144-b6c3-2eba140d8e82" type="System.Int64">
          <orm:column name="user_id0" sql-type="int8" nullable="false" length="0" scale="0" ado-type="" />
        </orm:field>
        <orm:field name="_date2" property="Date2" behavior="readwrite" uniqueId="a9192fa7-1770-4d1a-beb6-2636d02a3381" type="System.DateTime">
          <orm:column name="date2" sql-type="timestamp" nullable="false" length="0" scale="0" ado-type="" />
        </orm:field>
        <orm:field name="_user_id2" property="User_Id2" behavior="readwrite" uniqueId="b3e95d81-7025-41ff-9dad-fd5d66e336cb" type="System.Int64">
          <orm:column name="user_id2" sql-type="int8" nullable="false" length="0" scale="0" ado-type="" />
        </orm:field>
        <orm:field name="_status" property="Status" behavior="readwrite" uniqueId="dcb96b01-9c50-44cc-b258-45b1397c2e3c" type="System.String">
          <orm:column name="status" sql-type="text" nullable="false" length="0" scale="0" ado-type="" />
        </orm:field>
        <orm:field name="_tk" property="Tk" behavior="readwrite" uniqueId="54fc89be-738e-4ef4-a873-66f0b3a4d229" type="System.String">
          <orm:column name="tk" sql-type="text" nullable="false" length="0" scale="0" ado-type="" />
        </orm:field>
        <orm:field name="_dmtk" property="Dmtk" behavior="readwrite" uniqueId="25447f82-93f6-4607-bf61-5d26c3c73bf9" type="MyERPModel.Dmtk">
          <orm:reference uniqueId="6f7ad5d3-9b0b-4f88-b70f-349ec13259c5" association-name="DmvvHasDmtk">
            <orm:sharedfield name="_tk" target-class="MyERPModel.Dmtk" target-field="_tk" />
          </orm:reference>
        </orm:field>
        <orm:field name="_userinfo" property="Userinfo0" behavior="readwrite" uniqueId="b34456a4-426f-4645-ac3a-af953ee752e7" type="MyERPModel.Userinfo">
          <orm:reference uniqueId="edcaaadd-f6e4-49b5-8a14-dc1bba9c585f" association-name="DmvvHasUserinfo0">
            <orm:sharedfield name="_user_id0" target-class="MyERPModel.Userinfo" target-field="_user_id" />
          </orm:reference>
        </orm:field>
        <orm:field name="_userinfo1" property="Userinfo2" behavior="readwrite" uniqueId="e0b3e145-8ae0-4761-b05b-0c289d595fdc" type="MyERPModel.Userinfo">
          <orm:reference uniqueId="f85a3b7a-dbd6-454e-9061-abd94d221a9b" association-name="DmvvHasUserinfo2">
            <orm:sharedfield name="_user_id2" target-class="MyERPModel.Userinfo" target-field="_user_id" />
          </orm:reference>
        </orm:field>
        <orm:field name="_dmkh" property="Dmkh" behavior="readwrite" uniqueId="55ebbb5b-7452-4be0-9a0e-83f5f254d1be" type="MyERPModel.Dmkh">
          <orm:reference uniqueId="a526526d-ac1e-47f0-ae03-ff7841e87699" association-name="DmvvHasDmkh">
            <orm:sharedfield name="_ma_kh" target-class="MyERPModel.Dmkh" target-field="_ma_kh" />
          </orm:reference>
        </orm:field>
        <orm:field name="_dmnhvv" property="Dmnhvv1" behavior="readwrite" uniqueId="01dcf7c2-6e8b-4391-bcdc-abbcf7367880" type="MyERPModel.Dmnhvv">
          <orm:reference uniqueId="7b8610d2-8f19-4712-b021-7b5e24db29e4" association-name="DmvvHasDmnhvv1">
            <orm:sharedfield name="_nh_vv1" target-class="MyERPModel.Dmnhvv" target-field="_ma_nh" />
          </orm:reference>
        </orm:field>
        <orm:field name="_dmnhvv1" property="Dmnhvv2" behavior="readwrite" uniqueId="9a7a53c6-642a-4297-a94e-dace6bec87a9" type="MyERPModel.Dmnhvv">
          <orm:reference uniqueId="ca8b2278-6ddb-47ed-b36d-602244181c19" association-name="DmvvHasDmnhvv2">
            <orm:sharedfield name="_nh_vv2" target-class="MyERPModel.Dmnhvv" target-field="_ma_nh" />
          </orm:reference>
        </orm:field>
        <orm:field name="_dmnhvv2" property="Dmnhvv3" behavior="readwrite" uniqueId="f7bd3ee8-da0f-404d-9653-0486a54f360e" type="MyERPModel.Dmnhvv">
          <orm:reference uniqueId="9c7c4f44-3eba-4e22-b0c3-882f92b9af05" association-name="DmvvHasDmnhvv3">
            <orm:sharedfield name="_nh_vv3" target-class="MyERPModel.Dmnhvv" target-field="_ma_nh" />
          </orm:reference>
        </orm:field>
      </orm:class>
      <orm:class name="Dmnhvv" uniqueId="c1a07b37-fa4e-428b-9e73-2fc9b5b4056a">
        <orm:table name="dmnhvv" />
        <orm:identity>
          <orm:single-field field-name="_ma_nh" />
        </orm:identity>
        <orm:concurrency strategy="changed" />
        <orm:field name="_loai_nh" property="Loai_Nh" behavior="readwrite" uniqueId="556773db-3da4-45bd-85f4-d7bc0c9b1e1f" type="System.Int16">
          <orm:column name="loai_nh" sql-type="int2" nullable="false" length="0" scale="0" ado-type="" />
        </orm:field>
        <orm:field name="_ma_nh" property="Ma_Nh" behavior="readwrite" uniqueId="4e3355de-c10d-4597-a3a0-ee12423f186a" type="System.String">
          <orm:column name="ma_nh" sql-type="text" nullable="false" length="0" scale="0" primary-key="true" ado-type="" />
        </orm:field>
        <orm:field name="_ten_nh" property="Ten_Nh" behavior="readwrite" uniqueId="f8fc0a8c-a47b-4918-969e-93859b9a31e5" type="System.String">
          <orm:column name="ten_nh" sql-type="text" nullable="false" length="0" scale="0" ado-type="" />
        </orm:field>
        <orm:field name="_ten_nh2" property="Ten_Nh2" behavior="readwrite" uniqueId="13b75a7a-3919-4407-b85d-827b9d67405e" type="System.String">
          <orm:column name="ten_nh2" sql-type="text" nullable="false" length="0" scale="0" ado-type="" />
        </orm:field>
        <orm:field name="_date0" property="Date0" behavior="readwrite" uniqueId="a2f5eb4d-c532-4e91-9795-ca7253370c53" type="System.DateTime">
          <orm:column name="date0" sql-type="timestamp" nullable="false" length="0" scale="0" ado-type="" />
        </orm:field>
        <orm:field name="_user_id0" property="User_Id0" behavior="readwrite" uniqueId="919915f0-a7d0-47c1-bb6c-7f88674599eb" type="System.Int64">
          <orm:column name="user_id0" sql-type="int8" nullable="false" length="0" scale="0" ado-type="" />
        </orm:field>
        <orm:field name="_status" property="Status" behavior="readwrite" uniqueId="da21f8a7-4981-4494-98be-63cba3ed1ffd" type="System.String">
          <orm:column name="status" sql-type="text" nullable="false" length="0" scale="0" ado-type="" />
        </orm:field>
        <orm:field name="_date2" property="Date2" behavior="readwrite" uniqueId="018f67f1-c083-48c8-b2a7-7d9d30098643" type="System.DateTime">
          <orm:column name="date2" sql-type="timestamp" nullable="false" length="0" scale="0" ado-type="" />
        </orm:field>
        <orm:field name="_user_id2" property="User_Id2" behavior="readwrite" uniqueId="3067e54b-f476-4b38-9a06-2ef534696a8e" type="System.Int64">
          <orm:column name="user_id2" sql-type="int8" nullable="false" length="0" scale="0" ado-type="" />
        </orm:field>
        <orm:field name="_userinfo" property="Userinfo0" behavior="readwrite" uniqueId="6e942301-9b08-445e-b8e2-aacc59d3e317" type="MyERPModel.Userinfo">
          <orm:reference uniqueId="b30b38b4-6ec3-454f-92bd-45c508927068" association-name="DmnhvvHasUserinfo0">
            <orm:sharedfield name="_user_id0" target-class="MyERPModel.Userinfo" target-field="_user_id" />
          </orm:reference>
        </orm:field>
        <orm:field name="_userinfo1" property="Userinfo2" behavior="readwrite" uniqueId="247a6428-0084-484c-8f1d-dbc99861cac1" type="MyERPModel.Userinfo">
          <orm:reference uniqueId="43788f0a-acb5-4501-af4b-874a63fe05df" association-name="DmnhvvHasUserinfo2">
            <orm:sharedfield name="_user_id2" target-class="MyERPModel.Userinfo" target-field="_user_id" />
          </orm:reference>
        </orm:field>
        <orm:field name="_dmvvs" property="Dmvv1s" behavior="readwrite" uniqueId="5ded7457-b33a-46e0-b008-e38d96f1ca9d" type="MyERPModel.Dmvv">
          <orm:collection element-class="MyERPModel.Dmvv" inverse-field="_dmnhvv" order-by="" uniqueId="7b8610d2-8f19-4712-b021-7b5e24db29e4" />
        </orm:field>
        <orm:field name="_dmvvs1" property="Dmvv2s" behavior="readwrite" uniqueId="14496fb5-d08a-4cc0-9f87-09950d03c57e" type="MyERPModel.Dmvv">
          <orm:collection element-class="MyERPModel.Dmvv" inverse-field="_dmnhvv1" order-by="" uniqueId="ca8b2278-6ddb-47ed-b36d-602244181c19" />
        </orm:field>
        <orm:field name="_dmvvs2" property="Dmvv3s" behavior="readwrite" uniqueId="c4f2f62d-93b2-453b-bb6b-c60c93f22c74" type="MyERPModel.Dmvv">
          <orm:collection element-class="MyERPModel.Dmvv" inverse-field="_dmnhvv2" order-by="" uniqueId="9c7c4f44-3eba-4e22-b0c3-882f92b9af05" />
        </orm:field>
      </orm:class>
      <orm:class name="Ph11" uniqueId="4e5c85f4-102a-4953-b79a-16aace7a5d6d">
        <orm:table name="ph11" />
        <orm:identity>
          <orm:single-field field-name="_Stt_Rec" />
        </orm:identity>
        <orm:concurrency strategy="changed" />
        <orm:field name="_Stt_Rec" property="Stt_Rec" behavior="readwrite" uniqueId="376a7929-e44d-405f-ad35-08fb5e223650" type="System.String">
          <orm:column name="stt_rec" sql-type="text" nullable="false" length="0" scale="0" primary-key="true" ado-type="" />
        </orm:field>
        <orm:field name="_Ma_Dvcs" property="Ma_Dvcs" behavior="readwrite" uniqueId="22911a3f-3f64-420e-a3fa-47cfc308425a" type="System.String">
          <orm:column name="ma_dvcs" sql-type="text" nullable="false" length="0" scale="0" ado-type="" />
        </orm:field>
        <orm:field name="_Ma_Ct" property="Ma_Ct" behavior="readwrite" uniqueId="b583a43f-9d2a-4212-ac1f-d1b214be78b2" type="System.String">
          <orm:column name="ma_ct" sql-type="text" nullable="false" length="0" scale="0" ado-type="" />
        </orm:field>
        <orm:field name="_Ngay_Ct" property="Ngay_Ct" behavior="readwrite" uniqueId="95825f35-313c-40d6-b1f5-6e64983431e3" type="System.DateTime">
          <orm:column name="ngay_ct" sql-type="date" nullable="false" length="0" scale="0" ado-type="" />
        </orm:field>
        <orm:field name="_Ngay_Lct" property="Ngay_Lct" behavior="readwrite" uniqueId="a6081d52-75da-4fad-8ca2-df2b76185ded" type="System.DateTime">
          <orm:column name="ngay_lct" sql-type="date" nullable="false" length="0" scale="0" ado-type="" />
        </orm:field>
        <orm:field name="_So_Ct" property="So_Ct" behavior="readwrite" uniqueId="e2df88d1-5417-4540-9b05-e66494a4f1e9" type="System.String">
          <orm:column name="so_ct" sql-type="text" nullable="false" length="0" scale="0" ado-type="" />
        </orm:field>
        <orm:field name="_So_Lo" property="So_Lo" behavior="readwrite" uniqueId="9bf57b52-ebb5-4a1a-9f34-be33e4add8a0" type="System.String">
          <orm:column name="so_lo" sql-type="text" nullable="false" length="0" scale="0" ado-type="" />
        </orm:field>
        <orm:field name="_Ngay_Lo" property="Ngay_Lo" behavior="readwrite" uniqueId="7f296048-650c-47e4-9939-ca3c5062e0c1" type="System.DateTime">
          <orm:column name="ngay_lo" sql-type="date" nullable="false" length="0" scale="0" ado-type="" />
        </orm:field>
        <orm:field name="_Ma_Nk" property="Ma_Nk" behavior="readwrite" uniqueId="6230b7f9-a896-4e64-b72f-692819793b06" type="System.String">
          <orm:column name="ma_nk" sql-type="text" nullable="false" length="0" scale="0" ado-type="" />
        </orm:field>
        <orm:field name="_Ma_Gd" property="Ma_Gd" behavior="readwrite" uniqueId="ee648f37-c994-4c4d-8025-7b0c243de72d" type="System.Int16">
          <orm:column name="ma_gd" sql-type="int2" nullable="false" length="0" scale="0" ado-type="" />
        </orm:field>
        <orm:field name="_Ma_Nt" property="Ma_Nt" behavior="readwrite" uniqueId="9a4e721e-a388-4085-94ee-5883e850b67c" type="System.String">
          <orm:column name="ma_nt" sql-type="text" nullable="false" length="0" scale="0" ado-type="" />
        </orm:field>
        <orm:field name="_Ty_Gia" property="Ty_Gia" behavior="readwrite" uniqueId="a293d787-6949-4d78-8140-c302ab485188" type="System.Decimal">
          <orm:column name="ty_gia" sql-type="numeric" nullable="false" length="38" scale="20" ado-type="" />
        </orm:field>
        <orm:field name="_T_Ps_No_Nt" property="T_Ps_No_Nt" behavior="readwrite" uniqueId="04d117bd-db83-451c-98a8-c77451150244" type="System.Decimal">
          <orm:column name="t_ps_no_nt" sql-type="numeric" nullable="false" length="38" scale="20" ado-type="" />
        </orm:field>
        <orm:field name="_T_Ps_No" property="T_Ps_No" behavior="readwrite" uniqueId="312ab0b0-d4ae-4a49-961d-fe67b836c2d4" type="System.Decimal">
          <orm:column name="t_ps_no" sql-type="numeric" nullable="false" length="38" scale="20" ado-type="" />
        </orm:field>
        <orm:field name="_T_Ps_Co_Nt" property="T_Ps_Co_Nt" behavior="readwrite" uniqueId="f18156a3-55be-4afe-b8b9-ca8b17c0df21" type="System.Decimal">
          <orm:column name="t_ps_co_nt" sql-type="numeric" nullable="false" length="38" scale="20" ado-type="" />
        </orm:field>
        <orm:field name="_Date0" property="Date0" behavior="readwrite" uniqueId="df0f946d-fc6d-48c0-b261-e310317555ab" type="System.DateTime">
          <orm:column name="date0" sql-type="timestamp" nullable="false" length="0" scale="0" ado-type="" />
        </orm:field>
        <orm:field name="_User_Id0" property="User_Id0" behavior="readwrite" uniqueId="47c77089-5d56-42a2-b576-509b93884940" type="System.Int64">
          <orm:column name="user_id0" sql-type="int8" nullable="false" length="0" scale="0" ado-type="" />
        </orm:field>
        <orm:field name="_Status" property="Status" behavior="readwrite" uniqueId="64c6e613-9699-4d4c-b61f-2f3e3abfd822" type="System.String">
          <orm:column name="status" sql-type="text" nullable="false" length="0" scale="0" ado-type="" />
        </orm:field>
        <orm:field name="_Date2" property="Date2" behavior="readwrite" uniqueId="333e1865-9ed7-48c2-aafe-dc3acc6b38f0" type="System.DateTime">
          <orm:column name="date2" sql-type="timestamp" nullable="false" length="0" scale="0" ado-type="" />
        </orm:field>
        <orm:field name="_User_Id2" property="User_Id2" behavior="readwrite" uniqueId="5887119d-78b4-4e4c-a9af-d953970bb1e5" type="System.Int64">
          <orm:column name="user_id2" sql-type="int8" nullable="false" length="0" scale="0" ado-type="" />
        </orm:field>
        <orm:field name="_dmnt" property="Dmnt" behavior="readwrite" uniqueId="e130c8de-7b7d-4c7d-ae79-5163dd85c6ec" type="MyERPModel.Dmnt">
          <orm:reference uniqueId="0cb22bb7-2d7d-4db3-80ce-b9fcfdf36e34" association-name="Ph11HasDmnt">
            <orm:sharedfield name="_Ma_Nt" target-class="MyERPModel.Dmnt" target-field="_ma_nt" />
          </orm:reference>
        </orm:field>
        <orm:field name="_userinfo" property="Userinfo0" behavior="readwrite" uniqueId="ad71934f-c342-46fa-9eef-597c22fd3b1e" type="MyERPModel.Userinfo">
          <orm:reference uniqueId="040d4b9b-a76f-4286-9053-f12ab5b5a49a" association-name="Ph11HasUserinfo0">
            <orm:sharedfield name="_User_Id0" target-class="MyERPModel.Userinfo" target-field="_user_id" />
          </orm:reference>
        </orm:field>
        <orm:field name="_userinfo1" property="Userinfo2" behavior="readwrite" uniqueId="b229fc60-d7e8-422c-bc67-cb627d60c821" type="MyERPModel.Userinfo">
          <orm:reference uniqueId="8561c739-3079-44e6-8083-14e5134e45d1" association-name="Ph11HasUserinfo2">
            <orm:sharedfield name="_User_Id2" target-class="MyERPModel.Userinfo" target-field="_user_id" />
          </orm:reference>
        </orm:field>
        <orm:field name="_dmdvcs" property="Dmdvcs" behavior="readwrite" uniqueId="2c957833-144d-42e4-be8c-33dfca7a18d1" type="MyERPModel.Dmdvcs">
          <orm:reference uniqueId="b2bed1d6-aa0b-4e12-b54a-8c77b7ca5faf" association-name="Ph11HasDmdvcs">
            <orm:sharedfield name="_Ma_Dvcs" target-class="MyERPModel.Dmdvcs" target-field="_ma_dvcs" />
          </orm:reference>
        </orm:field>
        <orm:field name="_ct11" property="Ct11s" behavior="readwrite" uniqueId="07ec2603-84e3-4c8d-a52d-e32cfad2f54a" type="MyERPModel.Ct11">
          <orm:collection element-class="MyERPModel.Ct11" inverse-field="_ph11" order-by="" uniqueId="5685b103-b6b7-44cb-a08e-f3278fc9a835" />
        </orm:field>
      </orm:class>
      <orm:class name="Ct11" uniqueId="8481a6cc-b6ad-4206-8b61-08181d982446">
        <orm:table name="ct11" />
        <orm:identity>
          <orm:multiple-field>
            <orm:single-field field-name="_stt_rec" />
            <orm:single-field field-name="_ln" />
          </orm:multiple-field>
        </orm:identity>
        <orm:concurrency strategy="changed" />
        <orm:field name="_stt_rec" property="Stt_Rec" behavior="readwrite" uniqueId="25cd9e95-1e3e-4b5b-b3fb-0c06856d0d6e" type="System.String">
          <orm:column name="stt_rec" sql-type="text" nullable="false" length="0" scale="0" primary-key="true" ado-type="" />
        </orm:field>
        <orm:field name="_ma_ct" property="Ma_Ct" behavior="readwrite" uniqueId="951113e5-7290-4507-839b-e69c9608f1c2" type="System.String">
          <orm:column name="ma_ct" sql-type="text" nullable="false" length="0" scale="0" ado-type="" />
        </orm:field>
        <orm:field name="_ngay_ct" property="Ngay_Ct" behavior="readwrite" uniqueId="806fda7d-e5f2-4626-b5be-9aa4c7d8a9fe" type="System.DateTime">
          <orm:column name="ngay_ct" sql-type="date" nullable="false" length="0" scale="0" ado-type="" />
        </orm:field>
        <orm:field name="_so_ct" property="So_Ct" behavior="readwrite" uniqueId="a0255897-38d4-40e8-93e5-3bb83e62aef2" type="System.String">
          <orm:column name="so_ct" sql-type="text" nullable="false" length="0" scale="0" ado-type="" />
        </orm:field>
        <orm:field name="_dien_giaii" property="Dien_Giaii" behavior="readwrite" uniqueId="f71c5a51-c976-4ab9-aafb-056026dbb4ba" type="System.String">
          <orm:column name="dien_giaii" sql-type="text" nullable="false" length="0" scale="0" ado-type="" />
        </orm:field>
        <orm:field name="_tk_i" property="Tk_I" behavior="readwrite" uniqueId="9769048a-6458-45a1-b27a-541663316f20" type="System.String">
          <orm:column name="tk_i" sql-type="text" nullable="false" length="0" scale="0" ado-type="" />
        </orm:field>
        <orm:field name="_ps_no_nt" property="Ps_No_Nt" behavior="readwrite" uniqueId="7f74c9b7-d033-4dd7-bc64-00349a96d0ca" type="System.Decimal">
          <orm:column name="ps_no_nt" sql-type="numeric" nullable="false" length="38" scale="200" ado-type="" />
        </orm:field>
        <orm:field name="_ps_co_nt" property="Ps_Co_Nt" behavior="readwrite" uniqueId="c786bea9-7e2e-4ada-8d3e-8ce759cff9bf" type="System.Decimal">
          <orm:column name="ps_co_nt" sql-type="numeric" nullable="false" length="38" scale="20" ado-type="" />
        </orm:field>
        <orm:field name="_ps_no" property="Ps_No" behavior="readwrite" uniqueId="a6da2cca-c3b0-4da4-a7ea-3d99874a1a7a" type="System.Decimal">
          <orm:column name="ps_no" sql-type="numeric" nullable="false" length="38" scale="20" ado-type="" />
        </orm:field>
        <orm:field name="_ps_co" property="Ps_Co" behavior="readwrite" uniqueId="62bb2580-e943-43c1-bf7c-a9957882a03a" type="System.Decimal">
          <orm:column name="ps_co" sql-type="numeric" nullable="false" length="38" scale="20" ado-type="" />
        </orm:field>
        <orm:field name="_nh_dk" property="Nh_Dk" behavior="readwrite" uniqueId="f8b6478c-a8f5-4fb9-bbd0-d19dfa00ef43" type="System.String">
          <orm:column name="nh_dk" sql-type="text" nullable="false" length="0" scale="0" ado-type="" />
        </orm:field>
        <orm:field name="_ma_kh_i" property="Ma_Kh_I" behavior="readwrite" uniqueId="9c36f9d9-c23c-40f7-bc55-e749de0bedf1" type="System.String">
          <orm:column name="ma_kh_i" sql-type="text" nullable="false" length="0" scale="0" ado-type="" />
        </orm:field>
        <orm:field name="_ma_vv_i" property="Ma_Vv_I" behavior="readwrite" uniqueId="7bf2150d-b5a5-4e2f-a3e9-f1c54ab63723" type="System.String">
          <orm:column name="ma_vv_i" sql-type="text" nullable="false" length="0" scale="0" ado-type="" />
        </orm:field>
        <orm:field name="_ma_td_i" property="Ma_Td_I" behavior="readwrite" uniqueId="5d9422d0-1691-4290-ba98-9a050cb5fcf0" type="System.String">
          <orm:column name="ma_td_i" sql-type="text" nullable="false" length="0" scale="0" ado-type="" />
        </orm:field>
        <orm:field name="_ln" property="Ln" behavior="readwrite" uniqueId="6b7ea4e4-fd50-44ad-a51a-8bc5584e8e5b" type="System.Int64">
          <orm:column name="ln" sql-type="int8" nullable="false" length="0" scale="0" primary-key="true" ado-type="" />
        </orm:field>
        <orm:field name="_ma_ku" property="Ma_Ku" behavior="readwrite" uniqueId="ca1a4089-e1c7-4fc6-a573-4b6119449ed1" type="System.String">
          <orm:column name="ma_ku" sql-type="text" nullable="false" length="0" scale="0" ado-type="" />
        </orm:field>
        <orm:field name="_ph11" property="Ph11" behavior="readwrite" uniqueId="b8f7d741-5a37-4b6f-af00-3e93ea88eaba" type="MyERPModel.Ph11">
          <orm:reference uniqueId="5685b103-b6b7-44cb-a08e-f3278fc9a835" association-name="Ct11HasPh11">
            <orm:sharedfield name="_stt_rec" target-class="MyERPModel.Ph11" target-field="_Stt_Rec" />
          </orm:reference>
        </orm:field>
        <orm:field name="_dmkh" property="Dmkh" behavior="readwrite" uniqueId="eff5976f-30c7-49d8-925e-b9453a644108" type="MyERPModel.Dmkh">
          <orm:reference uniqueId="39abcdb0-f796-44df-ac72-2516ae6d284d" association-name="Ct11HasDmkh">
            <orm:sharedfield name="_ma_kh_i" target-class="MyERPModel.Dmkh" target-field="_ma_kh" />
          </orm:reference>
        </orm:field>
        <orm:field name="_dmvv" property="Dmvv" behavior="readwrite" uniqueId="df6c37e9-f1f4-4c32-acc9-454417e2aee7" type="MyERPModel.Dmvv">
          <orm:reference uniqueId="4729eb29-9545-4fbb-b3c9-2107e833c959" association-name="Ct11HasDmvv">
            <orm:sharedfield name="_ma_vv_i" target-class="MyERPModel.Dmvv" target-field="_ma_vv" />
          </orm:reference>
        </orm:field>
        <orm:field name="_dmtk" property="Dmtk" behavior="readwrite" uniqueId="58d0ec19-1557-4fe6-9033-243bd28f7b3a" type="MyERPModel.Dmtk">
          <orm:reference uniqueId="2d3e0b1f-6e0d-42fc-8dd0-fe8f12fd2f67" association-name="Ct11HasDmtk">
            <orm:sharedfield name="_tk_i" target-class="MyERPModel.Dmtk" target-field="_tk" />
          </orm:reference>
        </orm:field>
        <orm:field name="_dmtd" property="Dmtd" behavior="readwrite" uniqueId="a5a78d7b-7d6e-4332-90ed-7d9f218acadb" type="MyERPModel.Dmtd">
          <orm:reference uniqueId="21f515eb-d035-4e02-b31b-70cf8b19b769" association-name="Ct11HasDmtd">
            <orm:sharedfield name="_ma_td_i" target-class="MyERPModel.Dmtd" target-field="_ma_td" />
          </orm:reference>
        </orm:field>
      </orm:class>
      <orm:class name="Dmdvcs" uniqueId="97b688dd-facf-4bf5-9c2f-4d63ce988854">
        <orm:table name="dmdvcs" />
        <orm:identity>
          <orm:single-field field-name="_ma_dvcs" />
        </orm:identity>
        <orm:concurrency strategy="changed" />
        <orm:field name="_ma_dvcs" property="Ma_Dvcs" behavior="readwrite" uniqueId="fe952f33-f611-4733-bc22-7165b8c4c528" type="System.String">
          <orm:column name="ma_dvcs" sql-type="text" nullable="false" length="0" scale="0" primary-key="true" ado-type="" />
        </orm:field>
        <orm:field name="_ten_dvcs" property="Ten_Dvcs" behavior="readwrite" uniqueId="4b5af097-14de-48d3-8db9-ea849445fb4c" type="System.String">
          <orm:column name="ten_dvcs" sql-type="text" nullable="false" length="0" scale="0" ado-type="" />
        </orm:field>
        <orm:field name="_ten_dvcs2" property="Ten_Dvcs2" behavior="readwrite" uniqueId="a713f6b1-2ebd-41c6-8918-f0fe87638433" type="System.String">
          <orm:column name="ten_dvcs2" sql-type="text" nullable="false" length="0" scale="0" ado-type="" />
        </orm:field>
        <orm:field name="_date0" property="Date0" behavior="readwrite" uniqueId="4276a5e1-583e-4381-b830-7a77196140b8" type="System.DateTime">
          <orm:column name="date0" sql-type="timestamp" nullable="false" length="0" scale="0" ado-type="" />
        </orm:field>
        <orm:field name="_user_id0" property="User_Id0" behavior="readwrite" uniqueId="e0206719-089e-44fe-a6d8-29513e70bb0d" type="System.Int64">
          <orm:column name="user_id0" sql-type="int8" nullable="false" length="0" scale="0" ado-type="" />
        </orm:field>
        <orm:field name="_date2" property="Date2" behavior="readwrite" uniqueId="8c552b56-8740-4114-a2fb-98c9eb47263d" type="System.DateTime">
          <orm:column name="date2" sql-type="timestamp" nullable="false" length="0" scale="0" ado-type="" />
        </orm:field>
        <orm:field name="_user_id2" property="User_Id2" behavior="readwrite" uniqueId="4ace2386-c7f5-4863-bf86-6e328aeb46dd" type="System.Int64">
          <orm:column name="user_id2" sql-type="int8" nullable="false" length="0" scale="0" ado-type="" />
        </orm:field>
        <orm:field name="_status" property="Status" behavior="readwrite" uniqueId="286ea9c5-4670-4eca-a93b-3764128c891a" type="System.String">
          <orm:column name="status" sql-type="text" nullable="false" length="0" scale="0" ado-type="" />
        </orm:field>
        <orm:field name="_m_ws_id" property="M_Ws_Id" behavior="readwrite" uniqueId="ad77c6b6-0826-4537-b39a-7b586f2b8b0f" type="System.String">
          <orm:column name="m_ws_id" sql-type="text" nullable="false" length="0" scale="0" ado-type="" />
        </orm:field>
        <orm:field name="_userinfo" property="Userinfo0" behavior="readwrite" uniqueId="80faad2e-b992-4242-a1de-4196c08f5fa0" type="MyERPModel.Userinfo">
          <orm:reference uniqueId="6cf46b87-f996-4e0e-850a-2ba457350c37" association-name="DmdvcsHasUserinfo0">
            <orm:sharedfield name="_user_id0" target-class="MyERPModel.Userinfo" target-field="_user_id" />
          </orm:reference>
        </orm:field>
        <orm:field name="_userinfo1" property="Userinfo2" behavior="readwrite" uniqueId="4cd5cf7e-3faf-47c8-9243-a5ddad3de871" type="MyERPModel.Userinfo">
          <orm:reference uniqueId="6596f954-a873-43e4-a0b9-843660adce30" association-name="DmdvcsHasUserinfo2">
            <orm:sharedfield name="_user_id2" target-class="MyERPModel.Userinfo" target-field="_user_id" />
          </orm:reference>
        </orm:field>
      </orm:class>
      <orm:class name="Dmtd" uniqueId="d1172a9d-6632-4017-ac36-14d50b13174a">
        <orm:table name="dmtd" />
        <orm:identity>
          <orm:single-field field-name="_ma_td" />
        </orm:identity>
        <orm:concurrency strategy="changed" />
        <orm:field name="_user_id2" property="User_Id2" behavior="readwrite" uniqueId="56110b65-f21b-40a3-9f18-564d23afb236" type="System.Int64">
          <orm:column name="user_id2" sql-type="int8" nullable="false" length="0" scale="0" ado-type="" />
        </orm:field>
        <orm:field name="_user_id0" property="User_Id0" behavior="readwrite" uniqueId="98d64fc2-e68a-44ba-bd06-eb4fcbe7c776" type="System.Int64">
          <orm:column name="user_id0" sql-type="int8" nullable="false" length="0" scale="0" ado-type="" />
        </orm:field>
        <orm:field name="_ten_td2" property="Ten_Td2" behavior="readwrite" uniqueId="3a0a8cb4-cbb0-47d2-bb3c-e9aa2e0e4965" type="System.String">
          <orm:column name="ten_td2" sql-type="text" nullable="false" length="0" scale="0" ado-type="" />
        </orm:field>
        <orm:field name="_ten_td" property="Ten_Td" behavior="readwrite" uniqueId="cd6f8448-cb4f-458b-82f1-fdb382cd9c9b" type="System.String">
          <orm:column name="ten_td" sql-type="text" nullable="false" length="0" scale="0" ado-type="" />
        </orm:field>
        <orm:field name="_status" property="Status" behavior="readwrite" uniqueId="07438339-e8fb-4a16-87c9-36787e8644f5" type="System.String">
          <orm:column name="status" sql-type="text" nullable="false" length="0" scale="0" ado-type="" />
        </orm:field>
        <orm:field name="_ma_td" property="Ma_Td" behavior="readwrite" uniqueId="2c962e35-08c8-463e-930e-51a4c0f82e98" type="System.String">
          <orm:column name="ma_td" sql-type="text" nullable="false" length="0" scale="0" primary-key="true" ado-type="" />
        </orm:field>
        <orm:field name="_date2" property="Date2" behavior="readwrite" uniqueId="44f672c6-9bdc-4529-9ae6-c5bbb1531038" type="System.DateTime">
          <orm:column name="date2" sql-type="timestamp" nullable="false" length="0" scale="0" ado-type="" />
        </orm:field>
        <orm:field name="_date0" property="Date0" behavior="readwrite" uniqueId="2d0ae781-24ec-40f0-b5dc-91cfa34946db" type="System.DateTime">
          <orm:column name="date0" sql-type="timestamp" nullable="false" length="0" scale="0" ado-type="" />
        </orm:field>
      </orm:class>
      <orm:class name="Dmct" uniqueId="6f9d7dd5-2eff-470f-afd8-44cb565dbd66">
        <orm:table name="dmct" />
        <orm:identity>
          <orm:single-field field-name="_ma_ct" />
        </orm:identity>
        <orm:concurrency strategy="changed" />
        <orm:field name="_ma_ct" property="Ma_Ct" behavior="readwrite" uniqueId="83ddb2ec-b1bf-4fdf-ac42-bd2b8316189c" type="System.String">
          <orm:column name="ma_ct" sql-type="text" nullable="false" length="0" scale="0" primary-key="true" ado-type="" />
        </orm:field>
        <orm:field name="_user_id2" property="User_Id2" behavior="readwrite" uniqueId="be41e505-edd0-4405-ac5e-b9d104cc825d" type="System.Int64">
          <orm:column name="user_id2" sql-type="int8" nullable="false" length="0" scale="0" ado-type="" />
        </orm:field>
        <orm:field name="_user_id0" property="User_Id0" behavior="readwrite" uniqueId="aed096c4-2730-4529-98fd-c49bb9621b09" type="System.Int64">
          <orm:column name="user_id0" sql-type="int8" nullable="false" length="0" scale="0" ado-type="" />
        </orm:field>
        <orm:field name="_ten_ct2" property="Ten_Ct2" behavior="readwrite" uniqueId="3a3f0082-de74-4d94-8ef8-97ff4bfd4e3b" type="System.String">
          <orm:column name="ten_ct2" sql-type="text" nullable="false" length="0" scale="0" ado-type="" />
        </orm:field>
        <orm:field name="_ten_ct" property="Ten_Ct" behavior="readwrite" uniqueId="27ac5a7b-d58b-4fe1-a948-faa18e9eab6a" type="System.String">
          <orm:column name="ten_ct" sql-type="text" nullable="false" length="0" scale="0" ado-type="" />
        </orm:field>
        <orm:field name="_stt_ctntxt" property="Stt_Ctntxt" behavior="readwrite" uniqueId="7d1d258d-9622-4caa-a683-04d979e749c8" type="System.Int16">
          <orm:column name="stt_ctntxt" sql-type="int2" nullable="false" length="0" scale="0" ado-type="" />
        </orm:field>
        <orm:field name="_stt_ct_nkc" property="Stt_Ct_Nkc" behavior="readwrite" uniqueId="b69a9de6-e841-486f-9f03-bff8c526b695" type="System.Int16">
          <orm:column name="stt_ct_nkc" sql-type="int2" nullable="false" length="0" scale="0" ado-type="" />
        </orm:field>
        <orm:field name="_so_ct" property="So_Ct" behavior="readwrite" uniqueId="5f4eb04f-ab30-40fe-a91c-e664a131aaa6" type="System.Int64">
          <orm:column name="so_ct" sql-type="int8" nullable="false" length="0" scale="0" ado-type="" />
        </orm:field>
        <orm:field name="_ma_phan_he" property="Ma_Phan_He" behavior="readwrite" uniqueId="a2fce2f9-a476-463c-b654-7c0f71d187ff" type="System.String">
          <orm:column name="ma_phan_he" sql-type="text" nullable="false" length="0" scale="0" ado-type="" />
        </orm:field>
        <orm:field name="_ma_nt" property="Ma_Nt" behavior="readwrite" uniqueId="0eeab798-76d3-4130-8445-90b442e3dc5b" type="System.String">
          <orm:column name="ma_nt" sql-type="text" nullable="false" length="0" scale="0" ado-type="" />
        </orm:field>
        <orm:field name="_ma_ct_me" property="Ma_Ct_Me" behavior="readwrite" uniqueId="e18c2c15-d6a2-427a-8ca9-f4d86b201cd4" type="System.String">
          <orm:column name="ma_ct_me" sql-type="text" nullable="false" length="0" scale="0" ado-type="" />
        </orm:field>
        <orm:field name="_ma_ct_in" property="Ma_Ct_In" behavior="readwrite" uniqueId="d7c4891c-cf9f-43f0-903f-7f63c3c94a08" type="System.String">
          <orm:column name="ma_ct_in" sql-type="text" nullable="false" length="0" scale="0" ado-type="" />
        </orm:field>
        <orm:field name="_m_trung_so" property="M_Trung_So" behavior="readwrite" uniqueId="34303206-826b-4636-9c99-e7c772681058" type="System.Int16">
          <orm:column name="m_trung_so" sql-type="int2" nullable="false" length="0" scale="0" ado-type="" />
        </orm:field>
        <orm:field name="_m_status" property="M_Status" behavior="readwrite" uniqueId="715dd19c-9f6b-4ef4-aded-5d78399a7fe2" type="System.String">
          <orm:column name="m_status" sql-type="text" nullable="false" length="0" scale="0" ado-type="" />
        </orm:field>
        <orm:field name="_m_ngay_ct" property="M_Ngay_Ct" behavior="readwrite" uniqueId="faad8d7b-77e6-4153-ac06-95495cf8c87f" type="System.Int16">
          <orm:column name="m_ngay_ct" sql-type="int2" nullable="false" length="0" scale="0" ado-type="" />
        </orm:field>
        <orm:field name="_m_ma_nk" property="M_Ma_Nk" behavior="readwrite" uniqueId="7c7d7c33-8c80-471d-b3f7-bcf6266e6966" type="System.String">
          <orm:column name="m_ma_nk" sql-type="text" nullable="false" length="0" scale="0" ado-type="" />
        </orm:field>
        <orm:field name="_m_ma_gd" property="M_Ma_Gd" behavior="readwrite" uniqueId="52864c16-5f35-4c8e-90f4-493c875a3e7b" type="System.String">
          <orm:column name="m_ma_gd" sql-type="text" nullable="false" length="0" scale="0" ado-type="" />
        </orm:field>
        <orm:field name="_m_loc_nsd" property="M_Loc_Nsd" behavior="readwrite" uniqueId="5e359cf1-24ce-4749-a790-6c3634ff8ad4" type="System.Int16">
          <orm:column name="m_loc_nsd" sql-type="int2" nullable="false" length="0" scale="0" ado-type="" />
        </orm:field>
        <orm:field name="_date2" property="Date2" behavior="readwrite" uniqueId="50f071f1-9d43-4252-a174-f1415657ea4c" type="System.DateTime">
          <orm:column name="date2" sql-type="timestamp" nullable="false" length="0" scale="0" ado-type="" />
        </orm:field>
        <orm:field name="_date0" property="Date0" behavior="readwrite" uniqueId="75e3b3ee-7ef2-4a7f-ad51-fd9286ef6462" type="System.DateTime">
          <orm:column name="date0" sql-type="timestamp" nullable="false" length="0" scale="0" ado-type="" />
        </orm:field>
        <orm:field name="_ct_nxt" property="Ct_Nxt" behavior="readwrite" uniqueId="b31e03e8-2dc3-47d6-9847-4211cc966a96" type="System.Int16">
          <orm:column name="ct_nxt" sql-type="int2" nullable="false" length="0" scale="0" ado-type="" />
        </orm:field>
      </orm:class>
    </orm:namespace>
    <orm:schema schema="">
      <orm:table name="userinfo">
        <orm:column name="user_id" sql-type="int8" nullable="false" length="0" scale="0" primary-key="true" ado-type="" />
        <orm:column name="user_name" sql-type="text" nullable="false" length="0" scale="0" ado-type="" />
        <orm:column name="user_pre" sql-type="text" nullable="false" length="0" scale="0" ado-type="" />
        <orm:column name="pass" sql-type="text" nullable="false" length="0" scale="0" ado-type="" />
        <orm:column name="comment" sql-type="text" nullable="false" length="0" scale="0" ado-type="" />
        <orm:column name="is_admin" sql-type="int2" nullable="false" length="0" scale="0" ado-type="" />
        <orm:column name="del_yn" sql-type="int2" nullable="false" length="0" scale="0" ado-type="" />
        <orm:column name="rights" sql-type="text" nullable="false" length="0" scale="0" ado-type="" />
        <orm:column name="r_access" sql-type="text" nullable="false" length="0" scale="0" ado-type="" />
        <orm:column name="r_add" sql-type="text" nullable="false" length="0" scale="0" ado-type="" />
        <orm:column name="r_edit" sql-type="text" nullable="false" length="0" scale="0" ado-type="" />
        <orm:column name="r_del" sql-type="text" nullable="false" length="0" scale="0" ado-type="" />
        <orm:column name="r_print" sql-type="text" nullable="false" length="0" scale="0" ado-type="" />
        <orm:column name="r_read" sql-type="text" nullable="false" length="0" scale="0" ado-type="" />
        <orm:column name="date0" sql-type="timestamp" nullable="false" length="0" scale="0" ado-type="" />
        <orm:column name="user_id0" sql-type="int8" nullable="false" length="0" scale="0" ado-type="" />
        <orm:column name="status" sql-type="text" nullable="false" length="0" scale="0" ado-type="" />
        <orm:column name="date2" sql-type="timestamp" nullable="false" length="0" scale="0" ado-type="" />
        <orm:column name="user_id2" sql-type="int8" nullable="false" length="0" scale="0" ado-type="" />
        <orm:column name="r_search" sql-type="text" nullable="false" length="0" scale="0" ado-type="" />
      </orm:table>
      <orm:table name="dmtk">
        <orm:column name="tk" sql-type="text" nullable="false" length="0" scale="0" primary-key="true" ado-type="" />
        <orm:column name="ten_tk" sql-type="text" nullable="false" length="0" scale="0" ado-type="" />
        <orm:column name="ten_tk2" sql-type="text" nullable="false" length="0" scale="0" ado-type="" />
        <orm:column name="ma_nt" sql-type="text" nullable="false" length="0" scale="0" ado-type="" />
        <orm:column name="loai_tk" sql-type="int2" nullable="false" length="0" scale="0" ado-type="" />
        <orm:column name="tk_me" sql-type="text" nullable="false" length="0" scale="0" ado-type="" />
        <orm:column name="bac_tk" sql-type="int2" nullable="false" length="0" scale="0" ado-type="" />
        <orm:column name="tk_sc" sql-type="int2" nullable="false" length="0" scale="0" ado-type="" />
        <orm:column name="tk_cn" sql-type="int2" nullable="false" length="0" scale="0" ado-type="" />
        <orm:column name="nh_tk2" sql-type="text" nullable="false" length="0" scale="0" ado-type="" />
        <orm:column name="date0" sql-type="timestamp" nullable="false" length="0" scale="0" ado-type="" />
        <orm:column name="user_id0" sql-type="int8" nullable="false" length="0" scale="0" ado-type="" />
        <orm:column name="date2" sql-type="timestamp" nullable="false" length="0" scale="0" ado-type="" />
        <orm:column name="user_id2" sql-type="int8" nullable="false" length="0" scale="0" ado-type="" />
        <orm:column name="nh_tk0" sql-type="text" nullable="false" length="0" scale="0" ado-type="" />
        <orm:column name="status" sql-type="text" nullable="false" length="0" scale="0" ado-type="" />
      </orm:table>
      <orm:table name="dmnt">
        <orm:column name="ma_nt" sql-type="text" nullable="false" length="0" scale="0" primary-key="true" ado-type="" />
        <orm:column name="ten_nt" sql-type="text" nullable="false" length="0" scale="0" ado-type="" />
        <orm:column name="date0" sql-type="timestamp" nullable="false" length="0" scale="0" ado-type="" />
        <orm:column name="user_id0" sql-type="int8" nullable="false" length="0" scale="0" ado-type="" />
        <orm:column name="ten_nt2" sql-type="text" nullable="false" length="0" scale="0" ado-type="" />
        <orm:column name="date2" sql-type="timestamp" nullable="false" length="0" scale="0" ado-type="" />
        <orm:column name="user_id2" sql-type="int8" nullable="false" length="0" scale="0" ado-type="" />
        <orm:column name="status" sql-type="text" nullable="false" length="0" scale="0" ado-type="" />
      </orm:table>
      <orm:table name="dmkh">
        <orm:column name="ma_kh" sql-type="text" nullable="false" length="0" scale="0" primary-key="true" ado-type="" />
        <orm:column name="ten_kh" sql-type="text" nullable="false" length="0" scale="0" ado-type="" />
        <orm:column name="ten_kh2" sql-type="text" nullable="false" length="0" scale="0" ado-type="" />
        <orm:column name="ma_so_thue" sql-type="text" nullable="false" length="0" scale="0" ado-type="" />
        <orm:column name="dia_chi" sql-type="text" nullable="false" length="0" scale="0" ado-type="" />
        <orm:column name="dien_thoai" sql-type="text" nullable="false" length="0" scale="0" ado-type="" />
        <orm:column name="fax" sql-type="text" nullable="false" length="0" scale="0" ado-type="" />
        <orm:column name="e_mail" sql-type="text" nullable="false" length="0" scale="0" ado-type="" />
        <orm:column name="home_page" sql-type="text" nullable="false" length="0" scale="0" ado-type="" />
        <orm:column name="doi_tac" sql-type="text" nullable="false" length="0" scale="0" ado-type="" />
        <orm:column name="ong_ba" sql-type="text" nullable="false" length="0" scale="0" ado-type="" />
        <orm:column name="ten_bp" sql-type="text" nullable="false" length="0" scale="0" ado-type="" />
        <orm:column name="ngan_hang" sql-type="text" nullable="false" length="0" scale="0" ado-type="" />
        <orm:column name="ghi_chu" sql-type="text" nullable="false" length="0" scale="0" ado-type="" />
        <orm:column name="tk" sql-type="text" nullable="false" length="0" scale="0" ado-type="" />
        <orm:column name="tk_nh" sql-type="text" nullable="false" length="0" scale="0" ado-type="" />
        <orm:column name="nh_kh1" sql-type="text" nullable="false" length="0" scale="0" ado-type="" />
        <orm:column name="nh_kh2" sql-type="text" nullable="false" length="0" scale="0" ado-type="" />
        <orm:column name="nh_kh3" sql-type="text" nullable="false" length="0" scale="0" ado-type="" />
        <orm:column name="du_nt13" sql-type="numeric" nullable="false" length="38" scale="20" ado-type="" />
        <orm:column name="t_tien_cn" sql-type="numeric" nullable="false" length="38" scale="20" ado-type="" />
        <orm:column name="t_tien_hd" sql-type="numeric" nullable="false" length="38" scale="20" ado-type="" />
        <orm:column name="date0" sql-type="timestamp" nullable="false" length="0" scale="0" ado-type="" />
        <orm:column name="user_id0" sql-type="int8" nullable="false" length="0" scale="0" ado-type="" />
        <orm:column name="date2" sql-type="timestamp" nullable="false" length="0" scale="0" ado-type="" />
        <orm:column name="user_id2" sql-type="int8" nullable="false" length="0" scale="0" ado-type="" />
        <orm:column name="ma_tt" sql-type="text" nullable="false" length="0" scale="0" ado-type="" />
        <orm:column name="kh_yn" sql-type="int2" nullable="false" length="0" scale="0" ado-type="" />
        <orm:column name="cc_yn" sql-type="int2" nullable="false" length="0" scale="0" ado-type="" />
        <orm:column name="nv_yn" sql-type="int2" nullable="false" length="0" scale="0" ado-type="" />
      </orm:table>
      <orm:table name="dmnhkh">
        <orm:column name="loai_nh" sql-type="int2" nullable="false" length="0" scale="0" ado-type="" />
        <orm:column name="ma_nh" sql-type="text" nullable="false" length="0" scale="0" primary-key="true" ado-type="" />
        <orm:column name="ten_nh" sql-type="text" nullable="false" length="0" scale="0" ado-type="" />
        <orm:column name="ten_nh2" sql-type="text" nullable="false" length="0" scale="0" ado-type="" />
        <orm:column name="date0" sql-type="timestamp" nullable="false" length="0" scale="0" ado-type="" />
        <orm:column name="user_id0" sql-type="int8" nullable="false" length="0" scale="0" ado-type="" />
        <orm:column name="date2" sql-type="timestamp" nullable="false" length="0" scale="0" ado-type="" />
        <orm:column name="user_id2" sql-type="int8" nullable="false" length="0" scale="0" ado-type="" />
        <orm:column name="status" sql-type="text" nullable="false" length="0" scale="0" ado-type="" />
      </orm:table>
      <orm:table name="dmtt">
        <orm:column name="ma_tt" sql-type="text" nullable="false" length="0" scale="0" primary-key="true" ado-type="" />
        <orm:column name="ten_tt" sql-type="text" nullable="false" length="0" scale="0" ado-type="" />
        <orm:column name="ten_tt2" sql-type="text" nullable="false" length="0" scale="0" ado-type="" />
        <orm:column name="han_tt" sql-type="int2" nullable="false" length="0" scale="0" ado-type="" />
        <orm:column name="han_tt_gg" sql-type="int2" nullable="false" length="0" scale="0" ado-type="" />
        <orm:column name="pt_gg" sql-type="numeric" nullable="false" length="38" scale="20" ado-type="" />
        <orm:column name="date0" sql-type="timestamp" nullable="false" length="0" scale="0" ado-type="" />
        <orm:column name="user_id0" sql-type="int8" nullable="false" length="0" scale="0" ado-type="" />
        <orm:column name="date2" sql-type="timestamp" nullable="false" length="0" scale="0" ado-type="" />
        <orm:column name="user_id2" sql-type="int8" nullable="false" length="0" scale="0" ado-type="" />
        <orm:column name="status" sql-type="text" nullable="false" length="0" scale="0" ado-type="" />
      </orm:table>
      <orm:table name="dmvv">
        <orm:column name="ma_vv" sql-type="text" nullable="false" length="0" scale="0" primary-key="true" ado-type="" />
        <orm:column name="ten_vv" sql-type="text" nullable="false" length="0" scale="0" ado-type="" />
        <orm:column name="ten_vv2" sql-type="text" nullable="false" length="0" scale="0" ado-type="" />
        <orm:column name="ma_kh" sql-type="text" nullable="false" length="0" scale="0" ado-type="" />
        <orm:column name="nh_vv1" sql-type="text" nullable="false" length="0" scale="0" ado-type="" />
        <orm:column name="nh_vv2" sql-type="text" nullable="false" length="0" scale="0" ado-type="" />
        <orm:column name="nh_vv3" sql-type="text" nullable="false" length="0" scale="0" ado-type="" />
        <orm:column name="ngay_vv1" sql-type="date" nullable="false" length="0" scale="0" ado-type="" />
        <orm:column name="ngay_vv2" sql-type="date" nullable="false" length="0" scale="0" ado-type="" />
        <orm:column name="ma_nt" sql-type="text" nullable="false" length="0" scale="0" ado-type="" />
        <orm:column name="tien_nt" sql-type="numeric" nullable="false" length="38" scale="20" ado-type="" />
        <orm:column name="tien" sql-type="numeric" nullable="false" length="38" scale="20" ado-type="" />
        <orm:column name="ghi_chu" sql-type="text" nullable="false" length="0" scale="0" ado-type="" />
        <orm:column name="date0" sql-type="timestamp" nullable="false" length="0" scale="0" ado-type="" />
        <orm:column name="user_id0" sql-type="int8" nullable="false" length="0" scale="0" ado-type="" />
        <orm:column name="date2" sql-type="timestamp" nullable="false" length="0" scale="0" ado-type="" />
        <orm:column name="user_id2" sql-type="int8" nullable="false" length="0" scale="0" ado-type="" />
        <orm:column name="status" sql-type="text" nullable="false" length="0" scale="0" ado-type="" />
        <orm:column name="tk" sql-type="text" nullable="false" length="0" scale="0" ado-type="" />
      </orm:table>
      <orm:table name="dmnhvv">
        <orm:column name="loai_nh" sql-type="int2" nullable="false" length="0" scale="0" ado-type="" />
        <orm:column name="ma_nh" sql-type="text" nullable="false" length="0" scale="0" primary-key="true" ado-type="" />
        <orm:column name="ten_nh" sql-type="text" nullable="false" length="0" scale="0" ado-type="" />
        <orm:column name="ten_nh2" sql-type="text" nullable="false" length="0" scale="0" ado-type="" />
        <orm:column name="date0" sql-type="timestamp" nullable="false" length="0" scale="0" ado-type="" />
        <orm:column name="user_id0" sql-type="int8" nullable="false" length="0" scale="0" ado-type="" />
        <orm:column name="status" sql-type="text" nullable="false" length="0" scale="0" ado-type="" />
        <orm:column name="date2" sql-type="timestamp" nullable="false" length="0" scale="0" ado-type="" />
        <orm:column name="user_id2" sql-type="int8" nullable="false" length="0" scale="0" ado-type="" />
      </orm:table>
      <orm:table name="ph11">
        <orm:column name="stt_rec" sql-type="text" nullable="false" length="0" scale="0" primary-key="true" ado-type="" />
        <orm:column name="ma_dvcs" sql-type="text" nullable="false" length="0" scale="0" ado-type="" />
        <orm:column name="ma_ct" sql-type="text" nullable="false" length="0" scale="0" ado-type="" />
        <orm:column name="ngay_ct" sql-type="date" nullable="false" length="0" scale="0" ado-type="" />
        <orm:column name="ngay_lct" sql-type="date" nullable="false" length="0" scale="0" ado-type="" />
        <orm:column name="so_ct" sql-type="text" nullable="false" length="0" scale="0" ado-type="" />
        <orm:column name="so_lo" sql-type="text" nullable="false" length="0" scale="0" ado-type="" />
        <orm:column name="ngay_lo" sql-type="date" nullable="false" length="0" scale="0" ado-type="" />
        <orm:column name="ma_nk" sql-type="text" nullable="false" length="0" scale="0" ado-type="" />
        <orm:column name="ma_gd" sql-type="int2" nullable="false" length="0" scale="0" ado-type="" />
        <orm:column name="ma_nt" sql-type="text" nullable="false" length="0" scale="0" ado-type="" />
        <orm:column name="ty_gia" sql-type="numeric" nullable="false" length="38" scale="20" ado-type="" />
        <orm:column name="t_ps_no_nt" sql-type="numeric" nullable="false" length="38" scale="20" ado-type="" />
        <orm:column name="t_ps_no" sql-type="numeric" nullable="false" length="38" scale="20" ado-type="" />
        <orm:column name="t_ps_co_nt" sql-type="numeric" nullable="false" length="38" scale="20" ado-type="" />
        <orm:column name="date0" sql-type="timestamp" nullable="false" length="0" scale="0" ado-type="" />
        <orm:column name="user_id0" sql-type="int8" nullable="false" length="0" scale="0" ado-type="" />
        <orm:column name="status" sql-type="text" nullable="false" length="0" scale="0" ado-type="" />
        <orm:column name="date2" sql-type="timestamp" nullable="false" length="0" scale="0" ado-type="" />
        <orm:column name="user_id2" sql-type="int8" nullable="false" length="0" scale="0" ado-type="" />
      </orm:table>
      <orm:table name="dmdvcs">
        <orm:column name="ma_dvcs" sql-type="text" nullable="false" length="0" scale="0" primary-key="true" ado-type="" />
        <orm:column name="ten_dvcs" sql-type="text" nullable="false" length="0" scale="0" ado-type="" />
        <orm:column name="ten_dvcs2" sql-type="text" nullable="false" length="0" scale="0" ado-type="" />
        <orm:column name="date0" sql-type="timestamp" nullable="false" length="0" scale="0" ado-type="" />
        <orm:column name="user_id0" sql-type="int8" nullable="false" length="0" scale="0" ado-type="" />
        <orm:column name="date2" sql-type="timestamp" nullable="false" length="0" scale="0" ado-type="" />
        <orm:column name="user_id2" sql-type="int8" nullable="false" length="0" scale="0" ado-type="" />
        <orm:column name="status" sql-type="text" nullable="false" length="0" scale="0" ado-type="" />
        <orm:column name="m_ws_id" sql-type="text" nullable="false" length="0" scale="0" ado-type="" />
      </orm:table>
      <orm:table name="ct11">
        <orm:column name="stt_rec" sql-type="text" nullable="false" length="0" scale="0" primary-key="true" ado-type="" />
        <orm:column name="ma_ct" sql-type="text" nullable="false" length="0" scale="0" ado-type="" />
        <orm:column name="ngay_ct" sql-type="date" nullable="false" length="0" scale="0" ado-type="" />
        <orm:column name="so_ct" sql-type="text" nullable="false" length="0" scale="0" ado-type="" />
        <orm:column name="dien_giaii" sql-type="text" nullable="false" length="0" scale="0" ado-type="" />
        <orm:column name="tk_i" sql-type="text" nullable="false" length="0" scale="0" ado-type="" />
        <orm:column name="ps_no_nt" sql-type="numeric" nullable="false" length="38" scale="200" ado-type="" />
        <orm:column name="ps_co_nt" sql-type="numeric" nullable="false" length="38" scale="20" ado-type="" />
        <orm:column name="ps_no" sql-type="numeric" nullable="false" length="38" scale="20" ado-type="" />
        <orm:column name="ps_co" sql-type="numeric" nullable="false" length="38" scale="20" ado-type="" />
        <orm:column name="nh_dk" sql-type="text" nullable="false" length="0" scale="0" ado-type="" />
        <orm:column name="ma_kh_i" sql-type="text" nullable="false" length="0" scale="0" ado-type="" />
        <orm:column name="ma_vv_i" sql-type="text" nullable="false" length="0" scale="0" ado-type="" />
        <orm:column name="ma_td_i" sql-type="text" nullable="false" length="0" scale="0" ado-type="" />
        <orm:column name="ln" sql-type="int8" nullable="false" length="0" scale="0" primary-key="true" ado-type="" />
        <orm:column name="ma_ku" sql-type="text" nullable="false" length="0" scale="0" ado-type="" />
      </orm:table>
      <orm:table name="dmct">
        <orm:column name="ma_ct" sql-type="text" nullable="false" length="0" scale="0" primary-key="true" ado-type="" />
        <orm:column name="user_id2" sql-type="int8" nullable="false" length="0" scale="0" ado-type="" />
        <orm:column name="user_id0" sql-type="int8" nullable="false" length="0" scale="0" ado-type="" />
        <orm:column name="ten_ct2" sql-type="text" nullable="false" length="0" scale="0" ado-type="" />
        <orm:column name="ten_ct" sql-type="text" nullable="false" length="0" scale="0" ado-type="" />
        <orm:column name="stt_ctntxt" sql-type="int2" nullable="false" length="0" scale="0" ado-type="" />
        <orm:column name="stt_ct_nkc" sql-type="int2" nullable="false" length="0" scale="0" ado-type="" />
        <orm:column name="so_ct" sql-type="int8" nullable="false" length="0" scale="0" ado-type="" />
        <orm:column name="ma_phan_he" sql-type="text" nullable="false" length="0" scale="0" ado-type="" />
        <orm:column name="ma_nt" sql-type="text" nullable="false" length="0" scale="0" ado-type="" />
        <orm:column name="ma_ct_me" sql-type="text" nullable="false" length="0" scale="0" ado-type="" />
        <orm:column name="ma_ct_in" sql-type="text" nullable="false" length="0" scale="0" ado-type="" />
        <orm:column name="m_trung_so" sql-type="int2" nullable="false" length="0" scale="0" ado-type="" />
        <orm:column name="m_status" sql-type="text" nullable="false" length="0" scale="0" ado-type="" />
        <orm:column name="m_ngay_ct" sql-type="int2" nullable="false" length="0" scale="0" ado-type="" />
        <orm:column name="m_ma_nk" sql-type="text" nullable="false" length="0" scale="0" ado-type="" />
        <orm:column name="m_ma_gd" sql-type="text" nullable="false" length="0" scale="0" ado-type="" />
        <orm:column name="m_loc_nsd" sql-type="int2" nullable="false" length="0" scale="0" ado-type="" />
        <orm:column name="date2" sql-type="timestamp" nullable="false" length="0" scale="0" ado-type="" />
        <orm:column name="date0" sql-type="timestamp" nullable="false" length="0" scale="0" ado-type="" />
        <orm:column name="ct_nxt" sql-type="int2" nullable="false" length="0" scale="0" ado-type="" />
      </orm:table>
      <orm:table name="dmtd">
        <orm:column name="user_id2" sql-type="int8" nullable="false" length="0" scale="0" ado-type="" />
        <orm:column name="user_id0" sql-type="int8" nullable="false" length="0" scale="0" ado-type="" />
        <orm:column name="ten_td2" sql-type="text" nullable="false" length="0" scale="0" ado-type="" />
        <orm:column name="ten_td" sql-type="text" nullable="false" length="0" scale="0" ado-type="" />
        <orm:column name="status" sql-type="text" nullable="false" length="0" scale="0" ado-type="" />
        <orm:column name="ma_td" sql-type="text" nullable="false" length="0" scale="0" primary-key="true" ado-type="" />
        <orm:column name="date2" sql-type="timestamp" nullable="false" length="0" scale="0" ado-type="" />
        <orm:column name="date0" sql-type="timestamp" nullable="false" length="0" scale="0" ado-type="" />
      </orm:table>
    </orm:schema>
    <orm:relational-naming-settings>
      <orm:remove-leading-underscore>False</orm:remove-leading-underscore>
      <orm:source-strategy>Property</orm:source-strategy>
      <orm:remove-camel-case>False</orm:remove-camel-case>
    </orm:relational-naming-settings>
  </orm:orm>
  <ModelSettings xmlns="">
    <SaveConnectionStringInAppConfig>false</SaveConnectionStringInAppConfig>
    <NamingSettings>
      <ClassRules>
        <CaseMode>PascalCase</CaseMode>
        <UnderscoreAsWordDelimiter>true</UnderscoreAsWordDelimiter>
      </ClassRules>
      <FieldRules>
        <AddPrefix>_</AddPrefix>
        <CaseMode>CamelCase</CaseMode>
        <UnderscoreAsWordDelimiter>true</UnderscoreAsWordDelimiter>
      </FieldRules>
      <PropertyRules>
        <CaseMode>PascalCase</CaseMode>
        <UnderscoreAsWordDelimiter>true</UnderscoreAsWordDelimiter>
      </PropertyRules>
      <NavigationPropertyRules>
        <PluralizationModeCollections>Unchanged</PluralizationModeCollections>
        <IsPrefixSuffixEnabled>false</IsPrefixSuffixEnabled>
      </NavigationPropertyRules>
    </NamingSettings>
    <CodeGenerationSettings>
      <ImplementINotifyPropertyChanging>true</ImplementINotifyPropertyChanging>
      <ImplementINotifyPropertyChanged>true</ImplementINotifyPropertyChanged>
      <ImplementIDataErrorInfo>true</ImplementIDataErrorInfo>
      <GenerateDataAnnotationAttributes>true</GenerateDataAnnotationAttributes>
      <CustomTemplateFileName>CodeGenerationTemplates\DefaultTemplateCS.tt</CustomTemplateFileName>
      <UseCustomTemplate>true</UseCustomTemplate>
      <MappingDefinitionType>Attributes</MappingDefinitionType>
    </CodeGenerationSettings>
    <SchemaUpdateSettings>
      <DeploymentProject>MyERPModel</DeploymentProject>
    </SchemaUpdateSettings>
    <BackendConfigurationSettings>
      <BackendConfiguration>
        <Backend>PostgreSql</Backend>
        <ProviderName>Npgsql</ProviderName>
        <Logging>
          <LogToConsole>True</LogToConsole>
          <MetricStoreSnapshotInterval>0</MetricStoreSnapshotInterval>
        </Logging>
      </BackendConfiguration>
    </BackendConfigurationSettings>
  </ModelSettings>
  <Types>
    <DomainClass Id="6eb72546-4b19-4be3-bc2f-147db413bae3" name="Dmtk" namespace="MyERPModel" showPropertiesCompartment="true" concurrencyMode="Changed" showNavigationCompartment="true" showImplementationCompartment="true">
      <Property Id="1bca08b6-06ed-403b-b789-1b0d0792338d" name="Tk" label="Tk : String" kind="Persistent" identity="true" fieldName="_tk" />
      <Property Id="4479f3d5-2c52-420f-b4aa-854f3522673a" name="Bac_Tk" type="Int16" label="Bac_Tk : Int16" kind="Persistent" fieldName="_bac_tk" />
      <Property Id="b195e850-7f51-4985-8d77-0caa89229611" name="Date0" type="DateTime" label="Date0 : DateTime" kind="Persistent" fieldName="_date0" />
      <Property Id="fc891926-702d-4fae-bda7-9a3b3a1930ce" name="Date2" type="DateTime" label="Date2 : DateTime" kind="Persistent" fieldName="_date2" />
      <Property Id="bd4c79f5-ba9f-4971-bd04-5b9f675f41c5" name="Loai_Tk" type="Int16" label="Loai_Tk : Int16" kind="Persistent" fieldName="_loai_tk" />
      <Property Id="29788ee2-2b0d-492f-809e-2ffdd40e1958" name="Ma_Nt" label="Ma_Nt : String" kind="Persistent" fieldName="_ma_nt" />
      <Property Id="975aabdf-092a-4ec1-baa3-72e0bb179933" name="Nh_Tk0" label="Nh_Tk0 : String" kind="Persistent" fieldName="_nh_tk0" />
      <Property Id="ecfda42c-4724-43fb-a854-f0266d07dd78" name="Nh_Tk2" label="Nh_Tk2 : String" kind="Persistent" fieldName="_nh_tk2" />
      <Property Id="566c75e1-121f-4b7f-8faa-7c6c7f5b3626" name="Status" label="Status : String" kind="Persistent" fieldName="_status" />
      <Property Id="b5ea29c0-b4ce-4a1d-bfd5-83abd4c14eea" name="Ten_Tk" label="Ten_Tk : String" kind="Persistent" fieldName="_ten_tk" />
      <Property Id="016bedd5-965e-40d0-8c6b-1cc475603e0b" name="Ten_Tk2" label="Ten_Tk2 : String" kind="Persistent" fieldName="_ten_tk2" />
      <Property Id="e00c6586-0a6a-4383-ac9a-f6edb8f25ffe" name="Tk_Cn" type="Int16" label="Tk_Cn : Int16" kind="Persistent" fieldName="_tk_cn" />
      <Property Id="6917e972-319f-48ff-8113-74f988f8f207" name="Tk_Me" label="Tk_Me : String" kind="Persistent" fieldName="_tk_me" />
      <Property Id="7d7c5901-188c-4d08-85cf-ba14a2dab0c9" name="Tk_Sc" type="Int16" label="Tk_Sc : Int16" kind="Persistent" fieldName="_tk_sc" />
      <Property Id="b2400957-7187-4b47-a8bb-9c3e896f861f" name="User_Id0" type="Int64" label="User_Id0 : Int64" kind="Persistent" fieldName="_user_id0" />
      <Property Id="814a2a82-f889-4130-a895-c13cb4cf2f72" name="User_Id2" type="Int64" label="User_Id2 : Int64" kind="Persistent" fieldName="_user_id2" />
      <AssociationTargets>
        <Association Id="6fad391b-70de-401d-96ff-e53ac29cf9bf" SourceMultiplicity="One" name="DmtkHasUserinfo">
          <DomainClassMoniker name="/MyERPModel/Userinfo" />
          <sourceNavigationalProperty>
            <associationDefinesSourceProperty Id="9f8a0402-57f0-41e6-a4c5-31f7e6d1414f">
              <NavigationalPropertyMoniker name="/MyERPModel/Dmtk/Userinfo0" />
            </associationDefinesSourceProperty>
          </sourceNavigationalProperty>
        </Association>
        <Association Id="c3cdcc6e-97e8-45ee-a368-e904724c9fe5" SourceMultiplicity="One" name="DmtkHasUserinfo1">
          <DomainClassMoniker name="/MyERPModel/Userinfo" />
          <sourceNavigationalProperty>
            <associationDefinesSourceProperty Id="551e043a-91b6-455a-9ee6-fe59d2277d60">
              <NavigationalPropertyMoniker name="/MyERPModel/Dmtk/Userinfo2" />
            </associationDefinesSourceProperty>
          </sourceNavigationalProperty>
        </Association>
        <Association Id="fcbb016d-6494-434d-8c91-4779bd0cc5b7" SourceMultiplicity="ZeroOne" name="DmtkHasDmnt">
          <DomainClassMoniker name="/MyERPModel/Dmnt" />
          <sourceNavigationalProperty>
            <associationDefinesSourceProperty Id="28f27c0f-1f4f-415b-8769-b04550fa5a27">
              <NavigationalPropertyMoniker name="/MyERPModel/Dmtk/Dmnt" />
            </associationDefinesSourceProperty>
          </sourceNavigationalProperty>
        </Association>
      </AssociationTargets>
      <navigationalProperties>
        <classHasNavigationalProperties Id="375665d5-5cad-45a7-97c8-2ab9f95d31d7">
          <NavigationalProperty Id="69fae26b-c824-4ae7-9d5c-0a64d36df88a" name="Userinfo0" type="Userinfo" label="Userinfo0 : Userinfo" nullable="true" kind="Persistent" fieldName="_userinfo0" isDependent="false" isManaged="false" />
        </classHasNavigationalProperties>
        <classHasNavigationalProperties Id="b307836f-bce0-4f67-916e-f98ccd5e8352">
          <NavigationalProperty Id="146c96cd-d45f-4027-8e48-a484b606d9a1" name="Userinfo2" type="Userinfo" label="Userinfo2 : Userinfo" nullable="true" kind="Persistent" fieldName="_userinfo2" isDependent="false" isManaged="false" />
        </classHasNavigationalProperties>
        <classHasNavigationalProperties Id="f41f0edd-4fa6-4bf9-98a2-7999e459e7bc">
          <NavigationalProperty Id="ece23fbc-8340-4545-a74b-b5d25c87c9ac" name="Dmnt" type="Dmnt" label="Dmnt : Dmnt" nullable="true" kind="Persistent" fieldName="_dmnt" isDependent="false" isManaged="false" />
        </classHasNavigationalProperties>
      </navigationalProperties>
    </DomainClass>
    <DomainClass Id="6ac6097f-bd1d-4391-ae80-67131f49d19f" name="Userinfo" namespace="MyERPModel" showPropertiesCompartment="true" concurrencyMode="Changed" showNavigationCompartment="true" showImplementationCompartment="true">
      <Property Id="022c9ba3-96ec-44f2-9646-99dc0465bf3f" name="User_Id" type="Int64" label="User_Id : Int64" kind="Persistent" identity="true" fieldName="_user_id" />
      <Property Id="0df610ae-aa0b-4637-887b-7f5773153de8" name="Comment" label="Comment : String" kind="Persistent" fieldName="_comment" />
      <Property Id="119799e7-413a-4e1b-9624-9839c541ec81" name="Date0" type="DateTime" label="Date0 : DateTime" kind="Persistent" fieldName="_date0" />
      <Property Id="d0c33e18-8018-4470-bdc3-3bcf2d098235" name="Date2" type="DateTime" label="Date2 : DateTime" kind="Persistent" fieldName="_date2" />
      <Property Id="ec9517bb-b132-4153-a42d-f658b15ee411" name="Del_Yn" type="Int16" label="Del_Yn : Int16" kind="Persistent" fieldName="_del_yn" />
      <Property Id="a5458d89-c31c-43a6-92a0-73918937ca74" name="Is_Admin" type="Int16" label="Is_Admin : Int16" kind="Persistent" fieldName="_is_admin" />
      <Property Id="23aee6ac-aa1b-43a4-a54e-2a144eae16fc" name="Pass" label="Pass : String" kind="Persistent" fieldName="_pass" />
      <Property Id="488f1b84-d91e-4095-afd8-c3b0eb409252" name="R_Access" label="R_Access : String" kind="Persistent" fieldName="_r_access" />
      <Property Id="793af9aa-3f83-41c8-89b2-fb63c7a7d13b" name="R_Add" label="R_Add : String" kind="Persistent" fieldName="_r_add" />
      <Property Id="3a33e58a-2af1-489c-941b-bb6042d025e6" name="R_Del" label="R_Del : String" kind="Persistent" fieldName="_r_del" />
      <Property Id="5105fc27-8a90-4f9f-9730-8c5e3474aa3b" name="R_Edit" label="R_Edit : String" kind="Persistent" fieldName="_r_edit" />
      <Property Id="2e2b3fc1-6d0d-4488-bea0-8dd1cb9766a0" name="R_Print" label="R_Print : String" kind="Persistent" fieldName="_r_print" />
      <Property Id="b6548582-2a8a-4074-be7d-2f4af96362be" name="R_Read" label="R_Read : String" kind="Persistent" fieldName="_r_read" />
      <Property Id="31853449-8600-474a-9304-925c581530b9" name="R_Search" label="R_Search : String" kind="Persistent" fieldName="_r_search" />
      <Property Id="beffb284-542e-4a59-8660-19bd353fa7dd" name="Rights" label="Rights : String" kind="Persistent" fieldName="_rights" />
      <Property Id="daf42c0e-9011-4140-8ecc-2bd7cf035cfe" name="Status" label="Status : String" kind="Persistent" fieldName="_status" />
      <Property Id="a814172d-fd22-4d88-9a8e-881ad75f5afe" name="User_Id0" type="Int64" label="User_Id0 : Int64" kind="Persistent" fieldName="_user_id0" />
      <Property Id="ccceba67-fc02-4bca-861c-17e3d901d42e" name="User_Id2" type="Int64" label="User_Id2 : Int64" kind="Persistent" fieldName="_user_id2" />
      <Property Id="6ae63020-9951-458b-8e73-ed65d7804f92" name="User_Name" label="User_Name : String" kind="Persistent" fieldName="_user_name" />
      <Property Id="b42a8a0c-4280-48d8-97be-7be1396df0ea" name="User_Pre" label="User_Pre : String" kind="Persistent" fieldName="_user_pre" />
    </DomainClass>
    <DomainClass Id="9d8598ff-424c-4d4a-bac3-97f1835b25b3" name="Dmnt" namespace="MyERPModel" showPropertiesCompartment="true" concurrencyMode="Changed" showNavigationCompartment="true" showImplementationCompartment="true">
      <Property Id="efd62e43-197b-4369-acac-e213606c2517" name="Ma_Nt" label="Ma_Nt : String" kind="Persistent" identity="true" fieldName="_ma_nt" />
      <Property Id="310d5722-6515-41f0-86c0-db94a491a637" name="Date0" type="DateTime" label="Date0 : DateTime" kind="Persistent" fieldName="_date0" />
      <Property Id="4285a20c-477a-4f21-a8c8-9f76ff97b472" name="Date2" type="DateTime" label="Date2 : DateTime" kind="Persistent" fieldName="_date2" />
      <Property Id="62df353b-ffe6-49b5-ad14-d89d88d2df6d" name="Status" label="Status : String" kind="Persistent" fieldName="_status" />
      <Property Id="5153ee1e-7f0f-46a4-9ef4-0826242f6bf5" name="Ten_Nt" label="Ten_Nt : String" kind="Persistent" fieldName="_ten_nt" />
      <Property Id="131ab654-e17c-4d11-9f80-851ec5b41271" name="Ten_Nt2" label="Ten_Nt2 : String" kind="Persistent" fieldName="_ten_nt2" />
      <Property Id="ecc8cdc8-b792-442b-95e0-421914c140ef" name="User_Id0" type="Int64" label="User_Id0 : Int64" kind="Persistent" fieldName="_user_id0" />
      <Property Id="93b8f6f0-afa8-4b8c-8531-cf053bf20da3" name="User_Id2" type="Int64" label="User_Id2 : Int64" kind="Persistent" fieldName="_user_id2" />
      <AssociationTargets>
        <Association Id="44358b57-de56-4243-9a5e-ab005df600fd" SourceMultiplicity="One" name="DmntHasUserinfo">
          <DomainClassMoniker name="/MyERPModel/Userinfo" />
          <sourceNavigationalProperty>
            <associationDefinesSourceProperty Id="7c0a9d3c-c83a-43ad-83dd-684e9e210cdc">
              <NavigationalPropertyMoniker name="/MyERPModel/Dmnt/Userinfo0" />
            </associationDefinesSourceProperty>
          </sourceNavigationalProperty>
        </Association>
        <Association Id="e299cd57-305f-4f78-a63a-9b44719d1682" SourceMultiplicity="One" name="DmntHasUserinfo1">
          <DomainClassMoniker name="/MyERPModel/Userinfo" />
          <sourceNavigationalProperty>
            <associationDefinesSourceProperty Id="a1dc747d-e404-4091-9f6a-11664f782b38">
              <NavigationalPropertyMoniker name="/MyERPModel/Dmnt/Userinfo2" />
            </associationDefinesSourceProperty>
          </sourceNavigationalProperty>
        </Association>
      </AssociationTargets>
      <navigationalProperties>
        <classHasNavigationalProperties Id="089c3c31-7d61-4bb2-bb5f-c01cbc755161">
          <NavigationalProperty Id="f6a45702-6eb3-4f49-a3e1-e2b527a0a0cc" name="Userinfo0" type="Userinfo" label="Userinfo0 : Userinfo" nullable="true" kind="Persistent" fieldName="_userinfo0" isDependent="false" isManaged="false" />
        </classHasNavigationalProperties>
        <classHasNavigationalProperties Id="2ef9b20a-f721-416c-9613-a13bece85544">
          <NavigationalProperty Id="dda1e6ff-7f62-4b3d-afd5-ab3f746e20dd" name="Userinfo2" type="Userinfo" label="Userinfo2 : Userinfo" nullable="true" kind="Persistent" fieldName="_userinfo2" isDependent="false" isManaged="false" />
        </classHasNavigationalProperties>
      </navigationalProperties>
    </DomainClass>
    <DomainClass Id="e5450aef-1d4d-4529-afab-ed799b140a9b" name="Dmkh" namespace="MyERPModel" showPropertiesCompartment="true" concurrencyMode="Changed" showNavigationCompartment="true" showImplementationCompartment="true">
      <Property Id="0f11fb69-72e9-4b0f-badd-59611caee9fd" name="Ma_Kh" label="Ma_Kh : String" kind="Persistent" identity="true" fieldName="_ma_kh" />
      <Property Id="cb1833d2-e863-49aa-b4fc-3086f79adff3" name="Cc_Yn" type="Int16" label="Cc_Yn : Int16" kind="Persistent" fieldName="_cc_yn" />
      <Property Id="0c5a86db-29b4-43d2-a101-5bca88ea1bc2" name="Date0" type="DateTime" label="Date0 : DateTime" kind="Persistent" fieldName="_date0" />
      <Property Id="fef07b89-7622-4ce6-a151-345e1507818a" name="Date2" type="DateTime" label="Date2 : DateTime" kind="Persistent" fieldName="_date2" />
      <Property Id="6036d69d-8761-439c-add6-5182985f786d" name="Dia_Chi" label="Dia_Chi : String" kind="Persistent" fieldName="_dia_chi" />
      <Property Id="7e1d6de7-d68b-4417-8d87-ec38952ee0b2" name="Dien_Thoai" label="Dien_Thoai : String" kind="Persistent" fieldName="_dien_thoai" />
      <Property Id="e123c7da-fa58-4aab-9136-f1b71109ad43" name="Doi_Tac" label="Doi_Tac : String" kind="Persistent" fieldName="_doi_tac" />
      <Property Id="68d0bd94-d454-4f7d-9328-bbe49ab09764" name="Du_Nt13" type="Decimal" label="Du_Nt13 : Decimal" kind="Persistent" fieldName="_du_nt13" />
      <Property Id="6b59f4b3-e517-406b-b84b-66f497dbf983" name="E_Mail" label="E_Mail : String" kind="Persistent" fieldName="_e_mail" />
      <Property Id="447024bd-3e3f-4caf-b94f-fd41e302006b" name="Fax" label="Fax : String" kind="Persistent" fieldName="_fax" />
      <Property Id="1131484d-5d15-4e6b-92d4-8f45af9fad71" name="Ghi_Chu" label="Ghi_Chu : String" kind="Persistent" fieldName="_ghi_chu" />
      <Property Id="11111f51-46ab-49a8-a88a-075b4bbbf05c" name="Home_Page" label="Home_Page : String" kind="Persistent" fieldName="_home_page" />
      <Property Id="cd412faf-9873-40fb-9877-a6fc1c2db011" name="Kh_Yn" type="Int16" label="Kh_Yn : Int16" kind="Persistent" fieldName="_kh_yn" />
      <Property Id="77b9d0e7-62bc-4d04-9474-37a24657b39f" name="Ma_So_Thue" label="Ma_So_Thue : String" kind="Persistent" fieldName="_ma_so_thue" />
      <Property Id="26b210e4-c0f7-49c7-aa7e-0b211a44cb3d" name="Ma_Tt" label="Ma_Tt : String" kind="Persistent" fieldName="_ma_tt" />
      <Property Id="ff889bd4-eb1a-4217-beda-a1cfbf32f3c3" name="Ngan_Hang" label="Ngan_Hang : String" kind="Persistent" fieldName="_ngan_hang" />
      <Property Id="c573f019-bbd0-44b0-ac0c-371423259210" name="Nh_Kh1" label="Nh_Kh1 : String" kind="Persistent" fieldName="_nh_kh1" />
      <Property Id="d213780a-b613-4029-8b8a-72c1846d2de0" name="Nh_Kh2" label="Nh_Kh2 : String" kind="Persistent" fieldName="_nh_kh2" />
      <Property Id="0a0e6c4f-541b-4e5a-abfc-b3ccc64d6fde" name="Nh_Kh3" label="Nh_Kh3 : String" kind="Persistent" fieldName="_nh_kh3" />
      <Property Id="27f8e1e9-8bde-4c7d-a710-020bbdb365d9" name="Nv_Yn" type="Int16" label="Nv_Yn : Int16" kind="Persistent" fieldName="_nv_yn" />
      <Property Id="a38bc99c-6a02-467e-8fce-e10439a5b2d4" name="Ong_Ba" label="Ong_Ba : String" kind="Persistent" fieldName="_ong_ba" />
      <Property Id="ce3a3d4f-030e-4eb3-b30e-aa2a74601f96" name="T_Tien_Cn" type="Decimal" label="T_Tien_Cn : Decimal" kind="Persistent" fieldName="_t_tien_cn" />
      <Property Id="87e79ed1-2e2f-48b7-afe7-164ffa8bb5a0" name="T_Tien_Hd" type="Decimal" label="T_Tien_Hd : Decimal" kind="Persistent" fieldName="_t_tien_hd" />
      <Property Id="a6760443-b692-4b99-8a78-006830936acb" name="Ten_Bp" label="Ten_Bp : String" kind="Persistent" fieldName="_ten_bp" />
      <Property Id="da861d07-fe52-4189-91b4-f143d124f93e" name="Ten_Kh" label="Ten_Kh : String" kind="Persistent" fieldName="_ten_kh" />
      <Property Id="31015d40-cefd-4723-9790-18ec5914cfc4" name="Ten_Kh2" label="Ten_Kh2 : String" kind="Persistent" fieldName="_ten_kh2" />
      <Property Id="4a359004-7e62-4e84-ac55-1246711f6d28" name="Tk" label="Tk : String" kind="Persistent" fieldName="_tk" />
      <Property Id="a70ee86f-4228-4eff-9fb9-b337e2396824" name="Tk_Nh" label="Tk_Nh : String" kind="Persistent" fieldName="_tk_nh" />
      <Property Id="430d5d25-978d-4b5a-8579-945c4f47d5eb" name="User_Id0" type="Int64" label="User_Id0 : Int64" kind="Persistent" fieldName="_user_id0" />
      <Property Id="38f2bfcc-6b2e-408b-90b2-aeaf66f90c1e" name="User_Id2" type="Int64" label="User_Id2 : Int64" kind="Persistent" fieldName="_user_id2" />
      <AssociationTargets>
        <Association Id="79bd3038-4073-4c52-bf4d-dc84d849109e" SourceMultiplicity="ZeroOne" name="DmkhHasDmtk">
          <DomainClassMoniker name="/MyERPModel/Dmtk" />
          <sourceNavigationalProperty>
            <associationDefinesSourceProperty Id="4604cd0c-d212-4365-8678-9f3e18205537">
              <NavigationalPropertyMoniker name="/MyERPModel/Dmkh/Dmtk" />
            </associationDefinesSourceProperty>
          </sourceNavigationalProperty>
        </Association>
        <Association Id="4814469e-705d-44ca-a892-be2d6b4f0e54" SourceMultiplicity="ZeroOne" name="DmkhHasUserinfo0">
          <DomainClassMoniker name="/MyERPModel/Userinfo" />
          <sourceNavigationalProperty>
            <associationDefinesSourceProperty Id="bc74a5cd-c05a-4b21-bf1a-b76c611f30bd">
              <NavigationalPropertyMoniker name="/MyERPModel/Dmkh/Userinfo0" />
            </associationDefinesSourceProperty>
          </sourceNavigationalProperty>
        </Association>
        <Association Id="ae4042d9-a1c9-4bc7-ade1-181aab777e31" SourceMultiplicity="ZeroOne" name="DmkhHasUserinfo2">
          <DomainClassMoniker name="/MyERPModel/Userinfo" />
          <sourceNavigationalProperty>
            <associationDefinesSourceProperty Id="bd12a96d-2e2a-436a-9d6e-11d7400687ac">
              <NavigationalPropertyMoniker name="/MyERPModel/Dmkh/Userinfo2" />
            </associationDefinesSourceProperty>
          </sourceNavigationalProperty>
        </Association>
        <Association Id="b2126885-36d0-49a2-8539-2121cf44542f" SourceMultiplicity="ZeroOne" name="DmkhHasDmnhkh1">
          <DomainClassMoniker name="/MyERPModel/Dmnhkh" />
          <targetNavigationalProperty>
            <associationDefinesTargetProperty Id="2259bd6d-450b-452a-acde-5e1210166d64">
              <NavigationalPropertyMoniker name="/MyERPModel/Dmnhkh/Dmkh1s" />
            </associationDefinesTargetProperty>
          </targetNavigationalProperty>
          <sourceNavigationalProperty>
            <associationDefinesSourceProperty Id="e686f307-ca50-48c7-9c13-bb60de4c2c01">
              <NavigationalPropertyMoniker name="/MyERPModel/Dmkh/Dmnhkh1" />
            </associationDefinesSourceProperty>
          </sourceNavigationalProperty>
        </Association>
        <Association Id="6176261b-02b5-4de6-9957-dcda7975d456" SourceMultiplicity="ZeroOne" name="DmkhHasDmnhkh2">
          <DomainClassMoniker name="/MyERPModel/Dmnhkh" />
          <targetNavigationalProperty>
            <associationDefinesTargetProperty Id="8eec029b-8f2d-4dbf-a0dc-b0b47649c230">
              <NavigationalPropertyMoniker name="/MyERPModel/Dmnhkh/Dmkh2s" />
            </associationDefinesTargetProperty>
          </targetNavigationalProperty>
          <sourceNavigationalProperty>
            <associationDefinesSourceProperty Id="c9850fe3-9a2c-4d4a-a77d-3db0599a4d15">
              <NavigationalPropertyMoniker name="/MyERPModel/Dmkh/Dmnhkh2" />
            </associationDefinesSourceProperty>
          </sourceNavigationalProperty>
        </Association>
        <Association Id="7d1337b8-4f28-4167-ad98-da3144edd038" SourceMultiplicity="ZeroOne" name="DmkhHasDmnhkh3">
          <DomainClassMoniker name="/MyERPModel/Dmnhkh" />
          <targetNavigationalProperty>
            <associationDefinesTargetProperty Id="5f8d8b0d-d0a9-4de3-bfbe-927e314362e6">
              <NavigationalPropertyMoniker name="/MyERPModel/Dmnhkh/Dmkh3s" />
            </associationDefinesTargetProperty>
          </targetNavigationalProperty>
          <sourceNavigationalProperty>
            <associationDefinesSourceProperty Id="3acb026b-c529-480d-a756-99fa2255a7e7">
              <NavigationalPropertyMoniker name="/MyERPModel/Dmkh/Dmnhkh3" />
            </associationDefinesSourceProperty>
          </sourceNavigationalProperty>
        </Association>
        <Association Id="bab23a19-ce7b-4953-88cf-999afbc304e2" SourceMultiplicity="ZeroOne" name="DmkhHasDmtt">
          <DomainClassMoniker name="/MyERPModel/Dmtt" />
          <sourceNavigationalProperty>
            <associationDefinesSourceProperty Id="ac6100cb-ab00-4ee0-8a85-082e55ffa4de">
              <NavigationalPropertyMoniker name="/MyERPModel/Dmkh/Dmtt" />
            </associationDefinesSourceProperty>
          </sourceNavigationalProperty>
        </Association>
      </AssociationTargets>
      <navigationalProperties>
        <classHasNavigationalProperties Id="238151ad-a67f-404e-b88c-0b7db4b4645e">
          <NavigationalProperty Id="453216c0-c4f7-4570-bfb0-236b03957604" name="Dmtk" type="Dmtk" label="Dmtk : Dmtk" nullable="true" kind="Persistent" fieldName="_dmtk" isDependent="false" isManaged="false" />
        </classHasNavigationalProperties>
        <classHasNavigationalProperties Id="f82cfaea-629e-44fa-b29c-e76d52979657">
          <NavigationalProperty Id="b51bbab1-9e7e-4a0b-a851-54398a619bec" name="Userinfo0" type="Userinfo" label="Userinfo0 : Userinfo" nullable="true" kind="Persistent" fieldName="_userinfo0" isDependent="false" isManaged="false" />
        </classHasNavigationalProperties>
        <classHasNavigationalProperties Id="81c3f249-3724-49e3-90d5-16850e9e6e76">
          <NavigationalProperty Id="46ef6cad-0a0f-4f30-95bb-21e6431fa3bb" name="Userinfo2" type="Userinfo" label="Userinfo2 : Userinfo" nullable="true" kind="Persistent" fieldName="_userinfo2" isDependent="false" isManaged="false" />
        </classHasNavigationalProperties>
        <classHasNavigationalProperties Id="3027bf47-e94d-4c17-8797-0796de662536">
          <NavigationalProperty Id="cea30193-3631-4412-9776-d37e5eef7be0" name="Dmnhkh1" type="Dmnhkh" label="Dmnhkh1 : Dmnhkh" nullable="true" kind="Persistent" fieldName="_dmnhkh" isDependent="false" isManaged="false" />
        </classHasNavigationalProperties>
        <classHasNavigationalProperties Id="84c0c864-7e6e-4502-93d5-50d397832c6a">
          <NavigationalProperty Id="61e5597f-cdd3-40e4-8bfe-a3c463c39601" name="Dmnhkh2" type="Dmnhkh" label="Dmnhkh2 : Dmnhkh" nullable="true" kind="Persistent" fieldName="_dmnhkh1" isDependent="false" isManaged="false" />
        </classHasNavigationalProperties>
        <classHasNavigationalProperties Id="335217fb-38fc-498d-b9c2-7db9f57a0dcf">
          <NavigationalProperty Id="42cd3516-8c42-4df7-87f2-16b471280e5d" name="Dmnhkh3" type="Dmnhkh" label="Dmnhkh3 : Dmnhkh" nullable="true" kind="Persistent" fieldName="_dmnhkh2" isDependent="false" isManaged="false" />
        </classHasNavigationalProperties>
        <classHasNavigationalProperties Id="6d3e88b5-3049-4827-82f7-252a49bb5503">
          <NavigationalProperty Id="f72b6dff-fd80-4e47-9f70-200af9bd898c" name="Dmtt" type="Dmtt" label="Dmtt : Dmtt" nullable="true" kind="Persistent" fieldName="_dmtt" isDependent="false" isManaged="false" />
        </classHasNavigationalProperties>
      </navigationalProperties>
    </DomainClass>
    <DomainClass Id="f2451eb6-4641-45a3-bcdf-230e9f344ef2" name="Dmnhkh" namespace="MyERPModel" showPropertiesCompartment="true" concurrencyMode="Changed" showNavigationCompartment="true" showImplementationCompartment="true">
      <Property Id="42010cbf-48ba-4309-844f-155498b0ddd6" name="Ma_Nh" label="Ma_Nh : String" kind="Persistent" identity="true" fieldName="_ma_nh" />
      <Property Id="00edf15b-3172-46b2-acc5-41e736324121" name="Date0" type="DateTime" label="Date0 : DateTime" kind="Persistent" fieldName="_date0" />
      <Property Id="3780b134-9e0b-43e1-b6ef-5cc77e2cd1dd" name="Date2" type="DateTime" label="Date2 : DateTime" kind="Persistent" fieldName="_date2" />
      <Property Id="630699bf-4f30-4efb-8a46-617c5caef057" name="Loai_Nh" type="Int16" label="Loai_Nh : Int16" kind="Persistent" fieldName="_loai_nh" />
      <Property Id="a44d60c2-7102-4045-8c8d-839b0ed412b6" name="Status" label="Status : String" kind="Persistent" fieldName="_status" />
      <Property Id="95fe9fbd-2959-4d84-bdec-d4e6c1d3406f" name="Ten_Nh" label="Ten_Nh : String" kind="Persistent" fieldName="_ten_nh" />
      <Property Id="1e898604-198e-4a90-8890-c95c0ff50fec" name="Ten_Nh2" label="Ten_Nh2 : String" kind="Persistent" fieldName="_ten_nh2" />
      <Property Id="9a4dc6c4-e7da-4652-9ae8-23233d5313f5" name="User_Id0" type="Int64" label="User_Id0 : Int64" kind="Persistent" fieldName="_user_id0" />
      <Property Id="bba63813-0787-46ca-b2aa-834bb3aadf9a" name="User_Id2" type="Int64" label="User_Id2 : Int64" kind="Persistent" fieldName="_user_id2" />
      <navigationalProperties>
        <classHasNavigationalProperties Id="0aa94e07-d85e-4f23-9fa2-1eedc34f380d">
          <NavigationalProperty Id="d371ffbe-26bc-48dc-a839-29029ee8deec" name="Dmkh2s" type="IList&lt;Dmkh&gt;" label="Dmkh2s : IList&lt;Dmkh&gt;" nullable="true" kind="Persistent" fieldName="_dmkhs" isDependent="false" isManaged="false" />
        </classHasNavigationalProperties>
        <classHasNavigationalProperties Id="e3cbd93d-4c85-46a4-aeed-93892cb0fb8b">
          <NavigationalProperty Id="2b67b638-39d0-439c-be67-5ad46760e7d1" name="Dmkh1s" type="IList&lt;Dmkh&gt;" label="Dmkh1s : IList&lt;Dmkh&gt;" nullable="true" kind="Persistent" fieldName="_dmkhs1" isDependent="false" isManaged="false" />
        </classHasNavigationalProperties>
        <classHasNavigationalProperties Id="0f5aea99-8826-4c5d-9a3d-55ea045c693c">
          <NavigationalProperty Id="021a8314-58fe-473f-becd-12f230f69c85" name="Dmkh3s" type="IList&lt;Dmkh&gt;" label="Dmkh3s : IList&lt;Dmkh&gt;" nullable="true" kind="Persistent" fieldName="_dmkhs2" isDependent="false" isManaged="false" />
        </classHasNavigationalProperties>
      </navigationalProperties>
    </DomainClass>
    <DomainClass Id="b0ff094e-1f92-4ae4-86c5-45512a524e98" name="Dmtt" namespace="MyERPModel" showPropertiesCompartment="true" concurrencyMode="Changed" showNavigationCompartment="true" showImplementationCompartment="true">
      <Property Id="0e0ff67f-9bed-4525-917e-22c5e8ce05a6" name="Ma_Tt" label="Ma_Tt : String" kind="Persistent" identity="true" fieldName="_ma_tt" />
      <Property Id="9175b1db-6b73-48bd-ace4-12381407a5a3" name="Date0" type="DateTime" label="Date0 : DateTime" kind="Persistent" fieldName="_date0" />
      <Property Id="23db19d5-5e55-43de-8f05-21c6b606fcbc" name="Date2" type="DateTime" label="Date2 : DateTime" kind="Persistent" fieldName="_date2" />
      <Property Id="0680a919-4bfc-405b-894b-d3499b44379e" name="Han_Tt" type="Int16" label="Han_Tt : Int16" kind="Persistent" fieldName="_han_tt" />
      <Property Id="594ee366-a7df-499b-ba68-35028e8cd806" name="Han_Tt_Gg" type="Int16" label="Han_Tt_Gg : Int16" kind="Persistent" fieldName="_han_tt_gg" />
      <Property Id="38db80c8-a6b0-4179-a2e7-94bc55e7fbd2" name="Pt_Gg" type="Decimal" label="Pt_Gg : Decimal" kind="Persistent" fieldName="_pt_gg" />
      <Property Id="ae70066e-d99c-4df0-9972-ccdee0f0fde9" name="Status" label="Status : String" kind="Persistent" fieldName="_status" />
      <Property Id="65829b43-f1af-483c-a7f8-3b535c695e74" name="Ten_Tt" label="Ten_Tt : String" kind="Persistent" fieldName="_ten_tt" />
      <Property Id="974234b0-7c29-43c7-881c-15499283f958" name="Ten_Tt2" label="Ten_Tt2 : String" kind="Persistent" fieldName="_ten_tt2" />
      <Property Id="31b31c92-f0af-48a1-a066-bd0a1ea2bafd" name="User_Id0" type="Int64" label="User_Id0 : Int64" kind="Persistent" fieldName="_user_id0" />
      <Property Id="67c598f4-89c8-44b2-a85e-31a41ad0db03" name="User_Id2" type="Int64" label="User_Id2 : Int64" kind="Persistent" fieldName="_user_id2" />
    </DomainClass>
    <DomainClass Id="295c1357-df0e-4eef-b13d-68e20e43c403" name="Dmvv" namespace="MyERPModel" showPropertiesCompartment="true" concurrencyMode="Changed" showNavigationCompartment="true" showImplementationCompartment="true">
      <Property Id="f5ec11cf-95ce-4da4-a64b-85ded41e39ea" name="Ma_Vv" label="Ma_Vv : String" kind="Persistent" identity="true" fieldName="_ma_vv" />
      <Property Id="4fd8ddbd-506d-4153-993e-ae4e886557a6" name="Date0" type="DateTime" label="Date0 : DateTime" kind="Persistent" fieldName="_date0" />
      <Property Id="a9192fa7-1770-4d1a-beb6-2636d02a3381" name="Date2" type="DateTime" label="Date2 : DateTime" kind="Persistent" fieldName="_date2" />
      <Property Id="ed9bf5aa-8b4f-46dc-b94f-476b44afa95b" name="Ghi_Chu" label="Ghi_Chu : String" kind="Persistent" fieldName="_ghi_chu" />
      <Property Id="d5f85a8d-43ba-42c6-a932-271e0a952c91" name="Ma_Kh" label="Ma_Kh : String" kind="Persistent" fieldName="_ma_kh" />
      <Property Id="bc0e7671-92ff-4805-8c4b-87134830a877" name="Ma_Nt" label="Ma_Nt : String" kind="Persistent" fieldName="_ma_nt" />
      <Property Id="8008ba90-9603-4e69-979c-81bb8c3be707" name="Ngay_Vv1" type="DateTime" label="Ngay_Vv1 : DateTime" kind="Persistent" fieldName="_ngay_vv1" />
      <Property Id="e25ec3b9-de9f-479b-8316-901db8c24cf1" name="Ngay_Vv2" type="DateTime" label="Ngay_Vv2 : DateTime" kind="Persistent" fieldName="_ngay_vv2" />
      <Property Id="3614177a-a906-4835-a652-0b23c7d39576" name="Nh_Vv1" label="Nh_Vv1 : String" kind="Persistent" fieldName="_nh_vv1" />
      <Property Id="b137becf-e416-4b4a-a178-ecba99feba3e" name="Nh_Vv2" label="Nh_Vv2 : String" kind="Persistent" fieldName="_nh_vv2" />
      <Property Id="919c27e1-78b7-4a84-899c-b51862a39189" name="Nh_Vv3" label="Nh_Vv3 : String" kind="Persistent" fieldName="_nh_vv3" />
      <Property Id="dcb96b01-9c50-44cc-b258-45b1397c2e3c" name="Status" label="Status : String" kind="Persistent" fieldName="_status" />
      <Property Id="a3b7a577-c36b-433b-a8f1-80ef160b0f00" name="Ten_Vv" label="Ten_Vv : String" kind="Persistent" fieldName="_ten_vv" />
      <Property Id="ea68ac13-3d62-4a09-9145-2615b0586d7c" name="Ten_Vv2" label="Ten_Vv2 : String" kind="Persistent" fieldName="_ten_vv2" />
      <Property Id="230b8eb7-20ec-457a-9776-f4ac9ef7b8d1" name="Tien" type="Decimal" label="Tien : Decimal" kind="Persistent" fieldName="_tien" />
      <Property Id="293b25e8-35f2-4100-afde-a7de663e51c4" name="Tien_Nt" type="Decimal" label="Tien_Nt : Decimal" kind="Persistent" fieldName="_tien_nt" />
      <Property Id="54fc89be-738e-4ef4-a873-66f0b3a4d229" name="Tk" label="Tk : String" kind="Persistent" fieldName="_tk" />
      <Property Id="8153d3a8-1acf-4144-b6c3-2eba140d8e82" name="User_Id0" type="Int64" label="User_Id0 : Int64" kind="Persistent" fieldName="_user_id0" />
      <Property Id="b3e95d81-7025-41ff-9dad-fd5d66e336cb" name="User_Id2" type="Int64" label="User_Id2 : Int64" kind="Persistent" fieldName="_user_id2" />
      <AssociationTargets>
        <Association Id="6f7ad5d3-9b0b-4f88-b70f-349ec13259c5" SourceMultiplicity="ZeroOne" name="DmvvHasDmtk">
          <DomainClassMoniker name="/MyERPModel/Dmtk" />
          <sourceNavigationalProperty>
            <associationDefinesSourceProperty Id="bf13b5aa-7df9-4244-a9f2-a74535e62f19">
              <NavigationalPropertyMoniker name="/MyERPModel/Dmvv/Dmtk" />
            </associationDefinesSourceProperty>
          </sourceNavigationalProperty>
        </Association>
        <Association Id="edcaaadd-f6e4-49b5-8a14-dc1bba9c585f" SourceMultiplicity="ZeroOne" name="DmvvHasUserinfo0">
          <DomainClassMoniker name="/MyERPModel/Userinfo" />
          <sourceNavigationalProperty>
            <associationDefinesSourceProperty Id="1c3173e7-7297-4fd3-ad92-e77a20d78aaa">
              <NavigationalPropertyMoniker name="/MyERPModel/Dmvv/Userinfo0" />
            </associationDefinesSourceProperty>
          </sourceNavigationalProperty>
        </Association>
        <Association Id="f85a3b7a-dbd6-454e-9061-abd94d221a9b" SourceMultiplicity="ZeroOne" name="DmvvHasUserinfo2">
          <DomainClassMoniker name="/MyERPModel/Userinfo" />
          <sourceNavigationalProperty>
            <associationDefinesSourceProperty Id="83f036f2-6871-422f-a87e-e60cde74685b">
              <NavigationalPropertyMoniker name="/MyERPModel/Dmvv/Userinfo2" />
            </associationDefinesSourceProperty>
          </sourceNavigationalProperty>
        </Association>
        <Association Id="a526526d-ac1e-47f0-ae03-ff7841e87699" SourceMultiplicity="ZeroOne" name="DmvvHasDmkh">
          <DomainClassMoniker name="/MyERPModel/Dmkh" />
          <sourceNavigationalProperty>
            <associationDefinesSourceProperty Id="e740404b-bc92-497a-ac93-f4d63762a956">
              <NavigationalPropertyMoniker name="/MyERPModel/Dmvv/Dmkh" />
            </associationDefinesSourceProperty>
          </sourceNavigationalProperty>
        </Association>
        <Association Id="7b8610d2-8f19-4712-b021-7b5e24db29e4" SourceMultiplicity="ZeroOne" name="DmvvHasDmnhvv1">
          <DomainClassMoniker name="/MyERPModel/Dmnhvv" />
          <targetNavigationalProperty>
            <associationDefinesTargetProperty Id="726dca4d-3983-45af-8a59-0add60352b32">
              <NavigationalPropertyMoniker name="/MyERPModel/Dmnhvv/Dmvv1s" />
            </associationDefinesTargetProperty>
          </targetNavigationalProperty>
          <sourceNavigationalProperty>
            <associationDefinesSourceProperty Id="97cea3da-66d2-4f54-9ab2-f1b38fc65262">
              <NavigationalPropertyMoniker name="/MyERPModel/Dmvv/Dmnhvv1" />
            </associationDefinesSourceProperty>
          </sourceNavigationalProperty>
        </Association>
        <Association Id="ca8b2278-6ddb-47ed-b36d-602244181c19" SourceMultiplicity="ZeroOne" name="DmvvHasDmnhvv2">
          <DomainClassMoniker name="/MyERPModel/Dmnhvv" />
          <targetNavigationalProperty>
            <associationDefinesTargetProperty Id="814354e0-6962-472e-9514-2aa5b3f02e42">
              <NavigationalPropertyMoniker name="/MyERPModel/Dmnhvv/Dmvv2s" />
            </associationDefinesTargetProperty>
          </targetNavigationalProperty>
          <sourceNavigationalProperty>
            <associationDefinesSourceProperty Id="535a1ed9-0622-474d-806b-bc58d9ec949f">
              <NavigationalPropertyMoniker name="/MyERPModel/Dmvv/Dmnhvv2" />
            </associationDefinesSourceProperty>
          </sourceNavigationalProperty>
        </Association>
        <Association Id="9c7c4f44-3eba-4e22-b0c3-882f92b9af05" SourceMultiplicity="ZeroOne" name="DmvvHasDmnhvv3">
          <DomainClassMoniker name="/MyERPModel/Dmnhvv" />
          <targetNavigationalProperty>
            <associationDefinesTargetProperty Id="6d9c9e58-2cd3-4377-a45d-c3a2e83efc4e">
              <NavigationalPropertyMoniker name="/MyERPModel/Dmnhvv/Dmvv3s" />
            </associationDefinesTargetProperty>
          </targetNavigationalProperty>
          <sourceNavigationalProperty>
            <associationDefinesSourceProperty Id="b06500cd-4af5-48c1-892f-cf460bcd9ff9">
              <NavigationalPropertyMoniker name="/MyERPModel/Dmvv/Dmnhvv3" />
            </associationDefinesSourceProperty>
          </sourceNavigationalProperty>
        </Association>
      </AssociationTargets>
      <navigationalProperties>
        <classHasNavigationalProperties Id="b9567c88-8e47-4605-b915-eec9fb46651e">
          <NavigationalProperty Id="25447f82-93f6-4607-bf61-5d26c3c73bf9" name="Dmtk" type="Dmtk" label="Dmtk : Dmtk" nullable="true" kind="Persistent" fieldName="_dmtk" isDependent="false" isManaged="false" />
        </classHasNavigationalProperties>
        <classHasNavigationalProperties Id="be51588a-b42a-4c60-86b2-da2567f5f21e">
          <NavigationalProperty Id="b34456a4-426f-4645-ac3a-af953ee752e7" name="Userinfo0" type="Userinfo" label="Userinfo0 : Userinfo" nullable="true" kind="Persistent" fieldName="_userinfo" isDependent="false" isManaged="false" />
        </classHasNavigationalProperties>
        <classHasNavigationalProperties Id="9334176b-6af6-440b-8797-f34bbab4bbb1">
          <NavigationalProperty Id="e0b3e145-8ae0-4761-b05b-0c289d595fdc" name="Userinfo2" type="Userinfo" label="Userinfo2 : Userinfo" nullable="true" kind="Persistent" fieldName="_userinfo1" isDependent="false" isManaged="false" />
        </classHasNavigationalProperties>
        <classHasNavigationalProperties Id="b6d161e0-2a5e-48f0-8a2e-26d47b8e7f7f">
          <NavigationalProperty Id="55ebbb5b-7452-4be0-9a0e-83f5f254d1be" name="Dmkh" type="Dmkh" label="Dmkh : Dmkh" nullable="true" kind="Persistent" fieldName="_dmkh" isDependent="false" isManaged="false" />
        </classHasNavigationalProperties>
        <classHasNavigationalProperties Id="d44b60f3-2bcc-492e-a956-ebb45cd354cf">
          <NavigationalProperty Id="01dcf7c2-6e8b-4391-bcdc-abbcf7367880" name="Dmnhvv1" type="Dmnhvv" label="Dmnhvv1 : Dmnhvv" nullable="true" kind="Persistent" fieldName="_dmnhvv" isDependent="false" isManaged="false" />
        </classHasNavigationalProperties>
        <classHasNavigationalProperties Id="fe8851ed-a354-4ceb-ac0e-c6c49972e14f">
          <NavigationalProperty Id="9a7a53c6-642a-4297-a94e-dace6bec87a9" name="Dmnhvv2" type="Dmnhvv" label="Dmnhvv2 : Dmnhvv" nullable="true" kind="Persistent" fieldName="_dmnhvv1" isDependent="false" isManaged="false" />
        </classHasNavigationalProperties>
        <classHasNavigationalProperties Id="dbaa462e-884b-41e5-b87b-f885b3783712">
          <NavigationalProperty Id="f7bd3ee8-da0f-404d-9653-0486a54f360e" name="Dmnhvv3" type="Dmnhvv" label="Dmnhvv3 : Dmnhvv" nullable="true" kind="Persistent" fieldName="_dmnhvv2" isDependent="false" isManaged="false" />
        </classHasNavigationalProperties>
      </navigationalProperties>
    </DomainClass>
    <DomainClass Id="c1a07b37-fa4e-428b-9e73-2fc9b5b4056a" name="Dmnhvv" namespace="MyERPModel" showPropertiesCompartment="true" concurrencyMode="Changed" showNavigationCompartment="true" showImplementationCompartment="true">
      <Property Id="4e3355de-c10d-4597-a3a0-ee12423f186a" name="Ma_Nh" label="Ma_Nh : String" kind="Persistent" identity="true" fieldName="_ma_nh" />
      <Property Id="a2f5eb4d-c532-4e91-9795-ca7253370c53" name="Date0" type="DateTime" label="Date0 : DateTime" kind="Persistent" fieldName="_date0" />
      <Property Id="018f67f1-c083-48c8-b2a7-7d9d30098643" name="Date2" type="DateTime" label="Date2 : DateTime" kind="Persistent" fieldName="_date2" />
      <Property Id="556773db-3da4-45bd-85f4-d7bc0c9b1e1f" name="Loai_Nh" type="Int16" label="Loai_Nh : Int16" kind="Persistent" fieldName="_loai_nh" />
      <Property Id="da21f8a7-4981-4494-98be-63cba3ed1ffd" name="Status" label="Status : String" kind="Persistent" fieldName="_status" />
      <Property Id="f8fc0a8c-a47b-4918-969e-93859b9a31e5" name="Ten_Nh" label="Ten_Nh : String" kind="Persistent" fieldName="_ten_nh" />
      <Property Id="13b75a7a-3919-4407-b85d-827b9d67405e" name="Ten_Nh2" label="Ten_Nh2 : String" kind="Persistent" fieldName="_ten_nh2" />
      <Property Id="919915f0-a7d0-47c1-bb6c-7f88674599eb" name="User_Id0" type="Int64" label="User_Id0 : Int64" kind="Persistent" fieldName="_user_id0" />
      <Property Id="3067e54b-f476-4b38-9a06-2ef534696a8e" name="User_Id2" type="Int64" label="User_Id2 : Int64" kind="Persistent" fieldName="_user_id2" />
      <AssociationTargets>
        <Association Id="b30b38b4-6ec3-454f-92bd-45c508927068" SourceMultiplicity="ZeroOne" name="DmnhvvHasUserinfo0">
          <DomainClassMoniker name="/MyERPModel/Userinfo" />
          <sourceNavigationalProperty>
            <associationDefinesSourceProperty Id="b9e555ec-8df1-4a07-92c1-97aab48d7063">
              <NavigationalPropertyMoniker name="/MyERPModel/Dmnhvv/Userinfo0" />
            </associationDefinesSourceProperty>
          </sourceNavigationalProperty>
        </Association>
        <Association Id="43788f0a-acb5-4501-af4b-874a63fe05df" SourceMultiplicity="ZeroOne" name="DmnhvvHasUserinfo2">
          <DomainClassMoniker name="/MyERPModel/Userinfo" />
          <sourceNavigationalProperty>
            <associationDefinesSourceProperty Id="4aa8f076-784b-4dcb-8f45-96fd79c6fdce">
              <NavigationalPropertyMoniker name="/MyERPModel/Dmnhvv/Userinfo2" />
            </associationDefinesSourceProperty>
          </sourceNavigationalProperty>
        </Association>
      </AssociationTargets>
      <navigationalProperties>
        <classHasNavigationalProperties Id="52f7b71d-4ca2-46fa-8a2c-d8c742f957c0">
          <NavigationalProperty Id="6e942301-9b08-445e-b8e2-aacc59d3e317" name="Userinfo0" type="Userinfo" label="Userinfo0 : Userinfo" nullable="true" kind="Persistent" fieldName="_userinfo" isDependent="false" isManaged="false" />
        </classHasNavigationalProperties>
        <classHasNavigationalProperties Id="42c07364-9354-453e-bdaf-7390cdd5e282">
          <NavigationalProperty Id="247a6428-0084-484c-8f1d-dbc99861cac1" name="Userinfo2" type="Userinfo" label="Userinfo2 : Userinfo" nullable="true" kind="Persistent" fieldName="_userinfo1" isDependent="false" isManaged="false" />
        </classHasNavigationalProperties>
        <classHasNavigationalProperties Id="a4cad273-2956-40d8-8228-fbb96606878a">
          <NavigationalProperty Id="5ded7457-b33a-46e0-b008-e38d96f1ca9d" name="Dmvv1s" type="IList&lt;Dmvv&gt;" label="Dmvv1s : IList&lt;Dmvv&gt;" nullable="true" kind="Persistent" fieldName="_dmvvs" isDependent="false" isManaged="false" />
        </classHasNavigationalProperties>
        <classHasNavigationalProperties Id="010b7c18-636b-43b0-b860-e577470d4322">
          <NavigationalProperty Id="14496fb5-d08a-4cc0-9f87-09950d03c57e" name="Dmvv2s" type="IList&lt;Dmvv&gt;" label="Dmvv2s : IList&lt;Dmvv&gt;" nullable="true" kind="Persistent" fieldName="_dmvvs1" isDependent="false" isManaged="false" />
        </classHasNavigationalProperties>
        <classHasNavigationalProperties Id="f404042e-19c5-49b8-8be3-8edcd63b309c">
          <NavigationalProperty Id="c4f2f62d-93b2-453b-bb6b-c60c93f22c74" name="Dmvv3s" type="IList&lt;Dmvv&gt;" label="Dmvv3s : IList&lt;Dmvv&gt;" nullable="true" kind="Persistent" fieldName="_dmvvs2" isDependent="false" isManaged="false" />
        </classHasNavigationalProperties>
      </navigationalProperties>
    </DomainClass>
    <DomainClass Id="4e5c85f4-102a-4953-b79a-16aace7a5d6d" name="Ph11" namespace="MyERPModel" showPropertiesCompartment="true" concurrencyMode="Changed" showNavigationCompartment="true" showImplementationCompartment="true">
      <Property Id="376a7929-e44d-405f-ad35-08fb5e223650" name="Stt_Rec" label="Stt_Rec : String" kind="Persistent" identity="true" fieldName="_Stt_Rec" />
      <Property Id="df0f946d-fc6d-48c0-b261-e310317555ab" name="Date0" type="DateTime" label="Date0 : DateTime" kind="Persistent" fieldName="_Date0" />
      <Property Id="333e1865-9ed7-48c2-aafe-dc3acc6b38f0" name="Date2" type="DateTime" label="Date2 : DateTime" kind="Persistent" fieldName="_Date2" />
      <Property Id="b583a43f-9d2a-4212-ac1f-d1b214be78b2" name="Ma_Ct" label="Ma_Ct : String" kind="Persistent" fieldName="_Ma_Ct" />
      <Property Id="22911a3f-3f64-420e-a3fa-47cfc308425a" name="Ma_Dvcs" label="Ma_Dvcs : String" kind="Persistent" fieldName="_Ma_Dvcs" />
      <Property Id="ee648f37-c994-4c4d-8025-7b0c243de72d" name="Ma_Gd" type="Int16" label="Ma_Gd : Int16" kind="Persistent" fieldName="_Ma_Gd" />
      <Property Id="6230b7f9-a896-4e64-b72f-692819793b06" name="Ma_Nk" label="Ma_Nk : String" kind="Persistent" fieldName="_Ma_Nk" />
      <Property Id="9a4e721e-a388-4085-94ee-5883e850b67c" name="Ma_Nt" label="Ma_Nt : String" kind="Persistent" fieldName="_Ma_Nt" />
      <Property Id="95825f35-313c-40d6-b1f5-6e64983431e3" name="Ngay_Ct" type="DateTime" label="Ngay_Ct : DateTime" kind="Persistent" fieldName="_Ngay_Ct" />
      <Property Id="a6081d52-75da-4fad-8ca2-df2b76185ded" name="Ngay_Lct" type="DateTime" label="Ngay_Lct : DateTime" kind="Persistent" fieldName="_Ngay_Lct" />
      <Property Id="7f296048-650c-47e4-9939-ca3c5062e0c1" name="Ngay_Lo" type="DateTime" label="Ngay_Lo : DateTime" kind="Persistent" fieldName="_Ngay_Lo" />
      <Property Id="e2df88d1-5417-4540-9b05-e66494a4f1e9" name="So_Ct" label="So_Ct : String" kind="Persistent" fieldName="_So_Ct" />
      <Property Id="9bf57b52-ebb5-4a1a-9f34-be33e4add8a0" name="So_Lo" label="So_Lo : String" kind="Persistent" fieldName="_So_Lo" />
      <Property Id="64c6e613-9699-4d4c-b61f-2f3e3abfd822" name="Status" label="Status : String" kind="Persistent" fieldName="_Status" />
      <Property Id="f18156a3-55be-4afe-b8b9-ca8b17c0df21" name="T_Ps_Co_Nt" type="Decimal" label="T_Ps_Co_Nt : Decimal" kind="Persistent" fieldName="_T_Ps_Co_Nt" />
      <Property Id="312ab0b0-d4ae-4a49-961d-fe67b836c2d4" name="T_Ps_No" type="Decimal" label="T_Ps_No : Decimal" kind="Persistent" fieldName="_T_Ps_No" />
      <Property Id="04d117bd-db83-451c-98a8-c77451150244" name="T_Ps_No_Nt" type="Decimal" label="T_Ps_No_Nt : Decimal" kind="Persistent" fieldName="_T_Ps_No_Nt" />
      <Property Id="a293d787-6949-4d78-8140-c302ab485188" name="Ty_Gia" type="Decimal" label="Ty_Gia : Decimal" kind="Persistent" fieldName="_Ty_Gia" />
      <Property Id="47c77089-5d56-42a2-b576-509b93884940" name="User_Id0" type="Int64" label="User_Id0 : Int64" kind="Persistent" fieldName="_User_Id0" />
      <Property Id="5887119d-78b4-4e4c-a9af-d953970bb1e5" name="User_Id2" type="Int64" label="User_Id2 : Int64" kind="Persistent" fieldName="_User_Id2" />
      <AssociationTargets>
        <Association Id="0cb22bb7-2d7d-4db3-80ce-b9fcfdf36e34" SourceMultiplicity="ZeroOne" name="Ph11HasDmnt">
          <DomainClassMoniker name="/MyERPModel/Dmnt" />
          <sourceNavigationalProperty>
            <associationDefinesSourceProperty Id="43b852b0-fa59-41b2-a0c5-0582dac08f09">
              <NavigationalPropertyMoniker name="/MyERPModel/Ph11/Dmnt" />
            </associationDefinesSourceProperty>
          </sourceNavigationalProperty>
        </Association>
        <Association Id="b2bed1d6-aa0b-4e12-b54a-8c77b7ca5faf" SourceMultiplicity="ZeroOne" name="Ph11HasDmdvcs">
          <DomainClassMoniker name="/MyERPModel/Dmdvcs" />
          <sourceNavigationalProperty>
            <associationDefinesSourceProperty Id="76e33f11-96ff-47db-9243-7ff25817fdec">
              <NavigationalPropertyMoniker name="/MyERPModel/Ph11/Dmdvcs" />
            </associationDefinesSourceProperty>
          </sourceNavigationalProperty>
        </Association>
        <Association Id="040d4b9b-a76f-4286-9053-f12ab5b5a49a" SourceMultiplicity="ZeroOne" name="Ph11HasUserinfo0">
          <DomainClassMoniker name="/MyERPModel/Userinfo" />
          <sourceNavigationalProperty>
            <associationDefinesSourceProperty Id="993cc262-449d-4302-95be-3de9f487a338">
              <NavigationalPropertyMoniker name="/MyERPModel/Ph11/Userinfo0" />
            </associationDefinesSourceProperty>
          </sourceNavigationalProperty>
        </Association>
        <Association Id="8561c739-3079-44e6-8083-14e5134e45d1" SourceMultiplicity="ZeroOne" name="Ph11HasUserinfo2">
          <DomainClassMoniker name="/MyERPModel/Userinfo" />
          <sourceNavigationalProperty>
            <associationDefinesSourceProperty Id="1273216b-279f-449c-8335-323b0e97778c">
              <NavigationalPropertyMoniker name="/MyERPModel/Ph11/Userinfo2" />
            </associationDefinesSourceProperty>
          </sourceNavigationalProperty>
        </Association>
      </AssociationTargets>
      <navigationalProperties>
        <classHasNavigationalProperties Id="7900e546-e7d3-4024-b430-ab80ca6515ad">
          <NavigationalProperty Id="07ec2603-84e3-4c8d-a52d-e32cfad2f54a" name="Ct11s" type="IList&lt;Ct11&gt;" label="Ct11s : IList&lt;Ct11&gt;" nullable="true" kind="Persistent" fieldName="_ct11" isDependent="false" isManaged="false" />
        </classHasNavigationalProperties>
        <classHasNavigationalProperties Id="cb193c8a-209b-4848-9ceb-bfd396a17517">
          <NavigationalProperty Id="e130c8de-7b7d-4c7d-ae79-5163dd85c6ec" name="Dmnt" type="Dmnt" label="Dmnt : Dmnt" nullable="true" kind="Persistent" fieldName="_dmnt" isDependent="false" isManaged="false" />
        </classHasNavigationalProperties>
        <classHasNavigationalProperties Id="e686d228-b41b-4213-9404-020d757d3903">
          <NavigationalProperty Id="2c957833-144d-42e4-be8c-33dfca7a18d1" name="Dmdvcs" type="Dmdvcs" label="Dmdvcs : Dmdvcs" nullable="true" kind="Persistent" fieldName="_dmdvcs" isDependent="false" isManaged="false" />
        </classHasNavigationalProperties>
        <classHasNavigationalProperties Id="6d4c1842-be81-44d0-afaa-6c8b8079f0ea">
          <NavigationalProperty Id="ad71934f-c342-46fa-9eef-597c22fd3b1e" name="Userinfo0" type="Userinfo" label="Userinfo0 : Userinfo" nullable="true" kind="Persistent" fieldName="_userinfo" isDependent="false" isManaged="false" />
        </classHasNavigationalProperties>
        <classHasNavigationalProperties Id="79913893-3de6-4fa1-ad6e-01e7c7cfa365">
          <NavigationalProperty Id="b229fc60-d7e8-422c-bc67-cb627d60c821" name="Userinfo2" type="Userinfo" label="Userinfo2 : Userinfo" nullable="true" kind="Persistent" fieldName="_userinfo1" isDependent="false" isManaged="false" />
        </classHasNavigationalProperties>
      </navigationalProperties>
    </DomainClass>
    <DomainClass Id="8481a6cc-b6ad-4206-8b61-08181d982446" name="Ct11" namespace="MyERPModel" showPropertiesCompartment="true" concurrencyMode="Changed" showNavigationCompartment="true" showImplementationCompartment="true">
      <Property Id="25cd9e95-1e3e-4b5b-b3fb-0c06856d0d6e" name="Stt_Rec" label="Stt_Rec : String" kind="Persistent" identity="true" fieldName="_stt_rec" />
      <Property Id="f71c5a51-c976-4ab9-aafb-056026dbb4ba" name="Dien_Giaii" label="Dien_Giaii : String" kind="Persistent" fieldName="_dien_giaii" />
      <Property Id="6b7ea4e4-fd50-44ad-a51a-8bc5584e8e5b" name="Ln" type="Int64" label="Ln : Int64" kind="Persistent" identity="true" fieldName="_ln" />
      <Property Id="951113e5-7290-4507-839b-e69c9608f1c2" name="Ma_Ct" label="Ma_Ct : String" kind="Persistent" fieldName="_ma_ct" />
      <Property Id="9c36f9d9-c23c-40f7-bc55-e749de0bedf1" name="Ma_Kh_I" label="Ma_Kh_I : String" kind="Persistent" fieldName="_ma_kh_i" />
      <Property Id="ca1a4089-e1c7-4fc6-a573-4b6119449ed1" name="Ma_Ku" label="Ma_Ku : String" kind="Persistent" fieldName="_ma_ku" />
      <Property Id="5d9422d0-1691-4290-ba98-9a050cb5fcf0" name="Ma_Td_I" label="Ma_Td_I : String" kind="Persistent" fieldName="_ma_td_i" />
      <Property Id="7bf2150d-b5a5-4e2f-a3e9-f1c54ab63723" name="Ma_Vv_I" label="Ma_Vv_I : String" kind="Persistent" fieldName="_ma_vv_i" />
      <Property Id="806fda7d-e5f2-4626-b5be-9aa4c7d8a9fe" name="Ngay_Ct" type="DateTime" label="Ngay_Ct : DateTime" kind="Persistent" fieldName="_ngay_ct" />
      <Property Id="f8b6478c-a8f5-4fb9-bbd0-d19dfa00ef43" name="Nh_Dk" label="Nh_Dk : String" kind="Persistent" fieldName="_nh_dk" />
      <Property Id="62bb2580-e943-43c1-bf7c-a9957882a03a" name="Ps_Co" type="Decimal" label="Ps_Co : Decimal" kind="Persistent" fieldName="_ps_co" />
      <Property Id="c786bea9-7e2e-4ada-8d3e-8ce759cff9bf" name="Ps_Co_Nt" type="Decimal" label="Ps_Co_Nt : Decimal" kind="Persistent" fieldName="_ps_co_nt" />
      <Property Id="a6da2cca-c3b0-4da4-a7ea-3d99874a1a7a" name="Ps_No" type="Decimal" label="Ps_No : Decimal" kind="Persistent" fieldName="_ps_no" />
      <Property Id="7f74c9b7-d033-4dd7-bc64-00349a96d0ca" name="Ps_No_Nt" type="Decimal" label="Ps_No_Nt : Decimal" kind="Persistent" fieldName="_ps_no_nt" />
      <Property Id="a0255897-38d4-40e8-93e5-3bb83e62aef2" name="So_Ct" label="So_Ct : String" kind="Persistent" fieldName="_so_ct" />
      <Property Id="9769048a-6458-45a1-b27a-541663316f20" name="Tk_I" label="Tk_I : String" kind="Persistent" fieldName="_tk_i" />
      <AssociationTargets>
        <Association Id="5685b103-b6b7-44cb-a08e-f3278fc9a835" SourceMultiplicity="ZeroOne" name="Ct11HasPh11">
          <DomainClassMoniker name="/MyERPModel/Ph11" />
          <targetNavigationalProperty>
            <associationDefinesTargetProperty Id="8cf6c8ae-4efb-4a67-b7e8-0b0f1319fea8">
              <NavigationalPropertyMoniker name="/MyERPModel/Ph11/Ct11s" />
            </associationDefinesTargetProperty>
          </targetNavigationalProperty>
          <sourceNavigationalProperty>
            <associationDefinesSourceProperty Id="0c10ef2f-2e7a-48f7-b7cd-440956d13a97">
              <NavigationalPropertyMoniker name="/MyERPModel/Ct11/Ph11" />
            </associationDefinesSourceProperty>
          </sourceNavigationalProperty>
        </Association>
        <Association Id="39abcdb0-f796-44df-ac72-2516ae6d284d" SourceMultiplicity="ZeroOne" name="Ct11HasDmkh">
          <DomainClassMoniker name="/MyERPModel/Dmkh" />
          <sourceNavigationalProperty>
            <associationDefinesSourceProperty Id="23047da8-f938-4cb6-98df-56eee31c73ce">
              <NavigationalPropertyMoniker name="/MyERPModel/Ct11/Dmkh" />
            </associationDefinesSourceProperty>
          </sourceNavigationalProperty>
        </Association>
        <Association Id="4729eb29-9545-4fbb-b3c9-2107e833c959" SourceMultiplicity="ZeroOne" name="Ct11HasDmvv">
          <DomainClassMoniker name="/MyERPModel/Dmvv" />
          <sourceNavigationalProperty>
            <associationDefinesSourceProperty Id="c711791a-f28c-4205-a9a7-f9c49844ffee">
              <NavigationalPropertyMoniker name="/MyERPModel/Ct11/Dmvv" />
            </associationDefinesSourceProperty>
          </sourceNavigationalProperty>
        </Association>
        <Association Id="2d3e0b1f-6e0d-42fc-8dd0-fe8f12fd2f67" SourceMultiplicity="ZeroOne" name="Ct11HasDmtk">
          <DomainClassMoniker name="/MyERPModel/Dmtk" />
          <sourceNavigationalProperty>
            <associationDefinesSourceProperty Id="7549d1e0-bea6-494a-9e7f-eff4d98d7280">
              <NavigationalPropertyMoniker name="/MyERPModel/Ct11/Dmtk" />
            </associationDefinesSourceProperty>
          </sourceNavigationalProperty>
        </Association>
        <Association Id="21f515eb-d035-4e02-b31b-70cf8b19b769" SourceMultiplicity="ZeroOne" name="Ct11HasDmtd">
          <DomainClassMoniker name="/MyERPModel/Dmtd" />
          <sourceNavigationalProperty>
            <associationDefinesSourceProperty Id="d8b4bb09-7fcc-4847-934f-6a8216d088dd">
              <NavigationalPropertyMoniker name="/MyERPModel/Ct11/Dmtd" />
            </associationDefinesSourceProperty>
          </sourceNavigationalProperty>
        </Association>
      </AssociationTargets>
      <navigationalProperties>
        <classHasNavigationalProperties Id="f7e47e64-371d-4627-88d6-72bfc2fe50e9">
          <NavigationalProperty Id="b8f7d741-5a37-4b6f-af00-3e93ea88eaba" name="Ph11" type="Ph11" label="Ph11 : Ph11" nullable="true" kind="Persistent" fieldName="_ph11" isDependent="false" isManaged="false" />
        </classHasNavigationalProperties>
        <classHasNavigationalProperties Id="26a5e52a-5b3a-48d2-9e29-e6de73e7b182">
          <NavigationalProperty Id="eff5976f-30c7-49d8-925e-b9453a644108" name="Dmkh" type="Dmkh" label="Dmkh : Dmkh" nullable="true" kind="Persistent" fieldName="_dmkh" isDependent="false" isManaged="false" />
        </classHasNavigationalProperties>
        <classHasNavigationalProperties Id="546c1d2e-27ee-4275-aa2d-55ee6a085aca">
          <NavigationalProperty Id="df6c37e9-f1f4-4c32-acc9-454417e2aee7" name="Dmvv" type="Dmvv" label="Dmvv : Dmvv" nullable="true" kind="Persistent" fieldName="_dmvv" isDependent="false" isManaged="false" />
        </classHasNavigationalProperties>
        <classHasNavigationalProperties Id="57c642e6-09c3-409f-8cc3-12d3aa4d8c59">
          <NavigationalProperty Id="58d0ec19-1557-4fe6-9033-243bd28f7b3a" name="Dmtk" type="Dmtk" label="Dmtk : Dmtk" nullable="true" kind="Persistent" fieldName="_dmtk" isDependent="false" isManaged="false" />
        </classHasNavigationalProperties>
        <classHasNavigationalProperties Id="d519ea73-5a01-4d46-8e40-407236fd9fea">
          <NavigationalProperty Id="a5a78d7b-7d6e-4332-90ed-7d9f218acadb" name="Dmtd" type="Dmtd" label="Dmtd : Dmtd" nullable="true" kind="Persistent" fieldName="_dmtd" isDependent="false" isManaged="false" />
        </classHasNavigationalProperties>
      </navigationalProperties>
    </DomainClass>
    <DomainClass Id="97b688dd-facf-4bf5-9c2f-4d63ce988854" name="Dmdvcs" namespace="MyERPModel" showPropertiesCompartment="true" concurrencyMode="Changed" showNavigationCompartment="true" showImplementationCompartment="true">
      <Property Id="fe952f33-f611-4733-bc22-7165b8c4c528" name="Ma_Dvcs" label="Ma_Dvcs : String" kind="Persistent" identity="true" fieldName="_ma_dvcs" />
      <Property Id="4276a5e1-583e-4381-b830-7a77196140b8" name="Date0" type="DateTime" label="Date0 : DateTime" kind="Persistent" fieldName="_date0" />
      <Property Id="8c552b56-8740-4114-a2fb-98c9eb47263d" name="Date2" type="DateTime" label="Date2 : DateTime" kind="Persistent" fieldName="_date2" />
      <Property Id="ad77c6b6-0826-4537-b39a-7b586f2b8b0f" name="M_Ws_Id" label="M_Ws_Id : String" kind="Persistent" fieldName="_m_ws_id" />
      <Property Id="286ea9c5-4670-4eca-a93b-3764128c891a" name="Status" label="Status : String" kind="Persistent" fieldName="_status" />
      <Property Id="4b5af097-14de-48d3-8db9-ea849445fb4c" name="Ten_Dvcs" label="Ten_Dvcs : String" kind="Persistent" fieldName="_ten_dvcs" />
      <Property Id="a713f6b1-2ebd-41c6-8918-f0fe87638433" name="Ten_Dvcs2" label="Ten_Dvcs2 : String" kind="Persistent" fieldName="_ten_dvcs2" />
      <Property Id="e0206719-089e-44fe-a6d8-29513e70bb0d" name="User_Id0" type="Int64" label="User_Id0 : Int64" kind="Persistent" fieldName="_user_id0" />
      <Property Id="4ace2386-c7f5-4863-bf86-6e328aeb46dd" name="User_Id2" type="Int64" label="User_Id2 : Int64" kind="Persistent" fieldName="_user_id2" />
      <AssociationTargets>
        <Association Id="6cf46b87-f996-4e0e-850a-2ba457350c37" SourceMultiplicity="ZeroOne" name="DmdvcsHasUserinfo0">
          <DomainClassMoniker name="/MyERPModel/Userinfo" />
          <sourceNavigationalProperty>
            <associationDefinesSourceProperty Id="f1863dd8-0988-4e69-a04c-c3aa0fd533a1">
              <NavigationalPropertyMoniker name="/MyERPModel/Dmdvcs/Userinfo0" />
            </associationDefinesSourceProperty>
          </sourceNavigationalProperty>
        </Association>
        <Association Id="6596f954-a873-43e4-a0b9-843660adce30" SourceMultiplicity="ZeroOne" name="DmdvcsHasUserinfo2">
          <DomainClassMoniker name="/MyERPModel/Userinfo" />
          <sourceNavigationalProperty>
            <associationDefinesSourceProperty Id="92586b3e-b002-41ef-a49c-992c3aeb128d">
              <NavigationalPropertyMoniker name="/MyERPModel/Dmdvcs/Userinfo2" />
            </associationDefinesSourceProperty>
          </sourceNavigationalProperty>
        </Association>
      </AssociationTargets>
      <navigationalProperties>
        <classHasNavigationalProperties Id="e2f8e13e-a992-4915-bc51-a448272d7528">
          <NavigationalProperty Id="80faad2e-b992-4242-a1de-4196c08f5fa0" name="Userinfo0" type="Userinfo" label="Userinfo0 : Userinfo" nullable="true" kind="Persistent" fieldName="_userinfo" isDependent="false" isManaged="false" />
        </classHasNavigationalProperties>
        <classHasNavigationalProperties Id="e44fa83a-cc8b-4032-b6eb-97e85edf0a37">
          <NavigationalProperty Id="4cd5cf7e-3faf-47c8-9243-a5ddad3de871" name="Userinfo2" type="Userinfo" label="Userinfo2 : Userinfo" nullable="true" kind="Persistent" fieldName="_userinfo1" isDependent="false" isManaged="false" />
        </classHasNavigationalProperties>
      </navigationalProperties>
    </DomainClass>
    <DomainClass Id="d1172a9d-6632-4017-ac36-14d50b13174a" name="Dmtd" namespace="MyERPModel" showPropertiesCompartment="true" concurrencyMode="Changed" showNavigationCompartment="true" showImplementationCompartment="true">
      <Property Id="2c962e35-08c8-463e-930e-51a4c0f82e98" name="Ma_Td" label="Ma_Td : String" kind="Persistent" identity="true" fieldName="_ma_td" />
      <Property Id="2d0ae781-24ec-40f0-b5dc-91cfa34946db" name="Date0" type="DateTime" label="Date0 : DateTime" kind="Persistent" fieldName="_date0" />
      <Property Id="44f672c6-9bdc-4529-9ae6-c5bbb1531038" name="Date2" type="DateTime" label="Date2 : DateTime" kind="Persistent" fieldName="_date2" />
      <Property Id="07438339-e8fb-4a16-87c9-36787e8644f5" name="Status" label="Status : String" kind="Persistent" fieldName="_status" />
      <Property Id="cd6f8448-cb4f-458b-82f1-fdb382cd9c9b" name="Ten_Td" label="Ten_Td : String" kind="Persistent" fieldName="_ten_td" />
      <Property Id="3a0a8cb4-cbb0-47d2-bb3c-e9aa2e0e4965" name="Ten_Td2" label="Ten_Td2 : String" kind="Persistent" fieldName="_ten_td2" />
      <Property Id="98d64fc2-e68a-44ba-bd06-eb4fcbe7c776" name="User_Id0" type="Int64" label="User_Id0 : Int64" kind="Persistent" fieldName="_user_id0" />
      <Property Id="56110b65-f21b-40a3-9f18-564d23afb236" name="User_Id2" type="Int64" label="User_Id2 : Int64" kind="Persistent" fieldName="_user_id2" />
    </DomainClass>
    <DomainClass Id="6f9d7dd5-2eff-470f-afd8-44cb565dbd66" name="Dmct" namespace="MyERPModel" showPropertiesCompartment="true" concurrencyMode="Changed" showNavigationCompartment="true" showImplementationCompartment="true">
      <Property Id="83ddb2ec-b1bf-4fdf-ac42-bd2b8316189c" name="Ma_Ct" label="Ma_Ct : String" kind="Persistent" identity="true" fieldName="_ma_ct" />
      <Property Id="b31e03e8-2dc3-47d6-9847-4211cc966a96" name="Ct_Nxt" type="Int16" label="Ct_Nxt : Int16" kind="Persistent" fieldName="_ct_nxt" />
      <Property Id="75e3b3ee-7ef2-4a7f-ad51-fd9286ef6462" name="Date0" type="DateTime" label="Date0 : DateTime" kind="Persistent" fieldName="_date0" />
      <Property Id="50f071f1-9d43-4252-a174-f1415657ea4c" name="Date2" type="DateTime" label="Date2 : DateTime" kind="Persistent" fieldName="_date2" />
      <Property Id="5e359cf1-24ce-4749-a790-6c3634ff8ad4" name="M_Loc_Nsd" type="Int16" label="M_Loc_Nsd : Int16" kind="Persistent" fieldName="_m_loc_nsd" />
      <Property Id="52864c16-5f35-4c8e-90f4-493c875a3e7b" name="M_Ma_Gd" label="M_Ma_Gd : String" kind="Persistent" fieldName="_m_ma_gd" />
      <Property Id="7c7d7c33-8c80-471d-b3f7-bcf6266e6966" name="M_Ma_Nk" label="M_Ma_Nk : String" kind="Persistent" fieldName="_m_ma_nk" />
      <Property Id="faad8d7b-77e6-4153-ac06-95495cf8c87f" name="M_Ngay_Ct" type="Int16" label="M_Ngay_Ct : Int16" kind="Persistent" fieldName="_m_ngay_ct" />
      <Property Id="715dd19c-9f6b-4ef4-aded-5d78399a7fe2" name="M_Status" label="M_Status : String" kind="Persistent" fieldName="_m_status" />
      <Property Id="34303206-826b-4636-9c99-e7c772681058" name="M_Trung_So" type="Int16" label="M_Trung_So : Int16" kind="Persistent" fieldName="_m_trung_so" />
      <Property Id="d7c4891c-cf9f-43f0-903f-7f63c3c94a08" name="Ma_Ct_In" label="Ma_Ct_In : String" kind="Persistent" fieldName="_ma_ct_in" />
      <Property Id="e18c2c15-d6a2-427a-8ca9-f4d86b201cd4" name="Ma_Ct_Me" label="Ma_Ct_Me : String" kind="Persistent" fieldName="_ma_ct_me" />
      <Property Id="0eeab798-76d3-4130-8445-90b442e3dc5b" name="Ma_Nt" label="Ma_Nt : String" kind="Persistent" fieldName="_ma_nt" />
      <Property Id="a2fce2f9-a476-463c-b654-7c0f71d187ff" name="Ma_Phan_He" label="Ma_Phan_He : String" kind="Persistent" fieldName="_ma_phan_he" />
      <Property Id="5f4eb04f-ab30-40fe-a91c-e664a131aaa6" name="So_Ct" type="Int64" label="So_Ct : Int64" kind="Persistent" fieldName="_so_ct" />
      <Property Id="b69a9de6-e841-486f-9f03-bff8c526b695" name="Stt_Ct_Nkc" type="Int16" label="Stt_Ct_Nkc : Int16" kind="Persistent" fieldName="_stt_ct_nkc" />
      <Property Id="7d1d258d-9622-4caa-a683-04d979e749c8" name="Stt_Ctntxt" type="Int16" label="Stt_Ctntxt : Int16" kind="Persistent" fieldName="_stt_ctntxt" />
      <Property Id="27ac5a7b-d58b-4fe1-a948-faa18e9eab6a" name="Ten_Ct" label="Ten_Ct : String" kind="Persistent" fieldName="_ten_ct" />
      <Property Id="3a3f0082-de74-4d94-8ef8-97ff4bfd4e3b" name="Ten_Ct2" label="Ten_Ct2 : String" kind="Persistent" fieldName="_ten_ct2" />
      <Property Id="aed096c4-2730-4529-98fd-c49bb9621b09" name="User_Id0" type="Int64" label="User_Id0 : Int64" kind="Persistent" fieldName="_user_id0" />
      <Property Id="be41e505-edd0-4405-ac5e-b9d104cc825d" name="User_Id2" type="Int64" label="User_Id2 : Int64" kind="Persistent" fieldName="_user_id2" />
    </DomainClass>
  </Types>
  <domainContext>
    <domainModelHasDomainContext Id="d7bd6e8c-e34a-47be-a590-3f03f86938da">
      <domainContainer name="MyERPModel" namespace="MyERPModel" showPropertiesCompartment="true">
        <entitySetProperty name="Dmtks" namespace="MyERPModel" type="Dmtk" label="Dmtks : IQueryable&lt;MyERPModel.Dmtk&gt;" />
        <entitySetProperty name="Userinfos" namespace="MyERPModel" type="Userinfo" label="Userinfos : IQueryable&lt;MyERPModel.Userinfo&gt;" />
        <entitySetProperty name="Dmnts" namespace="MyERPModel" type="Dmnt" label="Dmnts : IQueryable&lt;MyERPModel.Dmnt&gt;" />
        <entitySetProperty name="Dmkhs" namespace="MyERPModel" type="Dmkh" label="Dmkhs : IQueryable&lt;MyERPModel.Dmkh&gt;" />
        <entitySetProperty name="Dmnhkhs" namespace="MyERPModel" type="Dmnhkh" label="Dmnhkhs : IQueryable&lt;MyERPModel.Dmnhkh&gt;" />
        <entitySetProperty name="Dmtts" namespace="MyERPModel" type="Dmtt" label="Dmtts : IQueryable&lt;MyERPModel.Dmtt&gt;" />
        <entitySetProperty name="Dmvvs" namespace="MyERPModel" type="Dmvv" label="Dmvvs : IQueryable&lt;MyERPModel.Dmvv&gt;" />
        <entitySetProperty name="Dmnhvvs" namespace="MyERPModel" type="Dmnhvv" label="Dmnhvvs : IQueryable&lt;MyERPModel.Dmnhvv&gt;" />
        <entitySetProperty name="Ph11s" namespace="MyERPModel" type="Ph11" label="Ph11s : IQueryable&lt;MyERPModel.Ph11&gt;" />
        <entitySetProperty name="Ct11s" namespace="MyERPModel" type="Ct11" label="Ct11s : IQueryable&lt;MyERPModel.Ct11&gt;" />
        <entitySetProperty name="Dmdvcss" namespace="MyERPModel" type="Dmdvcs" label="Dmdvcss : IQueryable&lt;MyERPModel.Dmdvcs&gt;" />
        <entitySetProperty name="Dmtds" namespace="MyERPModel" type="Dmtd" label="Dmtds : IQueryable&lt;MyERPModel.Dmtd&gt;" />
        <entitySetProperty name="Dmcts" namespace="MyERPModel" type="Dmct" label="Dmcts : IQueryable&lt;MyERPModel.Dmct&gt;" />
      </domainContainer>
    </domainModelHasDomainContext>
  </domainContext>
</DomainModel>