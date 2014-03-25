-- MyERP.DataAccess.Ct11
CREATE TABLE "ct11" (
    "stt_rec" text NOT NULL,                -- _stt_rec
    "so_ct" text NOT NULL,                  -- _so_ct
    "ps_no_nt" numeric(38,200) NOT NULL,    -- _ps_no_nt
    "ps_no" numeric(38,20) NOT NULL,        -- _ps_no
    "ps_co_nt" numeric(38,20) NOT NULL,     -- _ps_co_nt
    "ps_co" numeric(38,20) NOT NULL,        -- _ps_co
    "nh_dk" text NOT NULL,                  -- _nh_dk
    "ngay_ct" date NOT NULL,                -- _ngay_ct
    "ma_ku" text NOT NULL,                  -- _ma_ku
    "ma_ct" text NOT NULL,                  -- _ma_ct
    "ln" int8 NOT NULL,                     -- _ln
    "ma_vv_i" text NOT NULL,                -- _dmvv
    "tk_i" text NOT NULL,                   -- _dmtk
    "ma_td_i" text NOT NULL,                -- _dmtd
    "ma_kh_i" text NOT NULL,                -- _dmkh
    "dien_giaii" text NOT NULL,             -- _dien_giaii
    CONSTRAINT "pk_ct11" PRIMARY KEY ("ln", "stt_rec")
);

-- MyERP.DataAccess.Dmct
CREATE TABLE "dmct" (
    "user_id2" int8 NOT NULL,               -- _user_id2
    "user_id0" int8 NOT NULL,               -- _user_id0
    "ten_ct2" text NOT NULL,                -- _ten_ct2
    "ten_ct" text NOT NULL,                 -- _ten_ct
    "stt_ctntxt" int2 NOT NULL,             -- _stt_ctntxt
    "stt_ct_nkc" int2 NOT NULL,             -- _stt_ct_nkc
    "so_ct" int8 NOT NULL,                  -- _so_ct
    "ma_phan_he" text NOT NULL,             -- _ma_phan_he
    "ma_nt" text NOT NULL,                  -- _ma_nt
    "ma_ct_me" text NOT NULL,               -- _ma_ct_me
    "ma_ct_in" text NOT NULL,               -- _ma_ct_in
    "ma_ct" text NOT NULL,                  -- _ma_ct
    "m_trung_so" int2 NOT NULL,             -- _m_trung_so
    "m_status" text NOT NULL,               -- _m_status
    "m_ngay_ct" int2 NOT NULL,              -- _m_ngay_ct
    "m_ma_nk" text NOT NULL,                -- _m_ma_nk
    "m_ma_gd" text NOT NULL,                -- _m_ma_gd
    "m_loc_nsd" int2 NOT NULL,              -- _m_loc_nsd
    "date2" timestamp NOT NULL,             -- _date2
    "date0" timestamp NOT NULL,             -- _date0
    "ct_nxt" int2 NOT NULL,                 -- _ct_nxt
    CONSTRAINT "pk_dmct" PRIMARY KEY ("ma_ct")
);

-- MyERP.DataAccess.Dmdvcs
CREATE TABLE "dmdvcs" (
    "user_id2" int8 NOT NULL,               -- _userinfo1
    "user_id0" int8 NOT NULL,               -- _userinfo
    "ten_dvcs2" text NOT NULL,              -- _ten_dvcs2
    "ten_dvcs" text NOT NULL,               -- _ten_dvcs
    "status" text NOT NULL,                 -- _status
    "ma_dvcs" text NOT NULL,                -- _ma_dvcs
    "m_ws_id" text NOT NULL,                -- _m_ws_id
    "date2" timestamp NOT NULL,             -- _date2
    "date0" timestamp NOT NULL,             -- _date0
    CONSTRAINT "pk_dmdvcs" PRIMARY KEY ("ma_dvcs")
);

-- MyERP.DataAccess.Dmkh
CREATE TABLE "dmkh" (
    "user_id2" int8 NOT NULL,               -- _userinfo2
    "user_id0" int8 NOT NULL,               -- _userinfo0
    "tk_nh" text NOT NULL,                  -- _tk_nh
    "ten_kh2" text NOT NULL,                -- _ten_kh2
    "ten_kh" text NOT NULL,                 -- _ten_kh
    "ten_bp" text NOT NULL,                 -- _ten_bp
    "t_tien_hd" numeric(38,20) NOT NULL,    -- _t_tien_hd
    "t_tien_cn" numeric(38,20) NOT NULL,    -- _t_tien_cn
    "ong_ba" text NOT NULL,                 -- _ong_ba
    "nv_yn" int2 NOT NULL,                  -- _nv_yn
    "ngan_hang" text NOT NULL,              -- _ngan_hang
    "ma_so_thue" text NOT NULL,             -- _ma_so_thue
    "ma_kh" text NOT NULL,                  -- _ma_kh
    "kh_yn" int2 NOT NULL,                  -- _kh_yn
    "home_page" text NOT NULL,              -- _home_page
    "ghi_chu" text NOT NULL,                -- _ghi_chu
    "fax" text NOT NULL,                    -- _fax
    "e_mail" text NOT NULL,                 -- _e_mail
    "du_nt13" numeric(38,20) NOT NULL,      -- _du_nt13
    "doi_tac" text NOT NULL,                -- _doi_tac
    "ma_tt" text NOT NULL,                  -- _dmtt
    "tk" text NOT NULL,                     -- _dmtk
    "nh_kh3" text NOT NULL,                 -- _dmnhkh2
    "nh_kh2" text NOT NULL,                 -- _dmnhkh1
    "nh_kh1" text NOT NULL,                 -- _dmnhkh
    "dien_thoai" text NOT NULL,             -- _dien_thoai
    "dia_chi" text NOT NULL,                -- _dia_chi
    "date2" timestamp NOT NULL,             -- _date2
    "date0" timestamp NOT NULL,             -- _date0
    "cc_yn" int2 NOT NULL,                  -- _cc_yn
    CONSTRAINT "pk_dmkh" PRIMARY KEY ("ma_kh")
);

-- MyERP.DataAccess.Dmnhkh
CREATE TABLE "dmnhkh" (
    "user_id2" int8 NOT NULL,               -- _user_id2
    "user_id0" int8 NOT NULL,               -- _user_id0
    "ten_nh2" text NOT NULL,                -- _ten_nh2
    "ten_nh" text NOT NULL,                 -- _ten_nh
    "status" text NOT NULL,                 -- _status
    "ma_nh" text NOT NULL,                  -- _ma_nh
    "loai_nh" int2 NOT NULL,                -- _loai_nh
    "date2" timestamp NOT NULL,             -- _date2
    "date0" timestamp NOT NULL,             -- _date0
    CONSTRAINT "pk_dmnhkh" PRIMARY KEY ("ma_nh")
);

-- MyERP.DataAccess.Dmnhvv
CREATE TABLE "dmnhvv" (
    "user_id2" int8 NOT NULL,               -- _userinfo1
    "user_id0" int8 NOT NULL,               -- _userinfo
    "ten_nh2" text NOT NULL,                -- _ten_nh2
    "ten_nh" text NOT NULL,                 -- _ten_nh
    "status" text NOT NULL,                 -- _status
    "ma_nh" text NOT NULL,                  -- _ma_nh
    "loai_nh" int2 NOT NULL,                -- _loai_nh
    "date2" timestamp NOT NULL,             -- _date2
    "date0" timestamp NOT NULL,             -- _date0
    CONSTRAINT "pk_dmnhvv" PRIMARY KEY ("ma_nh")
);

-- MyERP.DataAccess.Dmnt
CREATE TABLE "dmnt" (
    "user_id2" int8 NOT NULL,               -- _userinfo2
    "user_id0" int8 NOT NULL,               -- _userinfo0
    "ten_nt2" text NOT NULL,                -- _ten_nt2
    "ten_nt" text NOT NULL,                 -- _ten_nt
    "status" text NOT NULL,                 -- _status
    "ma_nt" text NOT NULL,                  -- _ma_nt
    "date2" timestamp NOT NULL,             -- _date2
    "date0" timestamp NOT NULL,             -- _date0
    CONSTRAINT "pk_dmnt" PRIMARY KEY ("ma_nt")
);

-- MyERP.DataAccess.Dmtd
CREATE TABLE "dmtd" (
    "user_id2" int8 NOT NULL,               -- _user_id2
    "user_id0" int8 NOT NULL,               -- _user_id0
    "ten_td2" text NOT NULL,                -- _ten_td2
    "ten_td" text NOT NULL,                 -- _ten_td
    "status" text NOT NULL,                 -- _status
    "ma_td" text NOT NULL,                  -- _ma_td
    "date2" timestamp NOT NULL,             -- _date2
    "date0" timestamp NOT NULL,             -- _date0
    CONSTRAINT "pk_dmtd" PRIMARY KEY ("ma_td")
);

-- MyERP.DataAccess.Dmtk
CREATE TABLE "dmtk" (
    "user_id2" int8 NOT NULL,               -- _userinfo2
    "user_id0" int8 NOT NULL,               -- _userinfo0
    "tk_sc" int2 NOT NULL,                  -- _tk_sc
    "tk_me" text NOT NULL,                  -- _tk_me
    "tk_cn" int2 NOT NULL,                  -- _tk_cn
    "tk" text NOT NULL,                     -- _tk
    "ten_tk2" text NOT NULL,                -- _ten_tk2
    "ten_tk" text NOT NULL,                 -- _ten_tk
    "status" text NOT NULL,                 -- _status
    "nh_tk2" text NOT NULL,                 -- _nh_tk2
    "nh_tk0" text NOT NULL,                 -- _nh_tk0
    "loai_tk" int2 NOT NULL,                -- _loai_tk
    "ma_nt" text NOT NULL,                  -- _dmnt
    "date2" timestamp NOT NULL,             -- _date2
    "date0" timestamp NOT NULL,             -- _date0
    "bac_tk" int2 NOT NULL,                 -- _bac_tk
    CONSTRAINT "pk_dmtk" PRIMARY KEY ("tk")
);

-- MyERP.DataAccess.Dmtt
CREATE TABLE "dmtt" (
    "user_id2" int8 NOT NULL,               -- _user_id2
    "user_id0" int8 NOT NULL,               -- _user_id0
    "ten_tt2" text NOT NULL,                -- _ten_tt2
    "ten_tt" text NOT NULL,                 -- _ten_tt
    "status" text NOT NULL,                 -- _status
    "pt_gg" numeric(38,20) NOT NULL,        -- _pt_gg
    "ma_tt" text NOT NULL,                  -- _ma_tt
    "han_tt_gg" int2 NOT NULL,              -- _han_tt_gg
    "han_tt" int2 NOT NULL,                 -- _han_tt
    "date2" timestamp NOT NULL,             -- _date2
    "date0" timestamp NOT NULL,             -- _date0
    CONSTRAINT "pk_dmtt" PRIMARY KEY ("ma_tt")
);

-- MyERP.DataAccess.Dmvv
CREATE TABLE "dmvv" (
    "user_id2" int8 NOT NULL,               -- _userinfo1
    "user_id0" int8 NOT NULL,               -- _userinfo
    "tien_nt" numeric(38,20) NOT NULL,      -- _tien_nt
    "tien" numeric(38,20) NOT NULL,         -- _tien
    "ten_vv2" text NOT NULL,                -- _ten_vv2
    "ten_vv" text NOT NULL,                 -- _ten_vv
    "status" text NOT NULL,                 -- _status
    "ngay_vv2" date NOT NULL,               -- _ngay_vv2
    "ngay_vv1" date NOT NULL,               -- _ngay_vv1
    "ma_vv" text NOT NULL,                  -- _ma_vv
    "ma_nt" text NOT NULL,                  -- _ma_nt
    "ghi_chu" text NOT NULL,                -- _ghi_chu
    "tk" text NOT NULL,                     -- _dmtk
    "nh_vv3" text NOT NULL,                 -- _dmnhvv2
    "nh_vv2" text NOT NULL,                 -- _dmnhvv1
    "nh_vv1" text NOT NULL,                 -- _dmnhvv
    "ma_kh" text NOT NULL,                  -- _dmkh
    "date2" timestamp NOT NULL,             -- _date2
    "date0" timestamp NOT NULL,             -- _date0
    CONSTRAINT "pk_dmvv" PRIMARY KEY ("ma_vv")
);

-- MyERP.DataAccess.Module
CREATE TABLE "module" (
    "name" text NOT NULL,                   -- _name
    "id" int8 NOT NULL,                     -- _id
    "group" text NOT NULL,                  -- _group
    "description" text NOT NULL,            -- _description
    CONSTRAINT "pk_mdule" PRIMARY KEY ("id")
);

-- MyERP.DataAccess.Ph11
CREATE TABLE "ph11" (
    "user_id2" int8 NOT NULL,               -- _userinfo1
    "user_id0" int8 NOT NULL,               -- _userinfo
    "ty_gia" numeric(38,20) NOT NULL,       -- _Ty_Gia
    "t_ps_no_nt" numeric(38,20) NOT NULL,   -- _T_Ps_No_Nt
    "t_ps_no" numeric(38,20) NOT NULL,      -- _T_Ps_No
    "t_ps_co_nt" numeric(38,20) NOT NULL,   -- _T_Ps_Co_Nt
    "stt_rec" text NOT NULL,                -- _Stt_Rec
    "status" text NOT NULL,                 -- _Status
    "so_lo" text NOT NULL,                  -- _So_Lo
    "so_ct" text NOT NULL,                  -- _So_Ct
    "ngay_lo" date NOT NULL,                -- _Ngay_Lo
    "ngay_lct" date NOT NULL,               -- _Ngay_Lct
    "ngay_ct" date NOT NULL,                -- _Ngay_Ct
    "ma_nk" text NOT NULL,                  -- _Ma_Nk
    "ma_gd" int2 NOT NULL,                  -- _Ma_Gd
    "ma_ct" text NOT NULL,                  -- _Ma_Ct
    "ma_nt" text NOT NULL,                  -- _dmnt
    "ma_dvcs" text NOT NULL,                -- _dmdvcs
    "date2" timestamp NOT NULL,             -- _Date2
    "date0" timestamp NOT NULL,             -- _Date0
    CONSTRAINT "pk_ph11" PRIMARY KEY ("stt_rec")
);

-- MyERP.DataAccess.Userinfo
CREATE TABLE "userinfo" (
    "user_pre" text NOT NULL,               -- _user_pre
    "user_name" text NOT NULL,              -- _user_name
    "user_id2" int8 NOT NULL,               -- _user_id2
    "user_id0" int8 NOT NULL,               -- _user_id0
    "user_id" int8 NOT NULL,                -- _user_id
    "status" text NOT NULL,                 -- _status
    "rights" text NOT NULL,                 -- _rights
    "r_search" text NOT NULL,               -- _r_search
    "r_read" text NOT NULL,                 -- _r_read
    "r_print" text NOT NULL,                -- _r_print
    "r_edit" text NOT NULL,                 -- _r_edit
    "r_del" text NOT NULL,                  -- _r_del
    "r_add" text NOT NULL,                  -- _r_add
    "r_access" text NOT NULL,               -- _r_access
    "pass" text NOT NULL,                   -- _pass
    "is_admin" bool NOT NULL,               -- _is_admin
    "del_yn" bool NOT NULL,                 -- _del_yn
    "date2" timestamp NOT NULL,             -- _date2
    "date0" timestamp NOT NULL,             -- _date0
    "comment" text NOT NULL,                -- _comment
    CONSTRAINT "pk_userinfo" PRIMARY KEY ("user_id")
);

CREATE INDEX "idx_ct11_stt_rec" ON "ct11"("stt_rec");

CREATE INDEX "idx_dmkh_nh_kh3" ON "dmkh"("nh_kh3");

CREATE INDEX "idx_dmkh_nh_kh2" ON "dmkh"("nh_kh2");

CREATE INDEX "idx_dmkh_nh_kh1" ON "dmkh"("nh_kh1");

CREATE INDEX "idx_dmvv_nh_vv3" ON "dmvv"("nh_vv3");

CREATE INDEX "idx_dmvv_nh_vv2" ON "dmvv"("nh_vv2");

CREATE INDEX "idx_dmvv_nh_vv1" ON "dmvv"("nh_vv1");

ALTER TABLE "ct11" ADD CONSTRAINT "ref_ct11_dmkh" FOREIGN KEY ("ma_kh_i") REFERENCES "dmkh"("ma_kh");

ALTER TABLE "ct11" ADD CONSTRAINT "ref_ct11_dmtd" FOREIGN KEY ("ma_td_i") REFERENCES "dmtd"("ma_td");

ALTER TABLE "ct11" ADD CONSTRAINT "ref_ct11_dmtk" FOREIGN KEY ("tk_i") REFERENCES "dmtk"("tk");

ALTER TABLE "ct11" ADD CONSTRAINT "ref_ct11_dmvv" FOREIGN KEY ("ma_vv_i") REFERENCES "dmvv"("ma_vv");

ALTER TABLE "ct11" ADD CONSTRAINT "ref_ct11_ph11" FOREIGN KEY ("stt_rec") REFERENCES "ph11"("stt_rec");

ALTER TABLE "dmdvcs" ADD CONSTRAINT "ref_dmdvcs_userinfo" FOREIGN KEY ("user_id0") REFERENCES "userinfo"("user_id");

ALTER TABLE "dmdvcs" ADD CONSTRAINT "ref_dmdvcs_userinfo2" FOREIGN KEY ("user_id2") REFERENCES "userinfo"("user_id");

ALTER TABLE "dmkh" ADD CONSTRAINT "ref_dmkh_dmnhkh" FOREIGN KEY ("nh_kh1") REFERENCES "dmnhkh"("ma_nh");

ALTER TABLE "dmkh" ADD CONSTRAINT "ref_dmkh_dmnhkh2" FOREIGN KEY ("nh_kh2") REFERENCES "dmnhkh"("ma_nh");

ALTER TABLE "dmkh" ADD CONSTRAINT "ref_dmkh_dmnhkh3" FOREIGN KEY ("nh_kh3") REFERENCES "dmnhkh"("ma_nh");

ALTER TABLE "dmkh" ADD CONSTRAINT "ref_dmkh_dmtk" FOREIGN KEY ("tk") REFERENCES "dmtk"("tk");

ALTER TABLE "dmkh" ADD CONSTRAINT "ref_dmkh_dmtt" FOREIGN KEY ("ma_tt") REFERENCES "dmtt"("ma_tt");

ALTER TABLE "dmkh" ADD CONSTRAINT "ref_dmkh_userinfo" FOREIGN KEY ("user_id0") REFERENCES "userinfo"("user_id");

ALTER TABLE "dmkh" ADD CONSTRAINT "ref_dmkh_userinfo2" FOREIGN KEY ("user_id2") REFERENCES "userinfo"("user_id");

ALTER TABLE "dmnhvv" ADD CONSTRAINT "ref_dmnhvv_userinfo" FOREIGN KEY ("user_id0") REFERENCES "userinfo"("user_id");

ALTER TABLE "dmnhvv" ADD CONSTRAINT "ref_dmnhvv_userinfo2" FOREIGN KEY ("user_id2") REFERENCES "userinfo"("user_id");

ALTER TABLE "dmnt" ADD CONSTRAINT "ref_dmnt_userinfo" FOREIGN KEY ("user_id0") REFERENCES "userinfo"("user_id");

ALTER TABLE "dmnt" ADD CONSTRAINT "ref_dmnt_userinfo2" FOREIGN KEY ("user_id2") REFERENCES "userinfo"("user_id");

ALTER TABLE "dmtk" ADD CONSTRAINT "ref_dmtk_dmnt" FOREIGN KEY ("ma_nt") REFERENCES "dmnt"("ma_nt");

ALTER TABLE "dmtk" ADD CONSTRAINT "ref_dmtk_userinfo" FOREIGN KEY ("user_id0") REFERENCES "userinfo"("user_id");

ALTER TABLE "dmtk" ADD CONSTRAINT "ref_dmtk_userinfo2" FOREIGN KEY ("user_id2") REFERENCES "userinfo"("user_id");

ALTER TABLE "dmvv" ADD CONSTRAINT "ref_dmvv_dmkh" FOREIGN KEY ("ma_kh") REFERENCES "dmkh"("ma_kh");

ALTER TABLE "dmvv" ADD CONSTRAINT "ref_dmvv_dmnhvv" FOREIGN KEY ("nh_vv1") REFERENCES "dmnhvv"("ma_nh");

ALTER TABLE "dmvv" ADD CONSTRAINT "ref_dmvv_dmnhvv2" FOREIGN KEY ("nh_vv2") REFERENCES "dmnhvv"("ma_nh");

ALTER TABLE "dmvv" ADD CONSTRAINT "ref_dmvv_dmnhvv3" FOREIGN KEY ("nh_vv3") REFERENCES "dmnhvv"("ma_nh");

ALTER TABLE "dmvv" ADD CONSTRAINT "ref_dmvv_dmtk" FOREIGN KEY ("tk") REFERENCES "dmtk"("tk");

ALTER TABLE "dmvv" ADD CONSTRAINT "ref_dmvv_userinfo" FOREIGN KEY ("user_id0") REFERENCES "userinfo"("user_id");

ALTER TABLE "dmvv" ADD CONSTRAINT "ref_dmvv_userinfo2" FOREIGN KEY ("user_id2") REFERENCES "userinfo"("user_id");

ALTER TABLE "ph11" ADD CONSTRAINT "ref_ph11_dmdvcs" FOREIGN KEY ("ma_dvcs") REFERENCES "dmdvcs"("ma_dvcs");

ALTER TABLE "ph11" ADD CONSTRAINT "ref_ph11_dmnt" FOREIGN KEY ("ma_nt") REFERENCES "dmnt"("ma_nt");

ALTER TABLE "ph11" ADD CONSTRAINT "ref_ph11_userinfo" FOREIGN KEY ("user_id0") REFERENCES "userinfo"("user_id");

ALTER TABLE "ph11" ADD CONSTRAINT "ref_ph11_userinfo2" FOREIGN KEY ("user_id2") REFERENCES "userinfo"("user_id");

